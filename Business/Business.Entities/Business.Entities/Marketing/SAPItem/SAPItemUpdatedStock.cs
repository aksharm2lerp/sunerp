using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Marketing.SAPItem
{
    public class SAPUpdateItemStock
    {
        public int SAPItemCollectionID { get; set; }
        public string WareHouse { get; set; }
        public string ItemGroupName { get; set; }
        public string FinishGoodName { get; set; }
        public int CoilLenght { get; set; }
        public int NoOfCoils { get; set; }
        public int TotalMtr { get; set; }
        public string BinLocation { get; set; }
        public string ItemCode { get; set; }
        public int AgingInDays { get; set; }
    }
    public class SAPItemGroup
    {
        public string ItemGroupName { get; set; }

    }

    public class WareHouse
    {
        public string Warehouse { get; set; }
    }
}
