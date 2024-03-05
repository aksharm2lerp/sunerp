using Business.Entities.Production.UtilityMasterModel;
using Business.Interface.Production.IUtilityMaster;
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
    [DisplayName("UtilityMaster")]
    public class UtilityMasterController : SettingsController
    {
        private readonly UtilityMasterInterface iUtilityMaster;
        public UtilityMasterController(UtilityMasterInterface iUtilityMaster)
        {
            this.iUtilityMaster = iUtilityMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<UtilityMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.UtilityMasterText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.UtilityID).Titled("UtilityID").SetWidth(20); c.Add(o => o.UtilityName).Titled("UtilityName").SetWidth(20); c.Add(o => o.Notes).Titled("Notes").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnUtilityMaster(this)' href='javascript:void(0)' data-id='{o.UtilityID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_UtilityMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<UtilityMaster> pds =(PagedDataTable<UtilityMaster>) iUtilityMaster.GetAllUtilityMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<UtilityMaster>(pds, query, false, "UtilityMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                UtilityMaster model = new UtilityMaster();
                model.UtilityID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iUtilityMaster.GetUtilityMasterAsync(id).Result;

                    return PartialView("AddOrUpdateUtilityMaster", model);
                }
                return PartialView("AddOrUpdateUtilityMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update UtilityMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateUtilityMaster(UtilityMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _UtilityID = await iUtilityMaster.AddOrUpdateUtilityMaster(model);

            if (_UtilityID > 0)
            {
                model.UtilityID = _UtilityID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update UtilityMaster 
    }
}
