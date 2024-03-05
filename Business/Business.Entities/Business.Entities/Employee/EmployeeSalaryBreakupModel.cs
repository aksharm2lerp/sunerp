namespace Business.Entities.Employee
{
    public class EmployeeSalaryBreakupModel
    {
        public int SrNo { get; set; }
        public int EmployeeSalaryBreakupID { get; set; }
        public int EmployeeID { get; set; }
        public int SalaryHeadID { get; set; }
        public decimal? SalaryHeadValue { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}
