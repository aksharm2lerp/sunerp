using Business.Entities.DevelopmentArea.FormDatabaseTableModel;
using Business.Interface.DevelopmentArea.IFormDatabaseTable;
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
    [DisplayName("FormDatabaseTable")]
    public class FormDatabaseTableController : SettingsController
    {
        private readonly FormDatabaseTableInterface iFormDatabaseTable;
        public FormDatabaseTableController(FormDatabaseTableInterface iFormDatabaseTable)
        {
            this.iFormDatabaseTable = iFormDatabaseTable;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<FormDatabaseTable>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.FormDatabaseTableText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.TableName).Titled("TableName").SetWidth(20); c.Add(o => o.Remark).Titled("Remark").SetWidth(20); c.Add(o => o.FormID).Titled("FormID").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnFormDatabaseTable(this)' href='javascript:void(0)' data-id='{o.FormDatabaseTableID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_FormDatabaseTable' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<FormDatabaseTable> pds = iFormDatabaseTable.GetAllFormDatabaseTableAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<FormDatabaseTable>(pds, query, false, "FormDatabaseTableGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                FormDatabaseTable model = new FormDatabaseTable();
                model.FormDatabaseTableID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iFormDatabaseTable.GetFormDatabaseTableAsync(id).Result;

                    return PartialView("AddOrUpdateFormDatabaseTable", model);
                }
                return PartialView("AddOrUpdateFormDatabaseTable", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update FormDatabaseTable 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateFormDatabaseTable(FormDatabaseTable model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _FormDatabaseTableID = await iFormDatabaseTable.AddOrUpdateFormDatabaseTable(model);

            if (_FormDatabaseTableID > 0)
            {
                model.FormDatabaseTableID = _FormDatabaseTableID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update FormDatabaseTable 
    }
}
