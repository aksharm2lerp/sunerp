using Business.Entities.Master.UserPermissionMasterModel;
using Business.Interface.IMaster.UserPermissionInterface;
using ERP.Controllers;
using ERP.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    [DisplayName("UserPermission")]
    public class UserPermissionController : SettingsController
    {
        #region Interface
        private readonly UserPermissionInterface _iUserPermission;
        public UserPermissionController(UserPermissionInterface userPermission)
        {
            _iUserPermission = userPermission;
        }
        #endregion Interface

        #region Index Page
        public ActionResult Index(int packageID, int userId)
        {
            try
            {
                //int userid = USERID;
                ////List<UserPermissionMaster> pds = _iUserPermission.GetAllPackageDetailAsync(packageid, 0, 0, "", "", "").Result;
                List<UserPermissionMaster> pds = new List<UserPermissionMaster>();
                //return View("Index", pds);
                if (packageID > 0 || userId > 0)
                {
                    ViewData["PackageId"] = packageID;
                    ViewData["UserId"] = userId;
                    pds = _iUserPermission.GetPackageDetailSummary(packageID, userId).Result;
                    if (pds.Count > 0)
                        return View(pds);
                    else
                        return View(pds);
                }
                else
                    return View(pds);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*public ActionResult Index(int packageid, [FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
                {
                    int userid = USERID;
                    IQueryCollection query = Request.Query;

                    Action<IGridColumnCollection<UserPermissionMaster>> columns = c =>
                    {
                        c.Add(o => o.SrNo).Titled("SrNo").SetWidth(10);
                        c.Add(o => o.FormName).Titled("Form Name").SetWidth(20);
                        c.Add().Titled("Assign").Encoded(false).Sanitized(false).SetWidth(10).Css("hidden-xs").RenderValueAs(o => $"<input type = 'checkbox'  href='javascript:void(0)' id='Assign' class='Assign' />");
                        c.Add().Titled("Readonly").Encoded(false).Sanitized(false).SetWidth(10).Css("hidden-xs").RenderValueAs(o => $"<input type = 'checkbox'  href='javascript:void(0)' id='Readonly' class='Readonly' />");
                        c.Add().Titled("Print").Encoded(false).Sanitized(false).SetWidth(10).Css("hidden-xs").RenderValueAs(o => $"<input type = 'checkbox'  href='javascript:void(0)' id='Print' class='Print' />");
                        c.Add().Titled("Export To Excel").Encoded(false).Sanitized(false).SetWidth(10).Css("hidden-xs").RenderValueAs(o => $"<input type = 'checkbox'  href='javascript:void(0)' id='ExportToExcel' class='ExportToExcel' />");
                        c.Add().Titled("Export To PDF").Encoded(false).Sanitized(false).SetWidth(10).Css("hidden-xs").RenderValueAs(o => $"<input type = 'checkbox'  href='javascript:void(0)' id='ExportToPDF' class='ExportToPDF' />");
                    };
                    PagedDataTable<UserPermissionMaster> pds = _iUserPermission.GetAllPackageDetailAsync(packageid, gridpage.ToInt(),
                        PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;


                    var server = new GridCoreServer<UserPermissionMaster>(pds, query, false, "ordersGrid",
                        columns, PAGESIZE, pds.TotalItemCount)
                        .Sortable()
                        //.Filterable()
                        //.WithMultipleFilters()
                        //.Searchable(false, false)
                        //.Groupable(true)
                        //.ClearFiltersButton(true)
                        //.Selectable(true)
                        //.SetStriped(true)
                        //.ChangePageSize(true)
                        //.WithGridItemsCount()
                        //.WithPaging(PAGESIZE, pds.TotalItemCount)
                        //.ChangeSkip(false)
                        .EmptyText("No record found");
                        //.ClearFiltersButton(false);
                    return View("Index", server.Grid);

                }*/
        #endregion Index Page

        #region GetPackageDetailSummary
        //public IActionResult GetPackageDetailSummary(int packageID, int userId)
        //{
        //    try
        //    {
        //        ViewData["PackageId"] = packageID;
        //        ViewData["UserId"] = userId;
        //        List<UserPermissionMaster> pds = _iUserPermission.GetPackageDetailSummary(packageID, userId).Result;
        //        return View("Index", pds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        #endregion GetPackageDetailSummary

        #region Package Assing Form To User Active Inactive

        [HttpPost]
        public async Task<IActionResult> AssingFormToUser(string tableData)
        {
            int modifiedBy = USERID;

            List<UserPermissionMaster> listTableData = JsonConvert.DeserializeObject<List<UserPermissionMaster>>(tableData);
            var test = listTableData;
            #region Creating DataTable.
            DataTable dataTable = new DataTable();
            dataTable.Columns.Clear();
            dataTable.Columns.Add(new DataColumn("UserFormID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("UserID", typeof(int)));
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

                dataRow["UserFormID"] = item.UserPermissionID;
                dataRow["UserID"] = item.UserID;
                dataRow["PackageID"] = item.PackageID;
                dataRow["FormID"] = item.FormID;
                dataRow["AddNew"] = 0;
                dataRow["Edit"] = 0;
                dataRow["Cancel"] = 0;
                dataRow["Email"] = 0;
                dataRow["EmailWithAttachment"] = 0;
                dataRow["Search"] = 0;
                dataRow["IsActive"] = item.Assign;
                dataRow["View"] = item.Readonly;
                dataRow["Print"] = item.Print;
                dataRow["ExportToPDF"] = item.ExportToPDF;
                dataRow["ExportToExcel"] = item.ExportToExcel;
                dataRow["CreatedOrModifyBy"] = USERID;
                dataTable.Rows.Add(dataRow);
            }

            #endregion Creating DataTable.

            int packageFormAssignToUserId = _iUserPermission.AddUpdatePackageFormAssignToUser(dataTable).Result;
            UserPermissionMaster packageFormTxn = new UserPermissionMaster();

            //{
            //    packageFormTxn.PackageID,
            //    //FormID = formID,IsActive = isActive,
            //    CreatedOrModifiedBy = USERID
            //};


            //var packageFormIsActive = await _iUserPermission.AddUpdatePackageFormAssignToUser(packageFormTxn);
            if (packageFormAssignToUserId > 0)
            {
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = true, message = "Data table generated." });
        }

        #endregion Package Assing Form To User Active Inactive
    }
}