using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.PartyMasterModel
{
    public class RequestedforQuotLists
    {
        public int SrNo { get; set; }
        public string ItemName {get; set;}
        public string UOMText {get; set;}
        public int Qty {get; set;}
        public string status { get; set; }
    }
}
