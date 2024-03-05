using Business.Interface.HR.IMachineryResourceAllocation;
using Business.Entities.HR.MachineryResourceAllocationModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Business.Entities.Production.MachineryModel;
using Business.Entities.Employee.EmploymentType;
using System.Collections.Generic;

namespace Business.Service.HR.SMachineryResourceAllocation
{
    public class MachineryResourceAllocationService : MachineryResourceAllocationInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryResourceAllocationService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Machinery Resource Allocation

        #region Index page
        public async Task<PagedDataTable<MachineryResourceAllocation>> GetAllMachineryResourceAllocationAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryResourceAllocationID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryResourceAllocation> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryResourceAllocation", param))
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
                    lst = table.ToPagedDataTableList<MachineryResourceAllocation>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryResourceAllocation> GetMachineryResourceAllocationAsync(int MachineryResourceAllocationID)
        {
            MachineryResourceAllocation result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryResourceAllocationID", MachineryResourceAllocationID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryResourceAllocation", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachineryResourceAllocation>();
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

        #region Add or Update Machinery Resource Allocation
        public async Task<int> AddOrUpdateMachineryResourceAllocation(MachineryResourceAllocation model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MachineryResourceAllocationID", model.MachineryResourceAllocationID),
                    new SqlParameter("@AllocationDate", model.AllocationDate),
                    new SqlParameter("@ShiftID", model.ShiftID),
                    new SqlParameter("@DepartmentID", model.DepartmentID),
                    new SqlParameter("@MachineryID", model.MachineryID),
                    new SqlParameter("@Operators", model.Operators),
                    new SqlParameter("@Helpers", model.Helpers),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryResourceAllocation", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Machinery Resource Allocation

        #endregion Machinery Resource Allocation

        #region Daily Machinery Resource Log

        public async Task<List<DailyMachineryResourceLog>> GetDailyMachineryResourceLogAsync(DateTime? todayDate, int shiftId, int departmentId, int machineryId)
        {
            try
            {
                List<DailyMachineryResourceLog> result = new List<DailyMachineryResourceLog>();
                SqlParameter[] param = {
                    new SqlParameter("@EntryDate", todayDate),
                    new SqlParameter("@ShiftID", shiftId),
                    new SqlParameter("@DepartmentID", departmentId),
                    new SqlParameter("@MachineryID", machineryId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_DailyMachineryResourceLog", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                DailyMachineryResourceLog dailyMachineryResourceLog = new DailyMachineryResourceLog();
                                dailyMachineryResourceLog.EmployeeID = item["EmployeeID"].ToInt();
                                dailyMachineryResourceLog.ResourceType = Convert.ToBoolean(item["ResourceType"]);
                                dailyMachineryResourceLog.EmployeeName = item["EmployeeName"].ToString();
                                dailyMachineryResourceLog.ApprovedByHOD = item["ApprovedByHOD"].ToString();
                                dailyMachineryResourceLog.ApprovedByHR = item["ApprovedByHR"].ToString();
                                dailyMachineryResourceLog.IsPresent = Convert.ToBoolean(item["IsPresent"]);
                                dailyMachineryResourceLog.IsAdditionalResource = Convert.ToBoolean(item["IsAdditionalResource"]);
                                dailyMachineryResourceLog.TransferToMachineID = item["TransferToMachineID"].ToInt();
                                dailyMachineryResourceLog.DailyMachineryResourceLogID = item["DailyMachineryResourceLogID"].ToInt();
                                dailyMachineryResourceLog.DailyMachineryResourceTxnID = item["DailyMachineryResourceTxnID"].ToInt();
                                result.Add(dailyMachineryResourceLog);
                            }
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


        #region Add update table.
        public async Task<int> AddUpdateMachineryResourceLogAsync(DailyMachineryResourceTxn dailyMachineryResourceTxn, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@DailyMachineryResourceLogID", dailyMachineryResourceTxn.DailyMachineryResourceLogID),
                new SqlParameter("@EntryDate", dailyMachineryResourceTxn.EntryDate ),
                new SqlParameter("@ShiftID", dailyMachineryResourceTxn.ShiftID ),
                new SqlParameter("@DepartmentID", dailyMachineryResourceTxn.DepartmentID ),
                new SqlParameter("@MachineryID", dailyMachineryResourceTxn.MachineryID ),
                new SqlParameter("@ApprovedByHOD", dailyMachineryResourceTxn.ApprovedByHOD ),
                new SqlParameter("@ApprovedByHR", dailyMachineryResourceTxn.ApprovedByHR ),
                new SqlParameter("@CreatedByOrModified", dailyMachineryResourceTxn.CreatedOrModifiedBy ),
                new SqlParameter("@LogTxn", dataTable)
                };
                param[8].Direction = ParameterDirection.Input;
                param[8].SqlDbType = SqlDbType.Structured;
                param[8].ParameterName = "@LogTxn";
                param[8].TypeName = "UDTT_DailyMachineryResourceTxn";
                param[8].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "[dbo].[Usp_IU_DailyMachineryResourceLog]", param);
                //bool result = Convert.ToBoolean(obj);
                return obj != null ? Convert.ToInt32(obj) : 0;
                //return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add update table.

        #endregion Daily Machinery Resource Log
    }
}


