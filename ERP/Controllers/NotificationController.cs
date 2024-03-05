using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Business.Interface.NotificationStatusI;
using Business.Entities.NotificationModel;
using System.Collections.Generic;
using System;
using ERP.Helpers;
using System.Threading.Tasks;
using Business.Entities.Employee;
using Business.SQL;
using Microsoft.AspNetCore.Http;
using GridShared;
using GridCore.Server;
using System.Data;
using Business.Entities.Master;
using Business.Entities.Master.ReminderMasterM;

namespace ERP.Controllers
{
    [Authorize]
    [Route("Notification")]
    public class NotificationController : SettingsController
    {
        #region Interface

        private readonly INotificationStatus _iNotificationStatus;
        public NotificationController(INotificationStatus notificationStatus)
        {
            _iNotificationStatus = notificationStatus;
        }

        #endregion Interface

        #region Show notification count & list

        [HttpGet]
        [Route("GetNotificationCount")]
        public ActionResult GetNotificationCount()
        {
            try
            {
                var notificationCount = _iNotificationStatus.GetNotificationStatusAsync(USERID).Result;
                return Json(new { status = true, count = notificationCount });
            }
            catch (Exception)
            {

                throw;
            }

        }

        //[HttpGet]
        //public ActionResult GetNotificationCount()
        //{

        //    var notificationCount = _iNotificationStatus.GetNotificationCountAsync(USERID).Result;
        //    return Json(new { status = true, count = notificationCount }); ;

        //}

        #endregion Show notification count & list

        #region View All Notification

        [HttpPost]
        [Route("ViewAllNotification")]
        public async Task<IActionResult> ViewAllNotification()
        {
            try
            {
                var IsViewTrue = await _iNotificationStatus.UpdateViewAllNotification(USERID);

                if (IsViewTrue > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion View All Notification

        #region View One Notification

        [HttpPost]
        [Route("ViewOneNotificationOnly")]
        public async Task<IActionResult> ViewOneNotificationOnly(int notificationID)
        {
            try
            {
                var IsViewTrue = await _iNotificationStatus.UpdateViewOneNotification(notificationID);

                if (IsViewTrue > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion View One Notification

        #region Get User Notification List Page

        //[HttpGet]
        //[Route("ViewAllNotificationList")]
        //public ActionResult ViewAllNotificationList()
        //{
        //    try
        //    {
        //        Notification notification = new Notification();

        //        return View("NotificationList", notification);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #region Using Grid View

        //[HttpGet]
        //[Route("ViewAllNotificationList")]
        //public ActionResult ViewAllNotificationList([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        //{
        //    try
        //    {
        //        int userid = USERID;
        //        IQueryCollection query = Request.Query;
        //        string value = string.Empty;
        //        Action<IGridColumnCollection<Notification>> columns = c =>
        //        {
        //            //c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
        //            //c.Add(o => o.PlainNotificationText).Titled("Notification").Sortable(true);
        //            c.Add().Titled("Notification").Encoded(false).Sanitized(false).Sortable(true).SetWidth(200).RenderValueAs(o => $"<div class='d-flex align-items-center'>{o.NotificationText}</div>");
        //            //c.Add(o => o.NotificationDateTime).Titled("Date&Time").Sortable(true);
        //            //c.Add(o => o.IsView).Titled("Status").SetWidth(10);
        //            c.Add().Titled("").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
        //            .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/{o.NotificationID}' ><i class='bx bx-edit'></i></a>");
        //        };
        //        PagedDataTable<Notification> pds = (PagedDataTable<Notification>)_iNotificationStatus.GetAllNotificationAsync(USERID).Result;

        //        var server = new GridCoreServer<Notification>(pds, query, false, "notificationlistGrid", columns, PAGESIZE, pds.TotalItemCount)
        //            .Sortable()
        //            .Filterable(false)
        //            .Searchable(false, false)
        //            .Selectable(true)
        //            .WithGridItemsCount()
        //            .EmptyText("No record found")
        //            .ClearFiltersButton(false)
        //            .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");


        //        return View(server.Grid);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        #endregion Using Grid View


        #region Using Table View
        [HttpGet]
        [Route("ViewAllNotificationList")]
        public IActionResult ViewAllNotificationList(DateTime startDate, DateTime endDate, string searchString)
        {
            try
            {


                if (startDate.ToDate() == "01/01/0001 00:00:00".ToDate())
                {
                    startDate = DateTime.Now.Date.AddMonths(-6);
                    endDate = DateTime.Now.Date;

                }
                if (endDate.ToDate() == "01/01/0001 00:00:00".ToDate()) // 1 / 1 / 1753 12:00:00 12 / 31 / 9999 11:59:59
                {
                    endDate = DateTime.Now.Date;
                }

                DataSet dataSet = _iNotificationStatus.GetAllNotificationAsync(USERID, startDate, endDate, searchString).Result;

                if (dataSet.Tables.Count > 0)
                {
                    //if (isDownload)
                    //{
                    //    return ExportToExcel(dataSet, "EmployeesList");
                    //}
                    //else
                    //{
                        return View(dataSet);
                    //}
                }
                else { return View(null); }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Using Table View

        #endregion Get User Notification List Page

        #region Get Employee Notification

        [HttpPost]
        public ActionResult GetEmployeeNotificationList()
        {
            try
            {
                List<Notification> pds = _iNotificationStatus.GetEmployeeNotificationList(USERID).Result;
                return Json(new { status = true, data = pds });
            }
            catch
            {
                return null;
            }
        }

        #endregion Get Employee Notification

        #region Get reminder for meeting.

        [HttpGet]
        [Route("GetReminder")]
        public IActionResult GetReminder()
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;
                ReminderModel reminderModel = _iNotificationStatus.GetReminder(USERID).Result;
                if (reminderModel != null)
                {
                    //foreach (var meeting in list)
                    //{
                    //    //DateTime dateTime = meeting.StartDate;
                    //    //dateTime = dateTime.AddMinutes(-15);
                    //    //if (dateTime <= meeting.StartDate && dateTime <= currentDateTime && currentDateTime <= meeting.StartDate)
                    //    //{
                    //    //    return Json(new { status = true, message = "You have a meeting in 15 minutes." });
                    //    //}
                    //}
                    return Json(new { status = true, reminderModel });
                }
                else
                    return Json(new { status = false });
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("ReviewReminder")]
        public IActionResult ReviewReminder(int reminderId)
        {
            try
            {
                if (reminderId > 0)
                {
                    bool isView = _iNotificationStatus.ReviewReminder(reminderId).Result;
                    if (isView)
                        return Json(new { status = true, message = "Reminder closed." });
                    else
                        return Json(new { status = false, message = "Something went wrong." });
                }
                else
                    return Json(new { status = false, message = "Something went wrong." });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Get reminder for meeting.

        #region Add New Remainder
        [HttpPost]
        [Route("AddReminder")]
        public IActionResult AddReminder(DateTime reminderDate, TimeSpan reminderTime, string reminderText, string reminderSubject)
        {
            try
            {
                if (!string.IsNullOrEmpty(reminderText) && !string.IsNullOrEmpty(reminderText))
                {
                    ReminderMasterModel remainderMasterModel = new ReminderMasterModel()
                    { ReminderDate = reminderDate, ReminderTime = reminderTime, ReminderText = reminderText, ReminderSubject = reminderSubject };
                    int reminderId = _iNotificationStatus.AddReminder(remainderMasterModel, USERID).Result;
                    if (reminderId > 0)
                        return Json(new { status = true, message = "New remainder added." });
                    else
                        return Json(new { status = false, message = "Something went wrong." });
                }
                else
                    return Json(new { status = false, message = "Please enter all details." });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Add New Remainder

        #region Show remainder count & list

        [HttpGet]
        [Route("GetReminderCount")]
        public ActionResult GetReminderCount()
        {
            try
            {
                var reminderCount = _iNotificationStatus.GetReminderStatusAsync(USERID).Result;
                return Json(new { status = true, count = reminderCount });
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion Show remainder count & list

        #region View All Reminder

        [HttpPost]
        [Route("ViewAllReminder")]
        public async Task<IActionResult> ViewAllReminder()
        {
            try
            {
                var IsViewTrue = await _iNotificationStatus.UpdateViewAllReminder(USERID);

                if (IsViewTrue > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion View All Reminder
    }
}
