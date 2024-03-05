using Business.Entities;
using Business.Entities.Marketing.Feedback;
using Business.Entities.PartyMasterModel;
using Business.Interface;
using Business.Interface.IParty;
using Business.Interface.Marketing;
using Business.SQL;
using DocumentFormat.OpenXml.Office2010.Excel;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("Feedback")]
    public class FeedbackController : SettingsController
    {

        private readonly UserManager<UserMasterMetadata> _userManager;
        private readonly SignInManager<UserMasterMetadata> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMasterService _masterService;
        private readonly IMarketingFeedbackService _marketingFeedbackService;
        private readonly IDataProtector protector;
        private readonly IPartyService _PartyService;

        public FeedbackController(UserManager<UserMasterMetadata> userManager, SignInManager<UserMasterMetadata> signInManager,
            IMasterService masterService, IWebHostEnvironment hostEnvironment, IMarketingFeedbackService marketingFeedbackService, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings, IPartyService partyService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._masterService = masterService;
            _webHostEnvironment = hostEnvironment;
            _marketingFeedbackService = marketingFeedbackService;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.MarketingFeedbackIdRouteValue);
            _PartyService = partyService;
        }




        /*Feedback List Start*/
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;

            Action<IGridColumnCollection<MarketingFeedback>> columns = c =>
            {

                c.Add(o => o.MarketingFeedbackID, "SrNo")
                    .Titled("SrNo")
                    .Sortable(true)
                    .SetWidth(10);

                c.Add(o => o.PartyName)
                    .Titled("Party Name")
                    .Sortable(true)
                    .SetWidth(20);

                c.Add(o => o.Note)
                    .Titled("Feedbach Note")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.MobileNo)
                    .Titled("Mobile No")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.FeedbackDate)
                    .Titled("Feedback Date")
                    .Sortable(true)
                    .SetWidth(20);

                /*c.Add(o => o.PartyTypeText)
                    .Titled("Party Type")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.Email)
                    .Titled("Email")
                    .Sortable(true)
                    .SetWidth(50);                

                c.Add(o => o.IsReceivedDocument)
                    .Titled("Document Status")
                    .Sortable(true)
                    .SetWidth(50); */

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/Feedback/Get/{o.EncryptedId}' ><i class='bx bx-edit'></i></a>");
                //.RenderValueAs(o => $"<a class='btn' onclick='fnMasterEntity2(this)' href='javascript:void(0)' data-id='{o.MarketingFeedbackID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_masterentity2' aria-controls='canvas_masterentity'><i class='bx bx-edit'></i> </a>");

            };
            PagedDataTable<MarketingFeedback> pds = _marketingFeedbackService.GetAllMarketingFeedbackAsync(gridpage.ToInt(),
                PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC", USERID).Result;
            foreach (var item in pds)
            {
                item.EncryptedId = protector.Protect(item.MarketingFeedbackID.ToString());
            }
            var server = new GridCoreServer<MarketingFeedback>(pds, query, false, "ordersGrid",
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
        /*Feedback List End*/

        /*Marketing Feedback silder Start*/
        [HttpPost]
        public IActionResult Get(string id)
        {
            try
            {
                MarketingFeedback model = new MarketingFeedback();

                var PartyTypeTextList = _masterService.GetPartyTypeMasterAsync();
                ViewData["PartyTypeText"] = new SelectList(PartyTypeTextList, "PartyTypeID", "PartyTypeText");

                if (!string.IsNullOrEmpty(id))
                {
                    int decId = Convert.ToInt32(protector.Unprotect(id));
                    // Decrypt the employee id using Unprotect method
                    if (decId > 0)
                    {
                        model = _marketingFeedbackService.GetMarketingFeedbackAsync(decId).Result;
                        return View("AddUpdateMarketingFeedback", model);
                    }
                }
                return View("AddUpdateMarketingFeedback", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        /*Marketing Feedback silder End*/

        /*Feedback Create Page Start*/
        [HttpPost]
        public async Task<IActionResult> CreateMarketingFeedback(MarketingFeedback model)
        {
            #region Adding string array into DataTable.
            string[] strArray = null;
            DataTable dataTable = new DataTable();
            // Define the columns of the DataTable
            dataTable.Columns.Add("MarketingFeedbackDetailID", typeof(int));
            dataTable.Columns.Add("MarketingFeedbackID", typeof(int));
            dataTable.Columns.Add("PositiveNoteID", typeof(int));
            dataTable.Columns.Add("Response", typeof(string));

            if (model.PositiveNotesArray != null && model.PositiveNotesArray.Count() > 0)
            {
                strArray = model.PositiveNotesArray.Split(",");

                // Loop through the array and add each set of three elements as a new row to the DataTable
                for (int i = 0; i < strArray.Length; i += 4)
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["MarketingFeedbackDetailID"] = strArray[i] ?? "0";
                    newRow["MarketingFeedbackID"] = model.MarketingFeedbackID;
                    newRow["PositiveNoteID"] = strArray[i + 2];
                    newRow["Response"] = strArray[i + 3];
                    dataTable.Rows.Add(newRow);
                }
            }
            #endregion Adding string array into DataTable.


            model.CreatedOrModifiedBy = USERID;
            var _marketingFeedbackId = await _marketingFeedbackService.MarketingFeedbackCreateAsync(model, dataTable);

            if (_marketingFeedbackId > 0)
            {
                model.MarketingFeedbackID = _marketingFeedbackId;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            // If we got this far, something failed, redisplay form
        }
        /*Feedback Create Page End*/



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

                throw;
            }
        }
        #endregion Auto fill party mobile and email.

        //

        #region Open popup model for add new party.
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public PartialViewResult OpenAddPartyPopup()
        {
            return PartialView("PopupAddParty");
        }
        #endregion Open popup model for add new party.

        #region Add new party from add party feedback.

        [HttpPost]
        public IActionResult AddParty(string partyName, string partyMobile, string partyEmail)
        {
            try
            {
                if (!string.IsNullOrEmpty(partyName) && !string.IsNullOrEmpty(partyMobile))
                {
                    PartyMaster partyMaster = new PartyMaster() { PartyName = partyName, Mobile1=partyMobile,Email=partyEmail,IsActive=true };
                    int partId = _PartyService.AddUpdateParty(partyMaster).Result;
                    if(partId > 0)
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
