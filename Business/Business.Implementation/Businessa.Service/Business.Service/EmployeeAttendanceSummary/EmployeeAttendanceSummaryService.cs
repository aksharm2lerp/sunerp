﻿using Business.Interface.IEmployeeAttendanceSummary;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;
using Business.Entities.Employee;
using Business.Entities.Master.EmployeeCategory;
using Business.Entities.Master.EmployementType;
using System.ComponentModel.Design;
using Business.Entities.HR.ReportsHR;

namespace Business.Service.EmployeeAttendanceSummary
{
    public class EmployeeAttendanceSummaryService : IEmployeeAttendanceSummaryService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public EmployeeAttendanceSummaryService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        public async Task<DataSet> GetEmployeeAllAttendanceSummary(int employeeCategoryId = 0, int userId = 0, int month = 0, int year = 0, int departmentId = 0, string searchString = "")
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            //PagedDataTable<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@EmployeeCategoryId",employeeCategoryId )
                        ,new SqlParameter("@UserID", userId)
                        ,new SqlParameter("@Month", month)
                        ,new SqlParameter("@Year", year)
                        ,new SqlParameter("@SearchString", searchString)
                        ,new SqlParameter("@DepartmentID", departmentId)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Report_EmployeeAttendanceSummary", param);
                //{
                //    if (ds.Tables.Count > 0)
                //    {
                //        table = ds.Tables[0];
                //        if (table.Rows.Count > 0)
                //        {
                //            if (table.ContainColumn("TotalCount"))
                //                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                //            else
                //                totalItemCount = table.Rows.Count;
                //        }
                //    }
                //lst = table.ToPagedDataTableList<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary>(1, 1000, totalItemCount);
                return ds;
                //}
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

        public async Task<DataSet> GetEmployeeAllDetailSummary(int employeecategoryId = 0, int departmentId = 0, string searchstring = null, int employmentStatusid = 0)
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            //PagedDataTable<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@EmployeeCategoryId",employeecategoryId )
                        ,new SqlParameter("@DepartmentID", departmentId)
                        ,new SqlParameter("@SearchString", searchstring)
                        ,new SqlParameter("@EmploymentStatusID", employmentStatusid)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Report_EmployeeDetailSummary", param);
                //{
                //    if (ds.Tables.Count > 0)
                //    {
                //        table = ds.Tables[0];
                //        if (table.Rows.Count > 0)
                //        {
                //            if (table.ContainColumn("TotalCount"))
                //                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                //            else
                //                totalItemCount = table.Rows.Count;
                //        }
                //    }
                //lst = table.ToPagedDataTableList<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary>(1, 1000, totalItemCount);
                return ds;
                //}
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

        #region Employee Salary Summuary

        public async Task<DataSet> GetEmployeeSalarySummary(int employeeCategoryId = 0, int userId = 0, int companyId = 0, int month = 0, int year = 0, int employeeId = 0)
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            //PagedDataTable<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@EmployeeCategoryId",employeeCategoryId )
                        ,new SqlParameter("@UserID", userId)
                        ,new SqlParameter("@Month", month)
                        ,new SqlParameter("@Year", year)
                        ,new SqlParameter("@EmployeeID", employeeId)
                        ,new SqlParameter("@CompanyID", companyId)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "UDF_Get_EmployeeSalaryDetail", param);
                //{
                //    if (ds.Tables.Count > 0)
                //    {
                //        table = ds.Tables[0];
                //        if (table.Rows.Count > 0)
                //        {
                //            if (table.ContainColumn("TotalCount"))
                //                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                //            else
                //                totalItemCount = table.Rows.Count;
                //        }
                //    }
                //lst = table.ToPagedDataTableList<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary>(1, 1000, totalItemCount);
                return ds;
                //}
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

        public async Task<DataSet> ProcesSalary(int year, int month, int companyId, int employmentTypeId, int employeeCategoryId, int userId,  DateTime salaryDate)
        {
            
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@YR", year)
                    ,new SqlParameter("@MTH", month)
                    ,new SqlParameter("@CompanyID", companyId)
                    ,new SqlParameter("@EmploymentTypeID", employmentTypeId)
                    ,new SqlParameter("@EmployeeCategoryId", employeeCategoryId)
                    ,new SqlParameter("@UserID", userId)
                    ,new SqlParameter("@SalaryDate", salaryDate)
                };

                DataSet  salaryProcess = (DataSet)await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "USP_RunSalaryProcess", param);
                return salaryProcess;
                
            }
            catch
            {
                throw;
            }
        }

        #endregion Employee Salary Summuary


        public async Task<int> VerifyEmplyeeSalary(int year, int month, int companyId, int employeeId, int employeeCategoryId, int userId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Year", year)
                    ,new SqlParameter("@Month", month)
                    ,new SqlParameter("@CompanyID", companyId)
                    ,new SqlParameter("@EmployeeID", employeeId)
                    ,new SqlParameter("@EmployeeCategoryId", employeeCategoryId)
                    //,new SqlParameter("@IsDeleted", employeeDocument.IsDeleted)
                    ,new SqlParameter("@UserID", userId)
                    ,new SqlParameter("@IsVerified", true)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "USP_Insert_VerifiedEmployeeSalary", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataSet> GetEmployeeSalaryDetail(int year, int month, int companyId, int employeeId, int employeeCategoryId,int userId)
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            //PagedDataTable<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@EmployeeCategoryId",employeeCategoryId )
                        ,new SqlParameter("@UserID", userId)
                        ,new SqlParameter("@Month", month)
                        ,new SqlParameter("@Year", year)
                        ,new SqlParameter("@EmployeeID", employeeId)
                        ,new SqlParameter("@CompanyID", companyId)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "UDF_Get_EmployeeSalaryDetailInHorizontal", param);
                //{
                //    if (ds.Tables.Count > 0)
                //    {
                //        table = ds.Tables[0];
                //        if (table.Rows.Count > 0)
                //        {
                //            if (table.ContainColumn("TotalCount"))
                //                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                //            else
                //                totalItemCount = table.Rows.Count;
                //        }
                //    }
                //lst = table.ToPagedDataTableList<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary>(1, 1000, totalItemCount);
                return ds;
                //}
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

        public async Task<DataTable> GetEmployeeSalarySummaryEdit(int employeeId, int year, int month, int companyId)
        {
            try
            {
                DataTable table = new DataTable();
                try
                {
                    SqlParameter[] param = {
                        new SqlParameter("@Month", month)
                        ,new SqlParameter("@Year", year)
                        ,new SqlParameter("@EmployeeID", employeeId)
                        ,new SqlParameter("@CompanyID", companyId)
                        };
                    DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SalaryCalculationByEmployeeID", param);
                    if (ds.Tables.Count > 0)
                        table = ds.Tables[0];
                    return table;
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
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<int> ApproveSaveEmployeeSalaryAsync(EmployeeFinalSalaryCalculationModel employeeFinalSalaryCalculationModel, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {

                    new SqlParameter("@Year", employeeFinalSalaryCalculationModel.Year),
                    new SqlParameter("@Month", employeeFinalSalaryCalculationModel.Month),
                    new SqlParameter("@CompanyID", employeeFinalSalaryCalculationModel.CompanyID),
                    new SqlParameter("@EmployeeID", employeeFinalSalaryCalculationModel.EmployeeID),
                    new SqlParameter("@EmployeeCategoryId", employeeFinalSalaryCalculationModel.EmployeeCategoryID),
                    new SqlParameter("@UserID", employeeFinalSalaryCalculationModel.UserId),
                    new SqlParameter("@IsVerified", employeeFinalSalaryCalculationModel.IsVerified),
                    new SqlParameter("@EmployeeFinalSalaryCalculation", dataTable)
                };
                param[7].Direction = ParameterDirection.Input;
                param[7].SqlDbType = SqlDbType.Structured;
                param[7].ParameterName = "@EmployeeFinalSalaryCalculation";
                param[7].TypeName = "UDTT_EmployeeFinalSalaryCalculation";
                param[7].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "USP_Edit_VerifiedEmployeeSalary", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataSet> GetVerifiedEmployeeSalarySummary(int employeeCategoryId = 0, int userId = 0, int companyId = 0, int month = 0, int year = 0, int employeeId = 0, int employementTypeId = 0, int departmentID = 0)
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            //PagedDataTable<Entities.EmployeeAttendanceSummary.EmployeeAttendanceSummary> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@EmployeeCategoryId",employeeCategoryId )
                        ,new SqlParameter("@UserID", userId)
                        ,new SqlParameter("@Month", month)
                        ,new SqlParameter("@Year", year)
                        ,new SqlParameter("@EmployeeID", employeeId)
                        ,new SqlParameter("@CompanyID", companyId)
                        ,new SqlParameter("@EmploymentTypeID", employementTypeId)
                        ,new SqlParameter("@DepartmentID", departmentID)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "UDF_Get_VerifiedEmployeeSalaryDetail", param);
                return ds;
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
    }
}
