namespace Business.Entities.HR.MachineryResourceAllocationModel
{
    public class DailyMachineryResourceLog
    {
        public int ID { get; set; }
        public int DailyMachineryResourceLogID { get; set; } = 0;
        public int DailyMachineryResourceTxnID { get; set; } = 0;
        public int EmployeeID { get; set; }
        public bool ResourceType { get; set; }
        public string EmployeeName { get; set; }
        public string ApprovedByHOD { get; set; }
        public string ApprovedByHR { get; set; }
        public bool IsPresent { get; set; }
        public bool IsAdditionalResource { get; set; }
        public int TransferToMachineID { get; set; }
    }
}
