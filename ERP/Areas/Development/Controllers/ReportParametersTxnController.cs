using Business.Entities.DevelopmentArea.ReportParametersTxnModel;
using Business.Interface.DevelopmentArea.IReportParametersTxn;
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
    [DisplayName("ReportParametersTxn")]
    public class ReportParametersTxnController : SettingsController
    {
        private readonly ReportParametersTxnInterface iReportParametersTxn;
        public ReportParametersTxnController(ReportParametersTxnInterface iReportParametersTxn)
        {
            this.iReportParametersTxn = iReportParametersTxn;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<ReportParametersTxn>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.ReportParametersTxnText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.ReportParametersID).Titled("ReportParametersID").SetWidth(20); c.Add(o => o.ParameterName).Titled("ParameterName").SetWidth(20); c.Add(o => o.ParameterType).Titled("ParameterType").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnReportParametersTxn(this)' href='javascript:void(0)' data-id='{o.ReportParametersID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_ReportParametersTxn' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<ReportParametersTxn> pds = iReportParametersTxn.GetAllReportParametersTxnAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<ReportParametersTxn>(pds, query, false, "ReportParametersTxnGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                ReportParametersTxn model = new ReportParametersTxn();
                model.ReportParametersID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iReportParametersTxn.GetReportParametersTxnAsync(id).Result;

                    return PartialView("AddOrUpdateReportParametersTxn", model);
                }
                return PartialView("AddOrUpdateReportParametersTxn", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update ReportParametersTxn 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateReportParametersTxn(ReportParametersTxn model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _ReportParametersID = await iReportParametersTxn.AddOrUpdateReportParametersTxn(model);

            if (_ReportParametersID > 0)
            {
                model.ReportParametersID = _ReportParametersID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update ReportParametersTxn 
    }
}
