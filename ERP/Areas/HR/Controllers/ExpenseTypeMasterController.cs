using Business.Entities.HR.ExpenseTypeMasterModel;
using Business.Interface.HR.IExpenseTypeMaster;
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
    [DisplayName("ExpenseTypeMaster")]
    public class ExpenseTypeMasterController : SettingsController
    {
        private readonly ExpenseTypeMasterInterface iExpenseTypeMaster;
        public ExpenseTypeMasterController(ExpenseTypeMasterInterface iExpenseTypeMaster)
        {
            this.iExpenseTypeMaster = iExpenseTypeMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<ExpenseTypeMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.ExpenseTypeMasterText).Titled("Feedback Notes").SetWidth(70);
                // c.Add(o => o.ExpenseTypeID).Titled("ExpenseTypeID").SetWidth(20);
                c.Add(o => o.ExpenseTypeText).Titled("Expense Type").SetWidth(20); c.Add(o => o.Description).Titled("Description").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnExpenseTypeMaster(this)' href='javascript:void(0)' data-id='{o.ExpenseTypeID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_ExpenseTypeMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<ExpenseTypeMaster> pds =(PagedDataTable<ExpenseTypeMaster>) iExpenseTypeMaster.GetAllExpenseTypeMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<ExpenseTypeMaster>(pds, query, false, "ExpenseTypeMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                ExpenseTypeMaster model = new ExpenseTypeMaster();
                model.ExpenseTypeID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iExpenseTypeMaster.GetExpenseTypeMasterAsync(id).Result;

                    return PartialView("AddOrUpdateExpenseTypeMaster", model);
                }
                return PartialView("AddOrUpdateExpenseTypeMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update ExpenseTypeMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateExpenseTypeMaster(ExpenseTypeMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _ExpenseTypeMasterID = await iExpenseTypeMaster.AddOrUpdateExpenseTypeMaster(model);

            if (_ExpenseTypeMasterID > 0)
            {
                model.ExpenseTypeID = _ExpenseTypeMasterID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update ExpenseTypeMaster 
    }
}
