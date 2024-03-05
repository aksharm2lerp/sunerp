using Business.Entities.Production.MachineryOperationDetailModel;
using Business.Interface;
using Business.Interface.Production.IMachineryOperationDetail;
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
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
//using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Production.Controllers
{
    [Area("Production"), Authorize]
    [DisplayName("MachineryOperationDetail")]
    public class MachineryOperationDetailController : SettingsController
    {
        private readonly MachineryOperationDetailInterface iMachineryOperationDetail;
        private readonly ICommonMasterService _commonMasterService;
        public MachineryOperationDetailController(MachineryOperationDetailInterface iMachineryOperationDetail, ICommonMasterService commonMasterService)
        {
            this.iMachineryOperationDetail = iMachineryOperationDetail;
            _commonMasterService = commonMasterService;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryOperationDetail>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachineryOperationDetailText).Titled("Feedback Notes").SetWidth(70);
                c.Add(o => o.OperationUses).Titled("OperationUses").SetWidth(20); c.Add(o => o.ProductionCapacity).Titled("ProductionCapacity").SetWidth(20); c.Add(o => o.NoOfOperators).Titled("NoOfOperators").SetWidth(20);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryOperationDetail(this)' href='javascript:void(0)' data-id='{o.MachineryOperationDetailID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryOperationDetail' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryOperationDetail> pds = (PagedDataTable<MachineryOperationDetail>)iMachineryOperationDetail.GetAllMachineryOperationDetailAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryOperationDetail>(pds, query, false, "MachineryOperationDetailGrid", columns, PAGESIZE, pds.TotalItemCount)
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

        #endregion Index Page

        #region Slider Page

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public PartialViewResult Get(int id, int key)
        {
            try
            {
                MachineryOperationDetail model = new MachineryOperationDetail();

                /*MachineryUtilityConsumption machineryUtilityConsumption = new MachineryUtilityConsumption
                {
                    MachineryOperationDetailID = 1,
                    MachineryUtilityConsumptionID = 1,
                    Number = 2,
                    UOMID = 1,
                    UtilityID = 1
                };
                model.CreatedBy = 29;
                model.MachineryOperationDetailID = 1;
                model.NoOfHelpers = "2";
                model.NoOfOperators = "3";
                model.OperationUses = "TEST USE";
                model.ProductionCapacity = "1200 units per hour";
                model.RiskFactor = "keep away from water";
                model.PowerConsumption = "10 Kv";
                model.UOMID = 1;
                model.UtilityID = 1;
                List<MachineryUtilityConsumption> machineryUtilityConsumptions = new List<MachineryUtilityConsumption>();
                machineryUtilityConsumptions.Add(machineryUtilityConsumption);
                model.machineryUtilityConsumptions = machineryUtilityConsumptions;*/

                if (Convert.ToInt32(id) > 0)
                {
                    model.MachineryOperationDetailID = id;
                    model = iMachineryOperationDetail.GetMachineryOperationDetailAsync(id).Result;

                    //return PartialView("AddUpdateMarketingFeedback", model);
                    return PartialView("AddOrUpdateMachineryOperationDetail", model);
                }
                return PartialView("AddOrUpdateMachineryOperationDetail", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryOperationDetail 

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryOperationDetail(MachineryOperationDetail model)
        {
            try
            {
                #region Adding string array into DataTable.
                string[] strArray = null;
                DataTable dataTable = new DataTable();
                // Define the columns of the DataTable
                dataTable.Columns.Add("MachineryUtilityConsumptionID", typeof(int));
                dataTable.Columns.Add("MachineryOperationDetailID", typeof(int));
                dataTable.Columns.Add("Number", typeof(decimal));
                dataTable.Columns.Add("UOMID", typeof(int));
                dataTable.Columns.Add("UtilityID", typeof(int));
                dataTable.Columns.Add("IsActive", typeof(bool));

                if (model.UtilityString != null && !string.IsNullOrEmpty(model.UtilityString) && model.UtilityString.Count() > 0)
                {
                    strArray = model.UtilityString.Split(",");

                    // Loop through the array and add each set of three elements as a new row to the DataTable
                    for (int i = 0; i < strArray.Length; i += 5)
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow["MachineryUtilityConsumptionID"] = strArray[i] ?? "0";
                        newRow["MachineryOperationDetailID"] = model.MachineryOperationDetailID;
                        newRow["Number"] = strArray[i + 3];
                        newRow["UOMID"] = strArray[i + 4];
                        newRow["UtilityID"] = strArray[i + 2];
                        newRow["IsActive"] = true;
                        dataTable.Rows.Add(newRow);
                    }
                }
                #endregion Adding string array into DataTable.
                model.CreatedOrModifiedBy = USERID;
                var _MachineryOperationDetailID = await iMachineryOperationDetail.AddOrUpdateMachineryOperationDetail(model, dataTable);

                if (_MachineryOperationDetailID > 0)
                {
                    model.MachineryOperationDetailID = _MachineryOperationDetailID;
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion Add or Update MachineryOperationDetail 


        #region Methods for dropdown

        public Microsoft.AspNetCore.Mvc.JsonResult GetAllUOMDropdown()
        {
            try
            {
                var uOMList = _commonMasterService.GetAllUOMAsync().Result;
                return Json(uOMList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public Microsoft.AspNetCore.Mvc.JsonResult GetAllUtilityDropdown()
        {
            try
            {
                var utilityList = _commonMasterService.GetAllUtilityAsync().Result;
                return Json(utilityList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Methods for dropdown
    }
}
