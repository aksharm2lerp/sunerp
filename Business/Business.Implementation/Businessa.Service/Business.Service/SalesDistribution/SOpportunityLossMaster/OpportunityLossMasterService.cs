using Business.Interface.SalesDistribution.IOpportunityLossMaster;
using Business.Entities.SalesDistribution.OpportunityLossMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.SalesDistribution.SOpportunityLossMaster
{
    public class OpportunityLossMasterService : OpportunityLossMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public OpportunityLossMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<OpportunityLossMaster>> GetAllOpportunityLossMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "OpportunityLossMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<OpportunityLossMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_OpportunityLossMaster", param))
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
                    lst = table.ToPagedDataTableList<OpportunityLossMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<OpportunityLossMaster> GetOpportunityLossMasterAsync(int OpportunityLossMasterID)
        {
            OpportunityLossMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@OpportunityLossID", OpportunityLossMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_OpportunityLossMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<OpportunityLossMaster>();
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

        #region Get Opportunity Loss detail by selecting Opportunity Loss ID
        public async Task<PagedDataTable<OpportunityLossDetail>> GetOpportunityLossDetailAsync(int OpportunityLossMasterID)
        {
            PagedDataTable<OpportunityLossDetail> result = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@OpportunityLossID", OpportunityLossMasterID)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_OpportunityLossDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        result = ds.Tables[0].ToPagedDataTableList<OpportunityLossDetail>();
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
        public async Task<int> AddOrUpdateOpportunityLossMaster(OpportunityLossMaster model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@OpportunityLossID", model.OpportunityLossID),
                    new SqlParameter("@OpportunityLossDate", model.OpportunityLossDate),
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
                param[15].TypeName = "UDTT_OpportunityLossDetail ";
                param[15].Value = dataTable;


                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_OpportunityLossMaster", param);

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
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_CustomerAddressTxn", param);
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
        public async Task<int> OpportunityLossDetailItemDeactivationAsync(int OpportunityLossDetailId, int OpportunityLossId, int userId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@OpportunityLossDetailID", OpportunityLossDetailId),
                    new SqlParameter("@OpportunityLossID", OpportunityLossId),
                    new SqlParameter("@CreatedOrModifiedBy", userId)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_U_OpportunityLossDetailItemActivation", param);

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


