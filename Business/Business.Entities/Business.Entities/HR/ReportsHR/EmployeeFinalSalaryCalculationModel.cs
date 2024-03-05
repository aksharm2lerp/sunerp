namespace Business.Entities.HR.ReportsHR
{
    public class EmployeeFinalSalaryCalculationModel
    {
        public int EmployeeFinalSalaryCalculationID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int CompanyID { get; set; }
        public int EmployeeID { get; set; }
        public string SalaryHeadName { get; set; }
        public string SalaryHeadLabel { get; set; }
        public string SalaryFormula { get; set; }
        public decimal CalculatedValue { get; set; }
        public int UserId { get; set; }
        public bool IsVerified { get; set; }
        public int EmployeeCategoryID { get; set; }
    }
}
