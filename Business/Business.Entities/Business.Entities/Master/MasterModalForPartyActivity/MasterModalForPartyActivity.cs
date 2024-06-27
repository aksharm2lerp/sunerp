using Business.Entities.NotificationModel;
using Business.Entities.PartyMasterModel;
using System.Collections.Generic;

namespace Business.Entities.Master.MasterModalForPartyActivity
{
    public class MasterModalForPartyActivity
    {
        public List<Notification> notification { get; set; }
        public List<RequestedforQuotLists> requestedforQuotLists { get; set; }
        public PartyMaster partyMaster { get; set; }



    }
}
