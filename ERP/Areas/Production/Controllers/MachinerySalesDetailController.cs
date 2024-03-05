using Business.Entities.Production.MachinerySalesDetailModel;
using Business.Interface.Production.IMachinerySalesDetail;
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
    [DisplayName("MachinerySalesDetail")]
    public class MachinerySalesDetailController : SettingsController
    {
        private readonly MachinerySalesDetailInterface iMachinerySalesDetail;
        public MachinerySalesDetailController(MachinerySalesDetailInterface iMachinerySalesDetail)
        {
            this.iMachinerySalesDetail = iMachinerySalesDetail;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachinerySalesDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachinerySalesDetailText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.InvoiceNo).Titled("InvoiceNo").SetWidth(20); c.Add(o => o.InvoiceDate).Titled("InvoiceDate").SetWidth(20); c.Add(o => o.LRNo).Titled("LRNo").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachinerySalesDetail(this)' href='javascript:void(0)' data-id='{o.MachinerySalesDetailID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachinerySalesDetail' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachinerySalesDetail> pds =(PagedDataTable<MachinerySalesDetail>) iMachinerySalesDetail.GetAllMachinerySalesDetailAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachinerySalesDetail>(pds, query, false, "MachinerySalesDetailGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachinerySalesDetail model = new MachinerySalesDetail();
                model.MachinerySalesDetailID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachinerySalesDetail.GetMachinerySalesDetailAsync(id).Result;

                    return PartialView("AddOrUpdateMachinerySalesDetail", model);
                }
                return PartialView("AddOrUpdateMachinerySalesDetail", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachinerySalesDetail 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachinerySalesDetail(MachinerySalesDetail model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachinerySalesDetail = await iMachinerySalesDetail.AddOrUpdateMachinerySalesDetail(model);

            if (_MachinerySalesDetail > 0)
            {
                model.MachinerySalesDetailID = _MachinerySalesDetail;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update MachinerySalesDetail 
    }
}
