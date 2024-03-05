using Business.Entities.Production.MachineCategoryMasterModel;
using Business.Interface.Production.IMachineCategoryMaster;
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
    [DisplayName("MachineCategoryMaster")]
    public class MachineCategoryMasterController : SettingsController
    {
        private readonly MachineCategoryMasterInterface iMachineCategoryMaster;
        public MachineCategoryMasterController(MachineCategoryMasterInterface iMachineCategoryMaster)
        {
            this.iMachineCategoryMaster = iMachineCategoryMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineCategoryMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                 ////c.Add(o => o.MachineCategoryID).Titled("MachineCategoryID").SetWidth(20); 
                c.Add(o => o.MachineCategoryName).Titled("MachineCategoryName").SetWidth(20); c.Add(o => o.Note).Titled("Note").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineCategoryMaster(this)' href='javascript:void(0)' data-id='{o.MachineCategoryID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineCategoryMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineCategoryMaster> pds =(PagedDataTable<MachineCategoryMaster>) iMachineCategoryMaster.GetAllMachineCategoryMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineCategoryMaster>(pds, query, false, "MachineCategoryMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                MachineCategoryMaster model = new MachineCategoryMaster();
                model.MachineCategoryID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineCategoryMaster.GetMachineCategoryMasterAsync(id).Result;

                    return PartialView("AddOrUpdateMachineCategoryMaster", model);
                }
                return PartialView("AddOrUpdateMachineCategoryMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineCategoryMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineCategoryMaster(MachineCategoryMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _MachineCategory = await iMachineCategoryMaster.AddOrUpdateMachineCategoryMaster(model);

            if (_MachineCategory > 0)
            {
                model.MachineCategoryID = _MachineCategory;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update MachineCategoryMaster 
    }
}
