using Business.Interface.NotificationStatusI;
using Business.SQL;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Business.Entities.NotificationModel;
using Microsoft.Extensions.Configuration;
using Business.Entities.OurProduct;
using Business.Entities.PartyMasterModel;
using Business.Entities.Master;
using Business.Entities.Master.ReminderMasterM;
using System.Diagnostics.CodeAnalysis;

namespace Business.Service.NotificationStatusS
{
    public class NotificationStatusService : INotificationStatus
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public NotificationStatusService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #endregion Database Connection

        #region I&U
        public async Task<int> NotificationStatusInsertOrUpdateAsync(Notification notification)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@NotificationID", notification.NotificationID)
                ,new SqlParameter("@PackageID", notification.PackageID)
                ,new SqlParameter("@UserID", notification.UserID)
                ,new SqlParameter("@NotificationText", notification.NotificationText)
                ,new SqlParameter("@NotificationDateTime", notification.NotificationDateTime)
                ,new SqlParameter("@IsSent", notification.IsSent)
                ,new SqlParameter("@SentDateTime", notification.SentDateTime)
                ,new SqlParameter("@sentToEmail", notification.sentToEmail)
                ,new SqlParameter("@IsView", notification.IsView)
                ,new SqlParameter("@ViewDateTime", notification.ViewDateTime)
                ,new SqlParameter("@IsActive", notification.IsActive)
                ,new SqlParameter("@CreatedOrModifiedBy", notification.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_Notification", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion I&U

        #region Get Notification Count & List

        public async Task<PagedDataTable<Notification>> GetNotificationStatusAsync(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_Notification", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<Notification> lst = table.ToPagedDataTableList<Notification>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public async Task<PagedDataTable<Notification>> GetNotificationCountAsync(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_NotificationCount", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<Notification> lst = table.ToPagedDataTableList<Notification>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        #endregion Get Notification Count & List

        #region Get Notification Conversation Activities..

        public async Task<PagedDataTable<Notification>> GetNotificationConversationActivities(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_NotificationOnConversationActivities", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<Notification> lst = table.ToPagedDataTableList<Notification>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Notification Conversation Activities..

        #region Get User Profile Conversation Activities..

        public async Task<PagedDataTable<PartyMaster>> GetUserProfileConversationActivities(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyMaster", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<PartyMaster> lst = table.ToPagedDataTableList<PartyMaster>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get User Profile Conversation Activities..

        #region View All Notification
        public async Task<int> UpdateViewAllNotification(int userID)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@UserID", userID)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_Update_ViewAllNotification", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion View All Notification

        #region View One Notification
        public async Task<int> UpdateViewOneNotification(int notificationID)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@NotificationID", notificationID)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_Update_ViewOneNotification", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion View One Notification

        #region Get Employee Notification List

        public async Task<PagedDataTable<Notification>> GetEmployeeNotificationList(int userId = 0)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@UserID",userId)
                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_Notification", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                    }
                    PagedDataTable<Notification> lst = table.ToPagedDataTableList<Notification>(0, 0, 0, "", "", "");
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        #region Using Grid View

        //public async Task<PagedDataTable<Notification>> GetAllNotificationAsync(int UserID)
        //{
        //    DataTable table = new DataTable();
        //    int totalItemCount = 0;
        //    try
        //    {
        //        SqlParameter[] param = {
        //            new SqlParameter("@UserID",UserID)
        //                /*new SqlParameter("@PageNo",pageNo)
        //                ,new SqlParameter("@PageSize",pageSize)
        //                ,new SqlParameter("@SearchString",searchString)*/
        //                ,new SqlParameter("@OrderBy","NotificationId")
        //                ,new SqlParameter("@SortBy",1)
        //                };

        //        using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_NotificationforPage", param))
        //        {
        //            if (ds.Tables.Count > 0)
        //            {
        //                table = ds.Tables[0];
        //                if (table.Rows.Count > 0)
        //                {
        //                    if (table.ContainColumn("TotalCount"))
        //                        totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
        //                    else
        //                        totalItemCount = table.Rows.Count;
        //                }
        //            }
        //            PagedDataTable<Notification> lst = table.ToPagedDataTableList<Notification>
        //                (0, 0, 0, "", "", "");
        //            return lst;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (table != null)
        //            table.Dispose();
        //    }
        //}

        #endregion Using Grid View

        #region Using Table View

        public async Task<DataSet> GetAllNotificationAsync(int UserID, DateTime StartDate, DateTime EndDate, string SearchString)
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            //PagedDataTable<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@UserID",UserID),
                        new SqlParameter("@StartDate", StartDate),
                        new SqlParameter("@EndDate", EndDate),
                        new SqlParameter("@SearchString", SearchString),
                        new SqlParameter("@PageNo", 1),
                        new SqlParameter("@PageSize", 10),
                        new SqlParameter("@OrderBy","NotificationID"),
                        new SqlParameter("@SortBy",0)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_NotificationforPage", param);
                //{
                //    if (ds.Tables.Count > 0)
                //    {
                //        table = ds.Tables[0];
                //        if (table.Rows.Count > 0)
                //        {
                //            if (table.ContainColumn("TotalCount"))
                //                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                //            else
                //                totalItemCount = table.Rows.Count;
                //        }
                //    }
                //lst = table.ToPagedDataTableList<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary>(1, 1000, totalItemCount);
                return ds;
                //}
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        #endregion Using Table View

        #endregion Get Employee Notification List

        #region GetRFQListConversationActivities

        public async Task<PagedDataTable<GoForRFQCardTable>> GetRFQListConversationActivities(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyMaster", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<GoForRFQCardTable> lst = table.ToPagedDataTableList<GoForRFQCardTable>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion GetRFQListConversationActivities

        #region Get reminder for meeting.

        public async Task<ReminderModel> GetReminder(int userId = 0)
        {
            try
            {
                ReminderModel reminderModel = null;

                SqlParameter[] param = { new SqlParameter("@UserID", userId) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_Reminder", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            reminderModel = dr.ToPagedDataTableList<ReminderModel>();
                        }
                    }
                }
                return reminderModel;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ReviewReminder(int rminderId)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@ReminderID", rminderId)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_Update_ReminderView", param);

                return Convert.ToBoolean(obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Get reminder for meeting.

        #region Add New Remainder

        public async Task<int> AddReminder(ReminderMasterModel reminderMasterModel, int UDI)
        {
            string date = String.Concat(reminderMasterModel.ReminderDate.ToShortDateString(), ' ', reminderMasterModel.ReminderTime);
            DateTime dt = Convert.ToDateTime(date);
             
            try
            {
                SqlParameter[] param = {
                  new SqlParameter("@ReminderID", 0),
                  new SqlParameter("@PackageID", 15),
                  new SqlParameter("@UserID", UDI),
                  new SqlParameter("@ReminderTitle", "Direct Reminder"),
                  new SqlParameter("@ReminderDateTime",dt ),
                  new SqlParameter("@ReminderSubject", reminderMasterModel.ReminderSubject),
                  new SqlParameter("@ReminderText", reminderMasterModel.ReminderText) 
                  
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_Reminder", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add New Remainder

        #region Show reminder count & list

        public async Task<PagedDataTable<ReminderMasterModel>> GetReminderStatusAsync(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ReminderbyUser", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<ReminderMasterModel> lst = table.ToPagedDataTableList<ReminderMasterModel>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Show reminder count & list

        #region View All reminder
        public async Task<int> UpdateViewAllReminder(int userID)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@UserID", userID)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_Update_ViewAllReminder", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion View All reminder

    }
}
