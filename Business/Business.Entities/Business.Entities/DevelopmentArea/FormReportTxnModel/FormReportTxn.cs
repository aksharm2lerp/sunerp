using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.DevelopmentArea.FormReportTxnModel
{
    public class FormReportTxn
    {
        public int SrNo { get; set; }
        public int FormReportID { get; set; }
        public string MappingDescription { get; set; }
        public int? FormID { get; set; }
        public int? ReportID { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}