using Business.Entities.Marketing.RequestForQuotTypeMasterModel;
using Business.Interface.Marketing.IRequestForQuotTypeMaster;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("RequestForQuotTypeMaster")]
    public class RequestForQuotTypeMasterController : SettingsController
    {
        private readonly RequestForQuotTypeMasterInterface iRequestForQuotTypeMaster;
        public RequestForQuotTypeMasterController(RequestForQuotTypeMasterInterface iRequestForQuotTypeMaster)
        {
            this.iRequestForQuotTypeMaster = iRequestForQuotTypeMaster;
        }

        #region Index Page
        public IActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<RequestForQuotTypeMaster>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                ////c.Add(o => o.RequestForQuotTypeMasterText).Titled("Feedback Notes").SetWidth(70);
                 c.Add(o => o.RequestForQuotTypeID).Titled("RequestForQuotTypeID").SetWidth(20); c.Add(o => o.RequestForQuotTypeText).Titled("RequestForQuotTypeText").SetWidth(20); c.Add(o => o.Remark).Titled("Remark").SetWidth(20);
              

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' onclick='fnRequestForQuotTypeMaster(this)' href='javascript:void(0)' data-id='{o.RequestForQuotTypeID}' data-bs-toggle='offcanvas' data-bs-target='#canvas_RequestForQuotTypeMaster' aria-controls='canvas_masterentity' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<RequestForQuotTypeMaster> pds =(PagedDataTable<RequestForQuotTypeMaster>) iRequestForQuotTypeMaster.GetAllRequestForQuotTypeMasterAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;

            var server = new GridCoreServer<RequestForQuotTypeMaster>(pds, query, false, "RequestForQuotTypeMasterGrid", columns, PAGESIZE, pds.TotalItemCount)
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
                RequestForQuotTypeMaster model = new RequestForQuotTypeMaster();
                model.RequestForQuotTypeID = id;
                if (Convert.ToInt32(id) > 0)
                {
                    model = iRequestForQuotTypeMaster.GetRequestForQuotTypeMasterAsync(id).Result;

                    return PartialView("AddOrUpdateRequestForQuotTypeMaster", model);
                }
                return PartialView("AddOrUpdateRequestForQuotTypeMaster", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Slider Page

        #region Add or Update RequestForQuotTypeMaster 

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRequestForQuotTypeMaster(RequestForQuotTypeMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            var _RequestForQuotTypeID = await iRequestForQuotTypeMaster.AddOrUpdateRequestForQuotTypeMaster(model);

            if (_RequestForQuotTypeID > 0)
            {
                model.RequestForQuotTypeID = _RequestForQuotTypeID;
                return Json(new { status = true, message = MessageHelper.Added });
            }
            else
                return Json(new { status = false, message = MessageHelper.Error });
            
        }

        #endregion Add or Update RequestForQuotTypeMaster 
    }
}
