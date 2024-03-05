using Business.Entities.HR.UserMapToEmployeeModel;
using Business.Interface.IUserMapToEmployeeService;
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
    [DisplayName("UserMapToEmployee")]
    public class UserMapToEmployeeController : SettingsController
    {
        private readonly UserMapToEmployeeInterface iUserMapToEmployee;
        public UserMapToEmployeeController(UserMapToEmployeeInterface iUserMapToEmployee)
        {
            this.iUserMapToEmployee = iUserMapToEmployee;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<UserMapToEmployee>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.UserMapToEmployeeText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.UserName).Titled("UserName").SetWidth(20); 
                c.Add(o => o.EmployeeName).Titled("Employee Name").SetWidth(20); c.Add(o => o.Remarks).Titled("Remarks").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnUserMapToEmployee(this)' href='javascript:void(0)' data-id='{o.UserMapToEmployeeID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_UserMapToEmployee' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<UserMapToEmployee> pds = iUserMapToEmployee.GetAllUserMapToEmployeeAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<UserMapToEmployee>(pds, query, false, "UserMapToEmployeeGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                ViewBag.UserID = USERID;
                ViewBag.CompanyID = COMPANYID;
                UserMapToEmployee model = new UserMapToEmployee();
                model.UserMapToEmployeeID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iUserMapToEmployee.GetUserMapToEmployeeAsync(id).Result;

                    return PartialView("AddOrUpdateUserMapToEmployee", model);
                }
                return PartialView("AddOrUpdateUserMapToEmployee", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update UserMapToEmployee 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateUserMapToEmployee(UserMapToEmployee model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _UserMapToEmployeeID = await iUserMapToEmployee.AddOrUpdateUserMapToEmployee(model);

            if (_UserMapToEmployeeID > 0)
            {
                model.UserMapToEmployeeID = _UserMapToEmployeeID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update UserMapToEmployee 
    }
}
