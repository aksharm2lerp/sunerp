using Business.Entities.HR;
using Business.Interface.IGatePassService;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;
using Business.Entities.EmployeeGatepass;
using Org.BouncyCastle.Bcpg;

namespace Business.Service.GatePass
{
    public class GatePassService : IGatePassService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public GatePassService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }
        public async Task<PagedDataTable<EmployeeGatePass>> GetAllEmployeeGatePassAsync(int pageNo = 1, int pageSize = 20, string searchString = "", string orderBy = "EmployeeID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        };

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeGatePass", param))
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
                    PagedDataTable<EmployeeGatePass> lst = table.ToPagedDataTableList<EmployeeGatePass>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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

        public async Task<EmployeeGatePass> GetEmployeeGatePassAsync(int employeeId, int employeeGatePassID)
        {
            EmployeeGatePass result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@EmployeeID", employeeId)
                    ,new SqlParameter("@EmployeeGatePassID", employeeGatePassID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeGatePass", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<EmployeeGatePass>();
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

        public async Task<int> AddUpdateEmployeeGatePassAsync(EmployeeGatePass employeeGatePass)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@EmployeeGatePassID", employeeGatePass.EmployeeGatePassID ),
                    new SqlParameter("@EmployeeID", employeeGatePass.EmployeeID ),
                    new SqlParameter("@DepartmentID", employeeGatePass.DepartmentID ),
                    new SqlParameter("@OutTime", employeeGatePass.OutTime ),
                    new SqlParameter("@InTime", employeeGatePass.InTime ),
                    new SqlParameter("@Reason", employeeGatePass.Reason ),
                    new SqlParameter("@Date", employeeGatePass.Date ),
                    new SqlParameter("@CreatedOrModifiedBy", employeeGatePass.CreatedOrModifiedBy ),
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeGatePass", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region test purpose method.

        public async Task<DataTable> GetEmployeeGatePassAsyncForPrint(int employeeGatePassID)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@EmployeeGatePassID", employeeGatePassID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Report_EmployeeGatePass", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion test purpose method.

        #region Add update access for HOD, HR.

        public async Task<int> AddRemoveApprovalAsync(int employeeGatepassId, bool isApproved, string approvalName, int UID)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@EmployeeGatePassID", employeeGatepassId),
                    new SqlParameter("@IsApproved", isApproved ),
                    new SqlParameter("@ApprovalBy", approvalName ),
                    new SqlParameter("@UserID", UID )
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeGatePassApproval", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Add update access for HOD, HR.

        #region Update in and out time for employee gatepass by security.
        public async Task<int> UpdateGatePassInOutTimeAsync(int employeeGatepassId, bool isChecked, DateTime? inTime, DateTime? outTime, int UID)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@EmployeeGatePassID", employeeGatepassId),
                    new SqlParameter("@IsChecked", isChecked ),
                    //new SqlParameter("@ApprovalBy", time ),
                    new SqlParameter("@InTime", inTime ),
                    new SqlParameter("@OutTime", outTime ),
                    new SqlParameter("@UserID", UID )
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeGatePassInOutTime", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Update in and out time for employee gatepass by security.
    }
}