using Business.Interface.HR.IEmployeeFacility;
using Business.Entities.HR.EmployeeFacilityModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.HR.SEmployeeFacility
{
    public class EmployeeFacilityService : EmployeeFacilityInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public EmployeeFacilityService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<EmployeeFacility>> GetAllEmployeeFacilityAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "EmployeeFacilityID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeFacility> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeFacility", param))
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
                    lst = table.ToPagedDataTableList<EmployeeFacility>(pageNo, pageSize, totalItemCount);
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
        public async Task<EmployeeFacility> GetEmployeeFacilityAsync(int EmployeeFacilityID)
        {
            EmployeeFacility result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@EmployeeFacilityID", EmployeeFacilityID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeFacility", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<EmployeeFacility>();
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
        public async Task<int> AddOrUpdateEmployeeFacility(EmployeeFacility model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@EmployeeFacilityID", model.EmployeeFacilityID), new SqlParameter("@EmployeeID", model.EmployeeID), new SqlParameter("@FacilityTypeMasterID", model.FacilityTypeMasterID), new SqlParameter("@IssueDate", model.IssueDate), new SqlParameter("@Purpose", model.Purpose), new SqlParameter("@ProductCode", model.ProductCode), new SqlParameter("@ProductDescription", model.ProductDescription), new SqlParameter("@IsReturnable", model.IsReturnable), new SqlParameter("@IsChargeable", model.IsChargeable), new SqlParameter("@IssuedBy", model.IssuedBy), new SqlParameter("@ReceivedBy", model.ReceivedBy),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeFacility", param);

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


