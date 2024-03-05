using Business.Interface.IMaster.UserPermissionInterface;
using Business.SQL;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Business.Entities.Master.UserPermissionMasterModel;
using Microsoft.Extensions.Configuration;

namespace Business.Service.Master.SUserPermission
{
    public class UserPermissionService : UserPermissionInterface
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public UserPermissionService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }
        #endregion Database Connection

        #region Package Detail Page Start
        public async Task<PagedDataTable<UserPermissionMaster>> GetAllPackageDetailAsync(int packageID, int pageNo, int pageSize, string searchString = "", string orderBy = "PackageName", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            string packagename = null;
            PagedDataTable<UserPermissionMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PackageID",packageID)
                   /* ,new SqlParameter("@PackageName",packageName)*/
                        /*new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)*/

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetALL_FormAssigntoPackage", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                            {
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                                packagename = Convert.ToString(table.Rows[0]["PackageName"]);
                            }
                            else
                            {
                                totalItemCount = table.Rows.Count;
                                packagename = "";
                            }
                        }
                    }
                    lst = table.ToPagedDataTableList<UserPermissionMaster>(pageNo, pageSize, totalItemCount, packagename);
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
        #endregion

        #region GetPackageDetailSummary

        public async Task<PagedDataTable<UserPermissionMaster>> GetPackageDetailSummary(int PackageId = 0, int userId = 0)
        {
            DataTable table = new DataTable();
            try
            {
                int totalItemCount = 0;
                SqlParameter[] param = {
                        new SqlParameter("@PackageID",PackageId),
                        new SqlParameter("@UserID",userId)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_FormAssigntoPackage", param);
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
                    PagedDataTable<UserPermissionMaster> lst = table.ToPagedDataTableList<UserPermissionMaster>(1, 1000, totalItemCount);
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

        #endregion GetPackageDetailSummary

        #region Package Assing Form To User Active Inactive

        public async Task<int> AddUpdatePackageFormAssignToUser(DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@UDTVUserFormTxn", dataTable)
                };
                param[0].Direction = ParameterDirection.Input;
                param[0].SqlDbType = SqlDbType.Structured;
                param[0].ParameterName = "@UDTVUserFormTxn";
                param[0].TypeName = "UDTT_UserFormTxn";
                param[0].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_FormAssigntoUserDetail", param);
                int result = Convert.ToInt32(obj);
                //return obj != null ? Convert.ToInt32(obj) : 0;
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Package Assing Form To User Active Inactive
    }
}