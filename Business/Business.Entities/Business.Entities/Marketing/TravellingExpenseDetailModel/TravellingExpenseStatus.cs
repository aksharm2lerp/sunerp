using Business.Entities.Employee.EmploymentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Marketing.TravellingExpenseDetailModel
{
    public class TravellingExpenseStatus
    {
        public int SrNo { get; set; }
        public int TravellingExpenseStatusID { get; set; }
        public int TravellingExpenseDetailID { get; set; }
        public DateTime TravellingExpenseStatusDate { get; set; } = DateTime.Now;
        public int StatusID { get; set; }
        public string StatusText { get; set; }
        public string UserFullName { get; set; }
        public string StatusNote { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public List<TravellingExpenseStatus> listTravellingExpenseStatus { get; set; } = new List<TravellingExpenseStatus>();
    }
}
