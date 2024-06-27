using Business.Entities.Admin.TicketManagementStatusMasterModel;
using Business.Interface.Admin.ITicketManagementStatusMaster;
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
    [DisplayName("TicketManagementStatusMaster")]
    public class TicketManagementStatusMasterController : SettingsController
    {
        private readonly TicketManagementStatusMasterInterface iTicketManagementStatusMaster;
        public TicketManagementStatusMasterController(TicketManagementStatusMasterInterface iTicketManagementStatusMaster)
        {
            this.iTicketManagementStatusMaster = iTicketManagementStatusMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<TicketManagementStatusMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.TicketManagementStatusMasterText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.TicketManagementStatusID).Titled("TicketManagementStatusID").SetWidth(20); c.Add(o => o.TicketManagementStatusText).Titled("TicketManagementStatusText").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnTicketManagementStatusMaster(this)' href='javascript:void(0)' data-id='{o.TicketManagementStatusID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_TicketManagementStatusMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<TicketManagementStatusMaster> pds =(PagedDataTable<TicketManagementStatusMaster>) iTicketManagementStatusMaster.GetAllTicketManagementStatusMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<TicketManagementStatusMaster>(pds, query, false, "TicketManagementStatusMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                TicketManagementStatusMaster model = new TicketManagementStatusMaster();
                model.TicketManagementStatusID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iTicketManagementStatusMaster.GetTicketManagementStatusMasterAsync(id).Result;

                    return PartialView("AddOrUpdateTicketManagementStatusMaster", model);
                }
                return PartialView("AddOrUpdateTicketManagementStatusMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update TicketManagementStatusMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateTicketManagementStatusMaster(TicketManagementStatusMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _TicketManagementStatusID = await iTicketManagementStatusMaster.AddOrUpdateTicketManagementStatusMaster(model);

            if (_TicketManagementStatusID > 0)
            {
                model.TicketManagementStatusID = _TicketManagementStatusID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update TicketManagementStatusMaster 
    }
}
