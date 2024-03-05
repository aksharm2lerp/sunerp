using Business.Interface.Marketing.IQuotationMaster;
using Business.Entities.Marketing.QuotationMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Marketing.SQuotationMaster
{
    public class QuotationMasterService : QuotationMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public QuotationMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<QuotationMaster>> GetAllQuotationMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "QuotationMasterID", string sortBy = "DESC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<QuotationMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_QuotationMaster", param))
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
                    lst = table.ToPagedDataTableList<QuotationMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<QuotationMaster> GetQuotationMasterAsync(int QuotationMasterID, int RequestforQuotId)
        {
            QuotationMaster result = null;
            try
            {
                SqlParameter[] param = { 
                        new SqlParameter("@QuotationID", QuotationMasterID),
                        new SqlParameter("@RequestForQuotID", RequestforQuotId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_QuotationMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<QuotationMaster>();
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

        #region Get Quotation detail by selecting Quotation ID
        public async Task<PagedDataTable<QuotationDetail>> GetQuotationDetailAsync(int QuotationMasterID)
        {
            PagedDataTable<QuotationDetail> result = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@QuotationID", QuotationMasterID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_QuotationDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        result = ds.Tables[0].ToPagedDataTableList<QuotationDetail>();
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
        public async Task<int> AddOrUpdateQuotationMaster(QuotationMaster model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@QuotationID", model.QuotationID),
                    new SqlParameter("@QuotationCode", model.QuotationCode),
                    new SqlParameter("@QuotationDate", model.QuotationDate),
                    new SqlParameter("@FinancialYearID", model.FinancialYearID),
                    new SqlParameter("@PartyID", model.PartyID),
                    new SqlParameter("@AddressTypeID", model.AddressTypeID),
                    new SqlParameter("@Reference", model.Reference),
                    new SqlParameter("@RequestForQuotID", model.RequestForQuotID),
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
                param[15].TypeName = "UDTT_QuotationDetail ";
                param[15].Value = dataTable;


                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_QuotationMaster", param);

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
        public async Task<int> QuotationDetailItemDeactivationAsync(int QuotationDetailId, int QuotationId, int userId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@QuotationDetailID", QuotationDetailId),
                    new SqlParameter("@QuotationID", QuotationId),
                    new SqlParameter("@CreatedOrModifiedBy", userId)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_U_QuotationDetailItemActivation", param);

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


