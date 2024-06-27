using Business.Entities.SalesDistribution.TermsMasterModel;
using Business.Interface.SalesDistribution.ITermsMaster;
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
    [DisplayName("TermsMaster")]
    public class TermsMasterController : SettingsController
    {
        private readonly TermsMasterInterface iTermsMaster;
        public TermsMasterController(TermsMasterInterface iTermsMaster)
        {
            this.iTermsMaster = iTermsMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<TermsMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.TermsMasterText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.CustomerName).Titled("Customer").SetWidth(20);
                c.Add(o => o.TermTypeText).Titled("Term").SetWidth(20); 
                c.Add(o => o.TermText).Titled("Term Desc").SetWidth(20); 
                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnTermsMaster(this)' href='javascript:void(0)' data-id='{o.TermsID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_TermsMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<TermsMaster> pds =(PagedDataTable<TermsMaster>) iTermsMaster.GetAllTermsMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<TermsMaster>(pds, query, false, "TermsMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                TermsMaster model = new TermsMaster();
                model.TermsID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iTermsMaster.GetTermsMasterAsync(id).Result;

                    return PartialView("AddOrUpdateTermsMaster", model);
                }
                return PartialView("AddOrUpdateTermsMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update TermsMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateTermsMaster(TermsMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _TermsID = await iTermsMaster.AddOrUpdateTermsMaster(model);

            if (_TermsID > 0)
            {
                model.TermsID = _TermsID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update TermsMaster 
    }
}
