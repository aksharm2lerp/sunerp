using Business.Interface.Production.IMachineryPurchaseDetail;
using Business.Entities.Production.MachineryPurchaseDetailModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SMachineryPurchaseDetail
{
    public class MachineryPurchaseDetailService : MachineryPurchaseDetailInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryPurchaseDetailService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineryPurchaseDetail>> GetAllMachineryPurchaseDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryPurchaseDetailID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryPurchaseDetail> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryPurchaseDetail", param))
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
                    lst = table.ToPagedDataTableList<MachineryPurchaseDetail>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryPurchaseDetail> GetMachineryPurchaseDetailAsync(int MachineryPurchaseDetailID)
        {
            MachineryPurchaseDetail result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryPurchaseDetailID", MachineryPurchaseDetailID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryPurchaseDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachineryPurchaseDetail>();
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
        public async Task<int> AddOrUpdateMachineryPurchaseDetail(MachineryPurchaseDetail model)
        {
            try
            {
                SqlParameter[] param = {
                 new SqlParameter("@MachineryPurchaseDetailID", model.MachineryPurchaseDetailID),
                    new SqlParameter("@GRNNo", model.GRNNo),
                    new SqlParameter("@GRNDate", model.GRNDate),
                    new SqlParameter("@InvoiceNo", model.InvoiceNo),
                    new SqlParameter("@InvoiceDate", model.InvoiceDate),
                    new SqlParameter("@CompanyManufacturerName", model.CompanyManufacturerName),
                    new SqlParameter("@CountryOrigin", model.CountryOrigin),
                    new SqlParameter("@ModelNumber", model.ModelNumber),
                    new SqlParameter("@ManufacturingDate", model.ManufacturingDate),
                    new SqlParameter("@PartNumber", model.PartNumber),
                    new SqlParameter("@AccountHead", model.AccountHead),
                    new SqlParameter("@ManufacturingSerialNumber", model.ManufacturingSerialNumber),
                    new SqlParameter("@PurchaseAmount", model.PurchaseAmount),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy),
                    new SqlParameter("@MachineryID",model.MachineryID)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryPurchaseDetail", param);

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


