using Business.Interface.SalesDistribution.ISalesOrderMaster;
using Business.Entities.SalesDistribution.SalesOrderMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.SalesDistribution.SSalesOrderMaster
{
    public class SalesOrderMasterService : SalesOrderMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public SalesOrderMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<SalesOrderMaster>> GetAllSalesOrderMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "SalesOrderMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<SalesOrderMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SalesOrderMaster", param))
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
                    lst = table.ToPagedDataTableList<SalesOrderMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<SalesOrderMaster> GetSalesOrderMasterAsync(int SalesOrderMasterID)
        {
            SalesOrderMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@SalesOrderID", SalesOrderMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_SalesOrderMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<SalesOrderMaster>();
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

        #region Get Sales Order detail by selecting Sales order ID
        public async Task<PagedDataTable<SalesOrderDetail>> GetSalesOrderDetailAsync(int SalesOrderMasterID)
        {
            PagedDataTable<SalesOrderDetail> result = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@SalesOrderID", SalesOrderMasterID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SalesOrderDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        result = ds.Tables[0].ToPagedDataTableList<SalesOrderDetail>();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add or Update Positive Note
        public async Task<int> AddOrUpdateSalesOrderMaster(SalesOrderMaster model, DataSet dataTable)
        {
            try
            {
                SqlParameter[] param = {
              new SqlParameter("@SalesOrderID", model.SalesOrderID),
              new SqlParameter("@SalesOrderDate", model.SalesOrderDate),
              new SqlParameter("@FinancialYearID", model.FinancialYearID),
              new SqlParameter("@CustomerID", model.CustomerID),
              new SqlParameter("@AddressTypeID", model.AddressTypeID),
              new SqlParameter("@Reference", model.Reference),
              new SqlParameter("@EmployeeID", model.EmployeeID),
              new SqlParameter("@EmployeeName", model.EmployeeName),
              new SqlParameter("@ShopOrderID", model.ShopOrderID),
              new SqlParameter("@ShopOrderDate", model.ShopOrderDate),
              new SqlParameter("@NetAmount", model.NetAmount),
              new SqlParameter("@GrossAmount", model.GrossAmount),
              new SqlParameter("@PaymentTerm", model.PaymentTerm),
              new SqlParameter("@DeliveryTerm", model.DeliveryTerm),
              new SqlParameter("@OtherRemark", model.OtherRemark),
              new SqlParameter("@IsActive", model.IsActive),
              new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy),
              new SqlParameter("@SOItems", dataTable.Tables[0]),
              new SqlParameter("@TaxTransactionAmounts", dataTable.Tables[1])
          };
                param[17].Direction = ParameterDirection.Input;
                param[17].SqlDbType = SqlDbType.Structured;
                param[17].ParameterName = "@SOItems";
                param[17].TypeName = "UDTT_SalesOrderDetail";
                param[17].Value = dataTable.Tables[0];

                param[18].Direction = ParameterDirection.Input;
                param[18].SqlDbType = SqlDbType.Structured;
                param[18].ParameterName = "@TaxTransactionAmounts";
                param[18].TypeName = "UDTT_SalesOrderAmountDetail";
                param[18].Value = dataTable.Tables[1];
                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_SalesOrderMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Positive Note

        public async Task<CustomerAddressTxn> GetCustomerAddressDetail(int addressTypeID, int customerId)
        {
            CustomerAddressTxn result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@AddressTypeID", addressTypeID),
                    new SqlParameter("@CustomerID", customerId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_CustomerAddressByAddressTypeIDDropDown", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<CustomerAddressTxn>();
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


        #region Deactive sales item
        public async Task<int> SalesOrderDetailItemDeactivationAsync(int salesOrderDetailId, int salesOrderId, int userId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@SalesOrderDetailID", salesOrderDetailId),
                    new SqlParameter("@SalesOrderID", salesOrderId),
                    new SqlParameter("@CreatedOrModifiedBy", userId)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_U_SalesOrderDetailItemActivation", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Deactive sales item

        #region Get formula for calculate taxes and amounts(GetFormulaByCustomerIdAsync)
        public async Task<DataTable> GetFormulaByCustomerIdAsync(int? customerId)
        {
            try
            {
                DataTable result = new DataTable();
                SqlParameter[] param = {
            new SqlParameter("@CustomerID", customerId)
        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_FormulaMasterByCustomerID", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            /*foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                FormulaMaster formulaMaster = new FormulaMaster();
                                formulaMaster.FormulaID = item["FormulaID"].ToInt();
                                formulaMaster.CustomerID = item["CustomerID"].ToInt();
                                formulaMaster.FormulaTypeID = item["FormulaTypeID"].ToInt();
                                formulaMaster.FormulaHead = Convert.ToString(item["FormulaHead"]);
                                formulaMaster.FormulaLabel = Convert.ToString(item["FormulaLabel"]);
                                formulaMaster.Formula = Convert.ToString(item["Formula"]);
                                formulaMaster.FormulaPercentage = Convert.ToDecimal(item["FormulaPercentage"]);
                                formulaMaster.FormulaValue = Convert.ToString(item["FormulaValue"]);
                                formulaMaster.IsActive = Convert.ToBoolean(item["IsActive"]);
                                result.Add(formulaMaster);
                            }*/

                            result = ds.Tables[0];
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
        #endregion Get formula for calculate taxes and amounts(GetFormulaByCustomerIdAsync)


    }
}


