using Business.Interface.IActivityOnMap;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using Business.Entities.ActivityOnMapModel;
using Business.SQL;
using System.Data.SqlClient;
using System.Data;

namespace Business.Service.SActivityOnMap
{
    public class ActivityOnMapService : ActivityOnMapInterface
    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public ActivityOnMapService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #endregion Database Connection

        //#region Google Map Start
        //public async Task<List<string>> GetGoogleMapAsync(int employeeId)
        //{
        //    try
        //    {
        //        List<string> strings = new List<string>();
        //       // string markers = string.Empty;
        //       // string Drawline = string.Empty;
        //       // SqlCommand cmd = new SqlCommand("SELECT * FROM UserGeoLocation WITH(NOLOCK) where Userid = 6 Order by TrackTimeStamp asc");
        //       //await using (SqlConnection con = new SqlConnection(connection))
        //       // {
        //       //     cmd.Connection = con;
        //       //     con.Open();
        //       //     using (SqlDataReader sdr = cmd.ExecuteReader())
        //       //     {
        //       //         while (sdr.Read())
        //       //         {
        //       //             markers += "{";
        //       //             Drawline += "{";
        //       //             markers += string.Format("'title': '{0}',", sdr["TrackTimeStamp"]);

        //       //             markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
        //       //             Drawline += string.Format("lat: {0},", sdr["Latitude"]);
        //       //             markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
        //       //             Drawline += string.Format("lng: {0}", sdr["Longitude"]);
        //       //             markers += string.Format("'description': '{0}'", "Visited Datetime :" + sdr["TrackTimeStamp"]);
        //       //             markers += "},";
        //       //             Drawline += "},";
        //       //         }
        //       //     }
        //       //     con.Close();
        //       //    strings.Add(markers);
        //       //     strings.Add(Drawline);
        //        //}
        //        return strings;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion Google Map End

        #region Using Table View For Google Map Location start        

        public async Task<PagedDataTable<ActivityOnMap>> GetAllLocationList(int uid, String startDate)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ActivityOnMap> lst = null;
            if (startDate == "")
            {
                startDate = null;
            }
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserID",uid) ,
                    new SqlParameter("@StartDate",startDate)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_GoogleMapLocationList", param);
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
                    lst = table.ToPagedDataTableList<ActivityOnMap>(1, 1000, totalItemCount);
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
        #endregion Using Table View For Google Map Location end
    }
}
