using Business.Entities.Marketing;
using Business.Entities.Marketing.CommunicationLog;
using Business.Entities.Marketing.Feedback;
using Business.Interface.Marketing.CommunicatonLog;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Service.Marketing.CommunicationLogService
{
    public class MarketingCommunicationLogService : IMarketingCommunicationLogService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MarketingCommunicationLogService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        public async Task<PagedDataTable<CommunicationLog>> GetAllMarketingCommunicationLogAsync(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "MarketingCommunicationLogID", string sortBy = "DESC", int userId = 0)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                         ,new SqlParameter("@UserID",userId)
                        };

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MarketingCommunicationLog", param))
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
                    PagedDataTable<CommunicationLog> lst = table.ToPagedDataTableList<CommunicationLog>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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

        public async Task<int> MarketingCommunicationLogInsertOrUpdateAsync(CommunicationLog communicationLog, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@MarketingCommunicationLogID", communicationLog.MarketingCommunicationLogID)
                ,new SqlParameter("@ContactByPerson", communicationLog.ContactByPerson)
                ,new SqlParameter("@ContactTo", communicationLog.ContactTo)
                ,new SqlParameter("@ContactChannelTypeID", communicationLog.ContactChannelTypeID)
                ,new SqlParameter("@Email", communicationLog.Email)
                ,new SqlParameter("@MobileNo", communicationLog.MobileNo)
                ,new SqlParameter("@VenueTypeID", communicationLog.VenueTypeID)
                ,new SqlParameter("@PartyTypeID", communicationLog.PartyTypeID)
                ,new SqlParameter("@CommunicationLogDate", communicationLog.CommunicationLogDate)
                ,new SqlParameter("@PlaceOfMeeting", communicationLog.PlaceOfMeeting)
                ,new SqlParameter("@IsSentDocument", communicationLog.IsSentDocument)
                ,new SqlParameter("@IsSentMarketingDocument", communicationLog.IsSentMarketingDocument)
                ,new SqlParameter("@ReferenceBetterBusiness", communicationLog.ReferenceBetterBusiness)
                ,new SqlParameter("@ReferenceMobileOrEmail", communicationLog.ReferenceMobileOrEmail)
                ,new SqlParameter("@Note", communicationLog.Note)
                ,new SqlParameter("@Feedback", communicationLog.Feedback)
                ,new SqlParameter("@FeedbackNoteID", communicationLog.FeedbackNoteID)
                ,new SqlParameter("@EmployeeID", communicationLog.EmployeeID)
                ,new SqlParameter("@PartyID", communicationLog.PartyID)
                //,new SqlParameter("@EmployeeName", communicationLog.EmployeeName)
                ,new SqlParameter("@CreatedOrModifiedBy", communicationLog.CreatedOrModifiedBy)
                ,new SqlParameter("@UDTT_MarketingCommunicationLogDetail", dataTable)
                };
                param[20].Direction = ParameterDirection.Input;
                param[20].SqlDbType = SqlDbType.Structured;
                param[20].ParameterName = "@UDTT_MarketingCommunicationLogDetail";
                param[20].TypeName = "UDTT_MarketingCommunicationLogDetail";
                param[20].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MarketingCommunicationLog", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CommunicationLog> GetMarketingCommunicationLogAsync(int MarketingCommunicationLogID)
        {
            CommunicationLog result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MarketingCommunicationLogID", MarketingCommunicationLogID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MarketingCommunicationLog", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<CommunicationLog>();
                            List<MarketingCommunicationLogDetail> listMarketingCommunicationLogDetail = new List<MarketingCommunicationLogDetail>();

                            foreach (DataRow item in ds.Tables["Table1"].Rows)
                            {
                                MarketingCommunicationLogDetail marketingCommunicationLogDetail = new MarketingCommunicationLogDetail();
                                marketingCommunicationLogDetail.MarketingCommunicationLogDetailID = item["MarketingCommunicationLogDetailID"].ToInt();
                                marketingCommunicationLogDetail.MarketingCommunicationLogID = item["MarketingCommunicationLogID"].ToInt();
                                marketingCommunicationLogDetail.PositiveNoteID = item["PositiveNoteID"].ToInt();
                                marketingCommunicationLogDetail.Response = item["Response"].ToString();
                                listMarketingCommunicationLogDetail.Add(marketingCommunicationLogDetail);
                            }
                            result.marketingCommunicationLogDetails = listMarketingCommunicationLogDetail;
                        }
                    }
                }
                return result;
                //return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
