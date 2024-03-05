using Business.Entities.Production.DepreciationMethodModel;
using Business.Interface.Production.IDepreciationMethod;
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

namespace ERP.Areas.Production.Controllers
{
    [Area("Production"), Authorize]
    [DisplayName("DepreciationMethod")]
    public class DepreciationMethodController : SettingsController
    {
        private readonly DepreciationMethodInterface iDepreciationMethod;
        public DepreciationMethodController(DepreciationMethodInterface iDepreciationMethod)
        {
            this.iDepreciationMethod = iDepreciationMethod;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<DepreciationMethod>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.DepreciationMethodText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.MethodName).Titled("MethodName").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnDepreciationMethod(this)' href='javascript:void(0)' data-id='{o.DepreciationMethodID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_DepreciationMethod' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<DepreciationMethod> pds =(PagedDataTable<DepreciationMethod>) iDepreciationMethod.GetAllDepreciationMethodAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<DepreciationMethod>(pds, query, false, "DepreciationMethodGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                DepreciationMethod model = new DepreciationMethod();
                model.DepreciationMethodID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iDepreciationMethod.GetDepreciationMethodAsync(id).Result;

                    return PartialView("AddOrUpdateDepreciationMethod", model);
                }
                return PartialView("AddOrUpdateDepreciationMethod", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update DepreciationMethod 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateDepreciationMethod(DepreciationMethod model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _DepreciationMethod = await iDepreciationMethod.AddOrUpdateDepreciationMethod(model);

            if (_DepreciationMethod > 0)
            {
                model.DepreciationMethodID = _DepreciationMethod;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update DepreciationMethod 
    }
}
