using Business.Interface.IUserMapToEmployeeService;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.SHR.UserMapToEmployee
{
    public class UserMapToEmployeeService : UserMapToEmployeeInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public UserMapToEmployeeService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<Entities.HR.UserMapToEmployeeModel.UserMapToEmployee>> GetAllUserMapToEmployeeAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "UserMapToEmployeeID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<Entities.HR.UserMapToEmployeeModel.UserMapToEmployee> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_UserMapToEmployee", param))
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
                    lst = table.ToPagedDataTableList<Entities.HR.UserMapToEmployeeModel.UserMapToEmployee>(pageNo, pageSize, totalItemCount);
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
        public async Task<Entities.HR.UserMapToEmployeeModel.UserMapToEmployee> GetUserMapToEmployeeAsync(int UserMapToEmployeeID)
        {
            Entities.HR.UserMapToEmployeeModel.UserMapToEmployee result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@UserMapToEmployeeID", UserMapToEmployeeID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_UserMapToEmployee", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<Entities.HR.UserMapToEmployeeModel.UserMapToEmployee>();
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
        public async Task<int> AddOrUpdateUserMapToEmployee(Entities.HR.UserMapToEmployeeModel.UserMapToEmployee model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@UserMapToEmployeeID", model.UserMapToEmployeeID), new SqlParameter("@UserID", model.UserID), new SqlParameter("@EmployeeID", model.EmployeeID), new SqlParameter("@Remarks", model.Remarks),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_UserMapToEmployee", param);

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


