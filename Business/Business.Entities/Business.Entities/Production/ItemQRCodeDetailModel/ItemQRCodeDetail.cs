using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.ItemQRCodeDetailModel
{
    public class ItemQRCodeDetail
    {
        public int SrNo { get; set; }
        public int ItemQRCodeDetailID { get; set; }
        public string SONo { get; set; }
        public DateTime? SODate { get; set; }
        public string PlanningCard { get; set; }
        public string MachineryName { get; set; }
        public int? MachineryID { get; set; }
        public int? ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UOM { get; set; }
        public int? UOMID { get; set; }
        public decimal? Qty { get; set; }
        public bool IsQRCodeGenerated { get; set; }
        public int? NoOfTakenPrint { get; set; }
        public int? DepartmentID { get; set; }
        public int? LocationID { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public int NoOfCount { get; set; } = 0;
    }
}