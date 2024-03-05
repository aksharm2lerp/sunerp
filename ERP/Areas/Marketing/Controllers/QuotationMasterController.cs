using Business.Entities.Marketing.QuotationMasterModel;
using Business.Interface;
using Business.Interface.Marketing.IQuotationMaster;
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
using Business.Entities.Marketing.RequestForQuotMasterModel;
using Business.Interface.Marketing.IRequestForQuotMaster;
 
using Microsoft.AspNetCore.Localization;
using GridMvc.Server;
using PartyAddressTxn = Business.Entities.Marketing.QuotationMasterModel.PartyAddressTxn;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Microsoft.AspNetCore.Authorization.Authorize]
    [DisplayName("QuotationMaster")]
    public class QuotationMasterController : SettingsController
    {
        private readonly QuotationMasterInterface iQuotationMaster;
        private readonly ICommonMasterService commonMasterService;
        private readonly SAPItemCollectionInterface _sAPItemCollectionInterface;
        public UOMIDMetadata _UOM = new UOMIDMetadata();

        private readonly RequestForQuotMasterInterface _iRequestForQuotMaster;


        public QuotationMasterController(QuotationMasterInterface iQuotationMaster, ICommonMasterService iCommonMst, SAPItemCollectionInterface sAPItemCollectionInterface, RequestForQuotMasterInterface iRequestForQuotMaster)
        {
            this.iQuotationMaster = iQuotationMaster;
            this.commonMasterService = iCommonMst;
            _sAPItemCollectionInterface = sAPItemCollectionInterface;
            _iRequestForQuotMaster = iRequestForQuotMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            try
            {
                int userid = USERID;
                IQueryCollection query = Request.Query;
                string value = string.Empty;
                Action<IGridColumnCollection<QuotationMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                        .Titled("Sr No")
                        .SetWidth(5);


                    c.Add(o => o.PartyName).Titled("Party Name").SetWidth(20);
                    c.Add(o => o.QuotationCode).Titled("Quotation Code").SetWidth(20);
                    c.Add(o => o.QuotationDate).Titled("Quotation Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                    c.Add(o => o.FinancialYearText).Titled("Quotation FinYear").SetWidth(10);
                    c.Add(o => o.RequestForQuotCode).Titled("RFQ Code").SetWidth(20);
                    c.Add(o => o.RequestForQuotDate).Titled("RFQ Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                    c.Add(o => o.RequestForQuotFinYear).Titled("RFQ FinYear").SetWidth(10);

                    c.Add(o => o.GrossAmount).Titled("Quot Amt").SetWidth(20);

                    //    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    //.RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.QuotationID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.QuotationID}'   data-id='{o.QuotationID}' data-key='{o.QuotationID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    c.Add()
                        .Titled("Edit")
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(20)
                        .Css("hidden-xs")
                         .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/QuotationMaster/Get/id={o.QuotationID}&requestforQuotid=0' ><i class='bx bx-edit'></i></a>");


                };
                PagedDataTable<QuotationMaster> pds = (PagedDataTable<QuotationMaster>)iQuotationMaster.GetAllQuotationMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

                var server = new GridCoreServer<QuotationMaster>(pds, query, false, "QuotationMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
                    .Sortable(true)
                    .Searchable(false, false)
                    .Selectable(true)
                    .WithGridItemsCount()
                    .ChangeSkip(false)
                    .EmptyText("No record found")
                    .ClearFiltersButton(false)
                    .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");


                //return PartialView("_completedQuotationDetail", server.Grid);
                 return View(server.Grid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public PartialViewResult Search(string keyword)
        {
            try
            {

                QuotationSearch model = new QuotationSearch();
                model.keyword = keyword;

                PagedDataTable<QuotationMaster> pds = iQuotationMaster.GetAllQuotationMasterAsync(1, PAGESIZE, keyword, "", "ASC").Result;

                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<QuotationMaster>> columns = c =>
                {
                    c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(5);


                    c.Add(o => o.PartyName).Titled("Party Name").SetWidth(20);
                    c.Add(o => o.QuotationCode).Titled("Quotation Code").SetWidth(20);
                    c.Add(o => o.QuotationDate).Titled("Quotation Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                    c.Add(o => o.FinancialYearText).Titled("Quotation FinYear").SetWidth(10);
                    c.Add(o => o.RequestForQuotCode).Titled("RFQ Code").SetWidth(20);
                    c.Add(o => o.RequestForQuotDate).Titled("RFQ Date").Format("{0:dd/MM/yyyy}").SetWidth(20);
                    c.Add(o => o.RequestForQuotFinYear).Titled("RFQ FinYear").SetWidth(10);

                    c.Add(o => o.GrossAmount).Titled("Quot Amt").SetWidth(20);

                    //c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    //.RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.QuotationID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.QuotationID}'   data-id='{o.QuotationID}' data-key='{o.QuotationID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    c.Add()
                        .Titled("Edit")
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(20)
                        .Css("hidden-xs")
                         //.RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/QuotationMaster/Get/{o.QuotationID}' ><i class='bx bx-edit'></i></a>");
                         .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/QuotationMaster/Get/id={o.QuotationID}&requestforQuotid=0' ><i class='bx bx-edit'></i></a>");

                };
                GridSettings settings = new GridSettings();
                
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<QuotationMaster>(pds, query, false, "QuotationMasterGrid",
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
                //return View("Index", server.Grid);
                return PartialView("_completedQuotationDetail", server.Grid);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }




        #endregion Index Page

        #region "Pending Quotation detail"
        [HttpPost]
        public PartialViewResult PendingSearch(string keyword)
        {
            try
            {

                RequestForQuotSearch model = new RequestForQuotSearch();
                model.keyword = keyword;

                PagedDataTable<RequestForQuotMaster> pds = _iRequestForQuotMaster.GetAllRequestForQuotPendingQuotationAsync(1, PAGESIZE, keyword, "", "ASC").Result;

                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<RequestForQuotMaster>> columns = c =>
                {
                    c.Add()
                .Titled("")
                .Encoded(false)
                .Sanitized(false)
                .Css("hidden-xs") //hide on phones
                .SetWidth(10)
                .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/QuotationMaster/GetSubgridPendingQuot/requestforQuotid={o.RequestForQuotID}' ><iconify-icon icon=\"ei:arrow-down\"></iconify-icon></a>");

                    //c.Add()
                    //.Titled("Open")
                    //.Encoded(false)
                    //.Sanitized(false)
                    //.Css("hidden-xs") //hide on phones
                    //.RenderValueAs(o => $"<a class='btn' onclick='' href='javascript:void(0)' data-id='{o.RequestForQuotID}' data-bs-toggle='offcanvas' data-bs-target='#' aria-controls=''><iconify-icon icon='material-symbols:play-arrow'></iconify-icon></a>").SetWidth(10);
                    //c.Add(o => o.RequestForQuotID).Titled("Request For Quot ID").SetWidth(10);

                    c.Add(o => o.SrNo)
                    .Titled("Sr No")
                    .SetWidth(5);

                    c.Add(o => o.RequestForQuotCode).Titled("RFQ Code").SetWidth(10);

                    c.Add(o => o.RequestForQuotTypeText).Titled("RFQ Type").SetWidth(10);
                    c.Add(o => o.FinancialYear).Titled("Fin Year").SetWidth(10);
                    c.Add(o => o.RequestForQuotDate).Titled("RFQ Date").Format("{0:dd/MM/yyyy}").SetWidth(10);
                    //c.Add(o => o.PartyCode).Titled("Party Code").SetWidth(10);
                    c.Add(o => o.PartyName).Titled("Party Name").SetWidth(15);

                    //c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                    //.RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.RequestForQuotID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.RequestForQuotID}'   data-id='{o.RequestForQuotID}' data-key='{o.RequestForQuotID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    c.Add()
                        .Titled("GoForQuot")
                        .Encoded(false)
                        .Sanitized(false)
                        .SetWidth(5)
                        .Css("hidden-xs") 
                        
                    .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/QuotationMaster/Get/id=0&requestforQuotid={o.RequestForQuotID}' ><i class='bx bx-edit'></i></a>");
                };
                GridSettings settings = new GridSettings();
                
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
                    .Named("RequestForQuotMasterGrid") 
                    .SubGrid("RequestForQuotID")
                    .CommonSettings(settings);
                return PartialView("_pendingQuotationDetail", server.Grid);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        [HttpPost]
        public ActionResult GetSubgridPendingQuot(int requestforQuotid)
        {

            try
            {
                PagedDataTable<RequestForQuotDetail> pds = _iRequestForQuotMaster.GetRequestForQuotDetailAsync(requestforQuotid).Result;

                Action<IGridColumnCollection<RequestForQuotDetail>> columns = c =>
                {


                    c.Add(o => o.SrNo)
                        .Titled("SrNo")
                        .SortInitialDirection(GridShared.Sorting.GridSortDirection.Ascending)
                        .SetWidth(5);


                    c.Add(o => o.ItemCode)
                        .Titled("Item Code")
                        .SetWidth(100);


                    c.Add(o => o.ItemName)
                        .Titled("Item Name")
                        .SetWidth(250);

                    c.Add(o => o.HSNcodes)
                         .Titled("HSN Code")
                         .SetWidth(100);

                    c.Add(o => o.UOM)
                         .Titled("UOM")
                         .SetWidth(50);

                    c.Add(o => o.Qty)
                         .Titled("Quantity")
                         .SetWidth(50).Format("{0:F}");

                    c.Add(o => o.Supl_Qty)
                         .Titled("Supl. Qty")
                         .SetWidth(50).Format("{0:F}");

                    c.Add(o => o.Cancel_Qty)
                         .Titled("Cancel Qty")
                         .SetWidth(50).Format("{0:F}");

                    c.Add(o => o.Remark)
                        .Titled("Remark")
                        .SetWidth(200);
                };

                var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
               // var locale = requestCulture.RequestCulture.UICulture.TwoLetterISOLanguageName;
                var orderDetails = _iRequestForQuotMaster.GetRequestForQuotDetailAsync(requestforQuotid);

                IQueryCollection query = Request.Query;

                var server = new GridCoreServer<RequestForQuotDetail>(pds, query,
                        false, "orderDetailsGrid" + requestforQuotid.ToString(), columns, PAGESIZE, pds.TotalItemCount)
                            .Sortable()
                            .Filterable()
                            .SetStriped(true)
                            .WithMultipleFilters()
                            .WithGridItemsCount()
                         ;
                return PartialView("_SubGrid", server.Grid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }




        #endregion

        #region Quotation Item detail 
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public PartialViewResult QuotationItemDetail(int QuotationID = 0)
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<QuotationDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No");


                //c.Add(o => o.QuotationDetailID).Titled("QuotationDetailID").Hidden=true;
                c.Add(o => o.QuotationID).Titled("Quotation ID").SetWidth(20);
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
                     .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/QuotationMaster/Get/{o.QuotationDetailID}' ><i class='bx bx-edit'></i></a>");

                //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnQuotationMaster(this)' href='javascript:void(0)' data-id='{o.QuotationID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_QuotationMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<QuotationDetail> pds = (PagedDataTable<QuotationDetail>)iQuotationMaster.GetQuotationDetailAsync(QuotationID).Result;

            var server = new GridCoreServer<QuotationDetail>(pds, query, false, "QuotationDetailGrid", columns, 1, pds.TotalItemCount)
                .Sortable()
                .Searchable(false, false)
                .Selectable(true)
                .WithGridItemsCount()
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false)
                .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");


            //return  View(server.Grid);
            return PartialView("QuotationItemDetail", server.Grid);
        }
        #endregion Quotation Item Detail



        #region Slider Page

        [HttpPost]
        public IActionResult Get(int id, int requestforQuotid)
        {
            try
            {
                QuotationMaster model = new QuotationMaster();
                model.QuotationID = id;
                model.RequestForQuotID = requestforQuotid;
                if (Convert.ToInt32(id) > 0 || Convert.ToInt32(requestforQuotid) > 0)
                {
                    model = iQuotationMaster.GetQuotationMasterAsync(id, requestforQuotid).Result;
                    if (model != null)
                    {

                        /*detail = iQuotationMaster.GetQuotationDetailAsync(id).Result;
                        PagedDataTable<QuotationDetail> pds = (PagedDataTable<QuotationDetail>iQuotationMaster.GetQuotationDetailAsync(id).Result;
                        List<QuotationDetail> lst = new List<QuotationDetail>();
                        foreach (var item in pds)
                        {
                            QuotationDetail detail = new QuotationDetail();
                            detail.SrNo = item.SrNo;
                            detail.QuotationDetailID = item.QuotationDetailID;
                            detail.QuotationID = item.QuotationID;
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
                        model.QuotationDetails = lst;*/

                        int i = 0;
                        int userid = USERID;
                        IQueryCollection query = Request.Query;
                        string value = string.Empty;
                        Action<IGridColumnCollection<QuotationDetail>> columns = c =>
                        {
                            c.Add(o => o.SrNo)
                                .Titled("Sr No");

                            c.Add().Titled("QuotationDetailID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.QuotationDetailID}' id='QuotationDetailId{o.SrNo}'>").Hidden = true;

                            c.Add().Titled("Quotation ID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.QuotationID}' id='QuotationId{o.SrNo}'>").Hidden = true;

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
                            //href='/Marketing/QuotationMaster/Get/{o.ItemID}'


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
                            //     .RenderValueAs(o => $"<a  class='fa-2x' href='/Marketing/QuotationMaster/Get/{o.QuotationDetailID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");

                            c.Add()
                                .Titled("Remove")
                                .Encoded(false)
                                .Sanitized(false)
                                .SetWidth(20)
                                .Css("hidden-xs")
                                 .RenderValueAs(o => $"<h5 class='fa-2x pt-1'><a class='MCLFRB' id='btnRemoveRow' onclick='removeRow(this)'><iconify-icon icon='mdi:remove-circle-outline'></iconify-icon></a></h5>");
                            i++;

                            //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnQuotationMaster(this)' href='javascript:void(0)' data-id='{o.QuotationID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_QuotationMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
                        };
                        PagedDataTable<QuotationDetail> pds = (PagedDataTable<QuotationDetail>)iQuotationMaster.GetQuotationDetailAsync(id).Result;

                        var server = new GridCoreServer<QuotationDetail>(pds, query, false, "QuotationDetailGrid", columns, 1, pds.TotalItemCount)
                            .Sortable(false)
                            .Searchable(false, false)
                            .Selectable(true)
                            .WithGridItemsCount()
                            .ChangeSkip(false)
                            .EmptyText("No record found")
                            .ClearFiltersButton(false).Named("QuotationDetailTable")
                            .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");

                        model.iSGrid = server.Grid;
                        //return  View(server.Grid);




                    }
                    return View("AddOrUpdateQuotationMaster", model);
                }
                
                return View("AddOrUpdateQuotationMaster", model);
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

        #region Add or Update QuotationMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateQuotationMaster(QuotationMaster model)
        {

            try
            {
                model.CreatedOrModifiedBy = USERID;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                List<QuotationDetail> sAPUpdateItemStocks = new List<QuotationDetail>();
                if (!string.IsNullOrEmpty(model.SAPCollectionJSONString))
                {
                    #region Creating DataTable 
                    sAPUpdateItemStocks = JsonConvert.DeserializeObject<List<QuotationDetail>>(model.SAPCollectionJSONString);

                    dataTable.Columns.Clear();
                    //dataTable.Columns.Add(new DataColumn("QuotationDetailID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("QuotationID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("ItemID", typeof(int)));
                    //dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("ItemName", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("HSNcodes", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("UOMID", typeof(int)));
                    ////dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
                    //dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));
                    //dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));

                    dataTable.Columns.Add(new DataColumn("QuotationDetailID", typeof(int)));
                    dataTable.Columns.Add(new DataColumn("QuotationID", typeof(int)));
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

                        //dataRow["QuotationDetailID"] = item.QuotationDetailID;
                        //dataRow["QuotationID"] = item.QuotationID;
                        //dataRow["ItemID"] = item.ItemID;
                        //dataRow["ItemCode"] = item.ItemCode;
                        //dataRow["ItemName"] = item.ItemName;
                        //dataRow["HSNcodes"] = item.HSNcodes;
                        //dataRow["UOMID"] = item.UOMID;
                        ////dataRow["UOM"] = item.UOM;
                        //dataRow["Qty"] = item.Qty;
                        //dataRow["Rate"] = item.Rate;
                        //dataRow["TotalAmount"] = item.TotalAmount;

                        dataRow["QuotationDetailID"] = item.QuotationDetailID;
                        dataRow["QuotationID"] = item.QuotationID;
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
                var _QuotationID = await iQuotationMaster.AddOrUpdateQuotationMaster(model, dataTable);

                if (_QuotationID > 0)
                {
                    model.QuotationID = _QuotationID;
                    return Json(new { status = true, message = MessageHelper.Added, orderId = _QuotationID });
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
            PartyAddressTxn PartyAddressTxn = new PartyAddressTxn();
            try
            {
                if (addressTypeId > 0 || partyId > 0)
                {
                    var partyAddressTxn = iQuotationMaster.GetPartyAddressDetail(addressTypeId, partyId).Result;
                    if (PartyAddressTxn != null)
                    {
                        PartyAddressTxn = partyAddressTxn;
                        ViewBag.PartyCode = partyAddressTxn.PartyCode;
                        return PartialView("QuotationPartyAddress", partyAddressTxn);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return PartialView("QuotationPartyAddress", PartyAddressTxn);
        }

        [HttpPost]
        public async Task<IActionResult> QuotationDetailItemDeactivation(int QuotationDetailId, int QuotationId)
        {
            try
            {
                if (QuotationDetailId > 0 && QuotationId > 0)
                {
                    var _QuotationDetailId = await iQuotationMaster.QuotationDetailItemDeactivationAsync(QuotationDetailId, QuotationId, USERID);
                    if (_QuotationDetailId>0)
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
        #endregion Add or Update QuotationMaster 

        #region GetSAPItemCollection

        [HttpGet]
        public IActionResult GetSAPItemCollection(string search = "", [FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", string itemGroup = "", string wareHouse = "")
        {
            try
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
                    //   .RenderValueAs(o => $"<a href='SAPItemCollection/GetPartyListByItemCode?itemCode={o.ItemCode}'>{o.FinishGoodName}</a>");

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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion GetSAPItemCollection
    }
}
