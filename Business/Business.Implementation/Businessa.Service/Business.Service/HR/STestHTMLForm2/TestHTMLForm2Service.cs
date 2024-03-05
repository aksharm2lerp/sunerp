using Business.Interface.HR.ITestHTMLForm2;
using Business.Entities.HR.TestHTMLForm2Model;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.HR.STestHTMLForm2
{
    public class TestHTMLForm2Service : TestHTMLForm2Interface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public TestHTMLForm2Service(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<TestHTMLForm2>> GetAllTestHTMLForm2Async(int pageNo, int pageSize, string searchString = "", string orderBy = "TestHTMLForm2ID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<TestHTMLForm2> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_TestHTMLForm2", param))
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
                    lst = table.ToPagedDataTableList<TestHTMLForm2>(pageNo, pageSize, totalItemCount);
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
        public async Task<TestHTMLForm2> GetTestHTMLForm2Async(int TestHTMLForm2ID)
        {
            TestHTMLForm2 result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@TestHTMLForm2ID", TestHTMLForm2ID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_TestHTMLForm2", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<TestHTMLForm2>();
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
        public async Task<int> AddOrUpdateTestHTMLForm2(TestHTMLForm2 model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@TestHTMLForm2ID", model.TestHTMLForm2ID), new SqlParameter("@TestHTMLForm2Name", model.TestHTMLForm2Name), new SqlParameter("@AddressID", model.AddressID), new SqlParameter("@RoleID", model.RoleID),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_TestHTMLForm2", param);

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


