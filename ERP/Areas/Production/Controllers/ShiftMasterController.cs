using Business.Entities.Master.UserPermissionMasterModel;
using Business.Entities.Production.ShiftMasterModel;
using Business.Interface.Production.IShiftMaster;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Production.Controllers
{
    [Area("Production"), Authorize]
    [DisplayName("ShiftMaster")]
    public class ShiftMasterController : SettingsController
    {
        private readonly ShiftMasterInterface iShiftMaster;
        public ShiftMasterController(ShiftMasterInterface iShiftMaster)
        {
            this.iShiftMaster = iShiftMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            string startTime = string.Empty;
            string endTime = string.Empty;
            Action<IGridColumnCollection<ShiftMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.ShiftMasterText).Titled("Feedback Notes").SetWidth(70);
                //c.Add(o => o.ShiftID).Titled("ShiftID").SetWidth(20);

                c.Add(o => o.ShiftName).Titled("Shift Name").SetWidth(20);

                c.Add(o => o.StartTime.Value.TimeOfDay).Titled("Start Time").SetWidth(20);

                c.Add(o => o.EndTime.Value.TimeOfDay).Titled("End Time").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnShiftMaster(this)' href='javascript:void(0)' data-id='{o.ShiftID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_ShiftMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<ShiftMaster> pds = (PagedDataTable<ShiftMaster>)iShiftMaster.GetAllShiftMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<ShiftMaster>(pds, query, false, "ShiftMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
                .Sortable()
                .Searchable(false, false)
                .Selectable(true)
                .WithGridItemsCount()
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false)
                .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");


            return View(server.Grid);
        }

        #endregion Index Page

        #region Slider Page

        [HttpPost]
        public PartialViewResult Get(int id, int key)
        {
            try
            {
                ShiftMaster model = new ShiftMaster();
                model.ShiftID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iShiftMaster.GetShiftMasterAsync(id).Result;

                    return PartialView("AddOrUpdateShiftMaster", model);
                }
                return PartialView("AddOrUpdateShiftMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update ShiftMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateShiftMaster(ShiftMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _Shift = await iShiftMaster.AddOrUpdateShiftMaster(model);

            if (_Shift > 0)
            {
                model.ShiftID = _Shift;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update ShiftMaster 

        #region ManageShift
        public ActionResult CompanyListsAsync(ManageShift model)
        {
            try
            {
                List<ManageShift> lists = new List<ManageShift>();
                lists = iShiftMaster.GetAllShiftMasterAsync(model).Result;
                return View("CompanyLists", lists);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion ManageShift

        #region ShiftLists
        public ActionResult ShiftListsAsync(int companyID)
        {
            try
            {
                List<ManageShift> lists = new List<ManageShift>();
                lists = iShiftMaster.GetAllShiftListsMasterAsync(companyID).Result;
                return View("ShiftLists", lists);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion ShiftLists

        #region AddOrUpdateManageShift Page calls
        public ActionResult AddOrUpdateManageShift(int companyID, int shiftID)
        {
            try
            {
                ManageShift manageShift = new ManageShift();
                if (companyID > 0 && shiftID > 0)
                {
                    ViewData["CompanyID"] = companyID;
                    ViewData["ShiftID"] = shiftID;
                    manageShift = iShiftMaster.GetEmployeeListByShift(companyID, shiftID).Result;
                    if(manageShift!=null)
                        return View("AddOrUpdateManageShift", manageShift);
                    else
                        return View("AddOrUpdateManageShift");
                }
                else
                    return View("AddOrUpdateManageShift");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
        #endregion AddOrUpdateManageShift Page calls

        #region AddorUpdateManageShift
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateManageShift(ManageShift model)
        {
            try
            {                
                model.CreatedOrModifiedBy = USERID;
                var _employeeShiftTnxID = await iShiftMaster.AddOrUpdateManageShift(model);

                if (_employeeShiftTnxID > 0)
                {
                    model.EmployeeShiftTnxID = _employeeShiftTnxID;
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion AddorUpdateManageShift

        
    }
}
