using Business.Entities.NotificationModel;
using Business.Entities.OurProduct;
using Business.Entities.PartyMasterModel;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IConversationActivities
{
    public interface ConversationActivitiesInterface
    {
        #region NotificationConversationActivities
        Task<PagedDataTable<Notification>> GetNotificationConversationActivities(int partyid, int userid);
        #endregion NotificationConversationActivities

        #region UserProfileConversationActivities
        Task<PartyMaster>GetUserProfileConversationActivities(int id);
        #endregion UserProfileConversationActivities

        #region GetRFQListConversationActivities
        Task<PagedDataTable<GoForRFQCardTable>>GetRFQListConversationActivities(int id);
        #endregion GetRFQListConversationActivities

        #region Send Mail

        Task<int> IUSendMail(string recipientToName, string subjectLine, string messageBox, int userid);

        #endregion Send Mail

        #region Party To Customer
        Task<int> PartyToCustomer(int PartyID, int userid);
        #endregion Party To Customer
    }
}
