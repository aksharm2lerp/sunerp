using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Production.MachineryUtilityConsumptionModel
{
    public class MachineryUtilityConsumption
    {
        public int MachineryUtilityConsumptionID { get; set; }
        public int MachineryOperationDetailID { get; set; }
        public int MachineryDailyMISEntryID { get; set; }
        public int UOMID { get; set; }
        public int UtilityID { get; set; }
        public int Number { get; set; }
    }
}
