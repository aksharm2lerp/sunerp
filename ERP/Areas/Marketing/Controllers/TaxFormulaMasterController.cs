using Business.Entities.Marketing.TaxFormulaMasterModel;
using Business.Interface.Marketing.ITaxFormulaMaster;
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

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("TaxFormulaMaster")]
    public class TaxFormulaMasterController : SettingsController
    {
        private readonly TaxFormulaMasterInterface iTaxFormulaMaster;
        public TaxFormulaMasterController(TaxFormulaMasterInterface iTaxFormulaMaster)
        {
            this.iTaxFormulaMaster = iTaxFormulaMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<TaxFormulaMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.TaxFormulaMasterText).Titled("Feedback Notes").SetWidth(70);
                // c.Add(o => o.TaxFormulaID).Titled("TaxFormulaID").SetWidth(20);
                c.Add(o => o.CustomerName).Titled("Customer Name").SetWidth(20);
                c.Add(o => o.FormulaHead).Titled("Formula Head").SetWidth(20);
                c.Add(o => o.FormulaLabel).Titled("Formula Label").SetWidth(20);
                c.Add(o => o.Formula).Titled("Formula").SetWidth(20);
                //c.Add(o => o.FormulaTypeID).Titled("FormulaTypeID").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnTaxFormulaMaster(this)' href='javascript:void(0)' data-id='{o.TaxFormulaID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_TaxFormulaMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<TaxFormulaMaster> pds =(PagedDataTable<TaxFormulaMaster>) iTaxFormulaMaster.GetAllTaxFormulaMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<TaxFormulaMaster>(pds, query, false, "TaxFormulaMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                TaxFormulaMaster model = new TaxFormulaMaster();
                model.TaxFormulaID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iTaxFormulaMaster.GetTaxFormulaMasterAsync(id).Result;

                    return PartialView("AddOrUpdateTaxFormulaMaster", model);
                }
                return PartialView("AddOrUpdateTaxFormulaMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update TaxFormulaMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateTaxFormulaMaster(TaxFormulaMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _TaxFormulaID = await iTaxFormulaMaster.AddOrUpdateTaxFormulaMaster(model);

            if (_TaxFormulaID > 0)
            {
                model.TaxFormulaID = _TaxFormulaID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update TaxFormulaMaster 
    }
}
