using Business.Entities.AddNewFeedback;
using Business.Entities.Marketing.CommunicationLog;
using Business.Entities.PartyMasterModel;
using Business.Interface;
using Business.Interface.IParty;
using Business.Interface.Marketing;
using Business.Interface.Marketing.CommunicatonLog;
using Business.SQL;
using ERP.Controllers;
using ERP.Extensions;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("CommunicationLog")]
    public class MarketingCommunicationLogController : SettingsController
    {
        #region Interface
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMasterService _masterService;
        private readonly IMarketingCommunicationLogService _iMarketingCommunicationLogService;
        private readonly IMarketingFeedbackService _marketingFeedbackService;
        private readonly IDataProtector protector;
        private readonly IPartyService _PartyService;

        public MarketingCommunicationLogController(IWebHostEnvironment hostEnvironment, IMasterService masterService, IMarketingCommunicationLogService iMarketingCommunicationLogService, IMarketingFeedbackService marketingFeedbackService, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings, IPartyService partyService)
        {
            _webHostEnvironment = hostEnvironment;
            this._masterService = masterService;
            this._iMarketingCommunicationLogService = iMarketingCommunicationLogService;
            _marketingFeedbackService = marketingFeedbackService;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.MarketingCommunicationLogIdRouteValue);
            _PartyService = partyService;
        }
        #endregion Interface

        #region /*Communicaton Log Index Start*/
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            ViewBag.UserID = USERID;
            IQueryCollection query = Request.Query;

            Action<IGridColumnCollection<CommunicationLog>> columns = c =>
            {

                c.Add(o => o.SrNo, "SrNo")
                    .Titled("SrNo")
                    .Sortable(true)
                    .SetWidth(10);

                c.Add(o => o.ContactByPerson)
                    .Titled("Contact By")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.ContactTo)
                   .Titled("Contact To")
                   .Sortable(true)
                   .SetWidth(50);

                c.Add(o => o.MobileNo)
                    .Titled("Mobile No")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.CommunicationLogDate)
                   .Titled("Communication Date")
                   .SetWidth(20)
                   .Format("{0:dd/MM/yyyy}").Sortable(true); ;

                c.Add(o => o.ContactChannelTypeText)
                    .Titled("Contact Channel")
                    .Sortable(true)
                    .SetWidth(50);

                /* c.Add(o => o.PartyTypeText)
                     .Titled("Party Type")
                     .Sortable(true)
                     .SetWidth(50);

                 c.Add(o => o.VanueTypeText)
                     .Titled("Vanue Type")
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

                 c.Add(o => o.IsSentMarketingDocument)
                     .Titled("Marketing Doc Status")
                     .Sortable(true)
                     .SetWidth(50);

                 c.Add(o => o.Note)
                     .Titled("Note")
                     .Sortable(true)
                     .SetWidth(50);

                 c.Add(o => o.Feedback)
                     .Titled("Feedback")
                     .Sortable(true)
                     .SetWidth(50);

                 c.Add(o => o.ReferenceBetterBusiness)
                     .Titled("Business")
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
                    .SetWidth(10)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/MarketingCommunicationLog/Get/{o.EncryptedId}' ><i class='bx bx-edit'></i></a>");
                //.RenderValueAs(o => $"<a class='btn' onclick='fnCommunicatioLog(this)' href='javascript:void(0)' data-id='{o.MarketingCommunicationLogID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_CommunicatioLog' aria-controls='canvas_CommunicatioLog'><i class='bx bx-edit'></i> </a>");

            };

            PagedDataTable<CommunicationLog> pds = _iMarketingCommunicationLogService.GetAllMarketingCommunicationLogAsync(gridpage.ToInt(),
               PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC",USERID).Result;
            foreach (var item in pds)
            {
                item.EncryptedId = protector.Protect(item.MarketingCommunicationLogID.ToString());
            }
            var server = new GridCoreServer<CommunicationLog>(pds, query, false, "ordersGrid",
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
        #endregion /*Communicaton Log Index End*/

        #region /*Communicaton Log  silder Start*/
        [HttpPost]
        public IActionResult Get(string id)
        {
            try
            {
                CommunicationLog model = new CommunicationLog();

                var PartyTypeTextList = _masterService.GetPartyTypeMasterAsync();
                ViewData["PartyTypeText"] = new SelectList(PartyTypeTextList, "PartyTypeID", "PartyTypeText");

                var ContactChannelTextList = _masterService.GetContactChannelMasterAsync();
                ViewData["ContactChannelText"] = new SelectList(ContactChannelTextList, "ContactChannelTypeID", "ContactChannelTypeText");

                var VenueTypeTextList = _masterService.GetVanueTypeMasterAsync();
                ViewData["VenueTypeText"] = new SelectList(VenueTypeTextList, "VenueTypeID", "VenueTypeText");
                ViewBag.UserID = USERID;
                ViewBag.CompanyID = COMPANYID;
                if (!string.IsNullOrEmpty(id))
                {
                    int decId = Convert.ToInt32(protector.Unprotect(id));
                    // Decrypt the employee id using Unprotect method
                    if (decId > 0)
                    {
                        model = _iMarketingCommunicationLogService.GetMarketingCommunicationLogAsync(decId).Result;

                        //return View("CreateMarketingCommunicationLog", model);
                        return View("AddUpdateMarketingCommunicationLog", model);
                    }
                }
                return View("AddUpdateMarketingCommunicationLog", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion /*Communicaton Log  silder End*/

        #region /*Communicaton Log Insert or Update Page Start*/
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateMarketingCommunicationLog(CommunicationLog model)
        {
            #region Adding string array into DataTable.
            string[] strArray = null;
            DataTable dataTable = new DataTable();
            // Define the columns of the DataTable
            dataTable.Columns.Add("MarketingCommunicationLogDetailID", typeof(int));
            dataTable.Columns.Add("MarketingCommunicationLogID", typeof(int));
            dataTable.Columns.Add("PositiveNoteID", typeof(int));
            dataTable.Columns.Add("Response", typeof(string));

            if (model.PositiveNotesArray != null && model.PositiveNotesArray.Count() > 0)
            {
                strArray = model.PositiveNotesArray.Split(",");

                // Loop through the array and add each set of three elements as a new row to the DataTable
                for (int i = 0; i < strArray.Length; i += 4)
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["MarketingCommunicationLogDetailID"] = strArray[i] ?? "0";
                    newRow["MarketingCommunicationLogID"] = model.MarketingCommunicationLogID;
                    newRow["PositiveNoteID"] = strArray[i + 2];
                    newRow["Response"] = strArray[i + 3];
                    dataTable.Rows.Add(newRow);
                }
            }
            #endregion Adding string array into DataTable.


            model.CreatedOrModifiedBy = USERID;
            var _marketingCommunicationLogID = await _iMarketingCommunicationLogService.MarketingCommunicationLogInsertOrUpdateAsync(model, dataTable);

            if (_marketingCommunicationLogID > 0)
            {
                model.MarketingCommunicationLogID = _marketingCommunicationLogID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
        }
        #endregion /*Communicaton Log Insert or Update Page End*/

        #region Dynamic fields (Adding new Feedback)
        [HttpGet]
        public IActionResult AddMoreFeedback()
        {
            AddNewFeedback model = new AddNewFeedback();
            return PartialView("_addMoreFeedback", model);
        }

        public IActionResult AddUpdateFeedbackList(AddNewFeedback model)
        {
            //Here,Post addmore value from view page and get multiple values from view page
            return View();
        }

        #endregion Dynamic fields (Adding new Feedback)

        #region Feedback notes Dropdown/ Method added by Rahul Mistry on 18-Apr-2023.

        public JsonResult GetAllMarketingClientFeedbackNote()
        {
            try
            {
                //var test = MarketingExtension.GetAllMarketingClientFeedbackNote();
                var newTest = _marketingFeedbackService.GetAllFeedbackNote().Select(x => new { PositiveNoteID = x.PositiveNoteID, PositiveNoteText = x.PositiveNoteText }).ToList();
                return Json(newTest);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Feedback notes Dropdown/ Method added by Rahul Mistry on 18-Apr-2023.

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
