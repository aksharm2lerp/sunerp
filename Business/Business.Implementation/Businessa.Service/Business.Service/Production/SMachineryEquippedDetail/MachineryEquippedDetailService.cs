using Business.Interface.Production.IMachineryEquippedDetail;
using Business.Entities.Production.MachineryEquippedDetailModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SMachineryEquippedDetail
{
    public class MachineryEquippedDetailService : MachineryEquippedDetailInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryEquippedDetailService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineryEquippedDetail>> GetAllMachineryEquippedDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryEquippedDetailID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryEquippedDetail> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryEquippedDetail", param))
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
                    lst = table.ToPagedDataTableList<MachineryEquippedDetail>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryEquippedDetail> GetMachineryEquippedDetailAsync(int MachineryEquippedDetailID)
        {
            MachineryEquippedDetail result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryEquippedDetailID", MachineryEquippedDetailID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryEquippedDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachineryEquippedDetail>();
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
        public async Task<int> AddOrUpdateMachineryEquippedDetail(MachineryEquippedDetail model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@MachineryEquippedDetailID", model.MachineryEquippedDetailID), new SqlParameter("@EquippedDate", model.EquippedDate), new SqlParameter("@CompanyID", model.CompanyID), new SqlParameter("@DepartmentID", model.DepartmentID), new SqlParameter("@PlantNameOrNumber", model.PlantNameOrNumber), new SqlParameter("@PositionOrLocation", model.PositionOrLocation), new SqlParameter("@CostCenter", model.CostCenter),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy)
                    ,new SqlParameter("@MachineryID",model.MachineryID) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryEquippedDetail", param);

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


