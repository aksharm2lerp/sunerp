using Business.Interface.Marketing.IRequestForQuotMaster;
using Business.Entities.Marketing.RequestForQuotMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
 

namespace Business.Service.Marketing.SRequestForQuotMaster
{
    public class RequestForQuotMasterService : RequestForQuotMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public RequestForQuotMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

            #region Index page
        public async Task<PagedDataTable<RequestForQuotMaster>> GetAllRequestForQuotMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "RequestForQuotMasterID", string sortBy = "DESC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<RequestForQuotMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_RequestForQuotMaster", param))
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
                    lst = table.ToPagedDataTableList<RequestForQuotMaster>(pageNo, pageSize, totalItemCount);
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

        public async Task<PagedDataTable<RequestForQuotMaster>> GetAllRequestForQuotPendingQuotationAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "RequestForQuotMasterID", string sortBy = "DESC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<RequestForQuotMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_RequestForQuotPendingQuot", param))
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
                    lst = table.ToPagedDataTableList<RequestForQuotMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<RequestForQuotMaster> GetRequestForQuotMasterAsync(int RequestForQuotMasterID)
        {
            RequestForQuotMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@RequestForQuotID", RequestForQuotMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_RequestForQuotMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<RequestForQuotMaster>();
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

        #region Get Request For Quot detail by selecting Request For Quot ID
         
        public async Task<PagedDataTable<RequestForQuotDetail>> GetRequestForQuotDetailAsync(int RequestForQuotMasterID)
        {
            PagedDataTable<RequestForQuotDetail> result = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@RequestForQuotID", RequestForQuotMasterID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_RequestForQuotDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        result = ds.Tables[0].ToPagedDataTableList<RequestForQuotDetail>();
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
        public async Task<int> AddOrUpdateRequestForQuotMaster(RequestForQuotMaster model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@RequestForQuotID", model.RequestForQuotID),
                    new SqlParameter("@RequestForQuotDate", model.RequestForQuotDate),
                    new SqlParameter("@FinancialYearID", model.FinancialYearID),
                    new SqlParameter("@PartyID", model.PartyID),
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
                    new SqlParameter("@RequestForQuotTypeID", model.RequestForQuotTypeID),
                    new SqlParameter("@SOItems", dataTable)
                };
                param[16].Direction = ParameterDirection.Input;
                param[16].SqlDbType = SqlDbType.Structured;
                param[16].ParameterName = "@SOItems";
                param[16].TypeName = "UDTT_RequestForQuotDetail ";
                param[16].Value = dataTable;


                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_RequestForQuotMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Positive Note

        public async Task<PartyAddressTxn> GetPartyAddressDetail(int addressTypeID, int partyId)
        {
            PartyAddressTxn result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@AddressTypeID", addressTypeID),
                    new SqlParameter("@PartyID", partyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyAddressTxn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyAddressTxn>();
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
        public async Task<int> RequestForQuotDetailItemDeactivationAsync(int RequestForQuotDetailId, int RequestForQuotId, int userId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@RequestForQuotDetailID", RequestForQuotDetailId),
                    new SqlParameter("@RequestForQuotID", RequestForQuotId),
                    new SqlParameter("@CreatedOrModifiedBy", userId)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_U_RequestForQuotDetailItemActivation", param);

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


