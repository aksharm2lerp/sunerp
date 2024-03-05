using Business.Interface;
using ERP.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Business.Interface.IOtherDeductionService;
using Business.SQL;
using Microsoft.AspNetCore.Http;
using System;
using GridShared;
using Business.Entities.OtherDeductionModel;
using GridCore.Server;
using ERP.Helpers;
using System.Threading.Tasks;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP.Areas.HR.Controllers
{
    [Area("HR"), Authorize]
    [DisplayName("OtherDeduction")]
    public class OtherDeductionController : SettingsController
    {
        #region Interface Link
        private readonly IOtherDeductionService _otherDeductionService;
        private readonly IMasterService _masterService;


        public OtherDeductionController(IOtherDeductionService otherDeductionService, IMasterService masterService)
        {
            _otherDeductionService = otherDeductionService;
            _masterService = masterService;
        }
        #endregion Interface Link

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;

            Action<IGridColumnCollection<OtherDeduction>> columns = c =>
            {
                c.Add(o => o.SrNo).Titled("Sr No.").Sortable(true);
                c.Add(o => o.EmployeeName).Titled("Employee Name").Sortable(true);
                c.Add(o => o.PaymentDate).Titled("Payment Date").Sortable(true).Format("{0:dd/MM/yyyy}");
                c.Add(o => o.Amount).Titled("Employee Amount").Sortable(true);
                c.Add(o => o.Description).Titled("Description").Sortable(true);
                //c.Add(o => o.IsActive).Titled("Status").Sortable(true);
                //Below code hide on phones
                //c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                //.RenderValueAs(o => $"<a class='btn' onclick='fnOtherDeduction(this)' href='javascript:void(0)' data-id='{o.OtherDeductionID}' data-bs-toggle='offcanvas' data-bs-target='#canvasOtherDeduction' aria-controls='canvasOtherDeduction'><i class='bx bx-edit'></i> </a>");

                c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                .RenderValueAs(o => $"<a class='btn' onclick='fnOtherDeduction(this)' href='javascript:void(0)' data-id='{o.OtherDeductionID}' data-bs-toggle='offcanvas' data-bs-target='#canvasOtherDeduction' data-key='{o.EmployeeID}' aria-controls='canvasOtherDeduction'><i class='bx bx-edit'></i> </a>");
            };
            PagedDataTable<OtherDeduction> pds = _otherDeductionService.GetAllOtherDeductionAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<OtherDeduction>(pds, query, false, "ordersGrid",
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
        #endregion Index Page

        #region Slider Page

        [HttpGet]
        public async Task<PartialViewResult> AddUpdateOtherDeduction(int OtherDeductionID)
        {
            try
            {
                OtherDeduction otherDeduction = await _otherDeductionService.GetOtherDeductionAsync(OtherDeductionID);

                if (otherDeduction == null)
                    otherDeduction = new OtherDeduction { OtherDeductionID = OtherDeductionID };

                var listEmployees = _masterService.GetAllEmployees();
                ViewData["EmployeeName"] = new SelectList(listEmployees, "EmployeeID", "EmployeeName");

                return PartialView("_addUpdateOtherDeduction", otherDeduction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Slider Page

        #region Add Or Updater

        [HttpPost]
        public async Task<ActionResult> AddUpdateOtherDeduction(OtherDeduction OtherDeduction)
        {
            try
            {
                OtherDeduction.CreatedOrModifiedBy = USERID;
                int OtherDeductionID = await _otherDeductionService.AddOrUpdateOtherDeductionAsync(OtherDeduction);
                if (OtherDeductionID > 0)
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

        #endregion Add Or Updater

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
