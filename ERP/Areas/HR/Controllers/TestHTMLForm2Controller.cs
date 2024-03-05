using Business.Entities.HR.TestHTMLForm2Model;
using Business.Interface.HR.ITestHTMLForm2;
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
    [DisplayName("TestHTMLForm2")]
    public class TestHTMLForm2Controller : SettingsController
    {
        private readonly TestHTMLForm2Interface iTestHTMLForm2;
        public TestHTMLForm2Controller(TestHTMLForm2Interface iTestHTMLForm2)
        {
            this.iTestHTMLForm2 = iTestHTMLForm2;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<TestHTMLForm2>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.TestHTMLForm2Text).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.TestHTMLForm2Name).Titled("TestHTMLForm2Name").SetWidth(20); c.Add(o => o.AddressID).Titled("AddressID").SetWidth(20); c.Add(o => o.RoleID).Titled("RoleID").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnTestHTMLForm2(this)' href='javascript:void(0)' data-id='{o.TestHTMLForm2ID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_TestHTMLForm2' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<TestHTMLForm2> pds =(PagedDataTable<TestHTMLForm2>) iTestHTMLForm2.GetAllTestHTMLForm2Async(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<TestHTMLForm2>(pds, query, false, "TestHTMLForm2Grid", columns, PAGESIZE, pds.TotalItemCount)
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
                TestHTMLForm2 model = new TestHTMLForm2();
                model.TestHTMLForm2ID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iTestHTMLForm2.GetTestHTMLForm2Async(id).Result;

                    return PartialView("AddOrUpdateTestHTMLForm2", model);
                }
                return PartialView("AddOrUpdateTestHTMLForm2", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update TestHTMLForm2 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateTestHTMLForm2(TestHTMLForm2 model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _TestHTMLForm2ID = await iTestHTMLForm2.AddOrUpdateTestHTMLForm2(model);

            if (_TestHTMLForm2ID > 0)
            {
                model.TestHTMLForm2ID = _TestHTMLForm2ID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update TestHTMLForm2 
    }
}
