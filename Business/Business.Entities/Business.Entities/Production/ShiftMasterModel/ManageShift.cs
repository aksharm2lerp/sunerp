using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Production.ShiftMasterModel
{
    public class ManageShift
    {
        public int SrNo { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeID { get; set; }
        public int NoOfEmployees { get; set; }
        public string EmployeeName { get; set; }
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public int EmployeeShiftTnxID { get; set; }
        public string EmployeeShiftTnxName { get; set; }

        //public static implicit operator List<object>(ManageShift v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
