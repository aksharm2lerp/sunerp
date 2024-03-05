using Business.Entities.Marketing.Feedback;
using Business.Interface.DevelopmentArea.IDynamicFormService;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using Business.Entities.DevelopmentArea.DynamicFormM;
using Business.Entities.Marketing.CommunicationLog;
using System.Threading.Tasks;
using Business.Entities.EmployeeLoan;
using MailKit.Search;
using System.Globalization;
using System.Collections.Generic;

namespace Business.Service.DevelopmentArea.DynamicFormService
{
    public class DynamicFormService : IDynamicFormService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public DynamicFormService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Dropdown for add update table.
        public PagedDataTable<DatabaseTable> GetAllDatabaseTables()
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            PagedDataTable<DatabaseTable> lst = new PagedDataTable<DatabaseTable>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_DatabaseTables"))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        //if (table.Rows.Count > 0)
                        //{
                        //    if (table.ContainColumn("TotalCount"))
                        //        totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        //    else
                        //        totalItemCount = table.Rows.Count;
                        //}
                    }
                    lst = table.ToPagedDataTableList<DatabaseTable>();
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
            return lst;
        }
        public PagedDataTable<DataTypeMaster> GetAllDataTypes()
        {
            DataTable table = new DataTable();
            //int totalItemCount = 0;
            PagedDataTable<DataTypeMaster> lst = new PagedDataTable<DataTypeMaster>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_DataTypeMaster"))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        //if (table.Rows.Count > 0)
                        //{
                        //    if (table.ContainColumn("TotalCount"))
                        //        totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                        //    else
                        //        totalItemCount = table.Rows.Count;
                        //}
                    }
                    lst = table.ToPagedDataTableList<DataTypeMaster>();
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
            return lst;
        }
        #endregion Dropdown for add update table.

        #region Add update table.
        public async Task<bool> AddUpdateTable(DataTable dataTable, string tableDescription, string userName)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@OwnerName", userName)
                ,new SqlParameter("@TableDesc", tableDescription)
                ,new SqlParameter("@UDTT_UserTableCreationtemp", dataTable)
                };
                param[2].Direction = ParameterDirection.Input;
                param[2].SqlDbType = SqlDbType.Structured;
                param[2].ParameterName = "@UDTT_UserTableCreationtemp";
                param[2].TypeName = "UDTT_UserTableCreation";
                param[2].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_Utility_GenerateSQLObjects", param);
                bool result = Convert.ToBoolean(obj);
                //return obj != null ? Convert.ToInt32(obj) : 0;
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add update table.

        public async Task<string> GenerateModelProperties(string tableName)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@TableName", tableName)
                ,new SqlParameter("@CLASSNAME", "public class ")
                };
                string modelProperties = string.Empty;
                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "CREATEMODEL", param);
                modelProperties = obj.ToString();
                return modelProperties;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> GetSqlParams(string tableName)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@TableName", tableName)
                };
                List<string> sqlParameters = new List<string>();

               // var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_Get_TableStructure", param);
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_TableStructure", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        DataTable dataTable = ds.Tables[0];
                        string sqlParams = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                        string columns = ds.Tables[2].Rows[0].ItemArray[0].ToString();

                        sqlParameters.Add(sqlParams);
                        sqlParameters.Add(columns);
                    }
                    //PagedDataTable<EmployeeLoan> lst = table.ToPagedDataTableList<EmployeeLoan>
                    //    (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
                    //return lst;
                }


                //sqlParameters = obj.ToString();

                return sqlParameters;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataTable> GetDataTableStructure(string tableName)
        {
            try
            {
                DataTable dataTable = new DataTable();
                SqlParameter[] param = {
                new SqlParameter("@TableName", tableName)
                };
                List<string> sqlParameters = new List<string>();

                // var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_Get_TableStructure", param);
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_TableStructure", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        dataTable = ds.Tables[0];
                    }
                    //PagedDataTable<EmployeeLoan> lst = table.ToPagedDataTableList<EmployeeLoan>
                    //    (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
                    //return lst;
                }


                //sqlParameters = obj.ToString();

                return dataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
