using Business.Entities.Machinery.MachineryMaster;
using Business.Entities.PartyMasterModel;
using Business.Entities.Production.MachineryModel;
using Business.Interface.Production.IMachinery;
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

namespace ERP.Areas.Production.Controllers
{
    [Area("Production"), Authorize]
    [DisplayName("Machinery")]
    public class MachineryController : SettingsController
    {
        private readonly MachineryInterface iMachinery;
        public MachineryController(MachineryInterface iMachinery)
        {
            this.iMachinery = iMachinery;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<Machinery>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(5);

                ////c.Add(o => o.MachineryText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.DepartmentName).Titled("Department").SetWidth(10);
                c.Add(o => o.ItemCode).Titled("Item Code").SetWidth(10);
                c.Add(o => o.MachineryName).Titled("Machinery Name").SetWidth(20);
                c.Add(o => o.MachineOperatingStatusText).Titled("Operating Status").SetWidth(10);
                c.Add(o => o.Description).Titled("Description").SetWidth(40);

                c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
.RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.MachineryID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.MachineryID}' data-approval='HOD' data-id='{o.MachineryID}' data-key='{o.MachineryID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(5)
                    //.Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='fa-2x' onclick='fnMachinery(this)' href='javascript:void(0)' data-id='{o.MachineryID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_Machinery' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<Machinery> pds = (PagedDataTable<Machinery>)iMachinery.GetAllMachineryAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<Machinery>(pds, query, false, "MachineryGrid", columns, PAGESIZE, pds.TotalItemCount)
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

        public Microsoft.AspNetCore.Mvc.ActionResult Search(string keyword)
        {
            try
            {

                MachinerySearch model = new MachinerySearch();
                model.keyword = keyword;

                PagedDataTable<Machinery> pds = iMachinery.GetAllMachineryAsync(1, PAGESIZE, keyword, "", "ASC").Result;

                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<Machinery>> columns = c =>
                {


                    c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                    c.Add(o => o.DepartmentName).Titled("Department").SetWidth(10);
                    c.Add(o => o.ItemCode).Titled("Item Code").SetWidth(10);
                    c.Add(o => o.MachineryName).Titled("Machinery Name").SetWidth(20);
                    c.Add(o => o.MachineOperatingStatusText).Titled("Operating Status").SetWidth(10);
                    c.Add(o => o.Description).Titled("Description").SetWidth(40);


                    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.MachineryID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.MachineryID}' data-approval='HOD' data-id='{o.MachineryID}' data-key='{o.MachineryID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    //Below code hide on phones
                    c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    //.RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/Party/AddUpdateParty/{o.MachineryID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");
                    .RenderValueAs(o => $"<a class='fa-2x' onclick='fnMachinery(this)' href='javascript:void(0)' data-id='{o.MachineryID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_Machinery' aria-controls='canvas_masterentity' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");


                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<Machinery>(pds, query, false, "MachineryGrid",
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



        #region Slider Page

        [HttpPost]
        public PartialViewResult Get(int id)
        {
            try
            {
                Machinery model = new Machinery();
                model.MachineryID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachinery.GetMachineryAsync(id).Result;
                    return PartialView("AddOrUpdateMachinery", model);
                }
                return PartialView("AddOrUpdateMachinery", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update Machinery 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachinery(Machinery model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _Machinery = await iMachinery.AddOrUpdateMachinery(model);

            if (_Machinery > 0)
            {
                model.MachineryID = _Machinery;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });

        }

        #endregion Add or Update Machinery 

        #region Get item code using MachineryID(From Machinery Dropdown, select ItemCode).

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public Microsoft.AspNetCore.Mvc.ActionResult GetItemCode(int id)
        {
            try
            {
                string itemCode = iMachinery.GetMachineryAsync(id).Result.ItemCode;
                return Json(new { status = true, ItemCode = itemCode });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Get item code using MachineryID(From Machinery Dropdown, select ItemCode).
    }
}
