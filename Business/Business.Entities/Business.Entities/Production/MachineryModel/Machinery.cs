using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryModel
{
    public class Machinery
    {
        public int SrNo { get; set; }
        public int MachineryID { get; set; }
        public string ItemCode { get; set; }
        public int? ItemGroupID { get; set; }
        public string ItemGroupName { get; set; } = string.Empty;
        public int? ItemSubGroupID { get; set; }
        public string ItemSubGroupText { get; set; } = string.Empty;
        public int? DepartmentID { get; set; }
        public int? LocationID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string MachineryName { get; set; } = string.Empty;
        public int? MachineCategoryID { get; set; }
        public string MachineCategoryName { get; set; } = string.Empty;
        public int? MachineOperatingStatusID { get; set; }
        public string MachineOperatingStatusText { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Weight { get; set; } = string.Empty;
        public string SizeDimension { get; set; } = string.Empty;
        public string ShiftingNote { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}