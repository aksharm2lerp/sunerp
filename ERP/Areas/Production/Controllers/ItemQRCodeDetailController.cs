using Business.Entities.Production.ItemQRCodeDetailModel;
using Business.Interface.Production.IItemQRCodeDetail;
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
    [DisplayName("ItemQRCodeDetail")]
    public class ItemQRCodeDetailController : SettingsController
    {
        private readonly ItemQRCodeDetailInterface iItemQRCodeDetail;
        public ItemQRCodeDetailController(ItemQRCodeDetailInterface iItemQRCodeDetail)
        {
            this.iItemQRCodeDetail = iItemQRCodeDetail;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<ItemQRCodeDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.ItemQRCodeDetailText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.SONo).Titled("SO No").SetWidth(10); c.Add(o => o.PlanningCard).Titled("Planning Card").SetWidth(20);
                c.Add(o => o.MachineryName).Titled("Machinery").SetWidth(40);
                c.Add(o => o.UOM).Titled("UOM").SetWidth(5);
                c.Add(o => o.Qty).Titled("Qty").SetWidth(10);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(5)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnItemQRCodeDetail(this)' href='javascript:void(0)' data-id='{o.ItemQRCodeDetailID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_ItemQRCodeDetail' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<ItemQRCodeDetail> pds =(PagedDataTable<ItemQRCodeDetail>) iItemQRCodeDetail.GetAllItemQRCodeDetailAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<ItemQRCodeDetail>(pds, query, false, "ItemQRCodeDetailGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                ItemQRCodeDetail model = new ItemQRCodeDetail();
                model.ItemQRCodeDetailID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iItemQRCodeDetail.GetItemQRCodeDetailAsync(id).Result;

                    return PartialView("AddOrUpdateItemQRCodeDetail", model);
                }
                return PartialView("AddOrUpdateItemQRCodeDetail", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update ItemQRCodeDetail 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateItemQRCodeDetail(ItemQRCodeDetail model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _ItemQRCodeDetailID = await iItemQRCodeDetail.AddOrUpdateItemQRCodeDetail(model);

            if (_ItemQRCodeDetailID > 0)
            {
                model.ItemQRCodeDetailID = _ItemQRCodeDetailID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update ItemQRCodeDetail 
    }
}
