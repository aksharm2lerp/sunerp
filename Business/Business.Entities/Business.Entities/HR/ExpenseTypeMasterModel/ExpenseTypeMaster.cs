using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.HR.ExpenseTypeMasterModel
{
    public class ExpenseTypeMaster
    {
        public int SrNo { get; set; }
        public int ExpenseTypeID { get; set; }
        public string ExpenseTypeText { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}