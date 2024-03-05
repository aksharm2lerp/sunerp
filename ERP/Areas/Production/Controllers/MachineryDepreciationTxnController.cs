using Business.Entities.Production.MachineryDepreciationTxnModel;
using Business.Interface.Production.IMachineryDepreciationTxn;
using Business.SQL;
using ClosedXML.Excel;
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
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Production.Controllers
{
    [Area("Production"), Authorize]
    [DisplayName("MachineryDepreciationTxn")]
    public class MachineryDepreciationTxnController : SettingsController
    {
        private readonly MachineryDepreciationTxnInterface iMachineryDepreciationTxn;
        public MachineryDepreciationTxnController(MachineryDepreciationTxnInterface iMachineryDepreciationTxn)
        {
            this.iMachineryDepreciationTxn = iMachineryDepreciationTxn;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryDepreciationTxn>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachineryDepreciationTxnText).Titled("Feedback Notes").SetWidth(70);
                ////c.Add(o => o.MachineryDepreciationID).Titled("MachineryDepreciationID").SetWidth(20); 
                c.Add(o => o.ItemCode).Titled("Item Code").SetWidth(20);
                c.Add(o => o.MachineryName).Titled("Machinery Name").SetWidth(20);
                c.Add(o => o.PurchaseAmount).Titled("Purchased Amt").SetWidth(10);
                c.Add(o => o.PurchaseOn).Titled("Purchased Date").SetWidth(10);
                c.Add(o => o.NoOfYear).Titled("NoOfYearDep.").SetWidth(10);
                c.Add(o => o.DepreciationAmount).Titled("Dep. Amount.").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryDepreciationTxn(this)' href='javascript:void(0)' data-id='{o.MachineryDepreciationID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryDepreciationTxn' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryDepreciationTxn> pds = (PagedDataTable<MachineryDepreciationTxn>)iMachineryDepreciationTxn.GetAllMachineryDepreciationTxnAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryDepreciationTxn>(pds, query, false, "MachineryDepreciationTxnGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineryDepreciationTxn model = new MachineryDepreciationTxn();
                model.MachineryDepreciationID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineryDepreciationTxn.GetMachineryDepreciationTxnAsync(id).Result;

                    return PartialView("AddOrUpdateMachineryDepreciationTxn", model);
                }
                return PartialView("AddOrUpdateMachineryDepreciationTxn", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryDepreciationTxn 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryDepreciationTxn(MachineryDepreciationTxn model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineryDepreciationID = await iMachineryDepreciationTxn.AddOrUpdateMachineryDepreciationTxn(model);

            if (_MachineryDepreciationID > 0)
            {
                model.MachineryDepreciationID = _MachineryDepreciationID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update MachineryDepreciationTxn 

        [System.Web.Mvc.HttpGet]
        public async Task<IActionResult> MachineryDepreciationReport(string searchString, bool isExport)
        {
            try
            {
                DataSet dataSet = new DataSet();
                dataSet = await iMachineryDepreciationTxn.MachineryDepreciationReportAsync(searchString);
                var tester = !string.IsNullOrEmpty(searchString) ? searchString : string.Empty;
                ViewData["SearchValue"] = !string.IsNullOrEmpty(searchString) ? searchString : string.Empty;
                if (dataSet.Tables.Count > 0)
                {
                    if (isExport)
                    {
                        return ExportToExcel(dataSet, "MachineryDepreciationReport");
                    }

                    return View("MachineryDepreciationReport", dataSet);
                }
                else
                    return View("MachineryDepreciationReport");
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        #region Export to excel 
        public IActionResult ExportToExcel(DataSet dataSet, string filename)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataSet);
                using (MemoryStream stream = new MemoryStream())
                {

                    wb.SaveAs(stream);

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename + DateTime.Now + ".xlsx");
                }
            }

        }
        #endregion Export to excel
    }
}
