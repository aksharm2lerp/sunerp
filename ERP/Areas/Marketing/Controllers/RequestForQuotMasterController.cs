using Business.Entities.Marketing.RequestForQuotMasterModel;
using Business.Interface;
using Business.Interface.Marketing.IRequestForQuotMaster;
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
using Newtonsoft.Json;
using System.Data;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Microsoft.AspNetCore.Authorization.Authorize]
    [DisplayName("RequestForQuotMaster")]
    public class RequestForQuotMasterController : SettingsController
    {
        private readonly RequestForQuotMasterInterface iRequestForQuotMaster;
        private readonly ICommonMasterService commonMasterService;
        private readonly SAPItemCollectionInterface _sAPItemCollectionInterface;
        public UOMIDMetadata _UOM = new UOMIDMetadata();

        public RequestForQuotMasterController(RequestForQuotMasterInterface IRequestForQuotMaster, ICommonMasterService iCommonMst, SAPItemCollectionInterface sAPItemCollectionInterface)
        {
            this.iRequestForQuotMaster = IRequestForQuotMaster;
            this.commonMasterService = iCommonMst;
            _sAPItemCollectionInterface = sAPItemCollectionInterface;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "RequestForQuotID", [FromQuery(Name = "grid-dir")] string sortby = "1", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<RequestForQuotMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(5);
                c.Add(o => o.RequestForQuotTypeText).Titled("RFQ Type").SetWidth(10);
                c.Add(o => o.RequestForQuotCode).Titled("RFQ Code").SetWidth(10);
                c.Add(o => o.RequestForQuotDate).Titled("Request For Quot Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                c.Add(o => o.PartyCode).Titled("Party Code").SetWidth(20);
                c.Add(o => o.PartyName).Titled("Party Name").SetWidth(30);


                //    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                //.RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.RequestForQuotID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.RequestForQuotID}'   data-id='{o.RequestForQuotID}' data-key='{o.RequestForQuotID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                c.Add(o => o.IsQuotationPrepared).Titled("Quot-Completed").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs text-center")
                .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.RequestForQuotID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.RequestForQuotID}'   data-id='{o.RequestForQuotID}' data-key='{o.RequestForQuotID}' " + (o.IsQuotationPrepared ? "checked" : "unchecked") + " disabled >");


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(5)
                    .Css("hidden-xs")
                     .RenderValueAs(o => $"<a class='fa-2x' {(o.IsQuotationPrepared == true ? "" : "href='/Marketing/RequestForQuotMaster/Get/"+o.RequestForQuotID+"'")} ><i class='bx bx-edit'></i></a>");

                
            };
            PagedDataTable<RequestForQuotMaster> pds = (PagedDataTable<RequestForQuotMaster>)iRequestForQuotMaster.GetAllRequestForQuotMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<RequestForQuotMaster>(pds, query, false, "RequestForQuotMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
                .Sortable(false)
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

                RequestForQuotSearch model = new RequestForQuotSearch();
                model.keyword = keyword;

                PagedDataTable<RequestForQuotMaster> pds = iRequestForQuotMaster.GetAllRequestForQuotMasterAsync(1, PAGESIZE, keyword, "", "DESC").Result;

                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<RequestForQuotMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(5);
                    c.Add(o => o.RequestForQuotTypeText).Titled("RFQ Type").SetWidth(10);


                    c.Add(o => o.RequestForQuotCode).Titled("RFQ Code").SetWidth(10);
                    c.Add(o => o.RequestForQuotDate).Titled("Request For Quot Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                    c.Add(o => o.PartyCode).Titled("Party Code").SetWidth(20);
                    c.Add(o => o.PartyName).Titled("Party Name").SetWidth(20);

                    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.RequestForQuotID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.RequestForQuotID}'   data-id='{o.RequestForQuotID}' data-key='{o.RequestForQuotID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    c.Add()
                        .Titled("Edit")
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(20)
                        .Css("hidden-xs")
                         .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/RequestForQuotMaster/Get/{o.RequestForQuotID}' ><i class='bx bx-edit'></i></a>");

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<RequestForQuotMaster>(pds, query, false, "RequestForQuotMasterGrid",
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

        #region Request For Quot Item detail 
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public PartialViewResult RequestForQuotItemDetail(int RequestForQuotID = 0)
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<RequestForQuotDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No");


                //c.Add(o => o.RequestForQuotDetailID).Titled("RequestForQuotDetailID").Hidden=true;
                c.Add(o => o.RequestForQuotID).Titled("Request For Quot ID").SetWidth(20);
                //c.Add(o => o.ItemID).Titled("ItemID").Hidden=true;
                c.Add(o => o.ItemName).Titled("Item Name");
                //c.Add(o => o.HSNcodes).Titled("HSN Code");
                //c.Add(o => o.UOMID).Titled("UOMID").Hidden=true;
                c.Add(o => o.UOMText).Titled("UOM");
                c.Add(o => o.Qty).Titled("Qty");
                //c.Add(o => o.Rate).Titled("Rate");
                //c.Add(o => o.TotalAmount).Titled("Total Amt");
                //c.Add(o => o.Remark).Titled("Remark").SetWidth(30);

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(20)
                    .Css("hidden-xs")
                     .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/RequestForQuotMaster/Get/{o.RequestForQuotDetailID}' ><i class='bx bx-edit'></i></a>");

                //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnRequestForQuotMaster(this)' href='javascript:void(0)' data-id='{o.RequestForQuotID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_RequestForQuotMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<RequestForQuotDetail> pds = (PagedDataTable<RequestForQuotDetail>)iRequestForQuotMaster.GetRequestForQuotDetailAsync(RequestForQuotID).Result;

            var server = new GridCoreServer<RequestForQuotDetail>(pds, query, false, "RequestForQuotDetailGrid", columns, 1, pds.TotalItemCount)
                .Sortable()
                .Searchable(false, false)
                .Selectable(true)
                .WithGridItemsCount()
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false)
                .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");


            //return  View(server.Grid);
            return PartialView("RequestForQuotItemDetail", server.Grid);
        }
        #endregion Request For Quot Item Detail



        #region Slider Page

        [HttpPost]
        public IActionResult Get(int id)
        {
            try
            {
                RequestForQuotMaster model = new RequestForQuotMaster();
                model.RequestForQuotID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iRequestForQuotMaster.GetRequestForQuotMasterAsync(id).Result;
                    if (model != null)
                    {

                        /*detail = iRequestForQuotMaster.GetRequestForQuotDetailAsync(id).Result;
                        PagedDataTable<RequestForQuotDetail> pds = (PagedDataTable<RequestForQuotDetail>iRequestForQuotMaster.GetRequestForQuotDetailAsync(id).Result;
                        List<RequestForQuotDetail> lst = new List<RequestForQuotDetail>();
                        foreach (var item in pds)
                        {
                            RequestForQuotDetail detail = new RequestForQuotDetail();
                            detail.SrNo = item.SrNo;
                            detail.RequestForQuotDetailID = item.RequestForQuotDetailID;
                            detail.RequestForQuotID = item.RequestForQuotID;
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
                        model.RequestForQuotDetails = lst;*/

                        int i = 0;
                        int userid = USERID;
                        IQueryCollection query = Request.Query;
                        string value = string.Empty;
                        Action<IGridColumnCollection<RequestForQuotDetail>> columns = c =>
                        {
                            c.Add(o => o.SrNo)
                                .Titled("Sr No");

                            c.Add().Titled("RequestForQuotDetailID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.RequestForQuotDetailID}' id='RequestForQuotDetailId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("Request For Quot ID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.RequestForQuotID}' id='RequestForQuotId{o.SrNo}'>").Hidden = true;

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
                            //href='/Marketing/RequestForQuotMaster/Get/{o.ItemID}'


                            //c.Add().Titled("HSN Code").Encoded(false)
                            //    .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.HSNcodes}' id='hsnCodeIndex{o.SrNo}' >");



                            //c.Add().Titled("UOM").Encoded(false)
                            //    .Sanitized(false).RenderValueAs(o => $"<select class='form-select' value='{o.UOM}' id='uomIndex{o.SrNo}' data-items='{CommonExtension.GetAllUOMAsync()}'><option value=''>Select here...</option></select>");

                            //c.Add().Titled("UOM").Encoded(false);
                            //.SetSelectField(true, o => o.UOMText, o => this.GetAllUOM());
                            c.Add().Titled("UOM").Encoded(false)
                       .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.UOM}' id='UOMIndexnewRowIndex{o.SrNo}' readonly>");

                            c.Add().Titled("Qty").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.Qty}' oninput='fnCalcAmt({o.SrNo})' id='qtyIndex{o.SrNo}' >");

                            //c.Add().Titled("Rate").Encoded(false)
                                //.Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.Rate}' oninput='fnCalcAmt({o.SrNo})' id='rateIndex{i}'>");

                            //c.Add().Titled("Total Amt").Encoded(false)
                                //.Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.TotalAmount}'  id='amtIndex{o.SrNo}' readonly>");
                            //c.Add(o => o.Remark).Titled("Remark").SetWidth(30);

                            //c.Add()
                            //    .Titled("Edit")
                            //    .Encoded(false)
                            //    .Sanitized(false)
                            //    .SetWidth(20)
                            //    .Css("hidden-xs")
                            //     .RenderValueAs(o => $"<a  class='fa-2x' href='/Marketing/RequestForQuotMaster/Get/{o.RequestForQuotDetailID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");

                            c.Add()
                                .Titled("Remove")
                                .Encoded(false)
                                .Sanitized(false)
                                .SetWidth(20)
                                .Css("hidden-xs")
                                 .RenderValueAs(o => $"<h5 class='fa-2x pt-1'><a class='MCLFRB' id='btnRemoveRow' onclick='removeRow(this)'><iconify-icon icon='mdi:remove-circle-outline'></iconify-icon></a></h5>");
                            i++;

                            //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnRequestForQuotMaster(this)' href='javascript:void(0)' data-id='{o.RequestForQuotID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_RequestForQuotMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
                        };
                        PagedDataTable<RequestForQuotDetail> pds = (PagedDataTable<RequestForQuotDetail>)iRequestForQuotMaster.GetRequestForQuotDetailAsync(id).Result;

                        var server = new GridCoreServer<RequestForQuotDetail>(pds, query, false, "RequestForQuotDetailGrid", columns, 1, pds.TotalItemCount)
                            .Sortable(false)
                            .Searchable(false, false)
                            .Selectable(true)
                            .WithGridItemsCount()
                            .ChangeSkip(false)
                            .EmptyText("No record found")
                            .ClearFiltersButton(false).Named("RequestForQuotDetailTable")
                            .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");

                        model.iSGrid = server.Grid;
                        //return  View(server.Grid);




                    }
                    return View("AddOrUpdateRequestForQuotMaster", model);
                }
                return View("AddOrUpdateRequestForQuotMaster", model);
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

        #region Add or Update RequestForQuotMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRequestForQuotMaster(RequestForQuotMaster model)
        {

            try
            {
                model.CreatedOrModifiedBy = USERID;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                List<RequestForQuotDetail> sAPUpdateItemStocks = new List<RequestForQuotDetail>();
                if (!string.IsNullOrEmpty(model.SAPCollectionJSONString))
                {
                    #region Creating DataTable 
                    sAPUpdateItemStocks = JsonConvert.DeserializeObject<List<RequestForQuotDetail>>(model.SAPCollectionJSONString);

                    dataTable.Columns.Clear();
                    //dataTable.Columns.Add(new DataColumn("RequestForQuotDetailID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("RequestForQuotID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("ItemID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("ItemName", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("HSNcodes", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("UOMID", typeof(int)));
                    ////dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
                    //dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));
                    //dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));

                    dataTable.Columns.Add(new DataColumn("RequestForQuotDetailID", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("RequestForQuotID", typeof(int)));
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

                        //dataRow["RequestForQuotDetailID"] = item.RequestForQuotDetailID;
                        //dataRow["RequestForQuotID"] = item.RequestForQuotID;
                        //dataRow["ItemID"] = item.ItemID;
                        //dataRow["ItemCode"] = item.ItemCode;
                        //dataRow["ItemName"] = item.ItemName;
                        //dataRow["HSNcodes"] = item.HSNcodes;
                        //dataRow["UOMID"] = item.UOMID;
                        ////dataRow["UOM"] = item.UOM;
                        //dataRow["Qty"] = item.Qty;
                        //dataRow["Rate"] = item.Rate;
                        //dataRow["TotalAmount"] = item.TotalAmount;

                        dataRow["RequestForQuotDetailID"] = item.RequestForQuotDetailID;
                        dataRow["RequestForQuotID"] = item.RequestForQuotID;
                        dataRow["ItemID"] = item.ItemID;
                        dataRow["HSNcodes"] = "";
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
                var _RequestForQuotID = await iRequestForQuotMaster.AddOrUpdateRequestForQuotMaster(model, dataTable);

                if (_RequestForQuotID > 0)
                {
                    model.RequestForQuotID = _RequestForQuotID;
                    return Json(new { status = true, message = MessageHelper.Added, orderId = _RequestForQuotID });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public PartialViewResult GetActionResultAsyncPartyAddress(int addressTypeId, int partyId)
        {
            PartyAddressTxn partyAddressTxn = new PartyAddressTxn();
            try
            {
                if (addressTypeId > 0 || partyId > 0)
                {
                    var partyAddress = iRequestForQuotMaster.GetPartyAddressDetail(addressTypeId, partyId).Result;
                    if (partyAddress != null)
                    {
                        partyAddressTxn = partyAddress;
                        ViewBag.partyCode = partyAddress.PartyCode;
                        return PartialView("RequestForQuotPartyAddress", partyAddressTxn);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return PartialView("RequestForQuotPartyAddress", partyAddressTxn);
        }

        [HttpPost]
        public async Task<IActionResult> RequestForQuotDetailItemDeactivation(int RequestForQuotDetailId, int RequestForQuotId)
        {
            try
            {
                if (RequestForQuotDetailId > 0 && RequestForQuotId > 0)
                {
                    var _RequestForQuotDetailId = await iRequestForQuotMaster.RequestForQuotDetailItemDeactivationAsync(RequestForQuotDetailId, RequestForQuotId, USERID);
                    if (_RequestForQuotDetailId>0)
                        return Json(new { status = true, message = MessageHelper.Added });
                    else
                        return Json(new { status = false, message = MessageHelper.Error });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Add or Update RequestForQuotMaster 

        #region GetSAPItemCollection

        [HttpGet]
        public IActionResult GetSAPItemCollection(string search = "", [FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "1", [FromQuery(Name = "grid-filter")] string gridfilter = "", string itemGroup = "", string wareHouse = "")
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
