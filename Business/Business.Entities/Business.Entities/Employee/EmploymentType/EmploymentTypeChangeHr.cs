using Business.Entities.Employee.EmploymentStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Employee.EmploymentType
{
    public class EmploymentTypeChangeHr
    {
        public int EmploymentTypeTxnID { get; set; }
        public int SrNo { get; set; }
        public int EmploymentTypeID { get; set; }
        public string EmploymentTypeText { get; set; }
        public int EmployeeID { get; set; }
        public DateTime EmploymentTypeDate { get; set; } = DateTime.Today;
        public string EmploymentTypeNote { get; set; }
        public bool IsActive { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public List<EmploymentTypeChangeHr> listEmploymentTypeChangeHr { get; set; } = new List<EmploymentTypeChangeHr>();

    }
}
