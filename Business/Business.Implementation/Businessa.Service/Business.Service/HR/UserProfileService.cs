using Business.Interface.HR;
using Business.SQL;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Business.Entities.Employee;

namespace Business.Service.HR
{
    public class UserProfileService : IUserProfile
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public UserProfileService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #endregion Database Connection

        #region Get User Profile Basic Details..

        public async Task<PagedDataTable<AddUpdateEmployee>> GetUserProfileBasicDetails(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeProfile", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<AddUpdateEmployee> lst = table.ToPagedDataTableList<AddUpdateEmployee>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get User Profile Basic Details..

        #region Get User Profile Address Details..

        public async Task<PagedDataTable<EmployeeAddressTxn>> GetUserProfileAddressDetails(int id)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", id)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeProfileAddress", param);
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        if (table.ContainColumn("TotalCount"))
                            totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        else
                            totalItemCount = 0;
                    }
                }
                PagedDataTable<EmployeeAddressTxn> lst = table.ToPagedDataTableList<EmployeeAddressTxn>
                    (0, 0, totalItemCount, "", "", "");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get User Profile Address Details..


        #region
        public int GetEmployeeID(int id)
        {
            DataTable table = new DataTable();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID", id)
                };
                DataSet ds = SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeIDFromUserID", param).Result;
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0]["EmployeeID"].ToInt();
                    }
                    else
                        return 0;
                }
                //PagedDataTable<AddUpdateEmployee> lst = table.ToPagedDataTableList<AddUpdateEmployee>
                //    (0, 0, totalItemCount, "", "", "");
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
