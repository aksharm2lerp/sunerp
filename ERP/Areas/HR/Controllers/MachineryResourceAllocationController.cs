using Business.Entities.DevelopmentArea.DynamicFormM;
using Business.Entities.HR.MachineryResourceAllocationModel;
using Business.Entities.OurProduct;
using Business.Entities.Production.MachineryModel;
using Business.Interface;
using Business.Interface.HR.IMachineryResourceAllocation;
using Business.Service;
using Business.SQL;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.HR.Controllers
{
    [Area("HR"), Authorize]
    [DisplayName("MachineryResourceAllocation")]
    public class MachineryResourceAllocationController : SettingsController
    {
        private readonly MachineryResourceAllocationInterface iMachineryResourceAllocation;
        private readonly ICommonMasterService commonMasterService;
        public MachineryResourceAllocationController(MachineryResourceAllocationInterface iMachineryResourceAllocation, ICommonMasterService _commonmasterService)
        {
            this.iMachineryResourceAllocation = iMachineryResourceAllocation;
            commonMasterService = _commonmasterService;
        }

        #region MachineryResourceAllocation

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryResourceAllocation>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachineryResourceAllocationText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.AllocationDate).Titled("Allocation Date").SetWidth(20).Format("{0:dd/MM/yyyy}"); ;
                //c.Add(o => o.ShiftID).Titled("ShiftID").SetWidth(20);
                c.Add(o => o.Shift).Titled("Shift").SetWidth(20);
                c.Add(o => o.Department).Titled("Department").SetWidth(20);
                c.Add(o => o.MachineryName).Titled("Machinery").SetWidth(20);
                //c.Add(o => o.DepartmentID).Titled("DepartmentID").SetWidth(20);



                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryResourceAllocation(this)' href='javascript:void(0)' data-id='{o.MachineryResourceAllocationID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryResourceAllocation' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryResourceAllocation> pds = (PagedDataTable<MachineryResourceAllocation>)iMachineryResourceAllocation.GetAllMachineryResourceAllocationAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryResourceAllocation>(pds, query, false, "MachineryResourceAllocationGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineryResourceAllocation model = new MachineryResourceAllocation();
                model.MachineryResourceAllocationID = id;
                var listOperatorsAndHelpers = commonMasterService.GetAllEmployeeAsync().Result;
                ViewData["OperatorsAndHelpers"] = new SelectList(listOperatorsAndHelpers, "EmployeeID", "EmployeeName");
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineryResourceAllocation.GetMachineryResourceAllocationAsync(id).Result;

                    return PartialView("AddOrUpdateMachineryResourceAllocation", model);
                }
                return PartialView("AddOrUpdateMachineryResourceAllocation", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryResourceAllocation 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryResourceAllocation(MachineryResourceAllocation model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineryResourceAllocationID = await iMachineryResourceAllocation.AddOrUpdateMachineryResourceAllocation(model);

            if (_MachineryResourceAllocationID > 0)
            {
                model.MachineryResourceAllocationID = _MachineryResourceAllocationID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update MachineryResourceAllocation 

        #endregion MachineryResourceAllocation

        #region DailyMachineryResourceLog

        [System.Web.Mvc.HttpGet]
        public IActionResult GetDailyMachineryResourceLog(DateTime? todayDate, int shiftId, int departmentId, int machineryId)
        {
            try
            {
                if (todayDate.HasValue || shiftId > 0 || departmentId > 0 || machineryId > 0)
                {
                    List<DailyMachineryResourceLog> dailyMachineryResourceLogs = iMachineryResourceAllocation.GetDailyMachineryResourceLogAsync(todayDate, shiftId, departmentId, machineryId).Result;

                    return Json(new { status = true, dailyMachineryResourceLogs });
                }
                else
                    return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [System.Web.Mvc.HttpPost]
        public IActionResult AddUpdateMachineryResourceLog(DailyMachineryResourceTxn dailyMachineryResourceTxn)
        {
            try
            {
                List<DailyMachineryResourceTxn> dailyMachineryResourceTxns = new List<DailyMachineryResourceTxn>();

                if (!string.IsNullOrEmpty(dailyMachineryResourceTxn.MachineryResourceLogArray))
                    dailyMachineryResourceTxns = JsonConvert.DeserializeObject<List<DailyMachineryResourceTxn>>(dailyMachineryResourceTxn.MachineryResourceLogArray);

                #region Creating DataTable


                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("DailyMachineryResourceTxnID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("DailyMachineryResourceLogID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("ResourceType", typeof(bool)));
                dataTable.Columns.Add(new DataColumn("EmployeeID", typeof(int)));
                //dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
                dataTable.Columns.Add(new DataColumn("EmployeeOperatorHelperName", typeof(string)));
                dataTable.Columns.Add(new DataColumn("TransferToMachineID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("IsAdditionalResource", typeof(bool)));
                dataTable.Columns.Add(new DataColumn("IsPresent", typeof(bool)));

                foreach (var item in dailyMachineryResourceTxns)
                {
                    dataTable.Rows.Add(new object[]
                    {
                    item.DailyMachineryResourceTxnID,
                    item.DailyMachineryResourceLogID,
                    item.ResourceType,
                    item.EmployeeID,
                    item.EmployeeOperatorHelperName,
                    item.TransferToMachineID,
                    item.IsAdditionalResource,
                    item.IsPresent
                    });
                }
                #endregion Creating DataTable
                dailyMachineryResourceTxn.CreatedOrModifiedBy = USERID;
                int result = iMachineryResourceAllocation.AddUpdateMachineryResourceLogAsync(dailyMachineryResourceTxn, dataTable).Result;
                if (result > 0)
                    return Json(new { status = true, message = "Machinery resource saved." });

                else
                    return Json(new { status = false, message = "Machinery resource not saved." });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region Machinery dropdown
        //      
        //                return new SelectList(MachineryList, "MachineryID", "MachineryName");

        [System.Web.Mvc.HttpGet]
        public IActionResult GetAllMachineryAsync()
        {
            try
            {
                var MachineryList = commonMasterService.GetAllMachineryAsync().Result.Select(x => new { MachineryID = x.MachineryID, MachineryName = x.MachineryName }).ToList();
                return Json(new { status = true, MachineryList });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Machinery dropdown

        #endregion DailyMachineryResourceLog

        #region Available employee list for machine dropdown

        [System.Web.Mvc.HttpPost]
        public IActionResult GetAllAvailableEmployeesForMachineryAsync(DateTime todayDate, int shiftId, int departmentId, int machineryId)
        {
            try
            {
                //var MachineryList = commonMasterService.GetAllMachineryAsync().Result.Select(x => new { MachineryID = x.MachineryID, MachineryName = x.MachineryName }).ToList();
                //var listEmployees = commonMasterService.GetAllAvailableEmployeesForMachineryAsync(todayDate, shiftId, departmentId, machineryId).Result;
                var listEmployees = commonMasterService.GetAllAvailableEmployeesForMachineryAsync(todayDate).Result;
                return Json(new { status = true, listEmployees });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Available employee list for machine dropdown

        #region Select Machine Name form DepartmentID

        public JsonResult SelectMachine(int departmentId)
        {
            try
            {
                var test = commonMasterService.MachineNameByDepartmentID(departmentId).Result.Select(x => new { MachineryID = x.MachineryID, MachineryName = x.MachineryName });
                return Json(test);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Select Machine Name form DepartmentID

    }
}
