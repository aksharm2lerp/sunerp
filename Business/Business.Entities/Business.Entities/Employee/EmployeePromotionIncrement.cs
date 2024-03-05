using System;
using System.Collections.Generic;

namespace Business.Entities.Employee
{
    public class EmployeePromotionIncrement
    {
        public int SrNo { get; set; }
        public int EmployeeID { get; set; }
        public int EmployeePromotionIncrementID { get; set; }
        public int EmployeeAdminID { get; set; }
        public DateTime? PromotionIncrementDate { get; set; } = DateTime.Today.Date;
        public int? NewDepartmentID { get; set; }
        public int? NewDesignationID { get; set; } 
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationText { get; set; }
        public int? DesignationID { get; set; }
        public decimal? UpdatedCTC { get; set; }
        public decimal? YearlyCTC { get; set; }
        public decimal? CurrentCTC { get; set; }
        public string ApprovedByHR { get; set; }
        public string ApprovedByAdmin { get; set; }
        public bool? IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public List<EmployeePromotionIncrement> employeePromotionIncrements { get; set; }
    }
}
