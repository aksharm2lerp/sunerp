using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.DevelopmentArea.ReportParametersTxnModel
{
    public class ReportParametersTxn
    {
        public int SrNo { get; set; }
        public int ReportParametersID { get; set; }
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public int? ReportID { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}