using Business.Entities.Marketing.Dashboard;
using Business.Entities.Master.EmployeeCategory;
using Business.Entities.PartyMasterModel;
using Business.Entities.PositiveNoteModel;
using Business.Interface;
using Business.Interface.Marketing.IDashboard;
using Business.Interface.Marketing.IPartiesListbyNote;
using ERP.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("Dashboard")]
    public class DashboardController : SettingsController
    {
        #region Interface
        private readonly DashboardInterface _dashboardInterface;
        private readonly ICommonMasterService _commonMasterService;
        public DashboardController(DashboardInterface dashboardInterface, ICommonMasterService commonMasterService)
        {
            _dashboardInterface = dashboardInterface;
            _commonMasterService = commonMasterService;
        }
        #endregion Interface

        #region Index Page
        [HttpGet]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, int employee)
        {
            try
            {
               ViewData["StartDate"] = startDate;
                ViewBag.StartDate = startDate;
                ViewBag.EndDate = endDate;
                int UserId = _commonMasterService.GetUserIDFromEmployeeID(employee).Result;
                DashboardModel dataSet = await _dashboardInterface.GetUserLoginList(startDate, endDate, UserId);
                if (dataSet != null)
                    return View("Index",dataSet);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }            
        }
        #endregion Index Page

    }
}
