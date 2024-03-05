using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.HR.MachineryResourceAllocationModel
{
    public class MachineryResourceAllocation
    {
        public int SrNo { get; set; }
        public int MachineryResourceAllocationID { get; set; }
        public DateTime AllocationDate { get; set; } = DateTime.Now;
        public int? ShiftID { get; set; }
        public string Shift { get; set; }
        public int? DepartmentID { get; set; }
        public string Department { get; set; }
        public int? MachineryID { get; set; }
        public string Operators { get; set; }
        public string Helpers { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public string MachineryName { get; set; }
    }
}