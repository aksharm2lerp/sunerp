using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryShutDownTxnModel
{
    public class MachineryShutDownTxn
    {
        public int SrNo { get; set; }
        public int MachineryShutDownID { get; set; }
        public string ItemCode { get; set; }
        public int? MachineryID { get; set; }
        public string MachineryName { get; set; }
        public string ShutDownReason { get; set; }
        public DateTime ActionTakenTime { get; set; } = DateTime.Now;
        public DateTime ActionTakenDate { get; set; } = DateTime.Now;
        public string ActionTakenBy { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}