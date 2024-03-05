using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Employee
{
    public class AddUpdateEmployee
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee code cannot be null.")]
        public string EmployeeCode { get; set; }
        public string PrefixName { get; set; }

        [Required(ErrorMessage = "First name cannot be null.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name cannot be null.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Select employee gender.")]
        public int GenderID { get; set; }
        [Required(ErrorMessage = "Select employee blood group.")]
        public int EmployeeBloodGroupID { get; set; }
        public string BloodGroupText { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsHOD { get; set; }
        [Required(ErrorMessage = "Job Title cannot be null.")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Select department name.")]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Select designation name.")]
        public int DesignationID { get; set; }
        public string DesignationText { get; set; }
        [Required(ErrorMessage = "Select reporter name.")]
        public int? ReportingTo { get; set; }
        public int? ReportingToOther { get; set; }
        public string ReportingToName { get; set; }

        [Required(ErrorMessage = "Personal mobile no. cannot be null.")]
        public string PersonalMobileNo { get; set; }

        [Required(ErrorMessage = "Office mobile no. cannot be null.")]
        public string OfficeMobileNo { get; set; }

        [Required(ErrorMessage = "Alternative mobile no. cannot be null.")]
        public string AlternativeMobileNo { get; set; }
        public bool IsResigned { get; set; }
        public string Note { get; set; }
        public int? EmailGroupID { get; set; }

        [Required(ErrorMessage = "Personal email cannot be null.")]
        [EmailAddress(ErrorMessage = "Enter valid EmailID.")]
        public string PersonalEmail { get; set; }

        /*[EmailAddress(ErrorMessage = "Enter valid EmailID.")]
        [Required(ErrorMessage = "Office email cannot be null.")]*/
        public string OfficeEmail { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Select Birthdate")]
        public DateTime BirthDate { get; set; }
        public string Religion { get; set; }
        public int CompanyID { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ReferenceBy { get; set; }
        public string ReferenceContact { get; set; }
        public string ReferenceEmail { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public int EmploymentTypeID { get; set; }
        public string EmploymentTypeText { get; set; }
        public string CompanyName { get; set; }
        public int EmploymentStatusID { get; set; }
        public string EmploymentStatusText { get; set; }
        [Required(ErrorMessage = "Please enter Adhar card number.")]
        [RegularExpression("^[2-9]{1}[0-9]{3}\\s[0-9]{4}\\s[0-9]{4}$",ErrorMessage ="Invalid Adhar Number.")]
        public string AadharCardNo { get; set; }
        [RegularExpression("[A-Z]{5}[0-9]{4}[A-Z]{1}", ErrorMessage = "Invalid PAN Number.")]
        public string PANCardNo { get; set; }
        public string VoterIDNo { get; set; }
        public string ReportingToArray { get; set; }
    }


}
