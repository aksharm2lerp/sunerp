using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.ActivityOnMapModel
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationText { get; set; }
        public string PersonalMobileNo { get; set; }
        public string AlternativeMobileNo { get; set; }
        public string PersonalEmail { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public List<ActivityOnMap> activityOnMap { get; set; }
    }
}
