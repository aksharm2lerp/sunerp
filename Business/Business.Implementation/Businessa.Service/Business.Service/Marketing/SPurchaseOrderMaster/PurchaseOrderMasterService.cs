using Business.Interface.Marketing.IPurchaseOrderMaster;
using Business.Entities.Marketing.PurchaseOrderMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Marketing.SPurchaseOrderMaster
{
    public class PurchaseOrderMasterService : PurchaseOrderMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public PurchaseOrderMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<PurchaseOrderMaster>> GetAllPurchaseOrderMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "PurchaseOrderMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<PurchaseOrderMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PurchaseOrderMaster", param))
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
                    lst = table.ToPagedDataTableList<PurchaseOrderMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<PurchaseOrderMaster> GetPurchaseOrderMasterAsync(int PurchaseOrderMasterID)
        {
            PurchaseOrderMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@PurchaseOrderID", PurchaseOrderMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PurchaseOrderMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PurchaseOrderMaster>();
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

        #region Get Purchase Order detail by selecting Purchase Order ID
        public async Task<PagedDataTable<PurchaseOrderDetail>> GetPurchaseOrderDetailAsync(int PurchaseOrderMasterID)
        {
            PagedDataTable<PurchaseOrderDetail> result = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PurchaseOrderID", PurchaseOrderMasterID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PurchaseOrderDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        result = ds.Tables[0].ToPagedDataTableList<PurchaseOrderDetail>();
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
        public async Task<int> AddOrUpdatePurchaseOrderMaster(PurchaseOrderMaster model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PurchaseOrderID", model.PurchaseOrderID),
                    new SqlParameter("@PurchaseOrderDate", model.PurchaseOrderDate),
                    new SqlParameter("@FinancialYearID", model.FinancialYearID),
                    new SqlParameter("@CustomerID", model.CustomerID),
                    new SqlParameter("@AddressTypeID", model.AddressTypeID),
                    new SqlParameter("@Reference", model.Reference),
                    new SqlParameter("@ShopOrderID", model.ShopOrderID),
                    new SqlParameter("@ShopOrderDate", model.ShopOrderDate),
                    new SqlParameter("@NetAmount", model.NetAmount),
                    new SqlParameter("@GrossAmount", model.GrossAmount),
                    new SqlParameter("@PaymentTerm", model.PaymentTerm),
                    new SqlParameter("@DeliveryTerm", model.DeliveryTerm),
                    new SqlParameter("@OtherRemark", model.OtherRemark),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy),
                    new SqlParameter("@SOItems", dataTable)
                };
                param[15].Direction = ParameterDirection.Input;
                param[15].SqlDbType = SqlDbType.Structured;
                param[15].ParameterName = "@SOItems";
                param[15].TypeName = "UDTT_PurchaseOrderDetail ";
                param[15].Value = dataTable;


                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PurchaseOrderMaster", param);

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
        public async Task<int> PurchaseOrderDetailItemDeactivationAsync(int PurchaseOrderDetailId, int PurchaseOrderId, int userId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PurchaseOrderDetailID", PurchaseOrderDetailId),
                    new SqlParameter("@PurchaseOrderID", PurchaseOrderId),
                    new SqlParameter("@CreatedOrModifiedBy", userId)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_U_PurchaseOrderDetailItemActivation", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Deactive sales item

    }
}


