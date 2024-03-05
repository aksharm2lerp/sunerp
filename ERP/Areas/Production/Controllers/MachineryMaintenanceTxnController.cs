using Business.Entities.Production.MachineryMaintenanceTxnModel;
using Business.Interface.Production.IMachineryMaintenanceTxn;
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
    [DisplayName("MachineryMaintenanceTxn")]
    public class MachineryMaintenanceTxnController : SettingsController
    {
        private readonly MachineryMaintenanceTxnInterface iMachineryMaintenanceTxn;
        public MachineryMaintenanceTxnController(MachineryMaintenanceTxnInterface iMachineryMaintenanceTxn)
        {
            this.iMachineryMaintenanceTxn = iMachineryMaintenanceTxn;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryMaintenanceTxn>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachineryMaintenanceTxnText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.ItemCode).Titled("Item Code").SetWidth(20); 
                c.Add(o => o.MachineryName).Titled("Machinery Name").SetWidth(20); 
                c.Add(o => o.ActionTakenDate).Titled("Repair Date").SetWidth(20);
                c.Add(o => o.ActionTakenBy).Titled("Repair By").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryMaintenanceTxn(this)' href='javascript:void(0)' data-id='{o.MachineryMaintenanceID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryMaintenanceTxn' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryMaintenanceTxn> pds =(PagedDataTable<MachineryMaintenanceTxn>) iMachineryMaintenanceTxn.GetAllMachineryMaintenanceTxnAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryMaintenanceTxn>(pds, query, false, "MachineryMaintenanceTxnGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineryMaintenanceTxn model = new MachineryMaintenanceTxn();
                model.MachineryMaintenanceID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineryMaintenanceTxn.GetMachineryMaintenanceTxnAsync(id).Result;

                    return PartialView("AddOrUpdateMachineryMaintenanceTxn", model);
                }
                return PartialView("AddOrUpdateMachineryMaintenanceTxn", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryMaintenanceTxn 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryMaintenanceTxn(MachineryMaintenanceTxn model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineryMaintenance = await iMachineryMaintenanceTxn.AddOrUpdateMachineryMaintenanceTxn(model);

            if (_MachineryMaintenance > 0)
            {
                model.MachineryMaintenanceID = _MachineryMaintenance;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update MachineryMaintenanceTxn 
    }
}
