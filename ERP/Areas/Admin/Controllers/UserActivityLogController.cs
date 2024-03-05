using Business.Entities.Admin.UserActivityLogModel;
using Business.Interface.IUserActivityLogService;
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
    [DisplayName("UserActivityLog")]
    public class UserActivityLogController : SettingsController
    {
        private readonly UserActivityLogInterface iUserActivityLog;
        public UserActivityLogController(UserActivityLogInterface iUserActivityLog)
        {
            this.iUserActivityLog = iUserActivityLog;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<UserActivityLog>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.UserActivityLogText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.ActivityLogText).Titled("ActivityLogText").SetWidth(20); c.Add(o => o.PackageID).Titled("PackageID").SetWidth(20); c.Add(o => o.StartUserName).Titled("StartUserName").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnUserActivityLog(this)' href='javascript:void(0)' data-id='{o.UserActivityLogID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_UserActivityLog' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<UserActivityLog> pds =(PagedDataTable<UserActivityLog>) iUserActivityLog.GetAllUserActivityLogAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<UserActivityLog>(pds, query, false, "UserActivityLogGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                UserActivityLog model = new UserActivityLog();
                model.UserActivityLogID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iUserActivityLog.GetUserActivityLogAsync(id).Result;

                    return PartialView("AddOrUpdateUserActivityLog", model);
                }
                return PartialView("AddOrUpdateUserActivityLog", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update UserActivityLog 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateUserActivityLog(UserActivityLog model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _UserActivityLogID = await iUserActivityLog.AddOrUpdateUserActivityLog(model);

            if (_UserActivityLogID > 0)
            {
                model.UserActivityLogID = _UserActivityLogID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update UserActivityLog 
    }
}
