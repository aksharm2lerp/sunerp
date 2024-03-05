using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Employee
{
    public class EmployeeSearch
    {
        public string keyword { get; set; }
        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }
        public int CompanyID { get; set; }

    }
    

}
