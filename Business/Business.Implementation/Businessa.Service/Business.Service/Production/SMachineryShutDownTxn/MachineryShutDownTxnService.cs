using Business.Interface.Production.IMachineryShutDownTxn;
using Business.Entities.Production.MachineryShutDownTxnModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SMachineryShutDownTxn
{
    public class MachineryShutDownTxnService : MachineryShutDownTxnInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryShutDownTxnService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineryShutDownTxn>> GetAllMachineryShutDownTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryShutDownTxnID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryShutDownTxn> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryShutDownTxn", param))
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
                    lst = table.ToPagedDataTableList<MachineryShutDownTxn>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryShutDownTxn> GetMachineryShutDownTxnAsync(int MachineryShutDownTxnID)
        {
            MachineryShutDownTxn result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryShutDownID", MachineryShutDownTxnID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryShutDownTxn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachineryShutDownTxn>();
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
        public async Task<int> AddOrUpdateMachineryShutDownTxn(MachineryShutDownTxn model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@MachineryShutDownID", model.MachineryShutDownID), new SqlParameter("@ItemCode", model.ItemCode), new SqlParameter("@MachineryID", model.MachineryID), new SqlParameter("@ShutDownReason", model.ShutDownReason), new SqlParameter("@ActionTakenTime", model.ActionTakenTime), new SqlParameter("@ActionTakenDate", model.ActionTakenDate), new SqlParameter("@ActionTakenBy", model.ActionTakenBy),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryShutDownTxn", param);

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


