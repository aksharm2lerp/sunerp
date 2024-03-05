using Business.Interface.Production.IMachineryOperationDetail;
using Business.Entities.Production.MachineryOperationDetailModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Business.Entities.Marketing.Feedback;
using Business.Entities.Marketing;
using System.Collections.Generic;
using Business.Entities.Production.MachineryUtilityConsumptionModel;

namespace Business.Service.Production.SMachineryOperationDetail
{
    public class MachineryOperationDetailService : MachineryOperationDetailInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MachineryOperationDetailService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<MachineryOperationDetail>> GetAllMachineryOperationDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryOperationDetailID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryOperationDetail> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryOperationDetail", param))
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
                    lst = table.ToPagedDataTableList<MachineryOperationDetail>(pageNo, pageSize, totalItemCount);
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
        public async Task<MachineryOperationDetail> GetMachineryOperationDetailAsync(int MachineryOperationDetailID)
        {
            MachineryOperationDetail result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@MachineryOperationDetailID", MachineryOperationDetailID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_MachineryOperationDetail", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        result = dr.ToPagedDataTableList<MachineryOperationDetail>();

                        List<MachineryUtilityConsumption> listMachineryUtilityConsumptions = new List<MachineryUtilityConsumption>();

                        foreach (DataRow item in ds.Tables["Table1"].Rows)
                        {
                            MachineryUtilityConsumption machineryUtilityConsumption = new MachineryUtilityConsumption();
                            machineryUtilityConsumption.MachineryUtilityConsumptionID = item["MachineryUtilityConsumptionID"].ToInt();
                            machineryUtilityConsumption.MachineryOperationDetailID = item["MachineryOperationDetailID"].ToInt();
                            machineryUtilityConsumption.UtilityID = item["UtilityID"].ToInt();
                            machineryUtilityConsumption.Number = item["Number"].ToInt();
                            machineryUtilityConsumption.UOMID = item["UOMID"].ToInt();
                            listMachineryUtilityConsumptions.Add(machineryUtilityConsumption);
                        }
                        result.machineryUtilityConsumptions = listMachineryUtilityConsumptions;
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
        public async Task<int> AddOrUpdateMachineryOperationDetail(MachineryOperationDetail model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MachineryOperationDetailID", model.MachineryOperationDetailID),
                    new SqlParameter("@OperationUses", model.OperationUses),
                    new SqlParameter("@ProductionCapacity", model.ProductionCapacity),
                    new SqlParameter("@NoOfOperators", model.NoOfOperators),
                    new SqlParameter("@NoOfHelpers", model.NoOfHelpers),
                    new SqlParameter("@PowerConsumption", model.PowerConsumption),
                    new SqlParameter("@RiskFactor", model.RiskFactor),
                    new SqlParameter("@UOMID", model.UOMID),
                    new SqlParameter("@UtilityID", null),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy),
                    new SqlParameter("@UDTT_MachineryUtilityConsumption", dataTable)
                };

                param[11].Direction = ParameterDirection.Input;
                param[11].SqlDbType = SqlDbType.Structured;
                param[11].ParameterName = "@UDTT_MachineryUtilityConsumption";
                param[11].TypeName = "UDTT_MachineryUtilityConsumption";
                param[11].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_MachineryOperationDetail", param);

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


