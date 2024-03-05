using Business.Interface;
using Business.Interface.IEmployee;
using Business.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ERP.Extensions
{
    public class UserExtension
    {
        private static HttpContext Current => new HttpContextAccessor().HttpContext;
        public static ISiteUserService _siteUserService => (ISiteUserService)Current.RequestServices.GetService(typeof(ISiteUserService));

        #region User Dropdown List

        public static SelectList GetAllUsersForDropDown()
        {
            try
            {
                var employeeList = _siteUserService.GetAllUsersForDropDown().Result;
                return new SelectList(employeeList, "UserID", "Username");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion User Dropdown List
    }
}
