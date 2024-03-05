using Business.Entities;
using Business.Entities.Master;
using Business.Interface;
using Business.Service;
using Business.SQL;
using DocumentFormat.OpenXml.Office2010.Excel;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using GridShared.Sorting;
//using IronBarCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace ERP.Areas.SuperAdmin.Controllers
{


    [Area("SuperAdmin"), Authorize]
    [DisplayName("Item")]
    public class ItemController : SettingsController
    {
        private readonly ISuperAdminService _superAdmin;
        private readonly IMasterService _masterService;

        public ItemController(ISuperAdminService superAdmin, IMasterService masterService)
        {
            this._superAdmin = superAdmin;
            _masterService = masterService;

        }

        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-search")] string search = "", ItemSearch model = null)
        {
            try
            {
                int userid = USERID;
                var itemtype = _masterService.GetAllItemTypes();
                if (itemtype != null)
                {
                    ViewData["ItemSubGroup"] = new SelectList(itemtype.Result, "ItemSubGroupID", "ItemSubGroupText");
                }
                var itemGroup = _masterService.GetAllItemGroupTypes();
                if (itemGroup != null)
                {
                    ViewData["SubGroup"] = new SelectList(itemGroup.Result, "ItemGroupID", "ItemGroupName");
                }
                var itemLocation = _masterService.GetAllLocations();
                if (itemLocation != null && !itemLocation.IsFaulted)
                {
                    ViewData["PrimaryLocation"] = new SelectList(itemLocation.Result, "LocationID", "LocationName"); ;
                }
                IQueryCollection query = Request.Query;
                if (model != null && !search.IsNotStringNullOrEmpty() && model.keyword.IsNotStringNullOrEmpty())
                {
                    search = model.keyword;
                }
                PagedDataTable<ItemMaster> pds = _superAdmin.GetItemMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby, sortby == "0" ? "ASC" : "DESC");
                if (model != null && model.DefaultLocationID > 0)
                {
                    pds = pds.Where(x => x.DefaultLocationID == model.DefaultLocationID).ToPagedDataTableList();
                }
                Action<IGridColumnCollection<ItemMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                        .Titled("Sr no")
                        .SetWidth(110);
                    c.Add(o => o.ItemName)
                      .Titled("Item Name")
                      .SetWidth(110);
                    c.Add(o => o.ItemCode)
                      .Titled("Code")
                      .SetWidth(110);
                    c.Add(o => o.Description)
                      .Titled("Description")
                      .SetWidth(150);
                    c.Add(o => o.CLBL_QTY)
                      .Titled("CLBL_QTY")
                      .SetWidth(50);
                    c.Add(o => o.DefaultLocation)
                      .Titled("Location")
                      .SetWidth(100);
                    c.Add()
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(60)
                        .RenderValueAs(o =>
                            string.Format("<a href='javascript:void(0)' onclick = 'fnItem(this)' data-id='{0}'  class='btn'>Edit</a>", o.ItemID) +
                             string.Format("<a class='btn' class='btn' onclick='fnDeleteControls(this)' data-id='{0}' href='javascript:void(0)'>Delete</a>", o.ItemID));

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                var server = new GridCoreServer<ItemMaster>(pds, query, false, "ordersGrid",
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
                return View(server.Grid);
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Search(string keyword, int DefaultLocationID)
        {
            try
            {
                var itemtype = _masterService.GetAllItemTypes();
                if (itemtype != null)
                {
                    ViewData["ItemSubGroup"] = new SelectList(itemtype.Result, "ItemSubGroupID", "ItemSubGroupText");
                }
                var itemGroup = _masterService.GetAllItemGroupTypes();
                if (itemGroup != null)
                {
                    ViewData["SubGroup"] = new SelectList(itemGroup.Result, "ItemGroupID", "ItemGroupName");
                }
                var itemLocation = _masterService.GetAllLocations();
                if (itemLocation != null && !itemLocation.IsFaulted)
                {
                    ViewData["PrimaryLocation"] = new SelectList(itemLocation.Result, "LocationID", "LocationName"); ;
                }
                ItemSearch model = new ItemSearch();
                model.keyword = keyword;
                PagedDataTable<ItemMaster> pds = _superAdmin.GetItemMasterAsync(1, PAGESIZE, keyword, "", "ASC");
                if (model != null && model.DefaultLocationID > 0)
                {
                    pds = pds.Where(x => x.DefaultLocationID == model.DefaultLocationID).ToPagedDataTableList();
                }
                Action<IGridColumnCollection<ItemMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                        .Titled("Sr no")
                        .SetWidth(110);
                    c.Add(o => o.ItemName)
                      .Titled("Item Name")
                      .SetWidth(110);
                    c.Add(o => o.ItemCode)
                      .Titled("Code")
                      .SetWidth(110);
                    c.Add(o => o.Description)
                      .Titled("Description")
                      .SetWidth(150);
                    c.Add(o => o.CLBL_QTY)
                      .Titled("CLBL_QTY")
                      .SetWidth(50);
                    c.Add(o => o.DefaultLocation)
                      .Titled("Location")
                      .SetWidth(100);
                    c.Add()
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(60)
                        .RenderValueAs(o =>
                            string.Format("<a href='javascript:void(0)' onclick = 'fnItem(this)' data-id='{0}'  class='btn'>Edit</a>", o.ItemID) +
                             string.Format("<a class='btn' class='btn' onclick='fnDeleteControls(this)' data-id='{0}' href='javascript:void(0)'>Delete</a>", o.ItemID));

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<ItemMaster>(pds, query, false, "ordersGrid",
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

        public async Task<PartialViewResult> _Search()
        {
            try
            {
                var itemtype = _masterService.GetAllItemTypes();
                if (itemtype != null)
                {
                    ViewData["ItemSubGroup"] = new SelectList(itemtype.Result, "ItemSubGroupID", "ItemSubGroupText");
                }
                var itemGroup = _masterService.GetAllItemGroupTypes();
                if (itemGroup != null)
                {
                    ViewData["SubGroup"] = new SelectList(itemGroup.Result, "ItemGroupID", "ItemGroupName");
                }
                var itemLocation = _masterService.GetAllLocations();
                if (itemLocation != null && !itemLocation.IsFaulted)
                {
                    ViewData["PrimaryLocation"] = new SelectList(itemLocation.Result, "LocationID", "LocationName"); ;
                }
                return PartialView("_Search", new ItemSearch());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<PartialViewResult> Get(int id)
        {

            try
            {
                ItemMaster model = await _superAdmin.GetItemMasterAsync(id);
                if (model == null)
                {
                    model = new ItemMaster();
                    var itemtype = _masterService.GetAllItemTypes();
                    if (itemtype != null)
                    {
                        ViewData["ItemSubGroup"] = new SelectList(itemtype.Result, "ItemSubGroupID", "ItemSubGroupText");
                    }
                    var itemGroup = _masterService.GetAllItemGroupTypes();
                    if (itemGroup != null)
                    {
                        ViewData["SubGroup"] = new SelectList(itemGroup.Result, "ItemGroupID", "ItemGroupName");
                    }
                    var itemUOMID = _masterService.GetAllUOMID();
                    if (itemUOMID != null)
                    {
                        ViewData["UOMID"] = new SelectList(itemUOMID, "UOMID", "UOMText");
                    }
                    var itemLocation = _masterService.GetAllLocations();
                    if (itemLocation != null && !itemLocation.IsFaulted)
                    {
                        ViewData["PrimaryLocation"] = new SelectList(itemLocation.Result, "LocationID", "LocationName"); ;
                    }
                    var itemWarehouse = _masterService.GetAllWarehouse();
                    if (itemWarehouse != null && !itemWarehouse.IsFaulted)
                    {
                        ViewData["WareHouse"] = new SelectList(itemWarehouse.Result, "WareHouseID", "WareHouseName"); ;
                    }
                }
                return PartialView("_add", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Save(ItemMaster model)
        {
            try
            {
                int result = await _superAdmin.InsertOrUpdateItemMasterAsync(model);
                if (result > 0)
                {
                    if (model.ItemID == 0)
                        return Json(new { status = true, message = MessageHelper.Added });
                    else
                        return Json(new { status = true, message = MessageHelper.Updated });
                }
                return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Json(new { status = false, message = MessageHelper.Error });
            }
        }

        public ActionResult Create()
        {
            ItemMaster model = new ItemMaster();
            try
            {
                model = _superAdmin.GetItemMasterAsync(0).Result;
                if (model == null)
                {
                    model = new ItemMaster();
                    var itemtype = _masterService.GetAllItemTypes();
                    if (itemtype != null)
                    {
                        ViewData["ItemSubGroup"] = new SelectList(itemtype.Result, "ItemSubGroupID", "ItemSubGroupText");
                    }
                    var itemGroup = _masterService.GetAllItemGroupTypes();
                    if (itemGroup != null)
                    {
                        ViewData["SubGroup"] = new SelectList(itemGroup.Result, "ItemGroupID", "ItemGroupName");
                    }
                    var itemUOMID = _masterService.GetAllUOMID();
                    if (itemUOMID != null)
                    {
                        ViewData["UOMID"] = new SelectList(itemUOMID, "UOMID", "UOMText");
                    }
                    var itemLocation = _masterService.GetAllLocations();
                    if (itemLocation != null && !itemLocation.IsFaulted)
                    {
                        ViewData["PrimaryLocation"] = new SelectList(itemLocation.Result, "LocationID", "LocationName"); ;
                    }
                    var itemWarehouse = _masterService.GetAllWarehouse();
                    if (itemWarehouse != null && !itemWarehouse.IsFaulted)
                    {
                        ViewData["WareHouse"] = new SelectList(itemWarehouse.Result, "WareHouseID", "WareHouseName"); ;
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}