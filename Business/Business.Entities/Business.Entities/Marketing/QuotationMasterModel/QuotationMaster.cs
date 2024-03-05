using GridCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Business.Entities.Marketing.QuotationMasterModel
{
    public class QuotationMaster
    {
        public int SrNo { get; set; }
        public int QuotationID { get; set; }
        public DateTime? QuotationDate { get; set; } = DateTime.Today;

        public string QuotationCode { get; set; }
        public int? FinancialYearID { get; set; }
        public string FinancialYearText { get; set; }
        public int? PartyID { get; set; }
        public string Reference { get; set; }
        public string PartyCode { get; set; }
        public string SAPCollectionJSONString { get; set; }
        public string PartyName { get; set; }
        public int? ShopOrderID { get; set; }
        public DateTime? ShopOrderDate { get; set; } 
        public decimal? NetAmount { get; set; }
        public decimal? GrossAmount { get; set; }
        public string PaymentTerm { get; set; }
        public string DeliveryTerm { get; set; }
        public string OtherRemark { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public int? AddressTypeID { get; set; }

        public int RequestForQuotID { get; set; }
        public DateTime RequestForQuotDate { get; set; }
        public string RequestForQuotCode { get; set; }  
        public string RequestForQuotFinYear { get; set; }

        // public List<QuotationDetail> QuotationDetails { get; set; } = new List<QuotationDetail>();
        public ISGrid iSGrid { get; set; } 
    }

    public class QuotationDetail 
    {
        public int SrNo { get; set; }
        public int QuotationDetailID { get; set; }
        public int QuotationID { get; set; }
        public int? ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string HSNcodes { get; set; }
        public int? UOMID { get; set; }
        public string UOMText { get; set; }
        public string UOM { get; set; }
        public decimal Qty { get; set; } = 0;
        public decimal Rate { get; set; } = decimal.Zero;
        public decimal DiscountInPer { get; set; } = decimal.Zero;
        public decimal DiscountAmount { get; set; } = decimal.Zero;
        public decimal TaxInPer { get; set; } = decimal.Zero;
        public decimal TaxAmount { get; set; } = Decimal.Zero;
        public decimal TotalAmount { get; set; } = decimal.Zero;
        public string Remark { get; set; }
        public bool? IsInspectionRequired { get; set; }
        public int? InspectionAgencyID { get; set; }
        public bool IsActive { get; set; } = true;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
   
    public class QuotationSearch
    {
        public string keyword { get; set; }
        public int CompanyID { get; set; }
    }
}