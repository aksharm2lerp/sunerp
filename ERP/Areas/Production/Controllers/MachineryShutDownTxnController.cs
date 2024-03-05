using Business.Entities.Production.MachineryShutDownTxnModel;
using Business.Interface.Production.IMachineryShutDownTxn;
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
    [DisplayName("MachineryShutDownTxn")]
    public class MachineryShutDownTxnController : SettingsController
    {
        private readonly MachineryShutDownTxnInterface iMachineryShutDownTxn;
        public MachineryShutDownTxnController(MachineryShutDownTxnInterface iMachineryShutDownTxn)
        {
            this.iMachineryShutDownTxn = iMachineryShutDownTxn;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryShutDownTxn>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(5);

                c.Add(o => o.ItemCode).Titled("Item Code").SetWidth(10);
                c.Add(o => o.MachineryName).Titled("Machinery Name").SetWidth(20);
                c.Add(o => o.ShutDownReason).Titled("Shutdown Reason").SetWidth(35);
                c.Add(o => o.ActionTakenTime).Titled("Shutdown Time").SetWidth(10).Format("hh:mm");
                c.Add(o => o.ActionTakenDate).Titled("Shutdown Date").SetWidth(10);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(10)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryShutDownTxn(this)' href='javascript:void(0)' data-id='{o.MachineryShutDownID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryShutDownTxn' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryShutDownTxn> pds =(PagedDataTable<MachineryShutDownTxn>) iMachineryShutDownTxn.GetAllMachineryShutDownTxnAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryShutDownTxn>(pds, query, false, "MachineryShutDownTxnGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineryShutDownTxn model = new MachineryShutDownTxn();
                model.MachineryShutDownID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineryShutDownTxn.GetMachineryShutDownTxnAsync(id).Result;

                    return PartialView("AddOrUpdateMachineryShutDownTxn", model);
                }
                return PartialView("AddOrUpdateMachineryShutDownTxn", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryShutDownTxn 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryShutDownTxn(MachineryShutDownTxn model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineryShutDownID = await iMachineryShutDownTxn.AddOrUpdateMachineryShutDownTxn(model);

            if (_MachineryShutDownID > 0)
            {
                model.MachineryShutDownID = _MachineryShutDownID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update MachineryShutDownTxn 
    }
}
