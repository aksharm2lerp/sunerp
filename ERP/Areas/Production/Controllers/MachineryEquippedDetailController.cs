using Business.Entities.Production.MachineryEquippedDetailModel;
using Business.Interface.Production.IMachineryEquippedDetail;
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
    [DisplayName("MachineryEquippedDetail")]
    public class MachineryEquippedDetailController : SettingsController
    {
        private readonly MachineryEquippedDetailInterface iMachineryEquippedDetail;
        public MachineryEquippedDetailController(MachineryEquippedDetailInterface iMachineryEquippedDetail)
        {
            this.iMachineryEquippedDetail = iMachineryEquippedDetail;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryEquippedDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                
                c.Add(o => o.EquippedDate).Titled("EquippedDate").SetWidth(20); 
                c.Add(o => o.PlantNameOrNumber).Titled("PlantName/Number").SetWidth(20); 
                c.Add(o => o.PositionOrLocation).Titled("Position/Location").SetWidth(20);
                ////c.Add(o => o.DepartmentID).Titled("DepartmentID").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryEquippedDetail(this)' href='javascript:void(0)' data-id='{o.MachineryEquippedDetailID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryEquippedDetail' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryEquippedDetail> pds =(PagedDataTable<MachineryEquippedDetail>) iMachineryEquippedDetail.GetAllMachineryEquippedDetailAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryEquippedDetail>(pds, query, false, "MachineryEquippedDetailGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineryEquippedDetail model = new MachineryEquippedDetail();
                model.MachineryEquippedDetailID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineryEquippedDetail.GetMachineryEquippedDetailAsync(id).Result;

                    return PartialView("AddOrUpdateMachineryEquippedDetail", model);
                }
                return PartialView("AddOrUpdateMachineryEquippedDetail", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryEquippedDetail 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryEquippedDetail(MachineryEquippedDetail model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineryEquippedDetail = await iMachineryEquippedDetail.AddOrUpdateMachineryEquippedDetail(model);

            if (_MachineryEquippedDetail > 0)
            {
                model.MachineryEquippedDetailID = _MachineryEquippedDetail;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update MachineryEquippedDetail 
    }
}
