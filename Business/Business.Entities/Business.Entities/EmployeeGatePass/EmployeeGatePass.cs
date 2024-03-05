using System;

namespace Business.Entities.EmployeeGatepass
{
    public class EmployeeGatePass
    {
        public int SrNo { get; set; }
        public int EmployeeGatePassID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public TimeSpan? OutTime { get; set; }
        public TimeSpan? InTime { get; set; }
        public string Reason { get; set; }
        public DateTime? Date { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public bool IsHRApproved { get; set; }
        public bool IsHODApproved { get; set; }
        public bool IsOutTimeSecurityApproved { get; set; }
        public bool IsInTimeSecurityApproved { get; set; }

    }
}
