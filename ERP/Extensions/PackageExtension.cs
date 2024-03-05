using Business.Entities.Admin.IconMasterModel;
using Business.Interface.Marketing.IPackage;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Extensions
{
    public class PackageExtension
    {
        private static HttpContext Current => new HttpContextAccessor().HttpContext;
        public static IPackageService _packageService => (IPackageService)Current.RequestServices.GetService(typeof(IPackageService));
        public static SelectList GetAllPackage()
        {
            try
            {
                var packageList = _packageService.GetAllPackageForDropDownList().Result.Select(x => new { PackageID = x.PackageID, PackageName = x.PackageName });
                return new SelectList(packageList, "PackageID", "PackageName");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        #region Form Master Icon Extension

        //public static SelectList GetAllIconName()
        //{
        //    try
        //    {
        //        var iconNameList = _packageService.GetAllIconNameForDropDownList().Result.Select(x => new { IconMasterID = x.IconMasterID, IconName = x.IconName, IconHTMLTag = x.IconHTMLTag }).ToList();
        //        return new SelectList(iconNameList, "IconMasterID", "IconName", "IconHTMLTag");
        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //}
        public static List<IconMaster> GetAllIconName()
        {
            try
            {
                List<IconMaster> iconNameList = _packageService.GetAllIconNameForDropDownList().Result.ToList();
                //return new SelectList(iconNameList, "IconMasterID", "IconName", "IconHTMLTag");
                return iconNameList;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        #endregion Form Master Icon Extension


    }
}
