using Business.Entities.Party;
using Business.Entities.PartyMasterModel;
using Business.Interface;
using Business.Interface.IParty;
using Business.SQL;
using ERP.Controllers;
using ERP.Helpers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    public class PartyController : SettingsController
    {
        private readonly IMasterService _masterService;
        private readonly IPartyService _PartyService;
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string linkPartyLogoImage;
        private readonly string linkPartyDocument;
        public PartyController(IMasterService masterService, IConfiguration configuration, IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment, IPartyService PartyService)
        {
            _masterService = masterService;
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
            _webHostEnvironment = webHostEnvironment;
            _PartyService = PartyService;
            linkPartyLogoImage = _configuration.GetSection("PartyLogoImagePath")["PartyLogoImage"];
            linkPartyDocument = _configuration.GetSection("PartyLogoImagePath")["PartyDocuments"];
        }
        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<PartyMaster>> columns = c =>
            {
                c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                c.Add(o => o.PartyCode).Titled("Party Code").Sortable(true);
                c.Add(o => o.PartyName).Titled("Party Name").Sortable(true);
                c.Add(o => o.Mobile1).Titled("Mobile").Sortable(true);
                c.Add(o => o.Email).Titled("Email").Sortable(true);
                c.Add(o => o.GroupName).Titled("Exibition").Sortable(true);
                c.Add().Titled("PartyToCustomer").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs").RenderValueAs(o => $"<a class='fa-2x pointer' id='MigratePartyID' title='Party Migrate To Customer' data-id='{o.PartyID}' data-key='{o.PartyID}' data-bs-toggle='modal' data-bs-target='#ModalMigrate' onclick='fnOpenPartyIDMigrate({Convert.ToString(o.PartyID)})'><iconify-icon icon='carbon:migrate'></iconify-icon></a>");
                //c.Add(o => o.OwnerName).Titled("Owner Name").Sortable(true);
                //c.Add(o => o.IsActive).Titled("IsActive").Sortable(true);
                ////Below code hide on phones
                //c.Add().Titled("Details").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                //.RenderValueAs(o => $"<a class='btn IndexPagebtnEidtPadding' href='/Marketing/Party/AddUpdateParty/{o.PartyID}' ><i class='bx bx-edit'></i></a>");
                c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.PartyID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.PartyID}' data-approval='HOD' data-id='{o.PartyID}' data-key='{o.PartyID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                //Below code hide on phones
                c.Add().Titled("Details").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/Party/AddUpdateParty/{o.PartyID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");

            };
            PagedDataTable<PartyMaster> pds = _PartyService.GetAllPartyAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<PartyMaster>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable().ClearFiltersButton(true).Selectable(true).WithGridItemsCount().ChangeSkip(false).EmptyText("No record found").ClearFiltersButton(false);
            return View(server.Grid);
        }

        public ActionResult Search(string keyword)
        {
            try
            {
               
                PartySearch model = new PartySearch();
                model.keyword = keyword;

                PagedDataTable<PartyMaster> pds = _PartyService.GetAllPartyAsync(1, PAGESIZE, keyword, "", "ASC").Result;
                 
                //foreach (var item in pds)
                //{
                //    item.EncryptedId = protector.Protect(item.EmployeeID.ToString());
                //}

                Action<IGridColumnCollection<PartyMaster>> columns = c =>
                {
                    

                    c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                    c.Add(o => o.PartyCode).Titled("Party Code").Sortable(true);
                    c.Add(o => o.PartyName).Titled("Party Name").Sortable(true);
                    c.Add(o => o.Mobile1).Titled("Mobile").Sortable(true);
                    c.Add(o => o.Email).Titled("Email").Sortable(true);
                    c.Add(o => o.GroupName).Titled("Exibition").Sortable(true);
                    c.Add().Titled("PartyToCustomer").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs").RenderValueAs(o => $"<a class='fa-2x pointer' id='MigratePartyID' title='Party Migrate To Customer' data-id='{o.PartyID}' data-key='{o.PartyID}' data-bs-toggle='modal' data-bs-target='#ModalMigrate' onclick='fnOpenPartyIDMigrate({Convert.ToString(o.PartyID)})'><iconify-icon icon='carbon:migrate'></iconify-icon></a>");

                    c.Add(o => o.IsActive).Titled("Active").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<input type='checkbox' class='form-check-input' id='{"EMPActiveInactive" + o.PartyID}'   href='javascript:void(0)' data-rowid='{"EMPActiveInactive" + o.PartyID}' data-approval='HOD' data-id='{o.PartyID}' data-key='{o.PartyID}' " + (o.IsActive ? "checked" : "unchecked") + " disabled >");

                    //Below code hide on phones
                    c.Add().Titled("Details").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                    .RenderValueAs(o => $"<a class='fa-2x' href='/Marketing/Party/AddUpdateParty/{o.PartyID}' ><iconify-icon icon=\"ep:edit\"></iconify-icon></a>");

                };
                GridSettings settings = new GridSettings();
                //settings.QueryString = id.ToString();
                IQueryCollection query = Request.Query;
                var server = new GridCoreServer<PartyMaster>(pds, query, false, "PartyMasterGrid",
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


        #region Basic details
        [HttpGet]
        public ActionResult AddUpdateParty(int id)
        {
            try
            {
                PartyMaster PartyMaster = new PartyMaster();
                if (id > 0)
                {
                    PartyMaster = _PartyService.GetPartyAsync(id).Result;
                    ViewData["LogoImage"] = PartyMaster.LogoImagePath;
                }
                return View("AddUpdateParty", PartyMaster);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdateParty(PartyMaster PartyMaster)
        {

            var path1 = "";
            var id = await _PartyService.AddUpdateParty(PartyMaster);

            if (id > 0)
            {
                if (PartyMaster.LogoImage != null)
                {
                    string fileExtension = Path.GetExtension(PartyMaster.LogoImage.FileName);
                    //Add logic for save file in image folder. 29-09-2022.
                    PartyLogoImage PartyLogoImage = new PartyLogoImage();
                    path1 = _webHostEnvironment.WebRootPath + linkPartyLogoImage;  //full path Excluding file name ----  0
                    string filepath = path1;  //full path including file name  -----  1
                    string filename = id + "_" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace("-", "").Replace(":", "") + "_" + PartyMaster.LogoImage.FileName;
                    string dbfilepath = linkPartyLogoImage + filename;
                    filepath = filepath + filename;
                    PartyLogoImage.PartyID = id;
                    PartyLogoImage.PartyLogoImageID = PartyMaster.PartyLogoImageID;
                    PartyLogoImage.LogoImageName = filename;
                    PartyLogoImage.LogoImagePath = dbfilepath;
                    PartyLogoImage.CreatedOrModifiedBy = USERID;
                    PartyLogoImage.IsActive = true;
                    if (!Directory.Exists(path1))
                    { 
                        Directory.CreateDirectory(path1); 
                    }

                    else
                    {
                        using (var fileStream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            PartyMaster.LogoImage.CopyTo(fileStream);
                        }
                        var profilePhotoId = _PartyService.UpdatePartyLogoImage(PartyLogoImage).Result;
                        //return Json(new { status = false, message = MessageHelper.Error });
                        return RedirectToAction("AddUpdateParty", new { id });
                    }
                }
                //return Json(new { status = true, message = MessageHelper.Added });
                return RedirectToAction("AddUpdateParty", new { id });

            }
            else
            {
                //return Json(new { status = false, message = MessageHelper.Error });
                return RedirectToAction("AddUpdateParty");
            }
        }
        #endregion Basic details

        #region Contact Person Detail
        [HttpGet]
        public async Task<PartialViewResult> AddUpdatePartyContactPerson(int PartyContactID, int PartyId)
        {
            try
            {
                PartyContactTxn PartyContactTxn = new PartyContactTxn();
                PartyContactTxn.PartyID = PartyId;
                if (PartyContactID > 0 || PartyId > 0)
                {
                    var getPartyContactTxn = await _PartyService.GetPartyContactPerson(PartyContactID, PartyId);
                    if (getPartyContactTxn == null)
                        PartyContactTxn.PartyID = PartyId;
                    else
                        PartyContactTxn = getPartyContactTxn;

                    return PartialView("_addUpdatePartyContactPerson", PartyContactTxn);
                }
                else
                    return PartialView("_addUpdatePartyContactPerson", PartyContactTxn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdatePartyContactPerson(PartyContactTxn partyContactTxn)
        {
            try
            {
                partyContactTxn.CreatedOrModifiedBy = USERID;
                int PartyContactId = await _PartyService.AddUpdatePartyContactPerson(partyContactTxn);
                if (PartyContactId > 0)
                {
                    //return RedirectToAction("AddUpdateParty", new { id = partyContactTxn.PartyID });
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Contact Person Detail

        #region Address details
        [HttpGet]
        public async Task<PartialViewResult> AddUpdatePartyAddress(int PartyAddressTxnId, int PartyId)
        {
            try
            {
                PartyAddressTxn PartyAddressTxn = new PartyAddressTxn();
                PartyAddressTxn.PartyID = PartyId;
                if (PartyAddressTxnId > 0 || PartyId > 0)
                {
                    var partyAddressTxn = await _PartyService.GetPartyAddressTxn(PartyAddressTxnId, PartyId);
                    if (partyAddressTxn == null)
                        PartyAddressTxn.PartyID = PartyId;
                    else
                        PartyAddressTxn = partyAddressTxn;

                    return PartialView("_addUpdatePartyAddress", PartyAddressTxn);
                }
                else
                    return PartialView("_addUpdatePartyAddress", PartyAddressTxn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdatePartyAddress(PartyAddressTxn PartyAddressTxn)
        {
            try
            {
                int PartyAddressId = await _PartyService.AddUpdateCustomeAddress(PartyAddressTxn);
                if (PartyAddressId > 0)
                {
                    return RedirectToAction("AddUpdateParty", new { id = PartyAddressTxn.PartyID });
                    //return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Address details

        #region Party Contact Detail
        [HttpPost]
        public async Task<ActionResult> AddUpdatePartyContactDetail(PartyContactDetail PartyContactDetail)
        {
            try
            {
                int ContactId = await _PartyService.AddUpdatePartyContactDetail(PartyContactDetail);
                if (ContactId > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Party Contact Detail

        #region Party Registration
        [HttpPost]
        public async Task<ActionResult> AddUpdatePartyRegistration(PartyRegistration PartyRegistration)
        {
            try
            {
                PartyRegistration.CreatedOrModifiedBy = USERID;
                int registrationId = await _PartyService.AddUpdatePartyRegistration(PartyRegistration);
                if (registrationId > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion Party Registration

        #region Party Bank Details
        [HttpGet]
        public async Task<PartialViewResult> AddUpdatePartyBankAccount(int PartyBankDetailId, int PartyId)
        {
            try
            {
                PartyBankDetails PartyBankDetails = new PartyBankDetails();
                PartyBankDetails.PartyID = PartyId;
                if (PartyBankDetailId > 0 || PartyId > 0)
                {
                    var PartyBankdetail = await _PartyService.GetPartyBankAccount(PartyBankDetailId, PartyId);
                    if (PartyBankdetail == null)
                        PartyBankDetails.PartyID = PartyId;
                    else
                        PartyBankDetails = PartyBankdetail;

                    return PartialView("_addUpdatePartyBankAccount", PartyBankDetails);
                }
                else
                    return PartialView("_addUpdatePartyBankAccount", PartyBankDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdatePartyBankAccount(PartyBankDetails PartyBankDetails)
        {
            try
            {
                PartyBankDetails.CreatedOrModifiedBy = USERID;
                int PartyBankAccountId = await _PartyService.AddUpdatePartyBankDetails(PartyBankDetails);
                if (PartyBankAccountId > 0)
                {
                    //return RedirectToAction("AddUpdateParty", new { id = PartyBankDetails.PartyID });
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Party Bank Details

        #region Party document
        [HttpGet]
        public async Task<PartialViewResult> AddUpdatePartyDocument(int PartyDocumentId, int PartyId)
        {
            try
            {
                PartyDocument PartyDocument = await _PartyService.GetPartyDocument(PartyDocumentId, PartyId);

                if (PartyDocument == null)
                    PartyDocument = new PartyDocument { PartyID = PartyId };

                ViewData["DocumentPath"] = PartyDocument.DocumentPath;

                return PartialView("_addUpdatePartyDocument", PartyDocument);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdatePartyDocument(PartyDocument PartyDocument)
        {
            try
            {
                int id = PartyDocument.PartyID;
                if (PartyDocument.DocumentFile != null)
                {
                    var path1 = "";
                    string fileExtension = Path.GetExtension(PartyDocument.DocumentFile.FileName);

                    path1 = _webHostEnvironment.WebRootPath + linkPartyDocument;  //full path Excluding file name ----  0
                    string filepath = path1;  //full path including file name  -----  1
                    string filename = PartyDocument.DocumentName + "_" + PartyDocument.PartyID + "_" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace("-", "").Replace(":", "") + fileExtension;
                    string dbfilepath = linkPartyDocument + filename;
                    filepath = filepath + filename;

                    if (Directory.Exists(path1))
                    {
                        using (var fileStream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            PartyDocument.DocumentFile.CopyTo(fileStream);
                        }
                        PartyDocument.DocumentName = filename;
                        PartyDocument.DocumentExtension = fileExtension;
                        PartyDocument.DocumentPath = dbfilepath;
                        int documentId = await _PartyService.AddUpdatePartyDocument(PartyDocument);
                        if (documentId > 0)
                        {
                            //TempData["message"] = MessageHelper.Uploaded;
                            //ViewBag.Message = MessageHelper.Uploaded;
                            //return Json(new { status = true, message = MessageHelper.Uploaded });
                            return RedirectToAction("AddUpdateParty", new { id });
                        }
                        else
                        {
                            //ViewBag.Message = MessageHelper.Uploaded;
                            //return Json(new { status = false, message = MessageHelper.NoDocument });
                            return RedirectToAction("AddUpdateParty", new { id });
                        }
                    }
                }
                //ViewBag.Message = MessageHelper.NoDocument;
                //return Json(new { status = false, message = MessageHelper.Error });
                return RedirectToAction("Index", "Party");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> ActiveInActivePartyDocument(int PartyDocumentId, int PartyId, bool isActive)
        {
            PartyDocument PartyDocument = new PartyDocument()
            {
                PartyDocumentID = PartyDocumentId,
                PartyID = PartyId,
                IsActive = isActive,
                CreatedOrModifiedBy = USERID
            };
            int modifiedBy = USERID;
            int PartyDocumentIsActive = await _PartyService.ActiveInActivePartyDocument(PartyDocument);
            if (PartyDocumentIsActive > 0)
            {
                if (isActive)
                    return Json(new { status = true, message = MessageHelper.ActivatedDocument });
                else
                    return Json(new { status = true, message = MessageHelper.InactivatedDocument });
            }
            else
                return Json(new { status = true, message = MessageHelper.Error });
        }
        #endregion Party document

        #region Party Setting
        [HttpPost]
        public async Task<ActionResult> AddUpdatePartySetting(PartySetting PartySetting)
        {
            try
            {
                int settingId = await _PartyService.AddUpdatePartySetting(PartySetting);
                if (settingId > 0)
                {
                    return Json(new { status = true, message = MessageHelper.Added });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Party Setting
    }
}
