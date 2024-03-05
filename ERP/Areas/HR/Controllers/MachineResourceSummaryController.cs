using ERP.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using Business.Interface.HR.IMachineResourceSummary;
using Business.Entities.HR.MachineResourceSummaryModel;
using Business.Service.HR.SMachineResourceSummary;
using System.Collections.Generic;

namespace ERP.Areas.HR.Controllers
{
    [Area("HR"), Authorize]
    [DisplayName("MachineResourceSummary")]
    public class MachineResourceSummaryController : SettingsController
    {

        private readonly MachineResourceSummaryInterface _machineResourceSummaryService;

        public MachineResourceSummaryController(MachineResourceSummaryInterface machineResourceSummaryService)
        {
            _machineResourceSummaryService = machineResourceSummaryService;

        }
        public IActionResult Index()
        {
            try
            {
                MachineResourceSummary machineResourceSummary = new MachineResourceSummary();
                return View(machineResourceSummary);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetDetailMachineryResourceSummary(DateTime date, int shiftid, int departmentid, int machineryid)
        {
            try
            {

                MachineResourceSummary machineResourceSummary = _machineResourceSummaryService.GetEmployeeCount(date, shiftid, departmentid, machineryid).Result;
                if (machineResourceSummary != null)
                {
                    ViewData["Date"] = date;
                    ViewData["Shiftid"] = shiftid;
                    ViewData["Departmentid"] = departmentid;
                    ViewData["Machineryid"] = machineryid;
                    return View("Index", machineResourceSummary);
                }
                else
                    return View("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetDetailMachineryResourceLogDetail(DateTime todayDate, int machineryid, int cardNo)
        {
            try
            {
                List<EmployeeDetails> listEmployeeDetails = _machineResourceSummaryService.GetDetailMachineryResourceLogDetailAsync(todayDate, machineryid, cardNo).Result;
                if (listEmployeeDetails.Count > 0)
                    return Json(new { status = true, listEmployeeDetails });
                else
                    return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
