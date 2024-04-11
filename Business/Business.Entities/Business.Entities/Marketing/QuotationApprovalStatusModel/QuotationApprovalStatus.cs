using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Marketing.QuotationApprovalStatusModel
{
    public class QuotationApprovalStatus
    {
        public int SrNo { get; set; }
        public int QuotationApprovalStatusID { get; set; }
        public string QuotationApprovalStatusName { get; set; }
        public string StatusDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}