using Business.Entities.HR.EmployeeFacilityModel;
using Business.Interface.HR.IEmployeeFacility;
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
    [DisplayName("EmployeeFacility")]
    public class EmployeeFacilityController : SettingsController
    {
        private readonly EmployeeFacilityInterface iEmployeeFacility;
        public EmployeeFacilityController(EmployeeFacilityInterface iEmployeeFacility)
        {
            this.iEmployeeFacility = iEmployeeFacility;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<EmployeeFacility>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.EmployeeFacilityText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.EmployeeID).Titled("EmployeeID").SetWidth(20); c.Add(o => o.FacilityTypeMasterID).Titled("FacilityTypeMasterID").SetWidth(20); c.Add(o => o.IssueDate).Titled("IssueDate").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnEmployeeFacility(this)' href='javascript:void(0)' data-id='{o.EmployeeFacilityID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_EmployeeFacility' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<EmployeeFacility> pds =(PagedDataTable<EmployeeFacility>) iEmployeeFacility.GetAllEmployeeFacilityAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<EmployeeFacility>(pds, query, false, "EmployeeFacilityGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                EmployeeFacility model = new EmployeeFacility();
                model.EmployeeFacilityID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iEmployeeFacility.GetEmployeeFacilityAsync(id).Result;

                    return PartialView("AddOrUpdateEmployeeFacility", model);
                }
                return PartialView("AddOrUpdateEmployeeFacility", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update EmployeeFacility 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateEmployeeFacility(EmployeeFacility model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _EmployeeFacilityID = await iEmployeeFacility.AddOrUpdateEmployeeFacility(model);

            if (_EmployeeFacilityID > 0)
            {
                model.EmployeeFacilityID = _EmployeeFacilityID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update EmployeeFacility 
    }
}
