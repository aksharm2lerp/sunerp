using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryPurchaseDetailModel
{
    public class MachineryPurchaseDetail
    {
        public int SrNo { get; set; }
        public int MachineryPurchaseDetailID { get; set; }
        public string ItemCode { get; set; }
        public int? MachineryID { get; set; }

        public string MachineryName { get; set; }
        public string GRNNo { get; set; }
        public DateTime? GRNDate { get; set; } = DateTime.Today;
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; } = DateTime.Today;
        public string CompanyManufacturerName { get; set; }
        public string CountryOrigin { get; set; }
        public string ModelNumber { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string PartNumber { get; set; }
        public int? AccountHead { get; set; }
        public string ManufacturingSerialNumber { get; set; }
        public decimal? PurchaseAmount { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}