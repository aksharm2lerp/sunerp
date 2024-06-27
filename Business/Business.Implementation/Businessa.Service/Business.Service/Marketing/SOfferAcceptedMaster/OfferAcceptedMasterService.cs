using Business.Interface.Marketing.IOfferAcceptedMaster;
using Business.Entities.Marketing.OfferAcceptedMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Marketing.SOfferAcceptedMaster
{
    public class OfferAcceptedMasterService : OfferAcceptedMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public OfferAcceptedMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<OfferAcceptedMaster>> GetAllOfferAcceptedMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "OfferAcceptedMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<OfferAcceptedMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_OfferAcceptedMaster", param))
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
                    lst = table.ToPagedDataTableList<OfferAcceptedMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<OfferAcceptedMaster> GetOfferAcceptedMasterAsync(int OfferAcceptedMasterID)
        {
            OfferAcceptedMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@OfferAcceptedID", OfferAcceptedMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_OfferAcceptedMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<OfferAcceptedMaster>();
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

        #region Get Offer Accepted detail by selecting Offer Accepted ID
        public async Task<PagedDataTable<OfferAcceptedDetail>> GetOfferAcceptedDetailAsync(int OfferAcceptedMasterID)
        {
            PagedDataTable<OfferAcceptedDetail> result = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@OfferAcceptedID", OfferAcceptedMasterID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_OfferAcceptedDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        result = ds.Tables[0].ToPagedDataTableList<OfferAcceptedDetail>();
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
        public async Task<int> AddOrUpdateOfferAcceptedMaster(OfferAcceptedMaster model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@OfferAcceptedID", model.OfferAcceptedID),
                    new SqlParameter("@OfferAcceptedDate", model.OfferAcceptedDate),
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
                param[15].TypeName = "UDTT_OfferAcceptedDetail ";
                param[15].Value = dataTable;


                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_OfferAcceptedMaster", param);

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
        public async Task<int> OfferAcceptedDetailItemDeactivationAsync(int OfferAcceptedDetailId, int OfferAcceptedId, int userId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@OfferAcceptedDetailID", OfferAcceptedDetailId),
                    new SqlParameter("@OfferAcceptedID", OfferAcceptedId),
                    new SqlParameter("@CreatedOrModifiedBy", userId)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_U_OfferAcceptedDetailItemActivation", param);

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


