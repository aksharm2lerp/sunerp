using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Marketing.QuotationMasterModel
{
    public class QuotationReviewDetail { 
        public int SrNo { get; set; }
        public int? QuotationReviewID { get; set; }
        public int? QuotationID { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? QuotationDate { get; set; }
        public decimal? Amount { get; set; }
        public int? QuotationApprovalStatusID { get; set; }
        public int? AuthenticatedBy { get; set; }
        public DateTime? AuthenticatedDate { get; set; }
        public string QuotationApprovalStatusName { get; set; }
        public string Comment { get; set; }
        public string QuotationCode { get; set; }      
        public int CreatedOrModifiedBy { get; set; } 
    }
}
