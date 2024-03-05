using Business.Interface.Production.IMachineryMaintenanceTxn;
using Business.Entities.Production.MachineryMaintenanceTxnModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SMachineryMaintenanceTxn
{
    public class MachineryMaintenanceTxnService : MachineryMaintenanceTxnInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryMaintenanceTxnService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineryMaintenanceTxn>> GetAllMachineryMaintenanceTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryMaintenanceTxnID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryMaintenanceTxn> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryMaintenanceTxn", param))
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
                    lst = table.ToPagedDataTableList<MachineryMaintenanceTxn>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryMaintenanceTxn> GetMachineryMaintenanceTxnAsync(int MachineryMaintenanceTxnID)
        {
            MachineryMaintenanceTxn result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryMaintenanceID", MachineryMaintenanceTxnID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryMaintenanceTxn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachineryMaintenanceTxn>();
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
        public async Task<int> AddOrUpdateMachineryMaintenanceTxn(MachineryMaintenanceTxn model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@MachineryMaintenanceID", model.MachineryMaintenanceID), new SqlParameter("@ItemCode", model.ItemCode), new SqlParameter("@MachineryID", model.MachineryID), new SqlParameter("@DefectDescription", model.DefectDescription), new SqlParameter("@Troubleshoot", model.Troubleshoot), new SqlParameter("@ActionTakenTime", model.ActionTakenTime), new SqlParameter("@ActionTakenDate", model.ActionTakenDate), new SqlParameter("@ActionTakenBy", model.ActionTakenBy), new SqlParameter("@RepairingCharges", model.RepairingCharges),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryMaintenanceTxn", param);

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


