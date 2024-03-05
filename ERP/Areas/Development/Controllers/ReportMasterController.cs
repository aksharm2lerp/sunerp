using Business.Entities.DevelopmentArea.ReportMasterModel;
using Business.Interface.DevelopmentArea.IReportMaster;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Development.Controllers
{
    [Area("Development"), Authorize]
    [DisplayName("ReportMaster")]
    public class ReportMasterController : SettingsController
    {
        private readonly ReportMasterInterface iReportMaster;
        public ReportMasterController(ReportMasterInterface iReportMaster)
        {
            this.iReportMaster = iReportMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<ReportMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.ReportMasterText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.ReportID).Titled("ReportKey").SetWidth(10); 
                c.Add(o => o.ReportName).Titled("ReportName").SetWidth(20); 
                c.Add(o => o.ReportPath).Titled("ReportPath").SetWidth(20);
                c.Add(o => o.CommandType).Titled("CommandType").SetWidth(10);
                c.Add(o => o.CommandText).Titled("CommandText").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(10)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnReportMaster(this)' href='javascript:void(0)' data-id='{o.ReportID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_ReportMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<ReportMaster> pds = iReportMaster.GetAllReportMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<ReportMaster>(pds, query, false, "ReportMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                ReportMaster model = new ReportMaster();
                model.ReportID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iReportMaster.GetReportMasterAsync(id).Result;

                    return PartialView("AddOrUpdateReportMaster", model);
                }
                return PartialView("AddOrUpdateReportMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update ReportMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateReportMaster(ReportMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _ReportID = await iReportMaster.AddOrUpdateReportMaster(model);

            if (_ReportID > 0)
            {
                model.ReportID = _ReportID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update ReportMaster 
    }
}
