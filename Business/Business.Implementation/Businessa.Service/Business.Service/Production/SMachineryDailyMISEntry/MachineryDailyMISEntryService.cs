using Business.Interface.Production.IMachineryDailyMISEntry;
using Business.Entities.Production.MachineryDailyMISEntryModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Business.Entities.Production.MachineryOperationDetailModel;
using Business.Entities.Production.MachineryUtilityConsumptionModel;
using System.Collections.Generic;

namespace Business.Service.Production.SMachineryDailyMISEntry
{
    public class MachineryDailyMISEntryService : MachineryDailyMISEntryInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryDailyMISEntryService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineryDailyMISEntry>> GetAllMachineryDailyMISEntryAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryDailyMISEntryID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryDailyMISEntry> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryDailyMISEntry", param))
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
                    lst = table.ToPagedDataTableList<MachineryDailyMISEntry>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryDailyMISEntry> GetMachineryDailyMISEntryAsync(int MachineryDailyMISEntryID)
        {
            MachineryDailyMISEntry result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryDailyMISEntryID", MachineryDailyMISEntryID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryDailyMISEntry", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        result = dr.ToPagedDataTableList<MachineryDailyMISEntry>();

                        List<MachineryUtilityConsumption> listMachineryUtilityConsumptions = new List<MachineryUtilityConsumption>();

                        foreach (DataRow item in ds.Tables["Table1"].Rows)
                        {
                            MachineryUtilityConsumption machineryUtilityConsumption = new MachineryUtilityConsumption();
                            machineryUtilityConsumption.MachineryUtilityConsumptionID = item["MachineryDailyMISUtilityConsumptionID"].ToInt();
                            machineryUtilityConsumption.MachineryDailyMISEntryID = item["MachineryDailyMISEntryID"].ToInt();
                            machineryUtilityConsumption.UtilityID = item["UtilityID"].ToInt();
                            machineryUtilityConsumption.Number = item["Number"].ToInt();
                            machineryUtilityConsumption.UOMID = item["UOMID"].ToInt();
                            listMachineryUtilityConsumptions.Add(machineryUtilityConsumption);
                        }
                        result.machineryUtilityConsumptions = listMachineryUtilityConsumptions;
                    }
                }
                //if (ds != null)
                //{
                //    if (ds.Tables.Count > 0)
                //    {
                //        if (ds.Tables[0].Rows.Count > 0)
                //        {
                //            DataRow dr = ds.Tables[0].Rows[0];
                //            result = dr.ToPagedDataTableList<MachineryDailyMISEntry>();
                //        }
                //    }
                //}
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Get Singal Record

        #region Add or Update Positive Note
        public async Task<int> AddOrUpdateMachineryDailyMISEntry(MachineryDailyMISEntry model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MachineryDailyMISEntryID", model.MachineryDailyMISEntryID),
                    new SqlParameter("@ItemCode", model.ItemCode),
                    new SqlParameter("@MachineryID", model.MachineryID),
                    new SqlParameter("@NoOfOperators", model.NoOfOperators),
                    new SqlParameter("@NoOfHelpers", model.NoOfHelpers),
                    new SqlParameter("@WorkingHours", model.WorkingHours),
                    new SqlParameter("@ShiftID", model.ShiftID),
                    new SqlParameter("@ShopWorkOrderNo", model.ShopWorkOrderNo),
                    new SqlParameter("@ItemID", model.ItemID),
                    new SqlParameter("@OutputStock", model.OutputStock),
                    new SqlParameter("@UOMID", model.UOMID),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy),
                    new SqlParameter("@UDTT_MachineryDailyMISUtilityConsumption", dataTable)
                };

                param[13].Direction = ParameterDirection.Input;
                param[13].SqlDbType = SqlDbType.Structured;
                param[13].ParameterName = "@UDTT_MachineryDailyMISUtilityConsumption";
                param[13].TypeName = "UDTT_MachineryDailyMISUtilityConsumption";
                param[13].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryDailyMISEntry", param);

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


