using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryEquippedDetailModel
{
    public class MachineryEquippedDetail
    {
        public int SrNo { get; set; }

        public string ItemCode { get; set; }
        public int? MachineryID { get; set; }

        public string MachineryName { get; set; }
        public int MachineryEquippedDetailID { get; set; }
        public DateTime? EquippedDate { get; set; }
        public int? CompanyID { get; set; }
        public int? DepartmentID { get; set; }
        public string PlantNameOrNumber { get; set; }
        public string PositionOrLocation { get; set; }
        public string CostCenter { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }

    }
}