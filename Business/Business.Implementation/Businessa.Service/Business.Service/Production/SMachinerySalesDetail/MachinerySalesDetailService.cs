using Business.Interface.Production.IMachinerySalesDetail;
using Business.Entities.Production.MachinerySalesDetailModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SMachinerySalesDetail
{
    public class MachinerySalesDetailService : MachinerySalesDetailInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachinerySalesDetailService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachinerySalesDetail>> GetAllMachinerySalesDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachinerySalesDetailID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachinerySalesDetail> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachinerySalesDetail", param))
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
                    lst = table.ToPagedDataTableList<MachinerySalesDetail>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachinerySalesDetail> GetMachinerySalesDetailAsync(int MachinerySalesDetailID)
        {
            MachinerySalesDetail result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachinerySalesDetailID", MachinerySalesDetailID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachinerySalesDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<MachinerySalesDetail>();
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
        public async Task<int> AddOrUpdateMachinerySalesDetail(MachinerySalesDetail model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MachinerySalesDetailID", model.MachinerySalesDetailID),
                    new SqlParameter("@InvoiceNo", model.InvoiceNo),
                    new SqlParameter("@InvoiceDate", model.InvoiceDate),
                    new SqlParameter("@LRNo", model.LRNo),
                    new SqlParameter("@LRDate", model.LRDate),
                    new SqlParameter("@TransportationName", model.TransportationName),
                    new SqlParameter("@DispatchLocation", model.DispatchLocation),
                    new SqlParameter("@PartyName", model.PartyName),
                    new SqlParameter("@MachineOperatingStatusID", model.MachineOperatingStatusID),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy),
                    new SqlParameter("@MachineryID",model.MachineryID),
                    new SqlParameter("@ItemCode",model.ItemCode)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachinerySalesDetail", param);

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


