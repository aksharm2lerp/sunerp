using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.DevelopmentArea.ReportMasterModel
{
    public class ReportMaster
    {
        public int SrNo { get; set; }
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public string ReportPath { get; set; }
        public string CommandType { get; set; }
        public string CommandText { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}