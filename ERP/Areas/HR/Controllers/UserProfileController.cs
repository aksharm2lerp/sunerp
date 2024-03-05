using Business.Entities.Master.MasterModalForUserProfile;
using Business.Interface.HR;
using Business.Interface.IEmployee;
using Business.Interface.NotificationStatusI;
using DocumentFormat.OpenXml.Office2010.Excel;
using ERP.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;

namespace ERP.Areas.HR.Controllers
{
    [Area("HR"), Authorize]
    [DisplayName("UserProfile")]
    public class UserProfileController : SettingsController
    {
        #region Interface

        private readonly IUserProfile _iUserProfile;
        private readonly IEmployeeService _employeeService;
        private int employeeId = 0;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly string linkEmployeeDocument;
        public UserProfileController(IUserProfile userProfile, IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _iUserProfile = userProfile;
            _employeeService = employeeService;
            employeeId = _iUserProfile.GetEmployeeID(USERID);
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            linkEmployeeDocument = _configuration.GetSection("EmployeeImagePath")["EmployeeDocuments"];
        }

        #endregion Interface   

        #region Index
        public IActionResult Index()
        {
            try
            {

                MasterModalForUserProfile masterModalForUserProfile = new MasterModalForUserProfile();
                masterModalForUserProfile.EmployeeBankDetails = _employeeService.GetEmployeesAllBankAccount(1, 10, "", "", "", employeeId).Result;
                masterModalForUserProfile.EmployeeDocuments = _employeeService.GetEmployeesAllDocuments(1, 10, "", "", "", employeeId).Result;
                masterModalForUserProfile.EmployeeEducation = _employeeService.GetEmployeesAllEducation(1, 10, "", "", "", employeeId).Result;
                masterModalForUserProfile.EmployeeExperience = _employeeService.GetEmployeesAllExperience(1, 10, "", "", "", employeeId).Result;
                masterModalForUserProfile.employeeFamilyDetail = _employeeService.GetEmployeeFamily(employeeId).Result;
                /*masterModalForUserProfile.employeeAddressTxn = _employeeService.GetEmployeeAddressTxn(id,id).Result;
                masterModalForUserProfile.addUpdateEmployee = _employeeService.GetEmployeeAsync(id).Result;*/
                return View("Index", masterModalForUserProfile);

            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion Index

        #region User Profile Basic Details
        [HttpGet]
        public JsonResult GetUserProfileBasicDetails()
        {
            try
            {
                var basicDetails = _iUserProfile.GetUserProfileBasicDetails(USERID).Result;
                return Json(new { status = true, count = basicDetails });
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion User Profile Basic Details 

        #region User Profile Address Details
        [HttpGet]
        public JsonResult GetUserProfileAddressDetails()
        {
            try
            {
                var addressDetails = _iUserProfile.GetUserProfileAddressDetails(USERID).Result;
                return Json(new { status = true, count = addressDetails });
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion User Profile Address Details 

        #region Employee Education Image Download
        public FileResult OpenImage(string fileName)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@_webHostEnvironment.WebRootPath + linkEmployeeDocument + fileName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        #endregion Employee Education Image Download
    }
}
