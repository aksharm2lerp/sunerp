using Business.Interface.IEndUserTypeMasterService;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.SAdmin.EndUserTypeMaster
{
    public class EndUserTypeMasterService : EndUserTypeMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public EndUserTypeMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<Entities.Admin.EndUserTypeMasterModel.EndUserTypeMaster>> GetAllEndUserTypeMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "EndUserTypeMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<Entities.Admin.EndUserTypeMasterModel.EndUserTypeMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EndUserTypeMaster", param))
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
                    lst = table.ToPagedDataTableList<Entities.Admin.EndUserTypeMasterModel.EndUserTypeMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<Entities.Admin.EndUserTypeMasterModel.EndUserTypeMaster> GetEndUserTypeMasterAsync(int EndUserTypeMasterID)
        {
            Entities.Admin.EndUserTypeMasterModel.EndUserTypeMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@EndUserTypeMasterID", EndUserTypeMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EndUserTypeMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<Entities.Admin.EndUserTypeMasterModel.EndUserTypeMaster>();
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
        public async Task<int> AddOrUpdateEndUserTypeMaster(Entities.Admin.EndUserTypeMasterModel.EndUserTypeMaster model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@EndUserTypeMasterID", model.EndUserTypeMasterID), new SqlParameter("@EndUserTypeText", model.EndUserTypeText), new SqlParameter("@EndUserTypeTableName", model.EndUserTypeTableName),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EndUserTypeMaster", param);

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


