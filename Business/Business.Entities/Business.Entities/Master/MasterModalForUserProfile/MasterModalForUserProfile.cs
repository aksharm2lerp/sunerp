using Business.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Master.MasterModalForUserProfile
{
    public class MasterModalForUserProfile
    {
        public AddUpdateEmployee addUpdateEmployee { get; set; }
        public EmployeeAddressTxn employeeAddressTxn { get; set; }
        public EmployeeFamilyDetail employeeFamilyDetail { get; set; }
        public List<EmployeeBankDetails> EmployeeBankDetails { get; set; }
        public List<EmployeeDocument> EmployeeDocuments { get; set; }
        public List<EmployeeExperience> EmployeeExperience { get; set; }
        public List<EmployeeEducation> EmployeeEducation { get; set;}
        
    }
}
