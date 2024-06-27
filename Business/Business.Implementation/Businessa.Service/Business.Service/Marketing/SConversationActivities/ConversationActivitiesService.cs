using Business.Entities.PartyMasterModel;
using Business.Interface.Marketing.IConversationActivities;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Business.Entities.NotificationModel;
using Business.Entities.OurProduct;
using Business.Entities.Employee;

namespace Business.Service.Marketing.ConversationActivitiesService
{
    public class ConversationActivitiesService : ConversationActivitiesInterface
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public ConversationActivitiesService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #endregion Database Connection

        #region Get User Profile Conversation Activities

        //public async Task<PagedDataTable<PartyMaster>> GetUserProfileConversationActivities(int id)
        //{
        //    DataTable table = new DataTable();
        //    int totalItemCount = 0;
        //    try
        //    {
        //        SqlParameter[] param = {
        //            new SqlParameter("@PartyID", id)
        //        };
        //        DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartySummary", param);
        //        if (ds.Tables.Count > 0)
        //        {
        //            table = ds.Tables[0];
        //            if (table.Rows.Count > 0)
        //            {
        //                if (table.ContainColumn("TotalCount"))
        //                    totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
        //                else
        //                    totalItemCount = 0;
        //            }
        //        }
        //        PagedDataTable<PartyMaster> lst = table.ToPagedDataTableList<PartyMaster>
        //            (0, 0, totalItemCount, "", "", "");
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion Get User Profile Conversation Activities

        #region Get Notification Conversation Activities..

        public async Task<PagedDataTable<Notification>> GetNotificationConversationActivities(int partyid, int userid)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", userid),
                    new SqlParameter("@PartyID", partyid)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyNotification", param);
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

        /*public async Task<PartyMaster> GetUserProfileConversationActivities(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyWisePartyMaster", param);
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
        }*/

        public async Task<PartyMaster> GetUserProfileConversationActivities(int id)
        {
            PartyMaster result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyWisePartyMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyMaster>();
                        }
                        /*else
                        {
                            DataTable table = new DataTable();
                            table = ds.Tables[0];
                            result = table.ToPagedDataTableList<PartyMaster>();
                        }*/
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get User Profile Conversation Activities..

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

        #region Send Mail

        public async Task<int> IUSendMail(string recipientToName, string subjectLine, string messageBox, int userid)
        {
            try
            {

                SqlParameter[] param = {
          new SqlParameter("@FromEmailID", 1),
          new SqlParameter("@EmailTo", recipientToName),
                    //new SqlParameter("@EmailCc", recipientCcName),
                    //new SqlParameter("@EmailBcc", recipientBccName),
                    new SqlParameter("@EmailSubject", subjectLine),
          new SqlParameter("@EmailBody", messageBox),
          new SqlParameter("@UserID", userid),
        };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "usp_IU_EmailSentToSvc", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Send Mail

        #region Party To Customer

        public async Task<int> PartyToCustomer(int PartyID, int userid)
        {
            try
            {

                SqlParameter[] param = {
                new SqlParameter("@PartyID", PartyID),
                //new SqlParameter("@UserID", userid)
            };
                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "UPS_Migrate_PartyToCostumer", param);
                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Party To Customer

        #region party List of RFQ 
        public async Task<PagedDataTable<RequestedforQuotLists>> GetPartyRFQListConversationActivities(int partyid)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyID", partyid)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_RequestForQuotPartyList", param);
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
                PagedDataTable<RequestedforQuotLists> lst = table.ToPagedDataTableList<RequestedforQuotLists>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion party List of RFQ 

    }
}
