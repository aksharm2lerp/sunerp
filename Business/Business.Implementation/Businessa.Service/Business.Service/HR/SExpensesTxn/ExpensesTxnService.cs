using Business.Interface.HR.IExpensesTxn;
using Business.Entities.HR.ExpensesTxnModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.HR.SExpensesTxn
{
    public class ExpensesTxnService : ExpensesTxnInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public ExpensesTxnService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<ExpensesTxn>> GetAllExpensesTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ExpensesTxnID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ExpensesTxn> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ExpensesTxn", param))
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
                    lst = table.ToPagedDataTableList<ExpensesTxn>(pageNo, pageSize, totalItemCount);
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
        public async Task<ExpensesTxn> GetExpensesTxnAsync(int ExpensesTxnID)
        {
            ExpensesTxn result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@ExpensesID", ExpensesTxnID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_ExpensesTxn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<ExpensesTxn>();
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
        public async Task<int> AddOrUpdateExpensesTxn(ExpensesTxn model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@ExpensesID", model.ExpensesID), new SqlParameter("@EmployeeID", model.EmployeeID), new SqlParameter("@ExpenseTypeID", model.ExpenseTypeID), new SqlParameter("@StartDate", model.StartDate), new SqlParameter("@EndDate", model.EndDate), new SqlParameter("@Purpose", model.Purpose), new SqlParameter("@ExpensesDetail", model.ExpensesDetail), new SqlParameter("@ExpensesAmount", model.ExpensesAmount), new SqlParameter("@IsPaidByEmployee", model.IsPaidByEmployee), new SqlParameter("@IsPaidByCompany", model.IsPaidByCompany),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_ExpensesTxn", param);

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


