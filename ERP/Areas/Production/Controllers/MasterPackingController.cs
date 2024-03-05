using Business.Entities.Marketing.SAPItem;
using Business.Entities.PartyMasterModel;
using Business.Entities.Production.ItemQRCodeDetailModel;
using Business.Entities.Production.MasterPackingModel;
using Business.Entities.SalesDistribution.SalesOrderMasterModel;
using Business.Interface.Production.IMasterPacking;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Production.Controllers
{
    [Area("Production"), Authorize]
    [DisplayName("MasterPacking")]
    public class MasterPackingController : SettingsController
    {
        private readonly MasterPackingInterface iMasterPacking;
        public MasterPackingController(MasterPackingInterface iMasterPacking)
        {
            this.iMasterPacking = iMasterPacking;
        }

        #region Index Page
        [System.Web.Mvc.HttpGet]
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MasterPacking>> columns = c =>
            {
                c.Add(o => o.IsSelect, "Select").Titled("Select").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs").RenderValueAs(o => $"<input type='checkbox' class='form-check-input' name='PMIActiveInactive' value='{o.MasterPackingID}' id='{"PMIActiveInactive" + o.MasterPackingID}'   href='javascript:void(0)' data-rowid='{"PMIActiveInactive" + o.MasterPackingID}'data-id='{o.MasterPackingID}' data-key='{o.MasterPackingID}'>");


                c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(5);
                c.Add(o => o.MasterPackingCode).Titled("MasterPacking Code").SetWidth(20);
                c.Add(o => o.BatchNo).Titled("Batch No").SetWidth(5);
                c.Add(o => o.UserBatchCode).Titled("UserBatch Code").SetWidth(20);
                c.Add(o => o.ScannedBy).Titled("Scanned By").SetWidth(10);
                c.Add(o => o.CreatedDate).Titled("Scanned Date").SetWidth(10);
                c.Add(o => o.NoOfItems).Titled("No Of Items").SetWidth(5);



                c.Add(o => o.IsTakenPrint).Titled("Print Taken").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.MasterPackingID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.MasterPackingID}' data-approval='HOD' data-id='{o.MasterPackingID}' data-key='{o.MasterPackingID}' " + (o.IsTakenPrint ? "checked" : "unchecked") + " disabled >");

                //   c.Add().Titled("Print").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                //.RenderValueAs(o => $"<a class='fa-2x' onclick='fnPrintQR(this)' href='javascript:void(0)'  data-id='{o.MasterPackingID}'><iconify-icon icon='arcticons:mobile-print'></iconify-icon>   </a>");

                c.Add().Titled("Print").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
             .RenderValueAs(o => $"<a class='fa-2x' onclick='fnPrintOnlyQR(this)' href='javascript:void(0)'  data-id='{o.MasterPackingID}'><iconify-icon icon='arcticons:mobile-print'></iconify-icon>   </a>");

                c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                .RenderValueAs(o => $"<a class='fa-2x' onclick='fnMasterPacking(this)' href='javascript:void(0)' data-id='{o.MasterPackingID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MasterPacking' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MasterPacking> pds = (PagedDataTable<MasterPacking>)iMasterPacking.GetAllMasterPackingAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MasterPacking>(pds, query, false, "MasterPackingGrid", columns, PAGESIZE, pds.TotalItemCount)
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

                MasterPackingSearch model = new MasterPackingSearch();
                model.keyword = keyword;

                PagedDataTable<MasterPacking> pds = iMasterPacking.GetAllMasterPackingAsync(1, PAGESIZE, keyword, "", "ASC").Result;

                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<MasterPacking>> columns = c =>
                {
                    c.Add(o => o.IsSelect, "Select").Titled("Select").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs").RenderValueAs(o => $"<input type='checkbox' class='form-check-input' name='PMIActiveInactive' value='{o.MasterPackingID}' id='{"PMIActiveInactive" + o.MasterPackingID}'   href='javascript:void(0)' data-rowid='{"PMIActiveInactive" + o.MasterPackingID}'data-id='{o.MasterPackingID}' data-key='{o.MasterPackingID}'>");


                    c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(5);
                    c.Add(o => o.MasterPackingCode).Titled("MasterPacking Code").SetWidth(20);
                    c.Add(o => o.BatchNo).Titled("Batch No").SetWidth(5);
                    c.Add(o => o.UserBatchCode).Titled("UserBatch Code").SetWidth(20);
                    c.Add(o => o.ScannedBy).Titled("Scanned By").SetWidth(10);
                    c.Add(o => o.CreatedDate).Titled("Scanned Date").SetWidth(10);
                    c.Add(o => o.NoOfItems).Titled("No Of Items").SetWidth(5);



                    c.Add(o => o.IsTakenPrint).Titled("Print Taken").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.MasterPackingID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.MasterPackingID}' data-approval='HOD' data-id='{o.MasterPackingID}' data-key='{o.MasterPackingID}' " + (o.IsTakenPrint ? "checked" : "unchecked") + " disabled >");

                    c.Add().Titled("Print").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                    .RenderValueAs(o => $"<a class='fa-2x' onclick='fnPrintQR(this)' href='javascript:void(0)'  data-id='{o.MasterPackingID}'><iconify-icon icon='arcticons:mobile-print'></iconify-icon>   </a>");

                    c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(5).Css("hidden-xs")
                    .RenderValueAs(o => $"<a class='fa-2x' onclick='fnMasterPacking(this)' href='javascript:void(0)' data-id='{o.MasterPackingID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MasterPacking' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<MasterPacking>(pds, query, false, "MasterPackingGrid",
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
        public PartialViewResult Get(int id, bool isPrint = false)
        {
            try
            {
                MasterPacking model = new MasterPacking();
                model.MasterPackingID = id;
                int userid = USERID;
                IQueryCollection query = Request.Query;
                string value = string.Empty;
                if (Convert.ToInt32(id) > 0)
                {
                    var dualResults = iMasterPacking.GetMasterPackingAsync(id).Result;
                    model = dualResults.Item1 as MasterPacking;
                    //PagedDataTable<ScannedItemDetail> pds = dualResults.Item2;

                    #region MVC Grid Block

                    Action<IGridColumnCollection<ScannedItemDetail>> columns = c =>
                    {
                        c.Add(o => o.SrNo).Titled("Sr No");
                        c.Add().Titled("MasterPackingDetailID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.MasterPackingDetailID}'>").Hidden = true;
                        c.Add().Titled("MasterPackingID").Encoded(false)
                                .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.MasterPackingID}'>").Hidden = true;
                        c.Add(o => o.DocEntry).Titled("Doc Entry");
                        c.Add(o => o.PostDate).Titled("Post Date");
                        c.Add(o => o.Goods_Receipt_No).Titled("Goods Receipt No");
                        c.Add(o => o.OrderQty).Titled("OrderQty");
                        c.Add(o => o.ItemCode).Titled("ItemCode");
                        c.Add(o => o.ProdName).Titled("Item");
                        c.Add(o => o.BatchQty).Titled("BatchQty");
                        c.Add(o => o.BatchNum).Titled("BatchNum");
                        c.Add(o => o.CardName).Titled("CardName");
                        c.Add().Titled("Qr Code").Encoded(false)
                        .Sanitized(false).RenderValueAs(o => $"<input type='hidden' class='form-control' value='{o.QRCode}'>").Hidden = true;
                        c.Add().Titled("Remove").Encoded(false).Sanitized(false)
                             .RenderValueAs(o => $"<h5 class='fa-2x pt-1'><a class='MCLFRB' id='btnRemoveRow' onclick='removeRow(this)'><iconify-icon icon = 'mdi:remove-circle-outline'></iconify-icon></a></h5>");
                    };
                    var server = new GridCoreServer<ScannedItemDetail>(dualResults.Item2, query, false, "ScannedItemDetailGrid", columns, 1, dualResults.Item2.TotalItemCount)
                        .Sortable()
                        .Searchable(false, false)
                        .Selectable(true)
                        .WithGridItemsCount()
                        .ChangeSkip(false)
                        .EmptyText("No record found")
                        .ClearFiltersButton(false)
                        .WithPaging(PAGESIZE, dualResults.Item2.TotalItemCount, PAGESIZE, "grid-page");
                    model.iSGrid = server.Grid;

                    #endregion MVC Grid Block

                    if (isPrint)
                        return PartialView("_printQrCode", model);
                    else
                        return PartialView("AddOrUpdateMasterPacking", model);
                }
                else
                {
                    model = iMasterPacking.GetMasterPackingCodeReturnAsync(USERID).Result;
                }
                return PartialView("AddOrUpdateMasterPacking", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MasterPacking 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMasterPacking(MasterPacking model)
        {
            try
            {
                List<MasterPackingDetail> listMasterPackingDetail = new List<MasterPackingDetail>();
                DataTable dataTable = new DataTable();
                #region Creating DataTable 
                listMasterPackingDetail = JsonConvert.DeserializeObject<List<MasterPackingDetail>>(model.ScannedItemsArray);

                dataTable.Columns.Clear();

                dataTable.Columns.Add(new DataColumn("MasterPackingDetailID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("MasterPackingID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("GoodsReceiptNo", typeof(decimal)));
                dataTable.Columns.Add(new DataColumn("BatchNum", typeof(string)));
                dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dataTable.Columns.Add(new DataColumn("IsActive", typeof(bool)));
                dataTable.Columns.Add(new DataColumn("CreatedOrModifiedBy", typeof(int)));

                foreach (var item in listMasterPackingDetail)
                {
                    DataRow dataRow = dataTable.NewRow();

                    dataRow["MasterPackingDetailID"] = item.MasterPackingDetailID;
                    dataRow["MasterPackingID"] = item.MasterPackingID;
                    dataRow["GoodsReceiptNo"] = item.GoodsReceiptNo;
                    dataRow["BatchNum"] = item.BatchNum;
                    dataRow["ItemCode"] = item.ItemCode;
                    dataRow["IsActive"] = true;
                    dataRow["CreatedOrModifiedBy"] = USERID;

                    dataTable.Rows.Add(dataRow);
                }

                #endregion Creating DataTable 

                model.CreatedOrModifiedBy = USERID;
                var _PackingID = await iMasterPacking.AddOrUpdateMasterPacking(model, dataTable);

                //if (_PackingID > 0)
                //{
                model.MasterPackingID = _PackingID;
                return Json(new { status = true, message = MessageHelper.Added });
                //}
                //else
                //    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #endregion Add or Update MasterPacking 

        #region "Get Item detail by QRCode"
        //public async Task<ItemQRCodeDetail> GetItemQRCodeDetailAsync(int ItemQRCodeDetailID)
        //{
        //    ItemQRCodeDetail result = null;
        //    try
        //    {
        //        SqlParameter[] param = { new SqlParameter("@ItemQRCodeDetailID", ItemQRCodeDetailID) };
        //        DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_ItemQRCodeDetail", param);
        //        if (ds != null)
        //        {
        //            if (ds.Tables.Count > 0)
        //            {
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    DataRow dr = ds.Tables[0].Rows[0];
        //                    result = dr.ToPagedDataTableList<ItemQRCodeDetail>();
        //                }
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [System.Web.Mvc.HttpGet]
        public async Task<IActionResult> GetItemDetailByScannedQRCode(string qrCodeStr)
        {

            /*
            ScannedItemDetail model = new ScannedItemDetail();
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<ScannedItemDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No");
                c.Add(o => o.DocEntry).Titled("Doc Entry").SetWidth(20);
                c.Add(o => o.PostDate).Titled("Post Date");
                c.Add(o => o.Goods_Receipt_No).Titled("Goods Receipt No");
                c.Add(o => o.OrderQty).Titled("OrderQty");
                c.Add(o => o.ItemCode).Titled("ItemCode");
                c.Add(o => o.ProdName).Titled("Item");
                c.Add(o => o.BatchQty).Titled("BatchQty");
                c.Add(o => o.BatchNum).Titled("BatchNum");
                c.Add(o => o.CardName).Titled("CardName");
            c.Add()
                .Titled("Edit")
                .Encoded(false)
                .Sanitized(false)
                .SetWidth(20)
                .Css("hidden-xs")
                 .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/SalesDistribution/SalesOrderMaster/Get/{o.SalesOrderDetailID}' ><i class='bx bx-edit'></i></a>");
            .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnSalesOrderMaster(this)' href='javascript:void(0)' data-id='{o.SalesOrderID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_SalesOrderMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            model = await iMasterPacking.GetScannedItemDetailAsync(qrCodeStr);
            var server = new GridCoreServer<ScannedItemDetail>(pds, query, false, "ScannedItemDetailGrid", columns, 1, pds.TotalItemCount)
                .Sortable()
                .Searchable(false, false)
                .Selectable(true)
                .WithGridItemsCount()
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false)
                .WithPaging(PAGESIZE, pds.TotalItemCount, PAGESIZE, "grid-page");
            model.iSGrid = server.Grid;
            if (model != null)
                return Json(new { status = true, model });
            else return Json(new { status = false });
            */

            try
            {
                ScannedItemDetail model = new ScannedItemDetail();

                model = await iMasterPacking.GetScannedItemDetailAsync(qrCodeStr);

                if (model != null)
                    return Json(new { status = true, model });

                else return Json(new { status = false });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #endregion

        #region Multiple Print Master Packing QR Code 

        [HttpGet]
        public IActionResult MultiplePrint(string ids, bool isPrint = false)
        {
            try
            {
                List<MasterPacking> listMasterPackingQRCode = iMasterPacking.GetMultiplePrintMasterPackingAsync(ids, USERID).Result;
                if (listMasterPackingQRCode.Count > 0)
                    return PartialView("_printMultipleQrCode ", listMasterPackingQRCode);

                else
                    return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Multiple Print Master Packing QR Code
    }
}