using Business.Interface.Production.IMachineryDepreciationTxn;
using Business.Entities.Production.MachineryDepreciationTxnModel;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Business.Service.Production.SMachineryDepreciationTxn
{
    public class MachineryDepreciationTxnService : MachineryDepreciationTxnInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryDepreciationTxnService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineryDepreciationTxn>> GetAllMachineryDepreciationTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryDepreciationTxnID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryDepreciationTxn> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryDepreciationTxn", param))
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
                    lst = table.ToPagedDataTableList<MachineryDepreciationTxn>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryDepreciationTxn> GetMachineryDepreciationTxnAsync(int MachineryDepreciationTxnID)
        {
            MachineryDepreciationTxn result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryDepreciationID", MachineryDepreciationTxnID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryDepreciationTxn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachineryDepreciationTxn>();
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
        public async Task<int> AddOrUpdateMachineryDepreciationTxn(MachineryDepreciationTxn model)
        {
            try
            {
                SqlParameter[] param = {
                 new SqlParameter("@MachineryDepreciationID", model.MachineryDepreciationID), 
                    new SqlParameter("@ItemCode", model.ItemCode), 
                    new SqlParameter("@MachineryID", model.MachineryID), 
                    new SqlParameter("@PurchaseAmount", model.PurchaseAmount), 
                    new SqlParameter("@Rate", model.Rate), 
                    new SqlParameter("@NoOfYear", model.NoOfYear), 
                    new SqlParameter("@DepreciationMethodID", model.DepreciationMethodID),
                    new SqlParameter("@DepreciationAmount", model.DepreciationAmount), 
                    new SqlParameter("@ResidualValue", model.ResidualValue), 
                    new SqlParameter("@PurchaseOn", model.PurchaseOn),new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryDepreciationTxn", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Positive Note

        #region Machinery depreciation report
        public async Task<DataSet> MachineryDepreciationReportAsync(string searchString)
        {
            try
            {
                SqlParameter[] param = {
                 new SqlParameter("@SearchString", searchString)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Report_MachineryDepreciation", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Machinery depreciation report
    }
}


