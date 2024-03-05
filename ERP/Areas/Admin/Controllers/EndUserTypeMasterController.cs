using Business.Entities.Admin.EndUserTypeMasterModel;
using Business.Interface.IEndUserTypeMasterService;
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
    [DisplayName("EndUserTypeMaster")]
    public class EndUserTypeMasterController : SettingsController
    {
        private readonly EndUserTypeMasterInterface iEndUserTypeMaster;
        public EndUserTypeMasterController(EndUserTypeMasterInterface iEndUserTypeMaster)
        {
            this.iEndUserTypeMaster = iEndUserTypeMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<EndUserTypeMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.EndUserTypeMasterText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.EndUserTypeText).Titled("EndUserTypeText").SetWidth(20); c.Add(o => o.EndUserTypeTableName).Titled("EndUserTypeTableName").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnEndUserTypeMaster(this)' href='javascript:void(0)' data-id='{o.EndUserTypeMasterID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_EndUserTypeMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<EndUserTypeMaster> pds =(PagedDataTable<EndUserTypeMaster>) iEndUserTypeMaster.GetAllEndUserTypeMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<EndUserTypeMaster>(pds, query, false, "EndUserTypeMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                EndUserTypeMaster model = new EndUserTypeMaster();
                model.EndUserTypeMasterID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iEndUserTypeMaster.GetEndUserTypeMasterAsync(id).Result;

                    return PartialView("AddOrUpdateEndUserTypeMaster", model);
                }
                return PartialView("AddOrUpdateEndUserTypeMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update EndUserTypeMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateEndUserTypeMaster(EndUserTypeMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _EndUserTypeMasterID = await iEndUserTypeMaster.AddOrUpdateEndUserTypeMaster(model);

            if (_EndUserTypeMasterID > 0)
            {
                model.EndUserTypeMasterID = _EndUserTypeMasterID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update EndUserTypeMaster 
    }
}
