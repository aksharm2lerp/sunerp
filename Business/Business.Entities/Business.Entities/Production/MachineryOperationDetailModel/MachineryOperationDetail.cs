using Business.Entities.Production.MachineryUtilityConsumptionModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryOperationDetailModel
{
    public class MachineryOperationDetail
    {
        public int SrNo { get; set; }
        public int MachineryOperationDetailID { get; set; }
        public string OperationUses { get; set; }
        public string ProductionCapacity { get; set; }
        public string NoOfOperators { get; set; }
        public string NoOfHelpers { get; set; }
        public string PowerConsumption { get; set; }
        public string RiskFactor { get; set; } = string.Empty;
        public int? UOMID { get; set; }
        public int? UtilityID { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public string UtilityString { get; set; }
        public List<MachineryUtilityConsumption> machineryUtilityConsumptions { get; set; } = new List<MachineryUtilityConsumption>();
    }
}