using Business.Entities.EmployeeGatepass;
using Business.Interface;
using Business.Interface.IGatePassService;
using Business.SQL;
using DocumentFormat.OpenXml.Math;
using ERP.Controllers;
using ERP.Extensions;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.HR.Controllers
{
    [Area("HR"), Authorize]
    [DisplayName("Gatepass")]
    public class GatePassController : SettingsController
    {
        private readonly IGatePassService _gatePassService;
        private readonly IMasterService _masterService;
        public GatePassController(IGatePassService gatePassService, IMasterService masterService)
        {
            _gatePassService = gatePassService;
            _masterService = masterService;
        }
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            string desiname = DISPLAYDESIGNATIONNAME;
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            ViewBag.DisplayName = DISPLAYUSERTYPENAME;
            string nameUser = DISPLAYUSERTYPENAME;

            Action<IGridColumnCollection<EmployeeGatePass>> columns = c =>
            {
                c.Add(o => o.SrNo).Titled("Sr No.").Sortable(true);
                c.Add(o => o.EmployeeName).Titled("Employee Name").Sortable(true);
                c.Add(o => o.Department).Titled("Department").Sortable(true);
                c.Add(o => o.Date).Titled("Date").Sortable(true).Format("{0:dd/MM/yyyy}");
                c.Add(o => o.OutTime).Titled("OutTime").Sortable(true);
                c.Add(o => o.InTime).Titled("InTime").Sortable(true);
                c.Add(o => o.Reason).Titled("Reason").Sortable(true);

                //c.Add(o => o.TotalWagesPerDay).Titled("Total Wages Per Day").Sortable(true);
                //c.Add(o => o.IsActive).Titled("Status").Sortable(true);
                //c.Add(o => o.StartDate).Titled("Start Date").Sortable(true).Format("{0:dd/MM/yyyy}");
                //c.Add(o => o.EndDate).Titled("End Date").Sortable(true).Format("{0:dd/MM/yyyy}");
                //c.Add(o => o.EntryDate).Titled("Entry Date").Sortable(true).Format("{0:dd/MM/yyyy}");
                //Below code hide on phones


                c.Add(o => o.IsHODApproved).Titled("HOD").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
            .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"HODActiveInactive" + o.EmployeeGatePassID}' onchange='fnActiveInactiveApproval(this)' href='javascript:void(0)' data-rowid='{"HODActiveInactive" + o.EmployeeGatePassID}' data-approval='HOD' data-id='{o.EmployeeGatePassID}' data-key='{o.EmployeeID}' " + (o.IsHODApproved ? "checked" : "unchecked") + "" + (DISPLAYUSERTYPENAME != "HOD" ? " disabled" : "") + ">");


                c.Add(o => o.IsHRApproved).Titled("HR").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"HRActiveInactive" + o.EmployeeGatePassID}' onchange='fnActiveInactiveApproval(this)' href='javascript:void(0)' data-rowid='{"HRActiveInactive" + o.EmployeeGatePassID}' data-approval='HR' data-id='{o.EmployeeGatePassID}' data-key='{o.EmployeeID}'" + (o.IsHRApproved ? "checked" : "unchecked") + " " + (DISPLAYUSERTYPENAME != "HR" ? " disabled" : "") + " > ");


                c.Add(o => o.IsOutTimeSecurityApproved).Titled("Security OutTime").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EmployeeOutTime" + o.EmployeeGatePassID}' onchange='fnUpdateInOutTime(this)' href='javascript:void(0)' data-rowid='{"EmployeeOutTime" + o.EmployeeGatePassID}' data-time='outtime' data-id='{o.EmployeeGatePassID}' data-key='{o.EmployeeID}'" + (o.OutTime.Value.ToString() != "00:00:00" ? " disabled style='background-color:#7CFC00;'" : "style='background-color:#FF0000;'") + " " + (DISPLAYUSERTYPENAME != "Security" ? " disabled" : "") + " " + (o.IsOutTimeSecurityApproved ? "checked" : "unchecked") + " title='Out Time'>");

                c.Add(o => o.IsInTimeSecurityApproved).Titled("Security InTime").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EmployeeInTime" + o.EmployeeGatePassID}' onchange='fnUpdateInOutTime(this)' href='javascript:void(0)' data-rowid='{"EmployeeInTime" + o.EmployeeGatePassID}' data-time='intime' data-id='{o.EmployeeGatePassID}' data-key='{o.EmployeeID}'" + (o.InTime.Value.ToString() != "00:00:00" ? " disabled style='background-color:#7CFC00;'" : "style='background-color:#FF0000;'") + " " + (DISPLAYUSERTYPENAME != "Security" ? " disabled" : "") + " " + (o.IsInTimeSecurityApproved ? "checked" : "unchecked") + "  " + (o.IsOutTimeSecurityApproved ? "" : " disabled ") + "  title='In Time'>");



                if (!DISPLAYUSERTYPENAME.Equals("Security"))
                {
                    c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<a class='fa-2x' onclick='fnEmployeeGatepass(this)' href='javascript:void(0)' data-id='{o.EmployeeGatePassID}' data-bs-toggle='offcanvas' data-bs-target='#canvasEmployeeGatepass' data-key='{o.EmployeeID}' aria-controls='canvasEmployeeGatepass'><iconify-icon icon=\"ep:edit\"></iconify-icon> </a>");
                }

                c.Add().Titled("Print").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
             .RenderValueAs(o => $"<a class='fa-2x' onclick='fnPrint(this)' href='javascript:void(0)'  data-id='{o.EmployeeGatePassID}' data-key='{o.EmployeeID}'><iconify-icon icon='arcticons:mobile-print'></iconify-icon>   </a>");
            };

            PagedDataTable<EmployeeGatePass> pds = _gatePassService.GetAllEmployeeGatePassAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<EmployeeGatePass>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable()
                .ClearFiltersButton(true)
                .Selectable(true)
                .WithGridItemsCount()
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false);
            return View(server.Grid);
        }

        [HttpGet]
        public async Task<PartialViewResult> AddUpdateEmployeeGatepass(int employeeId, int employeeGatePassID)
        {
            try
            {
                EmployeeGatePass employeeGatePass = await _gatePassService.GetEmployeeGatePassAsync(employeeId, employeeGatePassID);

                if (employeeGatePass == null)
                    employeeGatePass = new EmployeeGatePass { EmployeeGatePassID = employeeGatePassID };

                var listEmployees = _masterService.GetAllEmployees();
                ViewData["EmployeeName"] = new SelectList(listEmployees, "EmployeeID", "EmployeeName");

                return PartialView("_addUpdateEmployeeGatepass", employeeGatePass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdateEmployeeGatepass(EmployeeGatePass employeeGatePass)
        {
            try
            {
                employeeGatePass.CreatedOrModifiedBy = USERID;
                int employeeGatePassId = await _gatePassService.AddUpdateEmployeeGatePassAsync(employeeGatePass);
                if (employeeGatePassId > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public JsonResult EmployeeNameByDepartmentID(int departmentId)
        {
            var test = _masterService.EmployeeNameByDepartmentID(departmentId).Result.Select(x => new { EmployeeID = x.EmployeeID, EmployeeName = x.EmployeeName });
            return Json(test);
        }

        [HttpPost]
        public async Task<IActionResult> AddRemoveApproval(int employeeGatepassId, bool isApproved, string approvalName)
        {
            try
            {
                int employeeGatePassId = await _gatePassService.AddRemoveApprovalAsync(employeeGatepassId, isApproved, approvalName, USERID);
                if (employeeGatePassId > 0)
                {
                    return Json(new { status = true, message = "Approval updated." });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGatePassInOutTime(int employeeGatepassId, bool isChecked, string time)
        {
            try
            {
                DateTime? inTime = null;
                DateTime? outTime = null;

                if (time.Equals("intime"))
                    inTime = DateTime.Now;
                if (time.Equals("outtime"))
                    outTime = DateTime.Now;

                int employeeGatePassId = await _gatePassService.UpdateGatePassInOutTimeAsync(employeeGatepassId, isChecked, inTime, outTime, USERID);
                if (employeeGatePassId > 0)
                {
                    return Json(new { status = true, message = "Time updated." });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}