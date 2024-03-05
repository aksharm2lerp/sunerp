using Business.Entities.Master;
using Business.Entities.Master.ReminderMasterM;
using Business.Entities.NotificationModel;
using Business.Entities.OurProduct;
using Business.Entities.PartyMasterModel;
using Business.SQL;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.NotificationStatusI
{
    public interface INotificationStatus
    {
        Task<PagedDataTable<Notification>> GetNotificationStatusAsync(int id);

        #region NotificationConversationActivities
        Task<PagedDataTable<Notification>> GetNotificationConversationActivities(int id);
        #endregion NotificationConversationActivities

        #region UserProfileConversationActivities
        Task<PagedDataTable<PartyMaster>> GetUserProfileConversationActivities(int id);
        #endregion UserProfileConversationActivities

        Task<int> NotificationStatusInsertOrUpdateAsync(Notification notification);
        Task<int> UpdateViewAllNotification(int userID);
        Task<int> UpdateViewOneNotification(int notificationID);
        Task<PagedDataTable<Notification>> GetEmployeeNotificationList(int userId = 0);
        /*Task<PagedDataTable<Notification>> GetNotificationCountAsync(int id);*/

        #region Get Employee Notification List

        #region Using Grid View

        //Task<PagedDataTable<Notification>> GetAllNotificationAsync(int UserID);

        #endregion Using Grid View

        #region Using Table View

        Task<DataSet> GetAllNotificationAsync(int UserID, DateTime StartDate, DateTime EndDate, string SearchString);

        #endregion Using Table View

        #endregion Get Employee Notification List

        #region GetRFQListConversationActivities
        Task<PagedDataTable<GoForRFQCardTable>> GetRFQListConversationActivities(int id);
        #endregion GetRFQListConversationActivities

        #region Get reminder for meeting.
        Task<ReminderModel> GetReminder(int userId = 0);
        Task<bool> ReviewReminder(int rminderId);

        #endregion Get reminder for meeting.

        #region Add New Remainder
        Task<int> AddReminder(ReminderMasterModel reminderMasterModel, int UDI);
        #endregion Add New Remainder

        #region Show remainder count & list
        Task<PagedDataTable<ReminderMasterModel>> GetReminderStatusAsync(int id);
        #endregion Show remainder count & list

        #region View all reminder 
        Task<int> UpdateViewAllReminder(int userID);
        #endregion View all reminder


    }
}
