using Business.Interface.Production.IItemQRCodeDetail;
using Business.Entities.Production.ItemQRCodeDetailModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SItemQRCodeDetail
{
    public class ItemQRCodeDetailService : ItemQRCodeDetailInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public ItemQRCodeDetailService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<ItemQRCodeDetail>> GetAllItemQRCodeDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ItemQRCodeDetailID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ItemQRCodeDetail> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ItemQRCodeDetail", param))
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
                    lst = table.ToPagedDataTableList<ItemQRCodeDetail>(pageNo, pageSize, totalItemCount);
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
        public async Task<ItemQRCodeDetail> GetItemQRCodeDetailAsync(int ItemQRCodeDetailID)
        {
            ItemQRCodeDetail result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@ItemQRCodeDetailID", ItemQRCodeDetailID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_ItemQRCodeDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<ItemQRCodeDetail>();
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
        public async Task<int> AddOrUpdateItemQRCodeDetail(ItemQRCodeDetail model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@ItemQRCodeDetailID", model.ItemQRCodeDetailID), new SqlParameter("@SONo", model.SONo), new SqlParameter("@SODate", model.SODate), new SqlParameter("@PlanningCard", model.PlanningCard), new SqlParameter("@MachineryID", model.MachineryID), new SqlParameter("@ItemID", model.ItemID), new SqlParameter("@UOMID", model.UOMID), new SqlParameter("@Qty", model.Qty), new SqlParameter("@IsQRCodeGenerated", model.IsQRCodeGenerated), new SqlParameter("@NoOfTakenPrint", model.NoOfTakenPrint), new SqlParameter("@DepartmentID", model.DepartmentID), new SqlParameter("@LocationID", model.LocationID),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_ItemQRCodeDetail", param);

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


