using Business.Entities.Production.MachineOperatingStatusModel;
using Business.Interface.Production.IMachineOperatingStatus;
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
    [DisplayName("MachineOperatingStatus")]
    public class MachineOperatingStatusController : SettingsController
    {
        private readonly MachineOperatingStatusInterface iMachineOperatingStatus;
        public MachineOperatingStatusController(MachineOperatingStatusInterface iMachineOperatingStatus)
        {
            this.iMachineOperatingStatus = iMachineOperatingStatus;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineOperatingStatus>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachineOperatingStatusText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.MachineOperatingStatusText).Titled("MachineOperatingStatusText").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineOperatingStatus(this)' href='javascript:void(0)' data-id='{o.MachineOperatingStatusID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineOperatingStatus' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineOperatingStatus> pds =(PagedDataTable<MachineOperatingStatus>) iMachineOperatingStatus.GetAllMachineOperatingStatusAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineOperatingStatus>(pds, query, false, "MachineOperatingStatusGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineOperatingStatus model = new MachineOperatingStatus();
                model.MachineOperatingStatusID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineOperatingStatus.GetMachineOperatingStatusAsync(id).Result;

                    return PartialView("AddOrUpdateMachineOperatingStatus", model);
                }
                return PartialView("AddOrUpdateMachineOperatingStatus", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineOperatingStatus 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineOperatingStatus(MachineOperatingStatus model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineOperatingStatus = await iMachineOperatingStatus.AddOrUpdateMachineOperatingStatus(model);

            if (_MachineOperatingStatus > 0)
            {
                model.MachineOperatingStatusID = _MachineOperatingStatus;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update MachineOperatingStatus 
    }
}
