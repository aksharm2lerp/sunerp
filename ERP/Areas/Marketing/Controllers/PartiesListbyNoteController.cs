using ERP.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;
using Business.Interface.NotificationStatusI;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Business.Entities.NotificationModel;
using System.Collections.Generic;
using Business.Entities.PartyMasterModel;
using Business.Entities.PositiveNoteModel;
using Business.Interface.Marketing.IPartiesListbyNote;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    public class PartiesListbyNoteController : SettingsController
    {
        #region Interface

        private readonly PartiesListbyNoteInterface _partiesListbyNoteInterface;
        public PartiesListbyNoteController(PartiesListbyNoteInterface partiesListbyNoteInterface)
        {
            _partiesListbyNoteInterface = partiesListbyNoteInterface;
        }

        #endregion Interface

        #region

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Using Table View
        [HttpGet]
        [Route("ViewAllNotificationList")]
        public IActionResult ViewAllNotificationList(int partyid = 0, int positivenoteid = 0, bool isTrue = false)
        {
            try
            {
                int userId = 0;
                //if (isTrue)
                //    userId = USERID;
                List<PartyMaster> dataSet = _partiesListbyNoteInterface.GetAllNotificationTest(userId, partyid, positivenoteid).Result;

                if (dataSet.Count > 0)
                {
                    return View("Index", dataSet);
                }
                else
                    return View("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Using Table View
    }
}
