using Business.Interface.IOtherDeductionService;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;
using Business.Entities.OtherDeductionModel;

namespace Business.Service.SOtherDeduction
{
    public class OtherDeductionService : IOtherDeductionService
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public OtherDeductionService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }
        #endregion Database Connection

        #region Index Page
        public async Task<PagedDataTable<OtherDeduction>> GetAllOtherDeductionAsync(int pageNo = 1, int pageSize = 20, string searchString = "", string orderBy = "SrNo", string sortBy = "ASC")
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

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_OtherDeduction", param))
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
                    PagedDataTable<OtherDeduction> lst = table.ToPagedDataTableList<OtherDeduction>
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
        #endregion Index Page

        #region Slider Page
        public async Task<OtherDeduction> GetOtherDeductionAsync(int OtherDeductionID)
        {
            OtherDeduction result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@OtherDeductionID", OtherDeductionID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_OtherDeduction", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<OtherDeduction>();
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
        #endregion Slider Page

        #region Add Or Updater
        public async Task<int> AddOrUpdateOtherDeductionAsync(OtherDeduction model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@OtherDeductionID", model.OtherDeductionID)
                    ,new SqlParameter("@EmployeeID", model.EmployeeID)
                    ,new SqlParameter("@PaymentDate", model.PaymentDate)
                    ,new SqlParameter("@Amount", model.Amount)
                    ,new SqlParameter("@Description", model.Description)
                    ,new SqlParameter("@IsActive", model.IsActive)
                    ,new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy)
                    ,new SqlParameter("@DepartmentID", model.DepartmentID)

                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_OtherDeduction", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add Or Updater
    }
}
