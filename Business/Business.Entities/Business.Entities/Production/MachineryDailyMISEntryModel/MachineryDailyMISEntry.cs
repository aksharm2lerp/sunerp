using Business.Entities.Production.MachineryUtilityConsumptionModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryDailyMISEntryModel
{
    public class MachineryDailyMISEntry
    {
        public int SrNo { get; set; }
        public int MachineryDailyMISEntryID { get; set; }
        public string ItemCode { get; set; }
        public int? MachineryID { get; set; }

        public string MachineryName { get; set; }
        public string NoOfOperators { get; set; }
        public string NoOfHelpers { get; set; }
        public string WorkingHours { get; set; }
        public int? ShiftID { get; set; }
        public string ShopWorkOrderNo { get; set; }
        public int? ItemID { get; set; }
        public string OutputStock { get; set; }
        public int? UOMID { get; set; }
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