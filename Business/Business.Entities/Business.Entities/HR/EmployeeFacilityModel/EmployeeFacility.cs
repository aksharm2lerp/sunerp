using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.HR.EmployeeFacilityModel
{
    public class EmployeeFacility
    {
        public int SrNo { get; set; }
        public int EmployeeFacilityID { get; set; }
        public int EmployeeID { get; set; }
        public int FacilityTypeMasterID { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Purpose { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public bool IsReturnable { get; set; }
        public bool IsChargeable { get; set; }
        public int? IssuedBy { get; set; }
        public int? ReceivedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}