using Business.Entities.SalesDistribution.SalesOrderMasterModel;
using Business.Interface;
using Business.Interface.SalesDistribution.ISalesOrderMaster;
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

namespace ERP.Areas.SalesDistribution.Controllers
{
    [Area("SalesDistribution"), Microsoft.AspNetCore.Authorization.Authorize]
    [DisplayName("SalesOrderMaster")]
    public class SalesOrderMasterController : SettingsController
    {
        private readonly SalesOrderMasterInterface iSalesOrderMaster;
        private readonly ICommonMasterService commonMasterService;
        private readonly SAPItemCollectionInterface _sAPItemCollectionInterface;
        public UOMIDMetadata _UOM = new UOMIDMetadata();

        public SalesOrderMasterController(SalesOrderMasterInterface iSalesOrderMaster, ICommonMasterService iCommonMst, SAPItemCollectionInterface sAPItemCollectionInterface)
        {
            this.iSalesOrderMaster = iSalesOrderMaster;
            this.commonMasterService = iCommonMst;
            _sAPItemCollectionInterface = sAPItemCollectionInterface;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<SalesOrderMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(10);


                c.Add(o => o.SalesOrderID).Titled("Sales Order ID").SetWidth(20);
                c.Add(o => o.SalesOrderDate).Titled("Sales Order Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                c.Add(o => o.CustomerCode).Titled("Customer Code").SetWidth(20);
                c.Add(o => o.CustomerName).Titled("Customer Name").SetWidth(20);
                c.Add(o => o.GrossAmount).Titled("Gross Amt").SetWidth(20);

            //    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
            //.RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.SalesOrderID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.SalesOrderID}'   data-id='{o.SalesOrderID}' data-key='{o.SalesOrderID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(20)
                    .Css("hidden-xs")
                     .RenderValueAs(o => $"<a class='fa-2x' href='/SalesDistribution/SalesOrderMaster/Get/{o.SalesOrderID}' ><i class='bx bx-edit'></i></a>");

                
            };
            PagedDataTable<SalesOrderMaster> pds = (PagedDataTable<SalesOrderMaster>)iSalesOrderMaster.GetAllSalesOrderMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<SalesOrderMaster>(pds, query, false, "SalesOrderMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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

                SalesOrderSearch model = new SalesOrderSearch();
                model.keyword = keyword;

                PagedDataTable<SalesOrderMaster> pds = iSalesOrderMaster.GetAllSalesOrderMasterAsync(1, PAGESIZE, keyword, "", "ASC").Result;

                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<SalesOrderMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(10);


                    c.Add(o => o.SalesOrderID).Titled("Sales Order ID").SetWidth(20);
                    c.Add(o => o.SalesOrderDate).Titled("Sales Order Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                    c.Add(o => o.CustomerCode).Titled("Customer Code").SetWidth(20);
                    c.Add(o => o.CustomerName).Titled("Customer Name").SetWidth(20);
                    c.Add(o => o.GrossAmount).Titled("Gross Amt").SetWidth(20);

                    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.SalesOrderID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.SalesOrderID}'   data-id='{o.SalesOrderID}' data-key='{o.SalesOrderID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    c.Add()
                        .Titled("Edit")
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(20)
                        .Css("hidden-xs")
                         .RenderValueAs(o => $"<a class='fa-2x' href='/SalesDistribution/SalesOrderMaster/Get/{o.SalesOrderID}' ><i class='bx bx-edit'></i></a>");

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<SalesOrderMaster>(pds, query, false, "SalesOrderMasterGrid",
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

        #region Sales Order Item detail 
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public PartialViewResult SalesOrderItemDetail(int salesOrderID = 0)
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<SalesOrderDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No");


                //c.Add(o => o.SalesOrderDetailID).Titled("SalesOrderDetailID").Hidden=true;
                c.Add(o => o.SalesOrderID).Titled("Sales Order ID").SetWidth(20);
                //c.Add(o => o.ItemID).Titled("ItemID").Hidden=true;
                c.Add(o => o.ItemName).Titled("Item Name");
                //c.Add(o => o.HSNcodes).Titled("HSN Code");
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
                     .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/SalesDistribution/SalesOrderMaster/Get/{o.SalesOrderDetailID}' ><i class='bx bx-edit'></i></a>");

                //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnSalesOrderMaster(this)' href='javascript:void(0)' data-id='{o.SalesOrderID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_SalesOrderMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<SalesOrderDetail> pds = (PagedDataTable<SalesOrderDetail>)iSalesOrderMaster.GetSalesOrderDetailAsync(salesOrderID).Result;

            var server = new GridCoreServer<SalesOrderDetail>(pds, query, false, "SalesOrderDetailGrid", columns, 1, pds.TotalItemCount)
                .Sortable()
                .Searchable(false, false)
                .Selectable(true)
                .WithGridItemsCount()
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false)
                .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");


            //return  View(server.Grid);
            return PartialView("SalesOrderItemDetail", server.Grid);
        }
        #endregion Sales Order Item Detail



        #region Slider Page

        [HttpPost]
        public IActionResult Get(int id)
        {
            try
            {
                SalesOrderMaster model = new SalesOrderMaster();
                model.SalesOrderID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iSalesOrderMaster.GetSalesOrderMasterAsync(id).Result;
                    if (model != null)
                    {

                        /*detail = iSalesOrderMaster.GetSalesOrderDetailAsync(id).Result;
                        PagedDataTable<SalesOrderDetail> pds = (PagedDataTable<SalesOrderDetail>iSalesOrderMaster.GetSalesOrderDetailAsync(id).Result;
                        List<SalesOrderDetail> lst = new List<SalesOrderDetail>();
                        foreach (var item in pds)
                        {
                            SalesOrderDetail detail = new SalesOrderDetail();
                            detail.SrNo = item.SrNo;
                            detail.SalesOrderDetailID = item.SalesOrderDetailID;
                            detail.SalesOrderID = item.SalesOrderID;
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
                        model.SalesOrderDetails = lst;*/

                        int i = 0;
                        int userid = USERID;
                        IQueryCollection query = Request.Query;
                        string value = string.Empty;

                        /*
                        Action<IGridColumnCollection<SalesOrderDetail>> columns = c =>
                        {
                            c.Add(o => o.SrNo)
                                .Titled("Sr No");

                            c.Add().Titled("SalesOrderDetailID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.SalesOrderDetailID}' id='salesOrderDetailId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("Sales Order ID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.SalesOrderID}' id='salesOrderId{o.SrNo}'>").Hidden = true;

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
                            //href='/SalesDistribution/SalesOrderMaster/Get/{o.ItemID}'


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

                            c.Add().Titled("Rate").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.Rate}' oninput='fnCalcAmt({o.SrNo})' id='rateIndex{o.SrNo}'>");

                            c.Add().Titled("Total Amt").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.TotalAmount}'  id='amtIndex{o.SrNo}' readonly>");
                            //c.Add(o => o.Remark).Titled("Remark").SetWidth(30);

                            //c.Add()
                            //    .Titled("Edit")
                            //    .Encoded(false)
                            //    .Sanitized(false)
                            //    .SetWidth(20)
                            //    .Css("hidden-xs")
                            //     .RenderValueAs(o => $"<a  class='fa-2x' href='/SalesDistribution/SalesOrderMaster/Get/{o.SalesOrderDetailID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");

                            c.Add()
                                .Titled("Remove")
                                .Encoded(false)
                                .Sanitized(false)
                                .SetWidth(20)
                                .Css("hidden-xs")
                                 .RenderValueAs(o => $"<h5 class='fa-2x pt-1'><a class='MCLFRB' id='btnRemoveRow' onclick='removeRow(this)'><iconify-icon icon='mdi:remove-circle-outline'></iconify-icon></a></h5>");
                            i++;

                            //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnSalesOrderMaster(this)' href='javascript:void(0)' data-id='{o.SalesOrderID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_SalesOrderMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
                        };
                        */

                        Action<IGridColumnCollection<SalesOrderDetail>> columns = c =>
                        {
                            c.Add(o => o.SrNo)
                                .Titled("Sr No");

                            c.Add().Titled("SalesOrderDetailID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.SalesOrderDetailID}' id='salesOrderDetailId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("Sales Order ID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.SalesOrderID}' id='salesOrderId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("ItemID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.ItemID}' id='itemId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("UOMID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.UOMID}' id='UOMIDnewRowIndex{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("Item Code").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.ItemCode}' id='itemCodeIndexnewRowIndex{o.SrNo}' title='{o.ItemCode}' readonly >");

                            c.Add().Titled("Item Name").Encoded(false).Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.ItemName}'  title='{o.ItemName}' id='itemNameIndexnewRowIndex{o.SrNo}' readonly >");

                            c.Add().Titled("UOM").Encoded(false)
                      .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.UOM}' id='UOMIndexnewRowIndex{o.SrNo}' title='{o.UOM}' readonly>");

                            c.Add().Titled("Add").Encoded(false).Sanitized(false).RenderValueAs(o => $"<a class='MCLFAB fa-lg pb-1' id='btnAddNewRow' onclick='fnAddNewRowValue({o.SrNo})' href='javascript:void(0)' data-bs-toggle='offcanvas' data-bs-target='#canvasAddNewRow' aria-controls='canvasAddNewRow'><iconify-icon class='parent-icon' icon='material-symbols:add-circle-outline-rounded'></iconify-icon></a>");

                            //c.Add().Titled("Qty").Encoded(false)
                            //    .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.Qty}' oninput='fnCalcAmt({o.SrNo})' id='qtyIndex{o.SrNo}' >");

                            //c.Add().Titled("Rate").Encoded(false)
                            //    .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.Rate}' oninput='fnCalcAmt({o.SrNo})' id='rateIndex{o.SrNo}'>");

                            c.Add().Titled("Stock no of coil").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.StockNoOfCoil}' oninput='fnCalculateSalesOrderItems({o.SrNo})' id='stockNoOfCoilIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Stock coil length").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.StockCoilLength}' oninput='fnCalculateSalesOrderItems({o.SrNo})' id='stockCoilLengthIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Order no of coil").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.OrderNoOfCoil}' oninput='fnUpdateOrderQuantityInMeter({o.SrNo})' id='orderNoOfCoilIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Order coil length").Encoded(false)
                              .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.OrderCoilLength}' oninput='fnUpdateOrderQuantityInMeter({o.SrNo})' id='orderCoilLengthIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Order qty in meter").Encoded(false)
                              .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.OrderQtyInMeter}' oninput='fnUpdatePricePerMeter({o.SrNo}); fnUpdatePriceListAmount({o.SrNo})' id='orderQtyInMeterIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Price list amt").Encoded(false)
                              .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.PriceListAmt}' oninput='fnUpdatePricePerMeter({o.SrNo}); fnUpdateDiscountsAmount({o.SrNo})' id='priceListAmtIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Per meter price").Encoded(false)
                              .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.PerMeterPrice}' oninput='fnUpdatePriceListAmount({o.SrNo})' id='perMeterPriceIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Discount").Encoded(false)
                              .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.DiscountAmount}' oninput='fnUpdateDiscountsAmount({o.SrNo})' id='discountIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Special discount").Encoded(false)
                              .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.SpecialDiscount}' oninput='fnUpdateDiscountsAmount({o.SrNo})' id='specialDiscountIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Cash discount").Encoded(false)
                            .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.CashDiscount}' oninput='fnUpdateDiscountsAmount({o.SrNo})' id='cashDiscountIndexnewRowIndex{o.SrNo}'>");

                            c.Add().Titled("Total amt").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='text' class='form-control' value='{o.TotalAmount}'  id='amtIndex{o.SrNo}' title='{o.TotalAmount}' readonly>");

                            c.Add()
                                .Titled("Remove")
                                .Encoded(false)
                                .Sanitized(false)
                                .SetWidth(20)
                                .Css("hidden-xs")
                                 .RenderValueAs(o => $"<h5 class='fa-2x pt-1'><a class='MCLFRB' id='btnRemoveRow' onclick='removeRow(this)'><iconify-icon icon='mdi:remove-circle-outline'></iconify-icon></a></h5>");
                            i++;
                        };

                        PagedDataTable<SalesOrderDetail> pds = (PagedDataTable<SalesOrderDetail>)iSalesOrderMaster.GetSalesOrderDetailAsync(id).Result;

                        var server = new GridCoreServer<SalesOrderDetail>(pds, query, false, "SalesOrderDetailGrid", columns, 1, pds.TotalItemCount)
                            .Sortable(false)
                            .Searchable(false, false)
                            .Selectable(true)
                            .WithGridItemsCount()
                            .ChangeSkip(false)
                            .EmptyText("No record found")
                            .ClearFiltersButton(false).Named("SalesOrderDetailTable")
                            .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");

                        model.iSGrid = server.Grid;
                        //return  View(server.Grid);




                    }
                    return View("AddOrUpdateSalesOrderMaster", model);
                }
                return View("AddOrUpdateSalesOrderMaster", model);
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

        #region Add or Update SalesOrderMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateSalesOrderMaster(SalesOrderMaster model)
        {
            try
            {
                model.CreatedOrModifiedBy = USERID;
                DataSet dataTable = new System.Data.DataSet();
                List<SalesOrderDetail> sAPUpdateItemStocks = new List<SalesOrderDetail>();
                if (!string.IsNullOrEmpty(model.SAPCollectionJSONString))
                {
                    #region Creating DataTable 
                    sAPUpdateItemStocks = JsonConvert.DeserializeObject<List<SalesOrderDetail>>(model.SAPCollectionJSONString);
                    dataTable.Tables.Add(new System.Data.DataTable());
                    dataTable.Tables[0].Columns.Clear();

                    dataTable.Tables[0].Columns.Add(new DataColumn("SalesOrderDetailID", typeof(int)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("SalesOrderID", typeof(int)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("ItemID", typeof(int)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("HSNcodes", typeof(string)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("UOMID", typeof(int)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("Qty", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("Rate", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("DiscountInPer", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("DiscountAmount", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("TaxInPer", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("Remark", typeof(string)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("IsInspectionRequired", typeof(bool)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("InspectionAgencyID", typeof(int)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("IsActive", typeof(bool)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("CreatedOrModifiedBy", typeof(int)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("CreatedDate", typeof(DateTime)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("ItemCode", typeof(string)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("ItemName", typeof(string)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("StockNoOfCoil", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("StockCoilLength", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("OrderNoOfCoil", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("OrderCoilLength", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("OrderQtyInMeter", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("PriceListAmt", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("PerMeterPrice", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("SpecialDiscount", typeof(decimal)));
                    dataTable.Tables[0].Columns.Add(new DataColumn("CashDiscount", typeof(decimal)));

                    foreach (var item in sAPUpdateItemStocks)
                    {
                        DataRow dataRow = dataTable.Tables[0].NewRow();

                        dataRow["SalesOrderDetailID"] = item.SalesOrderDetailID;
                        dataRow["SalesOrderID"] = item.SalesOrderID;
                        dataRow["ItemID"] = item.ItemID;
                        dataRow["HSNcodes"] = item.HSNcodes ?? string.Empty;
                        dataRow["UOMID"] = item.UOMID;
                        dataRow["Qty"] = item.Qty;
                        dataRow["Rate"] = item.Rate;
                        dataRow["DiscountInPer"] = item.DiscountInPer;
                        dataRow["DiscountAmount"] = item.DiscountAmount;
                        dataRow["TaxInPer"] = item.TaxInPer;
                        dataRow["TaxAmount"] = item.TaxAmount;
                        dataRow["TotalAmount"] = item.TotalAmount;
                        dataRow["Remark"] = item.Remark;
                        dataRow["IsInspectionRequired"] = item.IsInspectionRequired ?? false;
                        dataRow["InspectionAgencyID"] = item.InspectionAgencyID ?? 0;
                        dataRow["IsActive"] = item.IsActive;
                        dataRow["CreatedOrModifiedBy"] = item.CreatedBy ?? USERID;
                        dataRow["CreatedDate"] = DateTime.Now; //tem.SalesOrderDetailID < 0 ? DateTime.Now : null;// item.CreatedDate;
                        dataRow["ModifiedDate"] = DateTime.Now;// item.SalesOrderDetailID > 0 ? DateTime.Now : null;
                        dataRow["ItemCode"] = item.ItemCode;
                        dataRow["ItemName"] = item.ItemName;
                        dataRow["StockNoOfCoil"] = item.StockNoOfCoil;
                        dataRow["StockCoilLength"] = item.StockCoilLength;
                        dataRow["OrderNoOfCoil"] = item.OrderNoOfCoil;
                        dataRow["OrderCoilLength"] = item.OrderCoilLength;
                        dataRow["OrderQtyInMeter"] = item.OrderQtyInMeter;
                        dataRow["PriceListAmt"] = item.PriceListAmt;
                        dataRow["PerMeterPrice"] = item.PerMeterPrice;
                        dataRow["SpecialDiscount"] = item.SpecialDiscount;
                        dataRow["CashDiscount"] = item.CashDiscount;

                        dataTable.Tables[0].Rows.Add(dataRow);
                    }

                    System.Data.DataTable dataTable1 = JsonConvert.DeserializeObject<System.Data.DataTable>(model.TaxAmountJSONString);
                    //System.Data.DataTable dataTableClone = dataTable1.Clone();
                    //dataTableClone.Columns["FormulaPercentage"].DataType = typeof(decimal);

                    foreach (DataRow dr in dataTable1.Rows)
                    {
                        dr["FormulaPercentage"] = Convert.ToDecimal(dr["FormulaPercentage"]);
                        dr["CreatedOrModifiedBy"] = USERID;
                        //dataTableClone.ImportRow(dr);
                    }
                    dataTable.Tables.Add(dataTable1);
                    #endregion Creating DataTable 
                }

                var _SalesOrderID = await iSalesOrderMaster.AddOrUpdateSalesOrderMaster(model, dataTable);

                if (_SalesOrderID > 0)
                {
                    model.SalesOrderID = _SalesOrderID;
                    return Json(new { status = true, message = MessageHelper.Added, orderId = _SalesOrderID });
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
        public PartialViewResult GetActionResultAsyncCustomerAddress(int addressTypeId, int customerId)
        {
            CustomerAddressTxn customerAddressTxn = new CustomerAddressTxn();
            try
            {
                if (addressTypeId > 0 || customerId > 0)
                {
                    var CustomerAddressTxn = iSalesOrderMaster.GetCustomerAddressDetail(addressTypeId, customerId).Result;
                    if (CustomerAddressTxn != null)
                    {
                        customerAddressTxn = CustomerAddressTxn;
                        ViewBag.customerCode = customerAddressTxn.CustomerCode;
                        return PartialView("SalesOrderCustomerAddress", customerAddressTxn);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return PartialView("SalesOrderCustomerAddress", customerAddressTxn);
        }

        [HttpPost]
        public async Task<IActionResult> SalesOrderDetailItemDeactivation(int salesOrderDetailId, int salesOrderId)
        {
            try
            {
                if (salesOrderDetailId > 0 && salesOrderId > 0)
                {
                    var _salesOrderDetailId = await iSalesOrderMaster.SalesOrderDetailItemDeactivationAsync(salesOrderDetailId, salesOrderId, USERID);
                    if (_salesOrderDetailId>0)
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
        #endregion Add or Update SalesOrderMaster 

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

                //c.Add().Titled("Item Name").Encoded(false).Sanitized(false).Css("hidden-xs").RenderValueAs(o => $"<a onclick='fnPassItemDetail(this)' href='javascript:void(0)' data-code='{o.ItemCode}' data-name='{o.FinishGoodName}' data-bs-toggle='offcanvas' data-bs-target='#canvasEmployeeGatepass' data-key='' aria-controls='canvasEmployeeGatepass'>{o.FinishGoodName}</a>");
                c.Add().Titled("Item Name").Encoded(false).Sanitized(false).Css("hidden-xs").RenderValueAs(o => $"<a onclick='fnPassItemDetail(this)' href='javascript:void(0)' data-code='{o.ItemCode}' data-name='{o.FinishGoodName}' data-coil-len='{o.CoilLenght}' data-noOf-Coils='{o.NoOfCoils}' data-bs-toggle='offcanvas' data-bs-target='#canvasEmployeeGatepass' data-key='' aria-controls='canvasEmployeeGatepass'>{o.FinishGoodName}</a>");


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

        #region Get formula for calculate taxes and amounts(GetFormulaMasterByCustomerID)
        [HttpGet]
        public async Task<PartialViewResult> GetFormulaMasterByCustomerID(int? customerId)
        {
            try
            {
                System.Data.DataTable dataTable = new System.Data.DataTable();
                if (customerId > 0)
                    dataTable = await iSalesOrderMaster.GetFormulaByCustomerIdAsync(customerId);

                if (dataTable.Rows.Count > 0)
                    return PartialView("_transactionCalculation", dataTable);
                else
                    return PartialView("_transactionCalculation", null);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Get formula for calculate taxes and amounts(GetFormulaMasterByCustomerID)
    }
}
