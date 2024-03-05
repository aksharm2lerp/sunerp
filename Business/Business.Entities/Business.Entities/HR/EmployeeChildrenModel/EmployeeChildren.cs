using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.HR.EmployeeChildrenModel
{
    public class EmployeeChildren
    {
        public int SrNo { get; set; }
        public int EmployeeChildrenID { get; set; }
        public string ChildFullName { get; set; }
        public DateTime? DOB { get; set; }
        public bool IsStudying { get; set; }
        public string StandardOrDegree { get; set; }
        public string SchoolOrUniversity { get; set; }
        public int EmployeeID { get; set; }
        public bool IsActive { get; set; } = true;
        public bool FromFamilyBackground { get; set; } = false;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}