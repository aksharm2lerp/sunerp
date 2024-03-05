using Business.Interface.NotificationStatusI;
using ERP.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    // [DisplayName("ConversationActivities")]
    //[Route("ConversationActivities")]
    public class ConversationActivities2Controller : SettingsController
    {
        #region Interface

        private readonly INotificationStatus _iNotificationStatus;
        public ConversationActivitiesController(INotificationStatus notificationStatus)
        {
            _iNotificationStatus = notificationStatus;
        }

        #endregion Interface     

        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion Index


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
    }
}
