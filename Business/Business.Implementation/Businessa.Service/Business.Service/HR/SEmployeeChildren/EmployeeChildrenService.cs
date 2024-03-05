using Business.Interface.IEmployeeChildrenService;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.SHR.EmployeeChildren
{
    public class EmployeeChildrenService : EmployeeChildrenInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public EmployeeChildrenService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<Entities.HR.EmployeeChildrenModel.EmployeeChildren>> GetAllEmployeeChildrenAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "EmployeeChildrenID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<Entities.HR.EmployeeChildrenModel.EmployeeChildren> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeChildren", param))
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
                    lst = table.ToPagedDataTableList<Entities.HR.EmployeeChildrenModel.EmployeeChildren>(pageNo, pageSize, totalItemCount);
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
        public async Task<Entities.HR.EmployeeChildrenModel.EmployeeChildren> GetEmployeeChildrenAsync(int EmployeeChildrenID)
        {
            Entities.HR.EmployeeChildrenModel.EmployeeChildren result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@EmployeeChildrenID", EmployeeChildrenID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeChildren", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<Entities.HR.EmployeeChildrenModel.EmployeeChildren>();
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
        public async Task<int> AddOrUpdateEmployeeChildren(Entities.HR.EmployeeChildrenModel.EmployeeChildren model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@EmployeeChildrenID", model.EmployeeChildrenID), new SqlParameter("@ChildFullName", model.ChildFullName), new SqlParameter("@DOB", model.DOB), new SqlParameter("@IsStudying", model.IsStudying), new SqlParameter("@StandardOrDegree", model.StandardOrDegree), new SqlParameter("@SchoolOrUniversity", model.SchoolOrUniversity), new SqlParameter("@EmployeeID", model.EmployeeID),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeChildren", param);

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


