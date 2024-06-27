using Business.Entities.PartyMasterModel;
using Business.Interface.IParty;
using Business.Interface.NotificationStatusI;
using Business.Interface.Marketing.IConversationActivities;
using Business.SQL;
using ERP.Controllers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using Business.Entities.Master.MasterModalForPartyActivity;
using Business.Entities;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    // [DisplayName("ConversationActivities")]
    //[Route("ConversationActivities")]
    public class ConversationActivitiesController : SettingsController
    {
        #region Interface

        private readonly INotificationStatus _iNotificationStatus;
        private readonly IPartyService _PartyService;
        private readonly ConversationActivitiesInterface _conversationActivitiesInterface;

        public ConversationActivitiesController(INotificationStatus notificationStatus, IPartyService PartyService, ConversationActivitiesInterface conversationActivitiesInterface)
        {
            _iNotificationStatus = notificationStatus;
            _PartyService = PartyService;
            _conversationActivitiesInterface = conversationActivitiesInterface;

        }

        #endregion Interface     

        #region Party Summary List Index Page

        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<PartyMaster>> columns = c =>
            {
                c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                c.Add(o => o.PartyCode).Titled("Party Code").Sortable(true);
                c.Add(o => o.PartyName).Titled("Party Name").Sortable(true);
                c.Add(o => o.Mobile1).Titled("Mobile").Sortable(true);
                c.Add(o => o.Email).Titled("Email").Sortable(true);
                /*c.Add(o => o.GroupName).Titled("Group Name").Sortable(true);
                c.Add(o => o.OwnerName).Titled("Owner Name").Sortable(true);*/
                c.Add(o => o.IsActive).Titled("IsActive").Sortable(true);
                //Below code hide on phones
                //c.Add().Titled("Details").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/Party/AddUpdateParty/{o.PartyID}' ><i class='bx bx-edit'></i></a>");
                c.Add().Titled("Activites").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/ConversationActivities/PartyActivities/{o.PartyID}' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<PartyMaster> pds = _PartyService.GetAllPartySummaryAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<PartyMaster>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable().ClearFiltersButton(true).Selectable(true).WithGridItemsCount().ChangeSkip(false).EmptyText("No record found").ClearFiltersButton(false);
            return View(server.Grid);
        }

        #endregion Party Summary List Index Page

        #region Party Activities
        public IActionResult PartyActivities(int id)
        {
            try
            {
                MasterModalForPartyActivity masterModalForPartyActivity = new MasterModalForPartyActivity();
                masterModalForPartyActivity.notification = _conversationActivitiesInterface.GetNotificationConversationActivities(id,USERID).Result;
                masterModalForPartyActivity.partyMaster = _conversationActivitiesInterface.GetUserProfileConversationActivities(id).Result;
                masterModalForPartyActivity.requestedforQuotLists = _conversationActivitiesInterface.GetPartyRFQListConversationActivities(id).Result;

                //var notificationCount2 = _conversationActivitiesInterface.GetRFQListConversationActivities(id).Result;
                return View("PartyActivities", masterModalForPartyActivity);
            }
            catch (Exception)
            {
                throw;
            }            
        }
        #endregion Party Activities

        #region NotificationConversationActivities
        [HttpGet]
        public JsonResult GetNotificationConversationActivities()
        {
            try
            {
                var notificationCount = _iNotificationStatus.GetNotificationConversationActivities(USERID).Result;
                return Json(new { status = true, count = notificationCount });
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion NotificationConversationActivities   

        #region UserProfileConversationActivities
        [HttpGet]
        public JsonResult GetUserProfileConversationActivities()
        {
            try
            {
                var notificationCount = _iNotificationStatus.GetUserProfileConversationActivities(USERID).Result;
                return Json(new { status = true, count = notificationCount });
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion UserProfileConversationActivities 

        #region GetRFQListConversationActivities
        [HttpGet]
        public JsonResult GetRFQListConversationActivities()
        {
            try
            {
                var notificationCount = _iNotificationStatus.GetRFQListConversationActivities(USERID).Result;
                return Json(new { status = true, count = notificationCount });
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion GetRFQListConversationActivities

        #region Send Mail

        // public IActionResult SendMail(string recipientToName,string recipientCcName, string recipientBccName, string subjectLine, string messageBox)
        public IActionResult SendMail(string recipientToName, string subjectLine, string messageBox)
        {
            int userid = USERID;
            var id = _conversationActivitiesInterface.IUSendMail(recipientToName, subjectLine, messageBox, userid);
            //send email to party that person wants to meet
            MailRequest request = new MailRequest();
            request.Subject = subjectLine;
            request.ToEmail = recipientToName;
            //request.CCEmail = recipientCcName;
            //request.BCCEmail = recipientBccName;           
            request.Body = messageBox;
            bool isSent = false; //_emailService.SendEmail(request);
            if (isSent)
                return Json(new { status = true, message = "Mail sent successfully." });
            else
                return Json(new { status = false, message = "Mail not sent" });

        }

        #endregion Send Mail

        #region  Party To Customer        
        public IActionResult PartyToCustomer(int PartyID)
        {
            int userid = USERID;
            int id = _conversationActivitiesInterface.PartyToCustomer(PartyID, userid).Result;
            if (id == 1)
                return Json(new { status = true, message = "Convert to customer successfully." });
            if (id == 2)
                return Json(new { status = false, message = "Party is already existed as a Customer." });
            if (id == 3)
                return Json(new { status = false, message = "Mobile is not exist! Mobile number is required to transfer Party to Customer." });
            else
                return Json(new { status = false, message = "Somthing is wrong." });

        }
        #endregion Party To Customer
    }
}
