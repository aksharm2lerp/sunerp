using Business.Entities.Designation;
using Business.Entities.Marketing;
using Business.Entities.Marketing.Feedback;
using Business.Entities.PartyMasterModel;
using Business.Interface.Marketing;
using Business.SQL;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Business.Service.Marketing
{
    public class MarketingFeedbackService : IMarketingFeedbackService

    {

        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MarketingFeedbackService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        public async Task<PagedDataTable<MarketingFeedback>> GetAllMarketingFeedbackAsync(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "DepartmentID", string sortBy = "ASC", int userId = 0)
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

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MarketingFeedback", param))
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
                    PagedDataTable<MarketingFeedback> lst = table.ToPagedDataTableList<MarketingFeedback>
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

        public async Task<int> MarketingFeedbackCreateAsync(MarketingFeedback marketingFeedback, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@MarketingFeedbackID", marketingFeedback.MarketingFeedbackID)
                ,new SqlParameter("@FeedbackDate", DateTime.Now)
                ,new SqlParameter("@PartyName", marketingFeedback.PartyName)
                ,new SqlParameter("@PartyTypeID", marketingFeedback.PartyTypeID)
                ,new SqlParameter("@Email", marketingFeedback.Email)
                ,new SqlParameter("@MobileNo", marketingFeedback.MobileNo)
                ,new SqlParameter("@IsReceivedDocument", marketingFeedback.IsReceivedDocument)
                ,new SqlParameter("@Note", marketingFeedback.Note)
                ,new SqlParameter("@PositiveNoteID", marketingFeedback.PositiveNoteID)
                ,new SqlParameter("@CreatedOrModifiedBy", marketingFeedback.CreatedOrModifiedBy)
                ,new SqlParameter("@PartyID", marketingFeedback.PartyID)
                ,new SqlParameter("@UDTT_MarketingFeedbackDetail" ,dataTable)
                };
                param[11].Direction = ParameterDirection.Input;
                param[11].SqlDbType = SqlDbType.Structured;
                param[11].ParameterName = "@UDTT_MarketingFeedbackDetail";
                param[11].TypeName = "UDTT_MarketingFeedbackDetail";
                param[11].Value = dataTable;
                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MarketingFeedback", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MarketingFeedback> GetMarketingFeedbackAsync(int MarketingFeedbackID)
        {
            MarketingFeedback result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MarketingFeedbackID", MarketingFeedbackID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MarketingFeedback", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MarketingFeedback>();

                            List<MarketingFeedbackLogDetail> listMarketingFeedbackLogDetail = new List<MarketingFeedbackLogDetail>();

                            foreach (DataRow item in ds.Tables["Table1"].Rows)
                            {
                                MarketingFeedbackLogDetail marketingFeedbackLogDetail = new MarketingFeedbackLogDetail();
                                marketingFeedbackLogDetail.MarketingFeedbackDetailID = item["MarketingFeedbackDetailID"].ToInt();
                                marketingFeedbackLogDetail.MarketingFeedbackID = item["MarketingFeedbackID"].ToInt();
                                marketingFeedbackLogDetail.PositiveNoteID = item["PositiveNoteID"].ToInt();
                                marketingFeedbackLogDetail.Response = item["Response"].ToString();
                                listMarketingFeedbackLogDetail.Add(marketingFeedbackLogDetail);
                            }
                            result.marketingFeedbackLogDetails = listMarketingFeedbackLogDetail;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MarketingFeedback GetForm(int id, int MarketingFeedbackID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ID", id);
                param.Add("@MarketingFeedbackID", MarketingFeedbackID);
                return QueryHelper.GetTableDetail<MarketingFeedback>(connection, "Usp_Get_MasterList", param);
            }
            catch
            {
                throw;
            }
        }

        public PagedDataTable<MarketingFeedback> GetAllFeedbackNote()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MarketingFeedback> lst = new PagedDataTable<MarketingFeedback>();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PageNo", 1),
                    new SqlParameter("@PageSize", "0"),
                };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_PositiveNote", param))
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
                    lst = table.ToPagedDataTableList<MarketingFeedback>();
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
            return lst;
        }

        public PagedDataTable<PartyMaster> GetAllPartyMaster()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<PartyMaster> lst = new PagedDataTable<PartyMaster>();
            try
            {
                //SqlParameter[] param = {
                //    new SqlParameter("@PageNo", 1),
                //    new SqlParameter("@PageSize", "0"),
                //};
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyMasterForDropdown"))
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
                    lst = table.ToPagedDataTableList<PartyMaster>();
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
            return lst;
        }
    }
}
