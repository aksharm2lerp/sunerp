
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Business.Entities.ProductPhotoPath;
using Business.Interface;
using Business.Interface.ProductImages;
using ERP.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Linq;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using Business.Entities.Employee;
using Business.Entities.Employee.EmploymentType;
using System.Threading.Tasks;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;


namespace ERP.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    //[DisplayName("UploadProductImages")]
    public class UploadProductImagesController : SettingsController
    {
        private readonly IMasterService _masterService;
        private readonly IProductImages _iProductImages;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly string link;
        private readonly IProductImages _productImages;

        public UploadProductImagesController(IMasterService masterService, IProductImages iProductImages, IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IProductImages productImages)
        {
            _masterService = masterService;
            _iProductImages = iProductImages;
            _hostEnvironment = hostEnvironment;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            link = _configuration.GetSection("ProductImagePath")["UploadProductImages"];
            _productImages = productImages;

        }

        public IActionResult Index()
        {
            //List<string> pathList = new List<string>();
            List<ProductPhotoPath> imagePath = _productImages.GetImagePath().Result;
            //foreach (var path in imagePath)
            //{
            //    pathList.Add(path.ImagePath);                                                                 
            //}
            return View(imagePath);
        }

        //[HttpGet]
        //public IActionResult IndexProductDisplay()
        //{
        //    List<ProductPhotoPath> imagePath = _productImages.IndexProductDisplay().Result;
        //    return View(imagePath);
        //}


        [HttpGet]
        public async Task<PartialViewResult> IndexProductDisplay()
        {
            try
            {
                ProductPhotoPath imagePath = new ProductPhotoPath();
                imagePath = await _productImages.IndexProductDisplay();
                return PartialView(imagePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult AddOrEditProductImages(int id)
        {
            ProductPhotoPath productPhotoPath = new ProductPhotoPath();
            //var listUOMID = _masterService.GetAllUOMID();
            //ViewData["UOMID"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(listUOMID, "UOMID", "UOMText");

            if (id > 0)
            {
                productPhotoPath = _iProductImages.GetProductImageDetailAsync(id).Result;
            }
            return View("AddOrEditProductImages", productPhotoPath);
        }


        [HttpPost]
        public ActionResult AddOrEditProductImages(ProductPhotoPath productPhotoPath)
        {
            //var path1 = "";
            //productPhotoPath.CreatedOrModifiedBy = USERID;
            //if (productPhotoPath.ProductPhoto != null)
            //{
            //    string text1 = DateTime.Now.ToString();
            //    string fileExtension = Path.GetExtension(productPhotoPath.ProductPhoto.FileName);
            //    // Add logic for save file in image folder. 29-09-2022.
            //    path1 = _webHostEnvironment.WebRootPath + link;  //full path Excluding file name ----  0
            //    string filepath = path1;  //full path including file name  -----  1
            //    string filename = productPhotoPath.ProductPhoto.FileName;
            //    string dbfilepath = link + filename;
            //    filepath = filepath + filename;
            //    //productPhotoPath.ProductImageText = productPhotoPath.ProductPhoto.FileName;
            //    // productPhotoPath.ProductImageID = id;
            //    productPhotoPath.ImagePath = dbfilepath;
            //    productPhotoPath.CreatedOrModifiedBy = USERID;
            //    productPhotoPath.IsActive = true;

            //    var id = _iProductImages.AddOrEditProductImages(productPhotoPath).Result;

            //    if (id > 0 && Directory.Exists(path1))
            //    {
            //        using (var fileStream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
            //        {
            //            productPhotoPath.ProductPhoto.CopyTo(fileStream);
            //        }
            //        if (id <= 0)
            //            return View(ViewData["Message"] = "Profile photo not uploaded.");
            //        else
            //           // return RedirectToAction("Index", "UploadProductImages");
            //            return RedirectToAction("IndexProductDisplay", "UploadProductImages");
            //    }
            //    return View(ViewData["Message"] = "Root directory not found.");
            //}
            //else
            //{

            DataTable dataTable = new DataTable();
            dataTable.Columns.Clear();

            dataTable.Columns.Add(new DataColumn("ProductImageTxnID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductImageID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductImageTxnText", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ProductImageTxnPath", typeof(string)));
            dataTable.Columns.Add(new DataColumn("IsActive", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("carouselProductImageTxnActive", typeof(string)));

            productPhotoPath.CreatedOrModifiedBy = USERID;
            productPhotoPath.IsActive = true;
            if (productPhotoPath.MultipleFiles.Count > 0)
            {
                int imageSubName = 1;
                foreach (var file in productPhotoPath.MultipleFiles)
                {
                    //string filename = file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filename = productPhotoPath.ProductCategoryText + "_" + imageSubName + fileExtension;
                    filename = Path.GetFileName(filename);
                    string uploadpathPhysical = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images\\uploadProductImages\\MultipleUploadedFiles", filename);
                    string uploadpathDB = Path.Combine("\\assets\\images\\uploadProductImages\\MultipleUploadedFiles", filename);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["ProductImageTxnID"] = 0;
                    dataRow["ProductImageID"] = 0;
                    dataRow["ProductImageTxnText"] = filename;
                    dataRow["ProductImageTxnPath"] = uploadpathDB;                    
                    dataRow["IsActive"] = true;
                    if (imageSubName == 1)
                    { dataRow["carouselProductImageTxnActive"] = "active"; }
                    else
                    { dataRow["carouselProductImageTxnActive"] = ""; }
                    dataTable.Rows.Add(dataRow);
                    var stream = new FileStream(uploadpathPhysical, FileMode.Create);
                    file.CopyToAsync(stream);
                    imageSubName++;
                }
            }
            var id = _iProductImages.AddOrEditProductImages(productPhotoPath, dataTable).Result;

            if (id > 0)
            {
                // return RedirectToAction("Index", "UploadProductImages");
                return RedirectToAction("IndexProductDisplay", "UploadProductImages");
            }
            else
            {
                return View(ViewData["Message"] = "Error! Fail to save records!");

            }
            //}
        }
                else
                {
                    return View(ViewData["Message"] = "Error! Failt to save records!");

        #region Product Group Description By ProductGroup ID
        public JsonResult ProductGroupDescriptionByProductGroupID(int productGroupID)
        {
            var result = _masterService.ProductGroupDescriptionByProductGroupID(productGroupID).Result.Select(x => new { Remark = x.Remark }).FirstOrDefault();
            return Json(result);
        }
        #endregion Product Group Description By ProductGroup ID

    }
}
