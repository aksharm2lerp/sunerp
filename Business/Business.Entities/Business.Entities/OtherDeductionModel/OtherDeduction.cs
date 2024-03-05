using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.OtherDeductionModel
{
    public class OtherDeduction
    {
        public int SrNo { get; set; }
        public int OtherDeductionID { get; set; }

        [Required(ErrorMessage = "Please select Employee Name.")]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please select Payment date.")]
        public DateTime? PaymentDate { get; set; }

        [RegularExpression("^[0-9.]*$", ErrorMessage = "Amount be in number.")]
        public int? Amount { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentText { get; set; }
    }
}
