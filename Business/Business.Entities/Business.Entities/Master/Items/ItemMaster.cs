using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Master
{
    public class ItemMaster
    {
        public int ItemID { get; set; }
        [Required(ErrorMessage = "Please enter item name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please enter item code")]
        public string ItemCode { get; set; }
        public string ClientItemName { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select item group")]
        public int ItemSubGroupID { get; set; }
        [Required(ErrorMessage = "Please select item sub group")]
        public int ItemGroupID { get; set; }
        [Required(ErrorMessage = "Please select UOM number")]
        public int UOMID { get; set; }
        public bool IsGST { get; set; }
        public decimal MinLevel { get; set; }
        public decimal MaxLevel { get; set; }
        public decimal ReorderLevel { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal Rate { get; set; }
        [Required(ErrorMessage = "Please select location")]
        public int DefaultLocationID { get; set; }
        public int IsActive { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ChapterHeaderNo { get; set; }
        public string ComodityCode { get; set; }
        [Required(ErrorMessage = "Please select warehouse")]
        public int WareHouseID { get; set; }
        public int SrNo { get; set; }
        public string DefaultLocation { get; set; }
        public int CLBL_QTY { get; set; }
    }

    public class ItemSearch
    {
        public string keyword { get; set; }
        public int QtyFrom { get; set; }
        public int QtyTo { get; set;}
        public int ItemSubGroupID { get; set; }
        public int ItemGroupID { get; set; }
        public int DefaultLocationID { get; set; }

    }
}