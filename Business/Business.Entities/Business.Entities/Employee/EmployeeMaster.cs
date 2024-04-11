﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities.Employee
{
    public class EmployeeMaster
    {
        public int SrNo { get; set; }
        public int EmployeeID { get; set; }

        [NotMapped]
        public string EncryptedId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationText { get; set; }
        public string ReportingToMan { get; set; }
        public string GenderText { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsHRDataExist { get; set; } 
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }

    }
}
