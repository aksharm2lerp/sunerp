using Business.Interface.Production.IMachinery;
using Business.Entities.Production.MachineryModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SMachinery
{
    public class MachineryService : MachineryInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<Machinery>> GetAllMachineryAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<Machinery> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_Machinery", param))
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
                    lst = table.ToPagedDataTableList<Machinery>(pageNo, pageSize, totalItemCount);
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
        public async Task<Machinery> GetMachineryAsync(int MachineryID)
        {
            Machinery result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryID", MachineryID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_Machinery", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<Machinery>();
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
        public async Task<int> AddOrUpdateMachinery(Machinery model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@MachineryID", model.MachineryID), new SqlParameter("@ItemCode", model.ItemCode), new SqlParameter("@ItemGroupID", model.ItemGroupID), new SqlParameter("@ItemSubGroupID", model.ItemSubGroupID), new SqlParameter("@MachineryName", model.MachineryName), new SqlParameter("@MachineCategoryID", model.MachineCategoryID), new SqlParameter("@MachineOperatingStatusID", model.MachineOperatingStatusID), new SqlParameter("@Description", model.Description), new SqlParameter("@ValidFrom", model.ValidFrom), new SqlParameter("@ValidTo", model.ValidTo), new SqlParameter("@Weight", model.Weight), new SqlParameter("@SizeDimension", model.SizeDimension), new SqlParameter("@ShiftingNote", model.ShiftingNote), new SqlParameter("@DepartmentID", model.DepartmentID),new SqlParameter("@LocationID",model.LocationID) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_Machinery", param);

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


