using System;

namespace Business.Entities.HR.MachineryResourceAllocationModel
{
    public class DailyMachineryResourceTxn
    {
        public int SrNo { get; set; }
        public DateTime? EntryDate { get; set; } = DateTime.Today.Date;
        public int? ShiftID { get; set; } = 0;
        public int? DepartmentID { get; set; } = 0;
        public int? MachineryID { get; set; } = 0;
        public int DailyMachineryResourceTxnID { get; set; }
        public int DailyMachineryResourceLogID { get; set; }
        public bool ResourceType { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeOperatorHelperName { get; set; }
        public int? TransferToMachineID { get; set; }
        public bool IsAdditionalResource { get; set; }
        public bool IsPresent { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public string ApprovedByHOD { get; set; }
        public string ApprovedByHR { get; set; }
        public string MachineryResourceLogArray { get; set; }
    }
}
