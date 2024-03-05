
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.User
{
    public class UserEmpDetail
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string PersonalMobileNo { get; set; }
        public string PersonalEmail { get; set; } 
        public string OfficeMobileNo { get; set; }
        public string OfficeEmail { get; set; }

    }
}
