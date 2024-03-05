using Business.Entities.Admin.ProductCategoryMasterModel;
using Business.Interface.IProductCategoryMasterService;
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

namespace ERP.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    [DisplayName("Product Group Master")]
    public class ProductCategoryMasterController : SettingsController
    {
        private readonly ProductCategoryMasterInterface iProductCategoryMaster;
        public ProductCategoryMasterController(ProductCategoryMasterInterface iProductCategoryMaster)
        {
            this.iProductCategoryMaster = iProductCategoryMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<ProductCategoryMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.ProductCategoryMasterText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.ProductCategoryText).Titled("Product Group").SetWidth(20); 
                c.Add(o => o.Remark).Titled("Remark").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnProductCategoryMaster(this)' href='javascript:void(0)' data-id='{o.ProductCategoryID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_ProductCategoryMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<ProductCategoryMaster> pds =(PagedDataTable<ProductCategoryMaster>) iProductCategoryMaster.GetAllProductCategoryMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<ProductCategoryMaster>(pds, query, false, "ProductCategoryMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                ProductCategoryMaster model = new ProductCategoryMaster();
                model.ProductCategoryID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iProductCategoryMaster.GetProductCategoryMasterAsync(id).Result;

                    return PartialView("AddOrUpdateProductCategoryMaster", model);
                }
                return PartialView("AddOrUpdateProductCategoryMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update ProductCategoryMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateProductCategoryMaster(ProductCategoryMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _ProductCategoryMasterID = await iProductCategoryMaster.AddOrUpdateProductCategoryMaster(model);

            if (_ProductCategoryMasterID > 0)
            {
                model.ProductCategoryID = _ProductCategoryMasterID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update ProductCategoryMaster 
    }
}
