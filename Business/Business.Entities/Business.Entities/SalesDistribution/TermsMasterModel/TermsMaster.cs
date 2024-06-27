using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.SalesDistribution.TermsMasterModel
{
    public class TermsMaster
    {
        public int SrNo { get; set; }
        public int TermsID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string TermText { get; set; }
        public int? TermTypeID { get; set; }
        public string TermTypeText { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}