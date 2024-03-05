using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.HR.UserMapToEmployeeModel
{
    public class UserMapToEmployee
    {
        public int SrNo { get; set; }
        public int UserMapToEmployeeID { get; set; }
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string UserName { get; set; }
        public string Remarks { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}