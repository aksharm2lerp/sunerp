using Business.Entities;
using Business.Entities.Marketing.Meeting;
using Business.Interface;
using Business.Interface.Marketing.IMeeting;
using ERP.Controllers;
using ERP.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonResult = System.Web.Mvc.JsonResult;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Business.Service.Marketing;
using Business.SQL;
using System;
using System.IO;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("Meeting")]
    public class MarketingMeetingController : SettingsController
    {

        private readonly UserManager<UserMasterMetadata> _userManager;
        private readonly SignInManager<UserMasterMetadata> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMasterService _masterService;
        private readonly IMarketingMeeting _iMarketingMeeting;
        private readonly IEmailService _emailService = null;

        public MarketingMeetingController(UserManager<UserMasterMetadata> userManager, SignInManager<UserMasterMetadata> signInManager, IMasterService masterService, IWebHostEnvironment hostEnvironment, IMarketingMeeting marketingMeeting, IEmailService emailService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._masterService = masterService;
            _webHostEnvironment = hostEnvironment;
            _iMarketingMeeting = marketingMeeting;
            _emailService = emailService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public Microsoft.AspNetCore.Mvc.JsonResult MarketingMeet()
        {
            /*List<temp> events = new List<temp> { 
            new temp{ EventID=1, Subject="Test 1", Description="testing d 1", Start="17-11-2022", End="18-11-2022"} ,
            new temp{ EventID=2, Subject="Test 2", Description="testing d 2", Start="19-11-2022", End="20-11-2022"} ,
            new temp{ EventID=3, Subject="Test 3", Description="testing d 3", Start="14-11-2022", End="15-11-2022"} ,
            };*/

            List<MarketingMeeting> events = _iMarketingMeeting.GetAllMarketingMeetingAsync(0, 0, "", "", "", USERID).Result;

            //List<MarketingMeeting> events = new List<MarketingMeeting>();
            //var json = new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json(events);
        }

        public Microsoft.AspNetCore.Mvc.JsonResult MarketingMeetPartyWise(int partyID)
        {

            List<MarketingMeeting> events = _iMarketingMeeting.GetAllMarketingMeetingPartyWiseAsync(0, 0, "", "", "", USERID, partyID).Result;
            return Json(events);
        }
        public IActionResult Create(int id = 0)
        {
            var MeetingStatusTypeTextList = _masterService.GetAllMeetingStatusTypeMasterAsync(); ViewData["MeetingStatusTypeText"] = new SelectList(MeetingStatusTypeTextList, "MeetingStatusTypeID", "MeetingStatusTypeText");

            var MeetingDurationTypeTextList = _masterService.GetAllMeetingDurationTypeMasterAsync(); ViewData["MeetingDurationTypeText"] = new SelectList(MeetingDurationTypeTextList, "MeetingDurationTypeID", "MeetingDurationTypeText");

            if (id > 0)
            {
                MarketingMeeting events = _iMarketingMeeting.GetMarketingMeetingAsync(id).Result;
                return View("Create", events);
            }
            else
            {
                MarketingMeeting events = new MarketingMeeting();
                DateTime today = DateTime.Now;
                string date = today.ToString("yyyy-MM-dd HH:mm");
                events.EndDate = Convert.ToDateTime(date);
                events.StartDate = Convert.ToDateTime(date);
                return View("Create", events);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateMeetingDetail(MarketingMeeting model)
        {
            try
            {
                model.CreatedOrModifiedBy = USERID;
                var _marketingMeetingID = await _iMarketingMeeting.MarketingMeetingInsertOrUpdateAsync(model);
                model.MarketingMeetingID = _marketingMeetingID;

                if (_marketingMeetingID > 0 && model.MeetingStatusID != 3)
                {

                    //send email to whom visitor wants to meet
                    MailRequest request = new MailRequest();
                    //request.Subject = "Meeting Request -" + model.Subject;
                    request.ToEmail = model.ContactPerson;
                    request.CCEmail = model.AssignTo;
                    string FilePath = string.Empty;
                    if (model.MeetingStatusID > 0 && model.MeetingStatusID == 1) //Schedule
                    {
                        request.Subject = "Meeting Request -" + model.Subject;
                        FilePath = Directory.GetCurrentDirectory() + "\\Templates\\MeetingInvitation.html";
                    }
                    if (model.MeetingStatusID > 0 && model.MeetingStatusID == 2) //Reschedule
                    {
                        request.Subject = "Meeting has been re-schedule -" + model.Subject;
                        FilePath = Directory.GetCurrentDirectory() + "\\Templates\\MeetingReschedule.html";
                    }
                    if (model.MeetingStatusID > 0 && model.MeetingStatusID == 4) //Cancel
                    {
                        request.Subject = "Meeting has been cancel -" + model.Subject;
                        FilePath = Directory.GetCurrentDirectory() + "\\Templates\\MeetingCancel.html";
                    }
                    if (model.MeetingStatusID > 0 && model.MeetingStatusID == 3) //Cancel
                    {
                        request.Subject = "Meeting has completed -" + model.Subject;
                        //FilePath = Directory.GetCurrentDirectory() + "\\Templates\\MeetingCancel.html";
                    }
                    //string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\MeetingInvitation.html";
                    string path = Directory.GetCurrentDirectory();
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd();
                    str.Close();

                    //MailText = MailText.Replace("#username#", model.ContactPerson).Replace("#VisitorName#", model.FirstName + " " + model.LastName);
                    MailText = MailText.Replace("#username#", model.ContactPersonName);
                    MailText = MailText.Replace("#MeetingRequestTitle#", model.Subject);
                    // MailText = MailText.Replace("#approvallink#", "https://www.w3schools.com/");
                    MailText = MailText.Replace("#Sdate#", model.StartDate.ToString());
                    MailText = MailText.Replace("#Edate#", model.EndDate.ToString());
                    MailText = MailText.Replace("#TopicOfTheMeeting#", model.Subject);
                    MailText = MailText.Replace("#LocationOrVirtualPlatform#", model.MeetingLocation);
                    MailText = MailText.Replace("#EstimatedTimeOfMeeting#", model.MeetingDuration.ToString());
                    MailText = MailText.Replace("#CompanyName#", "SRiNi LiNK &reg;");
                    var filePathCompLogo = Path.Combine(Directory.GetCurrentDirectory(), "/wwwroot/companylogo/logo.jpg");
                    MailText = MailText.Replace("#CompanyLogo#", "<img src='" + filePathCompLogo + "' alt='SRiNi LiNK' />");
                    request.Body = MailText;
                    _emailService.SendEmail(request);

                    return Json(new { status = true, message = MessageHelper.Added });
                }

                if (_marketingMeetingID > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                {
                    return Json(new { status = false, message = MessageHelper.Error });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    /* public class temp { 
         public int EventID { get; set; }
         public string Subject { get; set; }
         public string Description { get; set; }
         public string Start { get; set; }
         public string End { get; set; }
         public string ThemeColor { get; set; }
         public string IsFullyDay { get; set; }
     }*/
}
