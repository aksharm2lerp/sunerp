using Business.Entities.Marketing.Dashboard;
using Business.Entities.PartyMasterModel;
using Business.Entities.PositiveNoteModel;
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
        public DashboardController(DashboardInterface dashboardInterface)
        {
            _dashboardInterface = dashboardInterface;
        }
        #endregion Interface

        #region Index Page
        [HttpGet]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                DashboardModel dataSet = await _dashboardInterface.GetUserLoginList(startDate, endDate);
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
