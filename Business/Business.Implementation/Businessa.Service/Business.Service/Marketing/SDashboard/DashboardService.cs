using Business.Entities.Marketing.Dashboard;
using Business.Interface.Marketing.IDashboard;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Business.Service.Marketing.SDashboard
{
    public class DashboardService : DashboardInterface
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public DashboardService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #endregion Database Connection

        #region Index Page

        public async Task<DashboardModel> GetUserLoginList(DateTime? startDate, DateTime? endDate)
        {
            DashboardModel result = null;
            try
            {
                SqlParameter[] param = { 
                    new SqlParameter("@StartDate", startDate), 
                    new SqlParameter("@EndDate", endDate)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Dashbord_UserLoginSummary", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        result = dr.ToPagedDataTableList<DashboardModel>();

                        List<LoginHistoryModel> listLoginHistoryModel = new List<LoginHistoryModel>();

                        foreach (DataRow item in ds.Tables["Table"].Rows)
                        {
                            LoginHistoryModel loginHistoryModel = new LoginHistoryModel();

                            loginHistoryModel.UserName = item["UserName"].ToString();
                            loginHistoryModel.PhoneNumber = item["PhoneNumber"].ToString();
                            loginHistoryModel.LoginDate = item["Login Date"].ToString();
                            loginHistoryModel.LoginTime = item["Login Time"].ToString();
                            loginHistoryModel.Browser = item["Browser"].ToString();
                            loginHistoryModel.Latitude = item["Latitude"].ToInt();
                            loginHistoryModel.longitude = item["longitude"].ToInt();
                            loginHistoryModel.DeviceIP  = item["DeviceIP"].ToString();
                            //loginHistoryModel.TotalLogin = item["UOMID"].ToInt();

                            listLoginHistoryModel.Add(loginHistoryModel);
                        }
                        result.ListLoginHistoryModels = listLoginHistoryModel;
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion Index Page
    }
}
