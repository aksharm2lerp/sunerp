using Business.Entities.Marketing.QuotationMasterModel;
using Business.Entities.Marketing.TravellingExpenseDetailModel;
using Business.Interface.Marketing.ITravellingExpenseDetail;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using FileResult = Microsoft.AspNetCore.Mvc.FileResult;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("TravellingExpenseDetail")]
    public class TravellingExpenseDetailController : SettingsController
    {
        private readonly TravellingExpenseDetailInterface iTravellingExpenseDetail;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string linkTravellingExpenseBillsImages;
        public TravellingExpenseDetailController(TravellingExpenseDetailInterface iTravellingExpenseDetail, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.iTravellingExpenseDetail = iTravellingExpenseDetail;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            linkTravellingExpenseBillsImages = _configuration.GetSection("TravellingExpenseBillsImages")["TravellingExpenseBillsImagesPath"];
        }

        #region Index_old Page
        public IActionResult Index_old([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<TravellingExpenseDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("Sr No.")
                    .SetWidth(10);

                ////c.Add(o => o.TravellingExpenseDetailText).Titled("Feedback Notes").SetWidth(70);

                c.Add(o => o.PartyName).Titled("Party Name").SetWidth(20);
                c.Add(o => o.TravellingDate).Titled("Travelling Date").SetWidth(20);
                c.Add(o => o.FromLocation).Titled("From Location").SetWidth(20);
                c.Add(o => o.ToLocation).Titled("To Location").SetWidth(20);
                c.Add()
                    .Titled("Bill Files")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn editaddress IndexPagebtnEidtPadding' href='/Marketing/TravellingExpenseDetail/DownloadBillFile?filename={o.TravellingExpenseBillsImagesText}'><iconify-icon icon='emojione-monotone:open-file-folder'></iconify-icon> {o.TravellingExpenseBillsImagesText}</a>");
                //<a class='btn editaddress IndexPagebtnEidtPadding' asp-area='Marketing' asp-controller='TravellingExpenseDetail' asp-action='DownloadBillFile' asp-route-filename='{o.TravellingExpenseBillsImagesText}'download><iconify-icon icon = 'emojione-monotone:open-file-folder' ></ iconify - icon > {o.TravellingExpenseBillsImagesText}</a>
                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnTravellingExpenseDetail(this)' href='javascript:void(0)' data-id='{o.TravellingExpenseDetailID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_TravellingExpenseDetail' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<TravellingExpenseDetail> pds = (PagedDataTable<TravellingExpenseDetail>)iTravellingExpenseDetail.GetAllTravellingExpenseDetailAsyncOld(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<TravellingExpenseDetail>(pds, query, false, "TravellingExpenseDetailGrid", columns, PAGESIZE, pds.TotalItemCount)
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

        #endregion Index_old Page

        #region Slider Page

        [HttpGet]
        public PartialViewResult Get(int id, int key)
        {
            try
            {
                TravellingExpenseDetail model = new TravellingExpenseDetail();
                model.TravellingExpenseDetailID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iTravellingExpenseDetail.GetTravellingExpenseDetailAsync(id).Result;

                    return PartialView("AddOrUpdateTravellingExpenseDetail", model);
                }
                return PartialView("AddOrUpdateTravellingExpenseDetail", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update TravellingExpenseDetail 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateTravellingExpenseDetail(TravellingExpenseDetail model)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Clear();
                dataTable.Columns.Add(new DataColumn("TravellingExpenseBillsImagesID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("TravellingExpenseDetailID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("TravellingExpenseBillsImagesText", typeof(string)));
                dataTable.Columns.Add(new DataColumn("TravellingExpenseBillsImagesPath", typeof(string)));
                dataTable.Columns.Add(new DataColumn("IsActive", typeof(bool)));

                model.CreatedOrModifiedBy = USERID;
                model.IsActive = true;
                if (model.TravelExpenseImage.Count > 0)
                {
                    if (model.TravellingExpenseDetailID == 0)
                    {
                        int imageCount = 1;
                        foreach (var file in model.TravelExpenseImage)
                        {
                            //string filename = file.FileName;
                            string fileExtension = Path.GetExtension(file.FileName);
                            string filename = "Bill_" + imageCount + "_" + USERID + "_" + model.PartyID + "_" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace("-", "").Replace(":", "") + fileExtension;
                            //Above filename is created in this formate Bill_1_30_238_170520241626.jpg (Bill_ImageCount_UserID_PartyID_DateTime.jpg)
                            filename = Path.GetFileName(filename);
                            string uploadpathPhysical = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images\\TravellingExpenseBillsImages", filename);
                            string uploadpathDB = Path.Combine("\\assets\\images\\TravellingExpenseBillsImages", filename);
                            DataRow dataRow = dataTable.NewRow();
                            dataRow["TravellingExpenseBillsImagesID"] = 0;
                            dataRow["TravellingExpenseDetailID"] = 0;
                            dataRow["TravellingExpenseBillsImagesText"] = filename;
                            dataRow["TravellingExpenseBillsImagesPath"] = uploadpathDB;
                            dataRow["IsActive"] = true;
                            dataTable.Rows.Add(dataRow);
                            var stream = new FileStream(uploadpathPhysical, FileMode.Create);
                            file.CopyTo(stream);
                            imageCount++;
                            stream.Dispose();
                            stream.Close();
                        }
                    }
                    else
                    {
                        int imageCount = 1;
                        foreach (var file in model.TravelExpenseImage)
                        {
                            //string filename = file.FileName;
                            string fileExtension = Path.GetExtension(file.FileName);
                            string filename = "Bill_" + imageCount + "_" + USERID + "_" + model.PartyID + "_" + model.TravellingExpenseDetailID + "_" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace("-", "").Replace(":", "") + fileExtension;
                            //Above filename is created in this formate Bill_1_30_238_1_170520241626.jpg (Bill_ImageCount_UserID_PartyID_TravellingExpenseDetailID_DateTime.jpg)
                            filename = Path.GetFileName(filename);
                            string uploadpathPhysical = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images\\TravellingExpenseBillsImages", filename);
                            string uploadpathDB = Path.Combine("\\assets\\images\\TravellingExpenseBillsImages", filename);
                            DataRow dataRow = dataTable.NewRow();
                            dataRow["TravellingExpenseBillsImagesID"] = 0;
                            dataRow["TravellingExpenseDetailID"] = 0;
                            dataRow["TravellingExpenseBillsImagesText"] = filename;
                            dataRow["TravellingExpenseBillsImagesPath"] = uploadpathDB;
                            dataRow["IsActive"] = true;
                            dataTable.Rows.Add(dataRow);
                            var stream = new FileStream(uploadpathPhysical, FileMode.Create);
                            file.CopyTo(stream);
                            imageCount++;
                            stream.Dispose();
                            stream.Close();
                        }
                    }
                }

                var _TravellingExpenseDetailID = await iTravellingExpenseDetail.AddOrUpdateTravellingExpenseDetail(model, dataTable);

                //if (_TravellingExpenseDetailID > 0)
                //{
                //    model.TravellingExpenseDetailID = _TravellingExpenseDetailID;
                //    //return Json(new { status = true, message = MessageHelper.Added });
                //    return View("Index");
                //}
                //else
                //return Json(new { status = false, message = MessageHelper.Error });
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        #endregion Add or Update TravellingExpenseDetail 

        #region Download Bills
        [HttpPost]
        public FileResult DownloadBillFile(string filename)
        {
            try
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(@_webHostEnvironment.WebRootPath + linkTravellingExpenseBillsImages + filename);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion Download Bills

        #region New Index Page
        [HttpGet]
        public async Task<PartialViewResult> Index()
        {
            try
            {
                int userid = USERID;
                TravellingExpenseDetail travellingExpenseDetail = new TravellingExpenseDetail();
                travellingExpenseDetail = await iTravellingExpenseDetail.GetAllTravellingExpenseDetailAsync(userid);
                return PartialView(travellingExpenseDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion New Index Page

        #region Get Travelling Expense Status

        [HttpGet]
        public async Task<PartialViewResult> TravellingExpenseStatus(int TEDID) //TEDID=TravellingExpenseDetailID
        {
            try
            {
                TravellingExpenseStatus travellingExpenseStatus = new TravellingExpenseStatus();
                travellingExpenseStatus = iTravellingExpenseDetail.TravellingExpenseStatus(TEDID).Result;
                return PartialView("_addUpdateTravellingExpenseStatus", travellingExpenseStatus);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Add Update Quotation Approval Type
        [HttpPost]
        public async Task<IActionResult> AddTravellingExpenseStatus(TravellingExpenseStatus model)
        {
            try
            {
                model.CreatedOrModifiedBy = USERID;
                var travellingExpenseStatusID = await iTravellingExpenseDetail.AddTravellingExpenseStatus(model);

                if (travellingExpenseStatusID > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

    }
}
