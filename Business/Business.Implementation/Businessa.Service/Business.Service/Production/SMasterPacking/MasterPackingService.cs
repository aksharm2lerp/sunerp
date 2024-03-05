using Business.Interface.Production.IMasterPacking;
using Business.Entities.Production.MasterPackingModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Business.Entities.SalesDistribution.SalesOrderMasterModel;
using Business.Entities.HR.MachineryResourceAllocationModel;
using System.Collections.Generic;

namespace Business.Service.Production.SMasterPacking
{
    public class MasterPackingService : MasterPackingInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MasterPackingService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MasterPacking>> GetAllMasterPackingAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MasterPackingID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MasterPacking> lst = null;
            try
            {
                searchString = null;
                orderBy = null;
                sortBy = null;
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MasterPacking", param))
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
                    lst = table.ToPagedDataTableList<MasterPacking>(pageNo, pageSize, totalItemCount);
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
        public async Task<(MasterPacking, PagedDataTable<ScannedItemDetail>)> GetMasterPackingAsync(int MasterPackingID)
        {
            MasterPacking result = null;
            DataTable table = null;
            int totalItemCount = 0;
            PagedDataTable<ScannedItemDetail> lst = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MasterPackingID", MasterPackingID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MasterPacking", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MasterPacking>();
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            //DataRow dr = ds.Tables[1].Rows[0];
                            //result = dr.ToPagedDataTableList<MasterPacking>();
                            table = ds.Tables[1];
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                            lst = table.ToPagedDataTableList<ScannedItemDetail>(1, 1000, totalItemCount);
                        }
                    }
                }
                return (result, lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Get Singal Record

        #region Add or Update Positive Note
        public async Task<int> AddOrUpdateMasterPacking(MasterPacking model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MasterPackingID", model.MasterPackingID),
                    new SqlParameter("@MasterPackingCode", model.MasterPackingCode),
                    new SqlParameter("@BatchNo", model.BatchNo),
                    new SqlParameter("@UserBatchCode", model.UserBatchCode),
                    new SqlParameter("@IsTakenPrint", model.IsTakenPrint),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy)
                    ,new SqlParameter("@MPItems", dataTable)
                };

                param[7].Direction = ParameterDirection.Input;
                param[7].SqlDbType = SqlDbType.Structured;
                param[7].ParameterName = "@MPItems";
                param[7].TypeName = "UDTT_MasterPackingDetail";
                param[7].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MasterPacking", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Positive Note


        #region Get Sales Order detail by selecting Sales order ID
        public async Task<ScannedItemDetail> GetScannedItemDetailAsync(string scannedQrCode)
        {
            ScannedItemDetail result = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@QRCode", scannedQrCode)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_ItemDetailByQrCode", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<ScannedItemDetail>();
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
        #endregion

        #region Get Master Packing Code
        public async Task<MasterPacking> GetMasterPackingCodeReturnAsync(int userId)
        {
            MasterPacking result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@CreatedOrModifiedBy", userId) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MasterPackingCodeReturn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MasterPacking>();
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
        #endregion Get Master Packing Code

        #region Multiple Print Master Packing QR Code
        public async Task<PagedDataTable<MasterPacking>> GetMultiplePrintMasterPackingAsync(string MasterPackingID, int userId)
        {
            MasterPacking result = null;
            DataTable table = null;
            int totalItemCount = 0;
            // PagedDataTable<MasterPacking> lst = null;
            try
            {
                SqlParameter[] param = {
            new SqlParameter("@MasterPackingID", MasterPackingID),
            //new SqlParameter("@CreatedOrModifiedBy", userId),
        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PrintMasterPackingMultipleQRCode", param);
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
                PagedDataTable<MasterPacking> lst = table.ToPagedDataTableList<MasterPacking>();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Multiple Print Master Packing QR Code
    }
}