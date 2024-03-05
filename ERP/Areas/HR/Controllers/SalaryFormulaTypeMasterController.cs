using Business.Entities.HR.SalaryFormulaTypeMasterModel;
using Business.Interface.HR.ISalaryFormulaTypeMaster;
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

namespace ERP.Areas.HR.Controllers
{
    [Area("HR"), Authorize]
    [DisplayName("SalaryFormulaTypeMaster")]
    public class SalaryFormulaTypeMasterController : SettingsController
    {
        private readonly SalaryFormulaTypeMasterInterface iSalaryFormulaTypeMaster;
        public SalaryFormulaTypeMasterController(SalaryFormulaTypeMasterInterface iSalaryFormulaTypeMaster)
        {
            this.iSalaryFormulaTypeMaster = iSalaryFormulaTypeMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<SalaryFormulaTypeMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.SalaryFormulaTypeMasterText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.SalaryFormulaTypeID).Titled("SalaryFormulaTypeID").SetWidth(20); c.Add(o => o.SalaryFormulaTypeText).Titled("SalaryFormulaTypeText").SetWidth(20); c.Add(o => o.Description).Titled("Description").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnSalaryFormulaTypeMaster(this)' href='javascript:void(0)' data-id='{o.SalaryFormulaTypeID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_SalaryFormulaTypeMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<SalaryFormulaTypeMaster> pds =(PagedDataTable<SalaryFormulaTypeMaster>) iSalaryFormulaTypeMaster.GetAllSalaryFormulaTypeMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<SalaryFormulaTypeMaster>(pds, query, false, "SalaryFormulaTypeMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                SalaryFormulaTypeMaster model = new SalaryFormulaTypeMaster();
                model.SalaryFormulaTypeID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iSalaryFormulaTypeMaster.GetSalaryFormulaTypeMasterAsync(id).Result;

                    return PartialView("AddOrUpdateSalaryFormulaTypeMaster", model);
                }
                return PartialView("AddOrUpdateSalaryFormulaTypeMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update SalaryFormulaTypeMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateSalaryFormulaTypeMaster(SalaryFormulaTypeMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _SalaryFormulaTypeID = await iSalaryFormulaTypeMaster.AddOrUpdateSalaryFormulaTypeMaster(model);

            if (_SalaryFormulaTypeID > 0)
            {
                model.SalaryFormulaTypeID = _SalaryFormulaTypeID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update SalaryFormulaTypeMaster 
    }
}
