using Business.Entities.Marketing.OfferAcceptedMasterModel;
using Business.Interface;
using Business.Interface.Marketing.IOfferAcceptedMaster;
using Business.Entities.UOMID;
using Business.SQL;
using DocumentFormat.OpenXml.Drawing.Charts;
using ERP.Controllers;
using ERP.Extensions;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;
using Business.Service;
using System.Linq;
using Dapper;
using Business.Entities.Marketing.SAPItem;
using Business.Interface.Marketing.ISAPItemCollection;
using Business.Entities.DevelopmentArea.DynamicFormM;
using Newtonsoft.Json;
using System.Data;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Microsoft.AspNetCore.Authorization.Authorize]
    [DisplayName("OfferAcceptedMaster")]
    public class OfferAcceptedMasterController : SettingsController
    {
        private readonly OfferAcceptedMasterInterface iOfferAcceptedMaster;
        private readonly ICommonMasterService commonMasterService;
        private readonly SAPItemCollectionInterface _sAPItemCollectionInterface;
        public UOMIDMetadata _UOM = new UOMIDMetadata();

        public OfferAcceptedMasterController(OfferAcceptedMasterInterface iOfferAcceptedMaster, ICommonMasterService iCommonMst, SAPItemCollectionInterface sAPItemCollectionInterface)
        {
            this.iOfferAcceptedMaster = iOfferAcceptedMaster;
            this.commonMasterService = iCommonMst;
            _sAPItemCollectionInterface = sAPItemCollectionInterface;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<OfferAcceptedMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(10);


                c.Add(o => o.OfferAcceptedID).Titled("Offer Accepted ID").SetWidth(20);
                c.Add(o => o.OfferAcceptedDate).Titled("Offer Accepted Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                c.Add(o => o.CustomerCode).Titled("Customer Code").SetWidth(20);
                c.Add(o => o.CustomerName).Titled("Customer Name").SetWidth(20);
                c.Add(o => o.GrossAmount).Titled("Gross Amt").SetWidth(20);

                c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
            .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.OfferAcceptedID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.OfferAcceptedID}'   data-id='{o.OfferAcceptedID}' data-key='{o.OfferAcceptedID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(20)
                    .Css("hidden-xs")
                     .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/OfferAcceptedMaster/Get/{o.OfferAcceptedID}' ><i class='bx bx-edit'></i></a>");

                
            };
            PagedDataTable<OfferAcceptedMaster> pds = (PagedDataTable<OfferAcceptedMaster>)iOfferAcceptedMaster.GetAllOfferAcceptedMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<OfferAcceptedMaster>(pds, query, false, "OfferAcceptedMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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

                OfferAcceptedSearch model = new OfferAcceptedSearch();
                model.keyword = keyword;

                PagedDataTable<OfferAcceptedMaster> pds = iOfferAcceptedMaster.GetAllOfferAcceptedMasterAsync(1, PAGESIZE, keyword, "", "ASC").Result;

                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<OfferAcceptedMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(10);


                    c.Add(o => o.OfferAcceptedID).Titled("Offer Accepted ID").SetWidth(20);
                    c.Add(o => o.OfferAcceptedDate).Titled("Offer Accepted Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                    c.Add(o => o.CustomerCode).Titled("Customer Code").SetWidth(20);
                    c.Add(o => o.CustomerName).Titled("Customer Name").SetWidth(20);
                    c.Add(o => o.GrossAmount).Titled("Gross Amt").SetWidth(20);

                    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.OfferAcceptedID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.OfferAcceptedID}'   data-id='{o.OfferAcceptedID}' data-key='{o.OfferAcceptedID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    c.Add()
                        .Titled("Edit")
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(20)
                        .Css("hidden-xs")
                         .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/OfferAcceptedMaster/Get/{o.OfferAcceptedID}' ><i class='bx bx-edit'></i></a>");

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<OfferAcceptedMaster>(pds, query, false, "OfferAcceptedMasterGrid",
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

        #region Offer Accepted Item detail 
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public PartialViewResult OfferAcceptedItemDetail(int OfferAcceptedID = 0)
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<OfferAcceptedDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No");


                //c.Add(o => o.OfferAcceptedDetailID).Titled("OfferAcceptedDetailID").Hidden=true;
                c.Add(o => o.OfferAcceptedID).Titled("Offer Accepted ID").SetWidth(20);
                //c.Add(o => o.ItemID).Titled("ItemID").Hidden=true;
                c.Add(o => o.ItemName).Titled("Item Name");
                c.Add(o => o.HSNcodes).Titled("HSN Code");
                //c.Add(o => o.UOMID).Titled("UOMID").Hidden=true;
                c.Add(o => o.UOMText).Titled("UOM");
                c.Add(o => o.Qty).Titled("Qty");
                c.Add(o => o.Rate).Titled("Rate");
                c.Add(o => o.TotalAmount).Titled("Total Amt");
                //c.Add(o => o.Remark).Titled("Remark").SetWidth(30);

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(20)
                    .Css("hidden-xs")
                     .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/OfferAcceptedMaster/Get/{o.OfferAcceptedDetailID}' ><i class='bx bx-edit'></i></a>");

                //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnOfferAcceptedMaster(this)' href='javascript:void(0)' data-id='{o.OfferAcceptedID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_OfferAcceptedMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<OfferAcceptedDetail> pds = (PagedDataTable<OfferAcceptedDetail>)iOfferAcceptedMaster.GetOfferAcceptedDetailAsync(OfferAcceptedID).Result;

            var server = new GridCoreServer<OfferAcceptedDetail>(pds, query, false, "OfferAcceptedDetailGrid", columns, 1, pds.TotalItemCount)
                .Sortable()
                .Searchable(false, false)
                .Selectable(true)
                .WithGridItemsCount()
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false)
                .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");


            //return  View(server.Grid);
            return PartialView("OfferAcceptedItemDetail", server.Grid);
        }
        #endregion Offer Accepted Item Detail



        #region Slider Page

        [HttpPost]
        public IActionResult Get(int id)
        {
            try
            {
                OfferAcceptedMaster model = new OfferAcceptedMaster();
                model.OfferAcceptedID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iOfferAcceptedMaster.GetOfferAcceptedMasterAsync(id).Result;
                    if (model != null)
                    {

                        /*detail = iOfferAcceptedMaster.GetOfferAcceptedDetailAsync(id).Result;
                        PagedDataTable<OfferAcceptedDetail> pds = (PagedDataTable<OfferAcceptedDetail>iOfferAcceptedMaster.GetOfferAcceptedDetailAsync(id).Result;
                        List<OfferAcceptedDetail> lst = new List<OfferAcceptedDetail>();
                        foreach (var item in pds)
                        {
                            OfferAcceptedDetail detail = new OfferAcceptedDetail();
                            detail.SrNo = item.SrNo;
                            detail.OfferAcceptedDetailID = item.OfferAcceptedDetailID;
                            detail.OfferAcceptedID = item.OfferAcceptedID;
                            detail.HSNcodes = item.HSNcodes;
                            detail.ItemCode = item.ItemCode;
                            detail.ItemID = item.ItemID;
                            detail.ItemName = item.ItemName;
                            detail.Qty = item.Qty;
                            detail.Rate = item.Rate;
                            detail.Remark = item.Remark;
                            detail.UOMID = item.UOMID;
                            detail.UOM = item.UOM;
                            detail.TotalAmount = item.TotalAmount;
                            lst.Add(detail);
                        }
                        model.OfferAcceptedDetails = lst;*/

                        int i = 0;
                        int userid = USERID;
                        IQueryCollection query = Request.Query;
                        string value = string.Empty;
                        Action<IGridColumnCollection<OfferAcceptedDetail>> columns = c =>
                        {
                            c.Add(o => o.SrNo)
                                .Titled("Sr No");

                            c.Add().Titled("OfferAcceptedDetailID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.OfferAcceptedDetailID}' id='OfferAcceptedDetailId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("Offer Accepted ID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.OfferAcceptedID}' id='OfferAcceptedId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("ItemID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.ItemID}' id='itemId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("UOMID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.UOMID}' id='UOMIDnewRowIndex{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("Item Code").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.ItemCode}' id='itemCodeIndexnewRowIndex{o.SrNo}' readonly >");

                            c.Add().Titled("Item Name").Encoded(false).Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.ItemName}' id='itemNameIndexnewRowIndex{o.SrNo}' readonly >");

                            c.Add().Titled("Add").Encoded(false).Sanitized(false).RenderValueAs(o => $"<a class='MCLFAB fa-lg pb-1' id='btnAddNewRow' onclick='fnAddNewRowValue({o.SrNo})' href='javascript:void(0)' data-bs-toggle='offcanvas' data-bs-target='#canvasAddNewRow' aria-controls='canvasAddNewRow'><iconify-icon class='parent-icon' icon='material-symbols:add-circle-outline-rounded'></iconify-icon></a>");

                            //c.Add()
                            //    .Titled("")
                            //    .Encoded(false)
                            //    .Sanitized(false)
                            //    .SetWidth(10)
                            //     .RenderValueAs(o => $"<a  class='fa-2x'  ><iconify-icon icon=\"gg:add-r\"></iconify-icon></a>");
                            //href='/Marketing/OfferAcceptedMaster/Get/{o.ItemID}'


                            c.Add().Titled("HSN Code").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.HSNcodes}' id='hsnCodeIndex{o.SrNo}' >");



                            //c.Add().Titled("UOM").Encoded(false)
                            //    .Sanitized(false).RenderValueAs(o => $"<select class='form-select' value='{o.UOM}' id='uomIndex{o.SrNo}' data-items='{CommonExtension.GetAllUOMAsync()}'><option value=''>Select here...</option></select>");

                            //c.Add().Titled("UOM").Encoded(false);
                            //.SetSelectField(true, o => o.UOMText, o => this.GetAllUOM());
                            c.Add().Titled("UOM").Encoded(false)
                       .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.UOM}' id='UOMIndexnewRowIndex{o.SrNo}' readonly>");

                            c.Add().Titled("Qty").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.Qty}' oninput='fnCalcAmt({o.SrNo})' id='qtyIndex{o.SrNo}' >");

                            c.Add().Titled("Rate").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.Rate}' oninput='fnCalcAmt({o.SrNo})' id='rateIndex{i}'>");

                            c.Add().Titled("Total Amt").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.TotalAmount}'  id='amtIndex{o.SrNo}' readonly>");
                            //c.Add(o => o.Remark).Titled("Remark").SetWidth(30);

                            //c.Add()
                            //    .Titled("Edit")
                            //    .Encoded(false)
                            //    .Sanitized(false)
                            //    .SetWidth(20)
                            //    .Css("hidden-xs")
                            //     .RenderValueAs(o => $"<a  class='fa-2x' href='/Marketing/OfferAcceptedMaster/Get/{o.OfferAcceptedDetailID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");

                            c.Add()
                                .Titled("Remove")
                                .Encoded(false)
                                .Sanitized(false)
                                .SetWidth(20)
                                .Css("hidden-xs")
                                 .RenderValueAs(o => $"<h5 class='fa-2x pt-1'><a class='MCLFRB' id='btnRemoveRow' onclick='removeRow(this)'><iconify-icon icon='mdi:remove-circle-outline'></iconify-icon></a></h5>");
                            i++;

                            //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnOfferAcceptedMaster(this)' href='javascript:void(0)' data-id='{o.OfferAcceptedID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_OfferAcceptedMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
                        };
                        PagedDataTable<OfferAcceptedDetail> pds = (PagedDataTable<OfferAcceptedDetail>)iOfferAcceptedMaster.GetOfferAcceptedDetailAsync(id).Result;

                        var server = new GridCoreServer<OfferAcceptedDetail>(pds, query, false, "OfferAcceptedDetailGrid", columns, 1, pds.TotalItemCount)
                            .Sortable(false)
                            .Searchable(false, false)
                            .Selectable(true)
                            .WithGridItemsCount()
                            .ChangeSkip(false)
                            .EmptyText("No record found")
                            .ClearFiltersButton(false).Named("OfferAcceptedDetailTable")
                            .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");

                        model.iSGrid = server.Grid;
                        //return  View(server.Grid);




                    }
                    return View("AddOrUpdateOfferAcceptedMaster", model);
                }
                return View("AddOrUpdateOfferAcceptedMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<SelectItem> GetAllUOM()
        {
            //using (var context = new NorthwindDbContext(_options))
            //{
            //    EmployeeRepository repository = new EmployeeRepository(context);
            //    return repository.GetAll()
            //        .Select(r => new SelectItem(r.EmployeeID.ToString(), r.EmployeeID.ToString() + " - "
            //           + r.FirstName + " " + r.LastName))
            //        .ToList();
            //}
            try
            {
                var UOMList = commonMasterService.GetAllUOMAsync().Result.ToList();
                return UOMList
                    .Select(x => new SelectItem(x.UOMID.ToString(), x.UOMText))
                    .ToList();
            }
            catch
            {
                throw;
            }

        }
        #endregion Slider Page

        #region Add or Update OfferAcceptedMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateOfferAcceptedMaster(OfferAcceptedMaster model)
        {

            try
            {
                model.CreatedOrModifiedBy = USERID;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                List<OfferAcceptedDetail> sAPUpdateItemStocks = new List<OfferAcceptedDetail>();
                if (!string.IsNullOrEmpty(model.SAPCollectionJSONString))
                {
                    #region Creating DataTable 
                    sAPUpdateItemStocks = JsonConvert.DeserializeObject<List<OfferAcceptedDetail>>(model.SAPCollectionJSONString);

                    dataTable.Columns.Clear();
                    //dataTable.Columns.Add(new DataColumn("OfferAcceptedDetailID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("OfferAcceptedID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("ItemID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("ItemName", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("HSNcodes", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("UOMID", typeof(int)));
                    ////dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
                    //dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));
                    //dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));

                    dataTable.Columns.Add(new DataColumn("OfferAcceptedDetailID", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("OfferAcceptedID", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("ItemID", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("HSNcodes", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("UOMID", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
                    dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));
                    dataTable.Columns.Add(new DataColumn("DiscountInPer", typeof(decimal)));
                    dataTable.Columns.Add(new DataColumn("DiscountAmount", typeof(decimal)));
                    dataTable.Columns.Add(new DataColumn("TaxInPer", typeof(decimal)));
                    dataTable.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
                    dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
                    dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("IsInspectionRequired", typeof(bool)));
                    dataTable.Columns.Add(new DataColumn("InspectionAgencyID", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("IsActive", typeof(bool)));
                    dataTable.Columns.Add(new DataColumn("CreatedOrModifiedBy", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("ItemName", typeof(string)));

                    foreach (var item in sAPUpdateItemStocks)
                    {
                        DataRow dataRow = dataTable.NewRow();

                        //dataRow["OfferAcceptedDetailID"] = item.OfferAcceptedDetailID;
                        //dataRow["OfferAcceptedID"] = item.OfferAcceptedID;
                        //dataRow["ItemID"] = item.ItemID;
                        //dataRow["ItemCode"] = item.ItemCode;
                        //dataRow["ItemName"] = item.ItemName;
                        //dataRow["HSNcodes"] = item.HSNcodes;
                        //dataRow["UOMID"] = item.UOMID;
                        ////dataRow["UOM"] = item.UOM;
                        //dataRow["Qty"] = item.Qty;
                        //dataRow["Rate"] = item.Rate;
                        //dataRow["TotalAmount"] = item.TotalAmount;

                        dataRow["OfferAcceptedDetailID"] = item.OfferAcceptedDetailID;
                        dataRow["OfferAcceptedID"] = item.OfferAcceptedID;
                        dataRow["ItemID"] = item.ItemID;
                        dataRow["HSNcodes"] = item.HSNcodes;
                        dataRow["UOMID"] = item.UOMID;
                        dataRow["Qty"] = item.Qty;
                        dataRow["Rate"] = item.Rate;
                        dataRow["DiscountInPer"] = 0;
                        dataRow["DiscountAmount"] = 0;
                        dataRow["TaxInPer"] = 0;
                        dataRow["TaxAmount"] = 0;
                        dataRow["TotalAmount"] = item.TotalAmount;
                        dataRow["Remark"] = string.Empty;
                        dataRow["IsInspectionRequired"] = false;
                        dataRow["InspectionAgencyID"] = 0;
                        dataRow["IsActive"] = true;
                        dataRow["CreatedOrModifiedBy"] = USERID;
                        dataRow["ItemCode"] = item.ItemCode;
                        dataRow["ItemName"] = item.ItemName;

                        dataTable.Rows.Add(dataRow);
                    }

                    #endregion Creating DataTable 
                }
                var _OfferAcceptedID = await iOfferAcceptedMaster.AddOrUpdateOfferAcceptedMaster(model, dataTable);

                if (_OfferAcceptedID > 0)
                {
                    model.OfferAcceptedID = _OfferAcceptedID;
                    return Json(new { status = true, message = MessageHelper.Added, orderId = _OfferAcceptedID });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public PartialViewResult GetActionResultAsyncCustomerAddress(int addressTypeId, int customerId)
        {
            CustomerAddressTxn customerAddressTxn = new CustomerAddressTxn();
            try
            {
                if (addressTypeId > 0 || customerId > 0)
                {
                    var CustomerAddressTxn = iOfferAcceptedMaster.GetCustomerAddressDetail(addressTypeId, customerId).Result;
                    if (CustomerAddressTxn != null)
                    {
                        customerAddressTxn = CustomerAddressTxn;
                        ViewBag.customerCode = customerAddressTxn.CustomerCode;
                        return PartialView("OfferAcceptedCustomerAddress", customerAddressTxn);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return PartialView("OfferAcceptedCustomerAddress", customerAddressTxn);
        }

        [HttpPost]
        public async Task<IActionResult> OfferAcceptedDetailItemDeactivation(int OfferAcceptedDetailId, int OfferAcceptedId)
        {
            try
            {
                if (OfferAcceptedDetailId > 0 && OfferAcceptedId > 0)
                {
                    var _OfferAcceptedDetailId = await iOfferAcceptedMaster.OfferAcceptedDetailItemDeactivationAsync(OfferAcceptedDetailId, OfferAcceptedId, USERID);
                    if (_OfferAcceptedDetailId>0)
                        return Json(new { status = true, message = MessageHelper.Added });
                    else
                        return Json(new { status = false, message = MessageHelper.Error });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion Add or Update OfferAcceptedMaster 

        #region GetSAPItemCollection

        [HttpGet]
        public IActionResult GetSAPItemCollection(string search = "", [FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", string itemGroup = "", string wareHouse = "")
        {
            ViewData["SearchString"] = search;
            int userid = USERID;
            IQueryCollection query = Request.Query;
            ViewData["ItemGroup"] = itemGroup;
            ViewData["WareHouse"] = wareHouse;

            Action<IGridColumnCollection<SAPUpdateItemStock>> columns = c =>
            {
                //c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                c.Add(o => o.WareHouse).Titled("WareHouse").Sortable(true);
                c.Add(o => o.ItemGroupName).Titled("Group Name").Sortable(true);

                //c.Add(o => o.FinishGoodName).Titled("Item Name").Sortable(true);  Old Code

                //c.Add().Titled("Item Name").Encoded(false).Sanitized(false).Css("hidden-xs").RenderValueAs(o => $"<a onclick='fnOpenBuyerList(this)' href='javascript:void(0)' data-id='{o.ItemCode}' data-name='{o.FinishGoodName}' data-bs-toggle='offcanvas' data-bs-target='#canvasEmployeeGatepass' data-key='' aria-controls='canvasEmployeeGatepass'>{o.FinishGoodName}</a>");

                c.Add().Titled("Item Name").Encoded(false).Sanitized(false).Css("hidden-xs").RenderValueAs(o => $"<a onclick='fnPassItemDetail(this)' href='javascript:void(0)' data-code='{o.ItemCode}' data-name='{o.FinishGoodName}' data-bs-toggle='offcanvas' data-bs-target='#canvasEmployeeGatepass' data-key='' aria-controls='canvasEmployeeGatepass'>{o.FinishGoodName}</a>");


                //c.Add().Titled("Item Name").Encoded(false).Sanitized(false).Css("hidden-xs")
                //   .RenderValueAs(o => $"<a href='SAPItemCollection/GetCustomerListByItemCode?itemCode={o.ItemCode}'>{o.FinishGoodName}</a>");

                c.Add(o => o.CoilLenght).Titled("Coil Lenght").Sortable(true);
                c.Add(o => o.NoOfCoils).Titled("Coils").Sortable(true);
                c.Add(o => o.TotalMtr).Titled("Total Mtr").Sortable(true);
                c.Add(o => o.BinLocation).Titled("Bin Location").Sortable(true);
                c.Add(o => o.AgingInDays).Titled("Aging(Days)").Sortable(true);

            };
            PagedDataTable<SAPUpdateItemStock> pds = _sAPItemCollectionInterface.GetAllSAPItemStockList(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC", itemGroup, wareHouse).Result;
            var server = new GridCoreServer<SAPUpdateItemStock>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable(true).ClearFiltersButton(true).Selectable(true).WithGridItemsCount().ChangeSkip(false).EmptyText("No record found").ClearFiltersButton(false);
            return PartialView("_getSAPItemCollection", server.Grid);
        }

        #endregion GetSAPItemCollection
    }
}
