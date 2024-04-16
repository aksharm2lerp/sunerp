using Business.Entities.Marketing.VisitingDetail;
using Business.Entities.PartyMasterModel;
using Business.Interface;
using Business.Interface.IParty;
using Business.Interface.Marketing.IVisitingDetailService;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("VisitingDetail")]
    public class MarketingVisitingDetailController : SettingsController
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMasterService _masterService;
        private readonly IMarketingVisitingDetailService _iMarketingVisitingDetailService;
        private readonly IDataProtector protector;
        private readonly IPartyService _PartyService;

        public MarketingVisitingDetailController(IWebHostEnvironment hostEnvironment, IMasterService masterService, IMarketingVisitingDetailService iMarketingVisitingDetailService, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings, IPartyService partyService)
        {
            _webHostEnvironment = hostEnvironment;
            this._masterService = masterService;
            _iMarketingVisitingDetailService = iMarketingVisitingDetailService;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.MarketingVisitedDetailIDRouteValue);
            _PartyService = partyService;
        }


        /* Visiting Detail Index Start */
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;

            Action<IGridColumnCollection<VisitingDetail>> columns = c =>
            {

                c.Add(o => o.SrNo, "SrNo")
                    .Titled("SrNo")
                    .Sortable(true)
                    .SetWidth(10);

                c.Add(o => o.VisitedByPerson)
                   .Titled("Visited By")
                   .Sortable(true)
                   .SetWidth(20);

                c.Add(o => o.VisitedTo)
                    .Titled("Meeting With")
                    .Sortable(true)
                    .SetWidth(20);

                c.Add(o => o.CompanyOrOrganazationName)
                   .Titled("Company Name")
                   .Sortable(true)
                   .SetWidth(20);

                c.Add(o => o.MobileNo)
                    .Titled("Mobile No")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.DateTime)
                   .Titled("Meeting Date")
                   .Sortable(true)
                   .SetWidth(20);

                c.Add(o => o.MeetingTotalTime)
                    .Titled("Meeting Duration")
                    .Sortable(true)
                    .SetWidth(50);

                /*c.Add(o => o.PartyTypeText)
                    .Titled("Party Type")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.VanueTypeText)
                    .Titled("Vanue Type")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.PlaceOfMeeting)
                    .Titled("Place")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.Email)
                    .Titled("Email")
                    .Sortable(true)
                    .SetWidth(50);                

                c.Add(o => o.IsSentDocument)
                    .Titled("Document Status")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.IsSentMarketingDocs)
                    .Titled("Marketing Doc Status")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.MOM)
                    .Titled("Note")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.Feedback)
                    .Titled("Feedback")
                    .Sortable(true)
                    .SetWidth(50);                

                c.Add(o => o.ReferenceBetterBusiness)
                    .Titled("Business Reference")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.ReferenceMobileOrEmail)
                    .Titled("Contact Detail")
                    .Sortable(true)
                    .SetWidth(20);*/

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/MarketingVisitingDetail/Get/{o.EncryptedId}' ><i class='bx bx-edit'></i></a>");
                //.RenderValueAs(o => $"<a class='btn' onclick='fnVisitingDetail(this)' href='javascript:void(0)' data-id='{o.MarketingVisitedDetailID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_VisitingDetail' aria-controls='canvas_VisitingDetail'><i class='bx bx-edit'></i> </a>");

            };

            PagedDataTable<VisitingDetail> pds = _iMarketingVisitingDetailService.GetAllMarketingVisitingDetailAsync(gridpage.ToInt(),
               PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC",USERID).Result;
            foreach (var item in pds)
            {
                item.EncryptedId = protector.Protect(item.MarketingVisitedDetailID.ToString());
            }
            var server = new GridCoreServer<VisitingDetail>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable()
                //.Filterable()
                //.WithMultipleFilters()
                //.Searchable(true, false)
                //.Groupable(true)
                .ClearFiltersButton(true)
                .Selectable(true)
                //.SetStriped(true)
                //.ChangePageSize(true)
                .WithGridItemsCount()
                //.WithPaging(PAGESIZE, pds.TotalItemCount)
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false);
            return View("Index", server.Grid);
        }
        /* Visiting Detail Index End */

        /* Visiting Detail  silder Start */
        [HttpGet]
        public IActionResult Get(string id)
        {
            try
            {
                ViewBag.UserID = USERID;
                ViewBag.CompanyID = COMPANYID;
                VisitingDetail model = new VisitingDetail();

                var PartyTypeTextList = _masterService.GetPartyTypeMasterAsync();
                ViewData["PartyTypeText"] = new SelectList(PartyTypeTextList, "PartyTypeID", "PartyTypeText");

                var VenueTypeTextList = _masterService.GetVanueTypeMasterAsync();
                ViewData["VenueTypeText"] = new SelectList(VenueTypeTextList, "VenueTypeID", "VenueTypeText");

                if (!string.IsNullOrEmpty(id))
                {
                    string matchString = @"^[A-F0-9]+$";
                    Match match = Regex.Match(id, matchString, RegexOptions.IgnoreCase);
                    int decId = 0;
                    if (!match.Success)
                        decId = Convert.ToInt32(protector.Unprotect(id));
                    else
                        decId = Convert.ToInt32(id);
                    // Decrypt the employee id using Unprotect method
                    if (decId > 0)
                    {
                        model = _iMarketingVisitingDetailService.GetMarketingVisitingDetailAsync(decId).Result;

                        return View("AddUpdateMarketingVisitingDetail", model);
                    }
                }
                return View("AddUpdateMarketingVisitingDetail", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        /* Visiting Detail silder Start */

        /* Visiting Detail Insert or Update Page Start */
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateMarketingVisitingDetail(VisitingDetail model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _marketingVisitedDetailID = await _iMarketingVisitingDetailService.MarketingVisitingDetailInsertOrUpdateAsync(model);

            if (_marketingVisitedDetailID > 0)
            {
                model.MarketingVisitedDetailID = _marketingVisitedDetailID;
                return Json(new { status = true, message = MessageHelper.Added, id = _marketingVisitedDetailID });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
        }
        /* Visiting Detail Insert or Update Page End */

        #region Auto fill party mobile and email.
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public Microsoft.AspNetCore.Mvc.JsonResult GetPartyMobileEmailByPartyID(int partyId)
        {
            try
            {
                if (partyId > 0)
                {
                    var partyMobileEmail = _PartyService.GetPartyAsync(partyId).Result;
                    return Json(new { status = true, partyMobileEmail = partyMobileEmail });
                }
                else
                    return Json(new { status = false });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion Auto fill party mobile and email.

        #region Add new party from add party feedback.

        [HttpPost]
        public IActionResult AddParty(string partyName, string partyMobile, string partyEmail)
        {
            try
            {
                if (!string.IsNullOrEmpty(partyName) && !string.IsNullOrEmpty(partyMobile))
                {
                    PartyMaster partyMaster = new PartyMaster() { PartyName = partyName, Mobile1 = partyMobile, Email = partyEmail, IsActive = true };
                    int partId = _PartyService.AddUpdateParty(partyMaster).Result;
                    if (partId > 0)
                        return Json(new { status = true, message = "New party added." });
                    else
                        return Json(new { status = false, message = "Something went wrong." });
                }
                else
                    return Json(new { status = false, message = "Please enter both, Party Name and Mobile No." });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Add new party from add party feedback.
    }
}
