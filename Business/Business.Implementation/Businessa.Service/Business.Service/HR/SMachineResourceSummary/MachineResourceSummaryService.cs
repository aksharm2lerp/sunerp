using Business.Entities.Employee;
using Business.Entities.HR.MachineResourceSummaryModel;
using Business.Interface.HR.IMachineResourceSummary;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Business.Service.HR.SMachineResourceSummary
{
    public class MachineResourceSummaryService : MachineResourceSummaryInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        private DataTable table;
        private string sortBy;

        public MachineResourceSummaryService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }
        public async Task<MachineResourceSummary> GetEmployeeCount(DateTime date, int shiftid, int departmentid, int machineryid)
        {
			try
			{
                MachineResourceSummary machineResourceSummary = new MachineResourceSummary();
                SqlParameter[] param =
                {
                    new SqlParameter("@StartDate",date),
                    new SqlParameter("@EndDate",date),
                    new SqlParameter("@ShiftID",shiftid),
                    new SqlParameter("@DepartmentID",departmentid),
                    new SqlParameter("@MachineryID",machineryid)
                };

                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Report_DailyMachineryResourceLog", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            machineResourceSummary = dr.ToPagedDataTableList<MachineResourceSummary>();
                        }
                    }
                }
                return machineResourceSummary;
             /*using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Report_DailyMachineryResourceLog",param))
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
                    PagedDataTable<EmployeeBankDetails> lst = table.ToPagedDataTableList<EmployeeBankDetails>
                        ();
                    return machineResourceSummary;
                }*/

            }
			catch (System.Exception ex)
			{

				throw;
			}
        }

        public async Task<PagedDataTable<EmployeeDetails>> GetDetailMachineryResourceLogDetailAsync(DateTime date, int machineryid, int cardNo)
        {
            try
            {
                int totalItemCount = 0;
                SqlParameter[] param =
                {
                    new SqlParameter("@StartDate",date),
                    new SqlParameter("@EndDate",date),
                    //new SqlParameter("@ShiftID",shiftid),
                    //new SqlParameter("@DepartmentID",departmentid),
                    new SqlParameter("@MachineryID",machineryid),
                    new SqlParameter("@CardNo",cardNo)
                };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Report_DailyMachineryResourceLogDetail", param))
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
                    PagedDataTable<EmployeeDetails> lst = table.ToPagedDataTableList<EmployeeDetails>
                        ();
                    return lst;
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
