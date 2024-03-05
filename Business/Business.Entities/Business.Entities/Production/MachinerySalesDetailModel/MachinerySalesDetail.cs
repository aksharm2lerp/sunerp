using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachinerySalesDetailModel
{
    public class MachinerySalesDetail
    {
        public int SrNo { get; set; }
        public int MachinerySalesDetailID { get; set; }
        public string ItemCode { get; set; }
        public int? MachineryID { get; set; }

        public string MachineryName { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string LRNo { get; set; }
        public DateTime? LRDate { get; set; }
        public string TransportationName { get; set; }
        public string DispatchLocation { get; set; }
        public string PartyName { get; set; }
        public int? MachineOperatingStatusID { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}