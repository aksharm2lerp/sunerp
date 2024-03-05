using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.HR.ExpensesTxnModel
{
    public class ExpensesTxn
    {
        public int SrNo { get; set; }
        public int ExpensesID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ExpenseTypeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Purpose { get; set; }
        public string ExpensesDetail { get; set; }
        public decimal? ExpensesAmount { get; set; }
        public bool IsPaidByEmployee { get; set; }
        public bool IsPaidByCompany { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}