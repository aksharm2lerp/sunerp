using Business.Interface.IUserActivityLogService;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.SAdmin.UserActivityLog
{
    public class UserActivityLogService : UserActivityLogInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public UserActivityLogService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<Entities.Admin.UserActivityLogModel.UserActivityLog>> GetAllUserActivityLogAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "UserActivityLogID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<Entities.Admin.UserActivityLogModel.UserActivityLog> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_UserActivityLog", param))
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
                    lst = table.ToPagedDataTableList<Entities.Admin.UserActivityLogModel.UserActivityLog>(pageNo, pageSize, totalItemCount);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        #endregion Index page

        #region Get Singal Record
        public async Task<Entities.Admin.UserActivityLogModel.UserActivityLog> GetUserActivityLogAsync(int UserActivityLogID)
        {
            Entities.Admin.UserActivityLogModel.UserActivityLog result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@UserActivityLogID", UserActivityLogID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_UserActivityLog", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<Entities.Admin.UserActivityLogModel.UserActivityLog>();
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
        #endregion Get Singal Record

        #region Add or Update Positive Note
        public async Task<int> AddOrUpdateUserActivityLog(Entities.Admin.UserActivityLogModel.UserActivityLog model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@UserActivityLogID", model.UserActivityLogID), new SqlParameter("@ActivityLogText", model.ActivityLogText), new SqlParameter("@PackageID", model.PackageID), new SqlParameter("@StartUserName", model.StartUserName), new SqlParameter("@EndUserName", model.EndUserName), new SqlParameter("@PageName", model.PageName),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_UserActivityLog", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Positive Note
    }
}


