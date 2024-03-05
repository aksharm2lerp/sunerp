using Business.Entities.Production.MachineryPurchaseDetailModel;
using Business.Interface.Production.IMachineryPurchaseDetail;
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
    [DisplayName("MachineryPurchaseDetail")]
    public class MachineryPurchaseDetailController : SettingsController
    {
        private readonly MachineryPurchaseDetailInterface iMachineryPurchaseDetail;
        public MachineryPurchaseDetailController(MachineryPurchaseDetailInterface iMachineryPurchaseDetail)
        {
            this.iMachineryPurchaseDetail = iMachineryPurchaseDetail;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryPurchaseDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachineryPurchaseDetailText).Titled("Feedback Notes").SetWidth(70);
                 
                c.Add(o => o.ItemCode).Titled("Item Code").SetWidth(20);
                c.Add(o => o.MachineryName).Titled("Machinery Name").SetWidth(20);
                c.Add(o => o.InvoiceNo).Titled("InvoiceNo").SetWidth(20);
                c.Add(o => o.InvoiceDate).Titled("Purchased Date").SetWidth(10);
                c.Add(o => o.GRNNo).Titled("GRNNo").SetWidth(20);
                c.Add(o => o.GRNDate).Titled("GRNDate").SetWidth(20);
                c.Add(o => o.PurchaseAmount).Titled("Purchased Amt").SetWidth(10);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryPurchaseDetail(this)' href='javascript:void(0)' data-id='{o.MachineryPurchaseDetailID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryPurchaseDetail' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryPurchaseDetail> pds =(PagedDataTable<MachineryPurchaseDetail>) iMachineryPurchaseDetail.GetAllMachineryPurchaseDetailAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryPurchaseDetail>(pds, query, false, "MachineryPurchaseDetailGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineryPurchaseDetail model = new MachineryPurchaseDetail();
                model.MachineryPurchaseDetailID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineryPurchaseDetail.GetMachineryPurchaseDetailAsync(id).Result;

                    return PartialView("AddOrUpdateMachineryPurchaseDetail", model);
                }
                return PartialView("AddOrUpdateMachineryPurchaseDetail", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryPurchaseDetail 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryPurchaseDetail(MachineryPurchaseDetail model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineryPurchaseDetail = await iMachineryPurchaseDetail.AddOrUpdateMachineryPurchaseDetail(model);

            if (_MachineryPurchaseDetail > 0)
            {
                model.MachineryPurchaseDetailID = _MachineryPurchaseDetail;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update MachineryPurchaseDetail 
    }
}
