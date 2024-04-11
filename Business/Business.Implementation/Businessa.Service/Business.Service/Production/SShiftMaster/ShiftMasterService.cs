using Business.Interface.Production.IShiftMaster;
using Business.Entities.Production.ShiftMasterModel;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Production.SShiftMaster
{
    public class ShiftMasterService : ShiftMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public ShiftMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<ShiftMaster>> GetAllShiftMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ShiftMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ShiftMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ShiftMaster", param))
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
                    lst = table.ToPagedDataTableList<ShiftMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<ShiftMaster> GetShiftMasterAsync(int ShiftMasterID)
        {
            ShiftMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@ShiftID", ShiftMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_ShiftMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<ShiftMaster>();
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
        public async Task<int> AddOrUpdateShiftMaster(ShiftMaster model)
        {
            try
            {
                SqlParameter[] param = {
                 new SqlParameter("@ShiftID", model.ShiftID),
                    new SqlParameter("@ShiftName", model.ShiftName),
                    new SqlParameter("@StartTime", model.StartTime),
                    new SqlParameter("@EndTime", model.EndTime),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_ShiftMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Positive Note

        #region ManageShift        
        public async Task<PagedDataTable<ManageShift>> GetAllShiftMasterAsync(ManageShift model)
        {
            DataTable table = new DataTable();
            try
            {
                int totalItemCount = 0;
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_CompanyMaster");
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
                    PagedDataTable<ManageShift> lst = table.ToPagedDataTableList<ManageShift>(1, 1000, totalItemCount);
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        #endregion ManageShift

        #region AddOrUpdateManageShift
        public async Task<int> AddOrUpdateManageShift(ManageShift model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@EmployeeShiftTnxID", model.EmployeeShiftTnxID),
                    new SqlParameter("@CompanyID", model.CompanyID ),
                    new SqlParameter("@ShiftID", model.ShiftID),
                    new SqlParameter("@EmployeeID", model.EmployeeID),                    
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeShiftTnx", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion AddOrUpdateManageShift

        #region GetPackageDetailSummary

        public async Task<ManageShift> GetEmployeeListByShift(int companyID, int shiftID)
        {
            ManageShift result = null;
            try
            {
                int totalItemCount = 0;
                SqlParameter[] param = {
                        new SqlParameter("@CompanyID",companyID),
                        new SqlParameter("@ShiftID",shiftID),
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeShiftTnx", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<ManageShift>();                       }
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }            
        }

        #endregion GetPackageDetailSummary

        #region Get Company Detail
        public async Task<PagedDataTable<ManageShift>> GetAllShiftListsMasterAsync(int companyID)
                                       
        {
            DataTable table = new DataTable();
            try
            {
                int totalItemCount = 0;
                //DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeShiftTnx");
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeShiftTnx");
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
                    PagedDataTable<ManageShift> lst = table.ToPagedDataTableList<ManageShift>(1, 1000, totalItemCount);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Get Company Detail

    }
}


