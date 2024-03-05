using Business.Entities;
using Business.Entities.Master;
using Business.Interface;
using Business.Service;
using Business.SQL;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using GridShared.Sorting;
//using IronBarCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace ERP.Areas.SuperAdmin.Controllers
{


    [Area("SuperAdmin"), Authorize]
    [DisplayName("FinishGoodItem")]
    public class FinishGoodItemController : SettingsController
    {
        private readonly ISuperAdminService _superAdmin;
        private readonly IMasterService _masterService;

        public FinishGoodItemController(ISuperAdminService superAdmin, IMasterService masterService)
        {
            this._superAdmin = superAdmin;
            _masterService = masterService;
        }

        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            try
            {
                int userid = USERID;
                IQueryCollection query = Request.Query;
                PagedDataTable<ItemTableCollection> pds = _superAdmin.GetAllItemTableCollection(gridpage.ToInt(), PAGESIZE, search, orderby, sortby == "0" ? "ASC" : "DESC");
                Action<IGridColumnCollection<ItemTableCollection>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                        .Titled("Sr No")
                        .SetWidth(50);
                    c.Add(o => o.TableName)
                      .Titled("Table Name")
                      .SetWidth(110);
                    c.Add(o => o.CreatedOrModfiedBy)
                      .Titled("Created By")
                      .SetWidth(110);
                    c.Add(o => o.CreatedDate)
                      .Titled("Created Date")
                      .SetWidth(110);
                    c.Add().Encoded(false)
                        .Sanitized(false)
                      .Titled("Add Records")
                      .SetWidth(110)
                      .RenderValueAs(o => string.Format("<a href='javascript:void(0);' onclick='fnAddRecordsToTable(this)' data-toggle=\"modal\" data-target=\"#exampleModal\" data-id='{0}'  " + (!o.IsActive ? "class='btn disabled'" : "class='btn'") + "><i class='bx bx-laptop'></i></a>", o.ItemTableCollectionID));
                    c.Add().Encoded(false)
                        .Sanitized(false)
                      .Titled("Edit Records")
                      .SetWidth(110)
                      .RenderValueAs(o => string.Format("<a href='javascript:void(0);' onclick='fnFinishGoodItem(this)' data-id='{0}'  class='btn'><i class='bx bx-edit'></i></a>", o.ItemTableCollectionID));
                    c.Add().Encoded(false)
                        .Sanitized(false)
                      .Titled("Active")
                      .SetWidth(110)
                      .RenderValueAs(o => string.Format("<a  class='btn' onclick='fnDelete(this)' data-id='{0}' data-act='{1}' href='javascrpt:void(0);'>" + (o.IsActive == true ? "<i class='bx bx-shield-alt'></i>" : "<i class='bx bx-shield-x'></i>") + "</a>", o.ItemTableCollectionID, o.IsActive));

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                var server = new GridCoreServer<ItemTableCollection>(pds, query, false, "ordersGrid",
                    columns, PAGESIZE, pds.TotalItemCount)
                    .Sortable()
                    .Searchable(true, false)
                    .ClearFiltersButton(false)
                    .SetStriped(true)
                    .ChangePageSize(true)
                    .WithGridItemsCount()
                    .WithPaging(PAGESIZE, pds.TotalItemCount)
                    .ChangeSkip(false)
                    .EmptyText("No record found")
                    .CommonSettings(settings)
                ;
                return View(server.Grid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, bool active)
        {
            try
            {
                int res = _superAdmin.DeleteFinishGoodItem(id, active).Result;
                if (res > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Updated });
                }
                return Json(new { status = false, message = MessageHelper.Error });
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
                ItemTableCollection model = new ItemTableCollection();
                if (id > 0)
                {
                    model = _superAdmin.GetItemTableCollection(id);
                }
                return PartialView("_add", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public ActionResult Create()
        {
            try
            {
                ItemTableCollection model = new ItemTableCollection();
                List<ColumnType> colTypes = Enum.GetValues(typeof(ColumnType)).Cast<ColumnType>().ToList();
                if (colTypes != null)
                {
                    ViewData["ColType"] = new SelectList(colTypes);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(ItemTableCollection model)
        {
            try
            {
                if (model != null && model.Column1Name.IsNotStringNullOrEmpty())
                {
                    model.CreatedOrModfiedByUserID = USERID;
                    int result = await _superAdmin.InsertOrUpdateFinishGoodItemAsync(model);
                    if (result > 0)
                    {
                        if (model.ItemTableCollectionID == 0)
                            return Json(new { status = true, message = MessageHelper.Added });
                        else
                            return Json(new { status = true, message = MessageHelper.Updated });
                    }
                }
                return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Json(new { status = false, message = MessageHelper.Error });
            }
        }
        public PartialViewResult _list()
        {
            try
            {
                return PartialView("_list");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddControls(FinishGoodItemDynamic finishGoodItemDynamic)
        {
            try
            {
                if (finishGoodItemDynamic != null && finishGoodItemDynamic.aList != null &&
                    finishGoodItemDynamic.aList[0].value.IsNotStringNullOrEmpty())
                {
                    int res = _superAdmin.DeleteFinishGoodItem1(finishGoodItemDynamic, USERID).Result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
            return Json(true);
        }

        [HttpPost]
        public ActionResult GetData(int id)
        {
            //var data = new { Message = "Hello, world!" };
            var pModel = new System.Web.Mvc.ViewDataDictionary(ViewData);
            var list = _superAdmin.GetAllItemTableCollection().Where(x => x.ItemTableCollectionID == id);
            var data = (ItemTableCollection)list.FirstOrDefault();

            pModel.Add("TableName", data.TableName);
            pModel.Add("Column1", data.Column1Name);
            pModel.Add("Column1Type", data.Column1Type);
            pModel.Add("Column2", data.Column2Name);
            pModel.Add("Column2Type", data.Column2Type);
            pModel.Add("Column3", data.Column3Name);
            pModel.Add("Column3Type", data.Column3Type);
            pModel.Add("ItemTableCollectionID", data.ItemTableCollectionID);
            return Json(pModel);
        }

        public PartialViewResult MyPartialView(int id)
        {
            DataTable dt = _superAdmin.DynamicTableData(id);

            return PartialView(dt);
        }
    }
    public enum ColumnType
    {
        Text,
        TextArea
    };
}