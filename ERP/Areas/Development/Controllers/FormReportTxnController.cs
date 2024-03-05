using Business.Entities.DevelopmentArea.FormReportTxnModel;
using Business.Interface.DevelopmentArea.IFormReportTxn;
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
    [DisplayName("FormReportTxn")]
    public class FormReportTxnController : SettingsController
    {
        private readonly FormReportTxnInterface iFormReportTxn;
        public FormReportTxnController(FormReportTxnInterface iFormReportTxn)
        {
            this.iFormReportTxn = iFormReportTxn;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<FormReportTxn>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.FormReportTxnText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.FormReportID).Titled("FormReportID").SetWidth(20); c.Add(o => o.MappingDescription).Titled("MappingDescription").SetWidth(20); c.Add(o => o.FormID).Titled("FormID").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnFormReportTxn(this)' href='javascript:void(0)' data-id='{o.FormReportID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_FormReportTxn' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<FormReportTxn> pds = iFormReportTxn.GetAllFormReportTxnAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<FormReportTxn>(pds, query, false, "FormReportTxnGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                FormReportTxn model = new FormReportTxn();
                model.FormReportID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iFormReportTxn.GetFormReportTxnAsync(id).Result;

                    return PartialView("AddOrUpdateFormReportTxn", model);
                }
                return PartialView("AddOrUpdateFormReportTxn", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update FormReportTxn 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateFormReportTxn(FormReportTxn model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _FormReportID = await iFormReportTxn.AddOrUpdateFormReportTxn(model);

            if (_FormReportID > 0)
            {
                model.FormReportID = _FormReportID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update FormReportTxn 
    }
}
