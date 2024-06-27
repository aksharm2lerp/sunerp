using Business.Interface.Production.IMachineCategoryMaster;
using Business.Entities.Production.MachineCategoryMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SMachineCategoryMaster
{
    public class MachineCategoryMasterService : MachineCategoryMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineCategoryMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineCategoryMaster>> GetAllMachineCategoryMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineCategoryMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineCategoryMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineCategoryMaster", param))
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
                    lst = table.ToPagedDataTableList<MachineCategoryMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineCategoryMaster> GetMachineCategoryMasterAsync(int MachineCategoryMasterID)
        {
            MachineCategoryMaster result = null;
            try
            {
                //SqlParameter[] param = { new SqlParameter("@MachineCategoryMasterID", MachineCategoryMasterID) };
                SqlParameter[] param = { new SqlParameter("@MachineCategoryID", MachineCategoryMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineCategoryMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachineCategoryMaster>();
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
        public async Task<int> AddOrUpdateMachineCategoryMaster(MachineCategoryMaster model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@MachineCategoryID", model.MachineCategoryID), new SqlParameter("@MachineCategoryName", model.MachineCategoryName), new SqlParameter("@Note", model.Note),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineCategoryMaster", param);

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


