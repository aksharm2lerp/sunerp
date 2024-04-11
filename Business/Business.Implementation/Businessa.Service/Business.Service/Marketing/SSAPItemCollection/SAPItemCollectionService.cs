using Business.Entities.Marketing.SAPItem;
using Business.Interface.Marketing.ISAPItemCollection;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;
using MailKit.Search;
using System.Globalization;

namespace Business.Service.Marketing.SSAPItemCollection
{
    public class SAPItemCollectionService : SAPItemCollectionInterface
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        private string sapconnection = string.Empty;
        public SAPItemCollectionService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
            sapconnection = _config.GetConnectionString("DefaultConnection"); //_config.GetConnectionString("SAPDbConnection");
        }

        #endregion Database Connection

        #region SAP ITEM List
        //public async Task<PagedDataTable<SAPUpdateItemStock>> GetAllSAPItemStockListAsync(string SearchString,string ItemGroupName)
        //{
        //    DataTable table = new DataTable();
        //    int totalItemCount = 0;
        //    PagedDataTable<SAPUpdateItemStock> lst = new PagedDataTable<SAPUpdateItemStock>();
        //    try
        //    {
        //        SqlParameter[] param = {
        //                new SqlParameter("@SearchString",SearchString)
        //                ,new SqlParameter("@ItemGroupName", ItemGroupName)
        //                };
        //        DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SAPItemStock", param);
        //        {
        //            if (ds.Tables.Count > 0)
        //            {
        //                table = ds.Tables[0];
        //                if (table.Rows.Count > 0)
        //                {
        //                    if (table.ContainColumn("TotalCount"))
        //                        totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
        //                    else
        //                        totalItemCount = table.Rows.Count;
        //                }
        //                lst = table.ToPagedDataTableList<SAPUpdateItemStock>(1, 1000, totalItemCount);
        //            }
        //            return lst;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (table != null)
        //            table.Dispose();
        //    }
        //}


        public async Task<PagedDataTable<SAPUpdateItemStock>> GetAllSAPItemStockList(int pageNo = 1, int pageSize = 50, string searchString = "", string orderBy = "PartyID", string sortBy = "ASC", string ItemGroupName = "", string WareHouse = "")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<SAPUpdateItemStock> lst = new PagedDataTable<SAPUpdateItemStock>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        ,new SqlParameter("@ItemGroupName", ItemGroupName)
                        ,new SqlParameter("@WareHouse", WareHouse)
                        };

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SAPItemStock", param))
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
                        lst = table.ToPagedDataTableList<SAPUpdateItemStock>
                           (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
                    }
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

        public async Task<PagedDataTable<SAPItemGroup>> GetAllSAPItemGroupAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<SAPItemGroup> lst = new PagedDataTable<SAPItemGroup>();
            try
            {

                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SAPItemGroup");
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<SAPItemGroup>();
                    }
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

        #endregion SAP Item list

        #region SAP WareHouse.

        public async Task<PagedDataTable<WareHouse>> GetAllSAPWareHouseAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<WareHouse> lst = new PagedDataTable<WareHouse>();
            try
            {

                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SAPWareHouse");
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<WareHouse>();
                    }
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

        #endregion SAP WareHouse.

        #region Get customer list by ItemCode.
        public async Task<DataTable> GetCustomerListByItemCodeAsync(string itemCode)
        {
            try
            {
                SqlParameter[] param = {
                    //new SqlParameter("@EmployeeFamilyDetailID", employeeFamilyId),
                    new SqlParameter("@ItemCode", itemCode)
                };
                DataTable dataTable = new DataTable();
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(sapconnection, CommandType.StoredProcedure, "Usp_Get_ClientListByItemCode", param);
                if (ds != null && ds.Tables.Count > 0)
                    return dataTable = ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Get customer list by ItemCode.

        #region Get customer sales detail by customer name and item code.
        public async Task<DataTable> GetClientSalesSummaryAsync(string itemCode, string customerName)
        {
            try
            {
                SqlParameter[] param = {
                    //new SqlParameter("@EmployeeFamilyDetailID", employeeFamilyId),
                    new SqlParameter("@ItemCode", itemCode),
                    new SqlParameter("@ClientName", customerName)
                };
                DataTable dataTable = new DataTable();
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(sapconnection, CommandType.StoredProcedure, "Usp_Get_ClientSalesSummary", param);
                if (ds != null && ds.Tables.Count > 0)
                    return dataTable = ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Get customer sales detail by customer name and item code.
    }
}
 


