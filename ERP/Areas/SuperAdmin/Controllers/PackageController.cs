using Business.Interface;
using Business.Entities.Master.Package;
using Business.Entities.PackageFormTxn;
using Business.Interface.Marketing.IPackage;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Newtonsoft.Json;
using System.Data;
using System.Linq;

namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    [DisplayName("Package")]
    public class PackageController : SettingsController
    {

        private readonly IPackageService _iPackageService;
        private readonly IMasterService _masterService;
        public PackageController(IPackageService iPackageService, IMasterService masterService)
        {
            _iPackageService = iPackageService;
            _masterService = masterService;
        }

        #region Package Index Page Start
        public IActionResult Index()
        {
            List<PackageMaster> packageList = _iPackageService.GetAllPackageAsync().Result;
            return View(packageList);
        }
        //07-12-2022 Below code working fine but it is comment because output shown in grid form. But we want to dispaly in card form. Dravesh Lokhande. 
        //public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        //{
        //    int userid = USERID;
        //    IQueryCollection query = Request.Query;

        //    Action<IGridColumnCollection<PackageMaster>> columns = c =>
        //    {
        //        c.Add(o => o.SrNo)
        //            .Titled("SrNo")
        //            .SetWidth(10);

        //        c.Add(o => o.PackageName)
        //            .Titled("Package Name")
        //            .SetWidth(70);

        //        c.Add(o => o.Description)
        //            .Titled("Description")
        //            .SetWidth(160);

        //        c.Add(o => o.IsActive)
        //            .Titled("Status")
        //            .SetWidth(160);

        //        c.Add()
        //            .Titled("Edit")
        //            .Encoded(false)
        //            .Sanitized(false)
        //            .SetWidth(60)
        //            .Css("hidden-xs") //hide on phones
        //            .RenderValueAs(o => $"<a class='btn' onclick='fnPackage(this)' href='javascript:void(0)' data-id='{o.PackageID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_Package' aria-controls='canvas_Package' ><i class='bx bx-edit'></i></a>");
        //    };
        //    PagedDataTable<PackageMaster> pds = _iPackageService.GetAllPackageAsync(gridpage.ToInt(),
        //        PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
        //    var server = new GridCoreServer<PackageMaster>(pds, query, false, "ordersGrid",
        //        columns, PAGESIZE, pds.TotalItemCount)
        //        .Sortable()
        //        //.Filterable()
        //        //.WithMultipleFilters()
        //        .Searchable(true, false)
        //        //.Groupable(true)
        //        .ClearFiltersButton(true)
        //        .Selectable(true)
        //        //.SetStriped(true)
        //        //.ChangePageSize(true)
        //        .WithGridItemsCount()
        //        //.WithPaging(PAGESIZE, pds.TotalItemCount)
        //        .ChangeSkip(false)
        //        .EmptyText("No record found")
        //        .ClearFiltersButton(false);
        //    return View("Index", server.Grid);
        //}
        #endregion        

        #region Package silder Start 

        [HttpPost]
        public PartialViewResult Get(int id)
        {
            System.Diagnostics.Debug.WriteLine("id-- " + id);
            try
            {
                PackageMaster model = new PackageMaster();

                var PackageTypeMasterList = _masterService.GetAllPackageTypeMasterAsync();
                ViewData["PackageTypeText"] = new SelectList(PackageTypeMasterList, "PackageTypeID", "PackageTypeText");

                if (id > 0)
                {
                    model = _iPackageService.GetPackageAsync(id).Result;
                    return PartialView("IUPackage", model);
                }
                else
                {
                    return PartialView("IUPackage", model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion

        #region Package Insert or Update Page Start

        [HttpPost]
        public async Task<IActionResult> IOrUPackage(PackageMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _PackagetID = await _iPackageService.InsertOrUpdatePackageAsync(model);

            if (_PackagetID > 0)
            {
                model.PackageID = _PackagetID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
        }

        #endregion

        #region Package Detail Page Start


        public ActionResult Detail2(int packageid, [FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            System.Diagnostics.Debug.WriteLine("-----PackageID======" + packageid);
            int userid = USERID;
            IQueryCollection query = Request.Query;

            Action<IGridColumnCollection<PackageFormTxn>> columns = c =>
            {

                c.Add(o => o.SrNo).Titled("SrNo").SetWidth(10);
                c.Add(o => o.FormName).Titled("Form Name").SetWidth(70);
                c.Add().Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs").RenderValueAs(o => $"<input type = 'hidden'  href='javascript:void(0)' class='packageFormActiveInactive' value='{o.FormID}' />");
                c.Add().Titled("Check for Assign").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs").RenderValueAs(o => $"<input type = 'checkbox' class='form-check-input' asp-for='{o.IsActive}' />");

                c.Add().Titled("Check for Assign").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs").RenderValueAs(o => $"<input type='checkbox' class='form-check-input' asp-for={o.IsActive}'>");

                //({o.IsActive} = 'false' ? unchecked : checked)

                /* onchange='fnPackageFormActiveInactive({o.PackageID}, {o.FormID})'*/
                /* value = '{o.IsActive}' asp -for= '{o.IsActive}'*/
                /*c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn' onclick='fnPackage(this)' href='javascript:void(0)' data-id='{o.PackageID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_Package' aria-controls='canvas_Package' ><i class='bx bx-edit'></i></a>");*/
            };
            PagedDataTable<PackageFormTxn> pds = _iPackageService.GetAllPackageDetailAsync(packageid, gridpage.ToInt(),
                10000, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            System.Diagnostics.Debug.WriteLine("-----PackageName-----" + pds);

            ViewBag.PackageName = pds.SearchText;
            ViewBag.PackageID = packageid;

            var server = new GridCoreServer<PackageFormTxn>(pds, query, false, "ordersGrid",
                columns, 10000, pds.TotalItemCount)
                .Sortable()
                .Searchable(false, false)
                .ClearFiltersButton(true)
                .Selectable(true)
                .EmptyText("No record found")
                .ChangeSkip(false)
                .ClearFiltersButton(false);
            return View("Detail", server.Grid);

        }

        #endregion

        #region Test Detail

        public IActionResult Detail(int packageid)
        {            
            List<PackageFormTxn> list = _iPackageService.GetAllPackageDetailAsync(packageid, 1,
                10000, "", "", "").Result.OrderBy(o=>!o.IsActive).ToList();
            ViewBag.PackageName = list.Select(x => x.PackageName).FirstOrDefault();
            ViewBag.PackageID = packageid;
            return View("Detail", list);
        }

        #endregion Test

        #region Package Form Active Inactive Start

        /*[HttpPost]
        public async Task<IActionResult> ActiveInActivePackageForm( int packageID, int formID, bool isActive)
        {
            PackageFormTxn packageFormTxn = new PackageFormTxn()
            {
                PackageID = packageID,
                FormID = formID,                
                IsActive = isActive,
                CreatedOrModifiedBy = USERID
            };
            int modifiedBy = USERID;
            int packageFormIsActive = await _iPackageService.ActiveInActivePackageForm(packageFormTxn);
            if (packageFormIsActive > 0)
            {
                if (isActive)
                    return Json(new { status = true, message = MessageHelper.ActivatedDocument });
                else
                    return Json(new { status = true, message = MessageHelper.InactivatedDocument });
            }
            else
                return Json(new { status = true, message = MessageHelper.Error });
        }*/

        [HttpPost]
        public async Task<IActionResult> AssingFormToPackage(string tableData)
        {
            int modifiedBy = USERID;

            List<PackageFormTxn> listTableData = JsonConvert.DeserializeObject<List<PackageFormTxn>>(tableData);
            var test = listTableData;
            #region Creating DataTable.
            DataTable dataTable = new DataTable();
            dataTable.Columns.Clear();
            dataTable.Columns.Add(new DataColumn("PackageFormID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("PackageID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("FormID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("AddNew", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Edit", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Cancel", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("View", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Print", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("EmailWithAttachment", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("ExportToPDF", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("ExportToExcel", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Search", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("IsActive", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("CreatedOrModifyBy", typeof(int)));

          
            foreach (var item in listTableData)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow["PackageFormID"] = item.PackageFormID;
                dataRow["PackageID"] = item.PackageID;
                dataRow["FormID"] = item.FormID;
                dataRow["AddNew"] = item.AddNew;
                dataRow["Edit"] = item.Edit;
                dataRow["Cancel"] = item.Cancel;
                dataRow["View"] = item.View;
                dataRow["Print"] = item.Print;
                dataRow["Email"] = item.Email;
                dataRow["EmailWithAttachment"] = item.EmailWithAttachment;
                dataRow["ExportToPDF"] = item.ExportToPDF;
                dataRow["ExportToExcel"] = item.ExportToExcel;
                dataRow["Search"] = item.Search;
                dataRow["IsActive"] = item.IsChecked;
                dataRow["CreatedOrModifyBy"] = USERID;
                dataTable.Rows.Add(dataRow);
            }

            #endregion Creating DataTable.

            int packageFormId = _iPackageService.AddUpdateFormAssignToPackage(dataTable).Result;
            // PackageFormTxn packageFormTxn = new PackageFormTxn()

            //{
            //    packageFormTxn.PackageID,
            //    //FormID = formID,IsActive = isActive,
            //    CreatedOrModifiedBy = USERID
            //};


            //var packageFormIsActive = await _iPackageService.ActiveInActivePackageForm(packageFormTxn);
            if (packageFormId > 0)
            {
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = true, message = MessageHelper.Error });
        }

        #endregion
    }
}
