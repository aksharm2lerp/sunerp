using Business.Entities.HR.ExpensesTxnModel;
using Business.Interface.HR.IExpensesTxn;
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
    [DisplayName("ExpensesTxn")]
    public class ExpensesTxnController : SettingsController
    {
        private readonly ExpensesTxnInterface iExpensesTxn;
        public ExpensesTxnController(ExpensesTxnInterface iExpensesTxn)
        {
            this.iExpensesTxn = iExpensesTxn;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<ExpensesTxn>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.ExpensesTxnText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.ExpensesID).Titled("ExpensesID").SetWidth(20); c.Add(o => o.EmployeeID).Titled("EmployeeID").SetWidth(20); c.Add(o => o.ExpenseTypeID).Titled("ExpenseTypeID").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnExpensesTxn(this)' href='javascript:void(0)' data-id='{o.ExpensesID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_ExpensesTxn' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<ExpensesTxn> pds =(PagedDataTable<ExpensesTxn>) iExpensesTxn.GetAllExpensesTxnAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<ExpensesTxn>(pds, query, false, "ExpensesTxnGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                ExpensesTxn model = new ExpensesTxn();
                model.ExpensesID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iExpensesTxn.GetExpensesTxnAsync(id).Result;

                    return PartialView("AddOrUpdateExpensesTxn", model);
                }
                return PartialView("AddOrUpdateExpensesTxn", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update ExpensesTxn 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateExpensesTxn(ExpensesTxn model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _ExpensesTxnID = await iExpensesTxn.AddOrUpdateExpensesTxn(model);

            if (_ExpensesTxnID > 0)
            {
                model.ExpensesID = _ExpensesTxnID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update ExpensesTxn 
    }
}
