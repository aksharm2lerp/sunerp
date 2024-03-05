using Business.Entities.Production.MachineryDailyMISEntryModel;
using Business.Interface.Production.IMachineryDailyMISEntry;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Production.Controllers
{
    [Area("Production"), Authorize]
    [DisplayName("MachineryDailyMISEntry")]
    public class MachineryDailyMISEntryController : SettingsController
    {
        private readonly MachineryDailyMISEntryInterface iMachineryDailyMISEntry;
        public MachineryDailyMISEntryController(MachineryDailyMISEntryInterface iMachineryDailyMISEntry)
        {
            this.iMachineryDailyMISEntry = iMachineryDailyMISEntry;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<MachineryDailyMISEntry>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.MachineryDailyMISEntryText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.ItemCode).Titled("ItemCode").SetWidth(20); c.Add(o => o.MachineryID).Titled("MachineryID").SetWidth(20); c.Add(o => o.NoOfOperators).Titled("NoOfOperators").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnMachineryDailyMISEntry(this)' href='javascript:void(0)' data-id='{o.MachineryDailyMISEntryID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_MachineryDailyMISEntry' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<MachineryDailyMISEntry> pds =(PagedDataTable<MachineryDailyMISEntry>) iMachineryDailyMISEntry.GetAllMachineryDailyMISEntryAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<MachineryDailyMISEntry>(pds, query, false, "MachineryDailyMISEntryGrid", columns, PAGESIZE, pds.TotalItemCount)
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

        [HttpPost]
        public PartialViewResult Get(int id, int key)
        {
            try
            {
                MachineryDailyMISEntry model = new MachineryDailyMISEntry();
                model.MachineryDailyMISEntryID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iMachineryDailyMISEntry.GetMachineryDailyMISEntryAsync(id).Result;

                    return PartialView("AddOrUpdateMachineryDailyMISEntry", model);
                }
                return PartialView("AddOrUpdateMachineryDailyMISEntry", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update MachineryDailyMISEntry 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateMachineryDailyMISEntry(MachineryDailyMISEntry model)
        {
            try
            {
                #region Adding string array into DataTable.
                string[] strArray = null;
                DataTable dataTable = new DataTable();
                // Define the columns of the DataTable
                dataTable.Columns.Add("MachineryDailyMISUtilityConsumptionID", typeof(int));
                dataTable.Columns.Add("MachineryDailyMISEntryID", typeof(int));
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
                        newRow["MachineryDailyMISUtilityConsumptionID"] = strArray[i] ?? "0";
                        newRow["MachineryDailyMISEntryID"] = model.MachineryDailyMISEntryID;
                        newRow["Number"] = strArray[i + 3];
                        newRow["UOMID"] = strArray[i + 4];
                        newRow["UtilityID"] = strArray[i + 2];
                        newRow["IsActive"] = true;
                        dataTable.Rows.Add(newRow);
                    }
                }
                #endregion Adding string array into DataTable.

                model.CreatedOrModifiedBy = USERID;
                var _MachineryDailyMISEntryID = await iMachineryDailyMISEntry.AddOrUpdateMachineryDailyMISEntry(model, dataTable);

                if (_MachineryDailyMISEntryID > 0)
                {
                    model.MachineryDailyMISEntryID = _MachineryDailyMISEntryID;
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
        #endregion Add or Update MachineryDailyMISEntry 
    }
}
