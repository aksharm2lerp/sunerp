using Business.Interface.Marketing.ISAPItemCollection;
using ERP.Controllers;
using System;
using Business.SQL;
using Microsoft.AspNetCore.Http;
using GridShared;
using GridCore.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.Entities.Marketing.SAPItem;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Web.Razor.Parser.SyntaxTree;
using Business.Entities.Employee;
using Business.Entities.ProductPhotoPath;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    public class SAPItemCollectionController : SettingsController
    {
        #region Interface

        private readonly SAPItemCollectionInterface _sAPItemCollectionInterface;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly string SAPItemCollectionDocumentation;
        public SAPItemCollectionController(SAPItemCollectionInterface sAPItemCollectionInterface, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _sAPItemCollectionInterface = sAPItemCollectionInterface;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            SAPItemCollectionDocumentation = _configuration.GetSection("SAPItemCollectionDocumentationPath")["SAPItemCollectionDocumentation"];
        }

        #endregion Interface

        #region Index Page

        [HttpGet]
        public IActionResult Index(string search = "", [FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", string itemGroup = "", string wareHouse = "")
        {
            if (string.IsNullOrEmpty(search))
            {
                search = null;
                ViewData["SearchString"] = null;
            }
            else
            {
                search = search.Replace(",", "%");
                ViewData["SearchString"] = search.Replace("%", ",");
            }

            int userid = USERID;
            IQueryCollection query = Request.Query;
            ViewData["ItemGroup"] = itemGroup;
            ViewData["WareHouse"] = wareHouse;

            Action<IGridColumnCollection<SAPUpdateItemStock>> columns = c =>
            {
                //c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                c.Add(o => o.WareHouse).Titled("WareHouse");
                c.Add(o => o.ItemGroupName).Titled("Group Name");

                //c.Add(o => o.FinishGoodName).Titled("Item Name").Sortable(true);  Old Code

                c.Add().Titled("Item Name").Encoded(false).Sanitized(false).Css("hidden-xs").RenderValueAs(o => $"<a onclick='fnOpenBuyerList(this)' href='javascript:void(0)' data-id='{o.ItemCode}' data-name='{o.FinishGoodName}' data-bs-toggle='offcanvas' data-bs-target='#canvasEmployeeGatepass' data-key='' aria-controls='canvasEmployeeGatepass'>{o.FinishGoodName}</a>");

                //c.Add().Titled("Item Name").Encoded(false).Sanitized(false).Css("hidden-xs")
                //   .RenderValueAs(o => $"<a href='SAPItemCollection/GetCustomerListByItemCode?itemCode={o.ItemCode}'>{o.FinishGoodName}</a>");

                c.Add(o => o.CoilLenght).Titled("Coil Lenght");
                c.Add(o => o.NoOfCoils).Titled("Coils");
                c.Add(o => o.TotalMtr).Titled("Total Mtr");
                c.Add(o => o.BinLocation).Titled("Bin Location");
                c.Add(o => o.AgingInDays).Titled("Aging(Days)");

            };
            PagedDataTable<SAPUpdateItemStock> pds = _sAPItemCollectionInterface.GetAllSAPItemStockList(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC", itemGroup, wareHouse).Result;
            var server = new GridCoreServer<SAPUpdateItemStock>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable(false).ClearFiltersButton(false).Selectable(true).WithGridItemsCount().ChangeSkip(false).EmptyText("No record found");
            return View(server.Grid);
        }
        #endregion Index Page

        #region Get customer list by ItemCode.
        [HttpGet]
        public async Task<IActionResult> GetCustomerListByItemCode(string itemCode)
        {
            try
            {
                List<CustomerListByItemCodeModel> customerListByItemCodes = new List<CustomerListByItemCodeModel>();
                if (!string.IsNullOrEmpty(itemCode))
                {
                    var dataTable = await _sAPItemCollectionInterface.GetCustomerListByItemCodeAsync(itemCode);
                    if (dataTable.Rows.Count > 0)
                    {
                        customerListByItemCodes = dataTable.AsEnumerable().Select(y => new CustomerListByItemCodeModel { CustomerName = y.Field<string>("Customer Name"), Volume = y.Field<decimal>("Volume") }).ToList();
                        return Json(new { status = true, customerListByItemCodes });
                    }
                    else
                        return Json(new { status = false, message = "No data found." });
                }
                else
                    return Json(new { status = false, message = "No data found." });
                //return PartialView("_customerListByItemCode", dataTable);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Get customer list by ItemCode.

        #region Get customer sales detail by customer name and item code.

        [HttpGet]
        public async Task<IActionResult> GetClientSalesSummary(string itemCode, string customerName)
        {
            try
            {
                List<ClientSalesSummaryModel> listClientSalesSummaryModel = new List<ClientSalesSummaryModel>();
                if (!string.IsNullOrEmpty(itemCode))
                {
                    var dataTable = await _sAPItemCollectionInterface.GetClientSalesSummaryAsync(itemCode, customerName);
                    if (dataTable.Rows.Count > 0)
                    {
                        listClientSalesSummaryModel = dataTable.AsEnumerable().Select(y => new ClientSalesSummaryModel { MonthYear = y.Field<string>("Month - Year"), Volume = y.Field<decimal>("Volume") }).ToList();
                        return Json(new { status = true, listClientSalesSummaryModel });
                    }
                    else
                        return Json(new { status = false, message = "No data found." });
                }
                else
                    return Json(new { status = false, message = "No data found." });
                //return PartialView("_customerListByItemCode", dataTable);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Get customer sales detail by customer name and item code.

        #region SPA Item Collection Documentation Download
        public FileResult OpenDocument(string fileName)
        {
          
            var fileStream = new FileStream(_webHostEnvironment.WebRootPath + SAPItemCollectionDocumentation + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return File(fileStream, "application/pdf");

           
        }
        #endregion SPA Item Collection Documentation Download

        #region Get Item Document List
        [HttpGet]
        public async Task<PartialViewResult> GetItemDocumentList()
        {
            try
            {
                ProductPhotoPath productDetails = new ProductPhotoPath();
                productDetails = _sAPItemCollectionInterface.GetItemDocumentList().Result;
                return PartialView("ItemDocumentList", productDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Get Item Document List


        public ActionResult ItemStockDashboard()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #region Executive Performance Summary
        public ActionResult ExecutivePerformanceSummary()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Executive Performance Summary

        #region Executive Activity Summary
        public ActionResult ExecutiveActivitySummary()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Executive Activity Summary

    }
}
