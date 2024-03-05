using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Master
{
    public class ItemTableCollection
    {
        public int ItemTableCollectionID { get; set; }
        public int ItemCategoryID { get; set; }
        [Required(ErrorMessage = "Please enter table name")]
        public string TableName { get; set; }
        [Required(ErrorMessage = "Please enter column1")]
        public string Column1Name { get; set; }
        public string Column2Name { get; set; }
        public string Column3Name { get; set; }
        public bool IsActive { get; set; }
        public string CreatedOrModfiedBy { get; set; }
        public int CreatedOrModfiedByUserID { get; set; }
        public string Column1Type { get; set; }
        public string Column2Type { get; set; }
        public string Column3Type { get; set; }
        public int SrNo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

public class MyType
{
    public string name { get; set; }
    public string value { get; set; }

}


public class FinishGoodItemDynamic
{
    public int ItemTableCollectionID { get; set; }
    public string TableName{get; set;}
    public List<MyType> aList { get; set; }
}


public class BillMaterial
{
    public string BOMCode { get; set; }
    public string ItemCode { get; set; }
    public string ItemDescription { get; set; }
    public string UOM { get; set; }    
    public int Qty { get; set; }    
    public decimal ExpectedCost { get; set;}
    public decimal ActualCost { get; set; }
    public DateTime Date { get; set; }
    public string BomType { get; set; }
    public string BomLevel { get; set; }
}