using Business.Entities.HR.EmployeeChildrenModel;
using Business.Interface.IEmployeeChildrenService;
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
    [DisplayName("EmployeeChildren")]
    public class EmployeeChildrenController : SettingsController
    {
        private readonly EmployeeChildrenInterface iEmployeeChildren;
        public EmployeeChildrenController(EmployeeChildrenInterface iEmployeeChildren)
        {
            this.iEmployeeChildren = iEmployeeChildren;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<EmployeeChildren>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.EmployeeChildrenText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.ChildFullName).Titled("ChildFullName").SetWidth(20); c.Add(o => o.DOB).Titled("DOB").SetWidth(20); c.Add(o => o.IsStudying).Titled("IsStudying").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnEmployeeChildren(this)' href='javascript:void(0)' data-id='{o.EmployeeChildrenID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_EmployeeChildren' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<EmployeeChildren> pds =(PagedDataTable<EmployeeChildren>) iEmployeeChildren.GetAllEmployeeChildrenAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<EmployeeChildren>(pds, query, false, "EmployeeChildrenGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                EmployeeChildren model = new EmployeeChildren();
                model.EmployeeChildrenID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iEmployeeChildren.GetEmployeeChildrenAsync(id).Result;

                    return PartialView("AddOrUpdateEmployeeChildren", model);
                }
                return PartialView("AddOrUpdateEmployeeChildren", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update EmployeeChildren 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateEmployeeChildren(EmployeeChildren model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _EmployeeChildrenID = await iEmployeeChildren.AddOrUpdateEmployeeChildren(model);

            if (_EmployeeChildrenID > 0)
            {
                model.EmployeeChildrenID = _EmployeeChildrenID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update EmployeeChildren 
    }
}
