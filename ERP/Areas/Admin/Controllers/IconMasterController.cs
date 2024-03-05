using Business.Entities.Admin.IconMasterModel;
using Business.Entities.Employee;
using Business.Interface.IIconMasterService;
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
    [DisplayName("IconMaster")]
    public class IconMasterController : SettingsController
    {
        private readonly IconMasterInterface iIconMaster;
        public IconMasterController(IconMasterInterface iIconMaster)
        {
            this.iIconMaster = iIconMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<IconMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(1);

                ////c.Add(o => o.IconMasterText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.IconName).Titled("IconName").SetWidth(2);
                
               // c.Add(o => o.IconHTMLTag).Titled("IconHTMLTag").SetWidth(20);

                c.Add()
                                    .Titled("Icon")
                                    .Encoded(false)
                                    .Sanitized(false)
                                    .SetWidth(2)
                                    .Css("hidden-xs") //hide on phones
                                    .RenderValueAs(o => $"<a class='h3'>{o.IconHTMLTag}</a>");

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='fa-2x' onclick='fnIconMaster(this)' href='javascript:void(0)' data-id='{o.IconMasterID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_IconMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<IconMaster> pds =(PagedDataTable<IconMaster>) iIconMaster.GetAllIconMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<IconMaster>(pds, query, false, "IconMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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

        public Microsoft.AspNetCore.Mvc.ActionResult Search(string keyword)
        {
            try
            {
                
                IconSearch model = new IconSearch();
                model.keyword = keyword;

                PagedDataTable<IconMaster> pds = iIconMaster.GetAllIconMasterAsync(1, PAGESIZE, keyword, "", "ASC").Result;
                
                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<IconMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                    c.Add(o => o.IconName).Titled("IconName").SetWidth(2);
                    c.Add()
                                        .Titled("Icon")
                                        .Encoded(false)
                                        .Sanitized(false)
                                        .SetWidth(2)
                                        .Css("hidden-xs") //hide on phones
                                        .RenderValueAs(o => $"<a class='h3'>{o.IconHTMLTag}</a>");

                    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
            .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.IconMasterID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.IconMasterID}' data-approval='HOD' data-id='{o.IconMasterID}' data-key='{o.IconMasterID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    //Below code hide on phones
                    c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    //.RenderValueAs(o => $"<a class='fa-2x' href='/Admin/Employee/AddUpdateEmployee/{o.IconMasterID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");
                    .RenderValueAs(o => $"<a class='fa-2x' onclick='fnIconMaster(this)' href='javascript:void(0)' data-id='{o.IconMasterID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_IconMaster' aria-controls='canvas_masterentity' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<IconMaster>(pds, query, false, "ordersGrid",
                    columns, PAGESIZE, pds.TotalItemCount)
                    .Sortable(true)
                    .Searchable(false, false)
                    .ClearFiltersButton(false)
                    .SetStriped(true)
                    .ChangePageSize(true)
                    .WithGridItemsCount()
                    .WithPaging(PAGESIZE, pds.TotalItemCount)
                    .ChangeSkip(false)
                    .EmptyText("No record found")
                    .CommonSettings(settings);
                return View("Index", server.Grid);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Index Page

        #region Slider Page

        [HttpPost]
        public PartialViewResult Get(int id, int key)
        {
            try
            {
                IconMaster model = new IconMaster();
                model.IconMasterID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iIconMaster.GetIconMasterAsync(id).Result;

                    return PartialView("AddOrUpdateIconMaster", model);
                }
                return PartialView("AddOrUpdateIconMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update IconMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateIconMaster(IconMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _IconMasterID = await iIconMaster.AddOrUpdateIconMaster(model);

            if (_IconMasterID > 0)
            {
                model.IconMasterID = _IconMasterID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update IconMaster 
    }
}
