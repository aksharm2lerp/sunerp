using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Master
{
    public class ItemSubGroupMaster

    {
        public int ItemSubGroupID { get; set; }
        public string ItemSubGroupText { get; set; }
    }

    public class ItemGroupMaster
    {
        public int ItemGroupID { get; set; }
        public string ItemGroupName { get; set;}    
    }

    public class LocationMaster
    {
        public int LocationID { get; set; }      
        public string LocationName { get; set; }

    }

    public class WareHouseMaster
    {
        public int WareHouseID { get; set; }
        public string WareHouseName { get; set; }    
    }
}
