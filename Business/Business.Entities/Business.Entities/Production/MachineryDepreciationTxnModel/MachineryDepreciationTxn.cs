using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryDepreciationTxnModel
{
    public class MachineryDepreciationTxn
    {
        public int SrNo { get; set; }
        public int MachineryDepreciationID { get; set; }
        public string ItemCode { get; set; }
        public int? MachineryID { get; set; }

        public string MachineryName { get; set; }
        public decimal PurchaseAmount { get; set; } = decimal.Zero;
        public decimal Rate { get; set; } = decimal.Zero;
        public int NoOfYear { get; set; } = 1;
        public int? DepreciationMethodID { get; set; }
        public decimal ResidualValue { get; set; }
        public decimal DepreciationAmount { get; set; }
        public DateTime PurchaseOn { get; set; } = DateTime.Today;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}