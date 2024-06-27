using Business.Entities.SalesDistribution.TermTypeMasterModel;
using Business.Interface.SalesDistribution.ITermTypeMaster;
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

namespace ERP.Areas.SalesDistribution.Controllers
{
    [Area("SalesDistribution"), Authorize]
    [DisplayName("TermTypeMaster")]
    public class TermTypeMasterController : SettingsController
    {
        private readonly TermTypeMasterInterface iTermTypeMaster;
        public TermTypeMasterController(TermTypeMasterInterface iTermTypeMaster)
        {
            this.iTermTypeMaster = iTermTypeMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<TermTypeMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.TermTypeMasterText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.TermTypeID).Titled("TermTypeID").SetWidth(20); c.Add(o => o.TermTypeText).Titled("TermTypeText").SetWidth(20); c.Add(o => o.Note).Titled("Note").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnTermTypeMaster(this)' href='javascript:void(0)' data-id='{o.TermTypeID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_TermTypeMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<TermTypeMaster> pds =(PagedDataTable<TermTypeMaster>) iTermTypeMaster.GetAllTermTypeMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<TermTypeMaster>(pds, query, false, "TermTypeMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                TermTypeMaster model = new TermTypeMaster();
                model.TermTypeID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iTermTypeMaster.GetTermTypeMasterAsync(id).Result;

                    return PartialView("AddOrUpdateTermTypeMaster", model);
                }
                return PartialView("AddOrUpdateTermTypeMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update TermTypeMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateTermTypeMaster(TermTypeMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _TermTypeID = await iTermTypeMaster.AddOrUpdateTermTypeMaster(model);

            if (_TermTypeID > 0)
            {
                model.TermTypeID = _TermTypeID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update TermTypeMaster 
    }
}
