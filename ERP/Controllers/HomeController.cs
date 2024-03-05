using Business.Entities.ProductPhotoPath;
using Business.Interface.ProductImages;
using ERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ERP.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductImages _productImages;

        public HomeController(ILogger<HomeController> logger, IProductImages productImages)
        {
            _logger = logger;
            _productImages = productImages;
        }

        public IActionResult Index()
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public IActionResult Image(string id)
        {
            if (id == "BuildingWire")
            {

                return View("BuildingWire");
            }
            else if (id == "SolarCable")
            {
                List<string> pathList = new List<string>();
                List<ProductPhotoPath> imagePath = _productImages.GetImagePath().Result;
                foreach (var path in imagePath)
                {
                    pathList.Add(path.ImagePath);
                }
                return View("SolarCable", imagePath);
            }
            else
            {
                return View("TelephoneCable");
            }
            

            //if (pathList != null)
            //    ViewData["Image"] = pathList;

            //return View("SolarCable", imagePath);
        }

        public dynamic GetPdf()
        {
            string filePath = "~/file/file.pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
            return File(filePath, "application/pdf");
        }

        #region Download PDF
        public dynamic Download(string id)
        {
            try
            {
                string filePath = string.Empty;
                string filename = string.Empty;

                if (id.Equals("HouseWire"))
                    filePath = "~/ProductsGroupFile/SRINILINK HOUSE WIRE.pdf";
                    filename = "SRINILINK HOUSE WIRE.pdf";

                if (id.Equals("BuildingWire"))
                    filePath = "~/ProductsGroupFile/SRINILINK HOUSE WIRE.pdf";
                    filename = "SRINILINK HOUSE WIRE.pdf";

                if (id.Equals("SolarCable"))
                    filePath = "~/ProductsGroupFile/SRINILINK SOLAR CABLE.pdf";
                    filename = "SRINILINK SOLAR CABLE.pdf";

                if (id.Equals("TelephoneCable"))
                    filePath = "~/ProductsGroupFile/SRINILINK CAT.pdf";
                    filename = "SRINILINK CAT.pdf";

                if (id.Equals("AutomobileWire"))
                    filePath = "~/ProductsGroupFile/SRINILINK AUTOCABLE.pdf";
                    filename = "SRINILINK AUTOCABLE.pdf";

                if (id.Equals("PanelWire"))
                    filePath = "~/ProductsGroupFile/SRINILINK MULTICORE.pdf";
                    filename = "SRINILINK MULTICORE.pdf";

                if (id.Equals("ArmouredCable"))
                    filePath = "~/ProductsGroupFile/SRINILINK ARMOUR-UNARMOUR XLPE HORIZONTAL.pdf";
                    filename = "SRINILINK ARMOUR-UNARMOUR XLPE HORIZONTAL.pdf";

                if (id.Equals("SubmersibleWire"))
                    filePath = "~/ProductsGroupFile/SRINILINK SUBMERSIBLE.pdf";
                    filename = "SRINILINK SUBMERSIBLE.pdf";

                if (id.Equals("FlexibleMultiCoreWires"))
                    filePath = "~/ProductsGroupFile/SRINILINK UL62 FLEXIBLE CORD BRO.pdf";
                    filename = "SRINILINK UL62 FLEXIBLE CORD BRO.pdf";

                if (id.Equals("ScreenCablewires"))
                    filePath = "~/ProductsGroupFile/SRINILINK SCREEN BRO.pdf";
                    filename = "SRINILINK SCREEN BRO.pdf";

                if (id.Equals("ApplianceCable"))
                    filePath = "~/ProductsGroupFile/SRINILINK UL758 CABLE BRO.pdf";
                    filename = "SRINILINK UL758 CABLE BRO.pdf";

                if (id.Equals("SingleCorePVC"))
                    filePath = "~/ProductsGroupFile/SRINILINK SINGLE CORE PVC.pdf";
                    filename = "SRINILINK SINGLE CORE PVC.pdf";

                if (id.Equals("OneCatalog"))
                    filePath = "~/ProductsGroupFile/ALL Cable Brochure.pdf";
                    filename = "ALL Cable Brochure.pdf";


                Response.Headers.Add("Content-Disposition", "inline; "+ filename);
                return File(filePath, "application/pdf");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion Download PDF



    }
}
