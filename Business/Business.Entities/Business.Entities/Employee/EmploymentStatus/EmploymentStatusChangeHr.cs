using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Employee.EmploymentStatus
{
    public class EmploymentStatusChangeHr
    {
        public int SrNo { get; set; }
        public int EmploymentStatusTxnID { get; set; }
        public int EmploymentStatusID { get; set; }
        public string EmploymentStatusText { get; set; }
        public int EmployeeID { get; set; }
        public DateTime EmploymentStatusDate { get; set; } = DateTime.Today;
        public string EmploymentStatusNote { get; set; }
        public bool IsActive { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public List<EmploymentStatusChangeHr> listEmploymentStatusChangeHrs { get; set; } = new List<EmploymentStatusChangeHr>();
      
    }
}
