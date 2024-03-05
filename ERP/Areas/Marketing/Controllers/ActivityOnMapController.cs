using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using Business.Interface.IEmployee;
using System.Data.SqlClient;
using ERP.Controllers;
using Business.Interface.IActivityOnMap;
using System.ComponentModel;
using System.Collections.Generic;
using Business.Entities.ActivityOnMapModel;
using System.Text.Json;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("ActivityOnMap")]
    public class ActivityOnMapController : SettingsController
    {
        #region Interface Link
        private readonly IEmployeeService _employeeService;
        private readonly ActivityOnMapInterface _activityOnMapInterface;
        public ActivityOnMapController(IEmployeeService employeeService, ActivityOnMapInterface activityOnMapInterface)
        {
            _employeeService = employeeService;
            _activityOnMapInterface = activityOnMapInterface;
        }
        #endregion Interface Link

        #region Index Page
        public IActionResult Index()
        {
            ViewBag.UserID = USERID;
            ViewBag.CompanyID = COMPANYID;
            //GoogleMapRahul();
            //GoogleMap();
            //test test = new test();
            return View();
        }
        #endregion Index Page

        #region Get Employee Detail start

        [HttpGet]
        public IActionResult GetEmployeeDetail(int employeeId, String startDate)
        {

            // test test1 = new test();
            //EmployeeDetails test1 = new EmployeeDetails();
           String DT = String.Empty;
            if (startDate.IsNotStringNullOrEmpty() ) {
                DT = startDate;
            }
            EmployeeDetails EmployeeDetails = _employeeService.GetEmployeeAsync2(employeeId).Result;
            //List<ActivityOnMap> activityOnMap = new List<ActivityOnMap>();
            var activityOnMap = _activityOnMapInterface.GetAllLocationList(employeeId, DT).Result;
            //var notificationCount2 = _conversationActivitiesInterface.GetRFQListConversationActivities(id).Result;
            //test1 = EmployeeDetails;
            if (activityOnMap.Count > 0)
            {
                EmployeeDetails.activityOnMap = activityOnMap;
                string json1 = JsonSerializer.Serialize(activityOnMap);

                string markers = json1;
                ViewBag.Markers = markers;
                 
            }
            return Json(EmployeeDetails);
        }

        #endregion Get Employee Detail end

        #region Google Map Start

        public void GoogleMap()
        {
            string markers = "[";
            string Drawline = "[";
            string conString = @"Data Source=103.92.235.45;Initial Catalog=stihydra_AksharSource;User Id=stihydra_bal;Password=xW41wnE9Fsrnu@og;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserGeoLocation WITH(NOLOCK) where Userid = 6 Order by TrackTimeStamp asc");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        Drawline += "{";
                        markers += string.Format("'title': '{0}',", sdr["TrackTimeStamp"]);
                        markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                        Drawline += string.Format("lat: {0},", sdr["Latitude"]);
                        markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                        Drawline += string.Format("lng: {0}", sdr["Longitude"]);
                        markers += string.Format("'description': '{0}'", "Visited Datetime :" + sdr["TrackTimeStamp"]);
                        markers += "},";
                        Drawline += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            Drawline += "];";

            ViewBag.Markers = markers;
            ViewBag.drawline = Drawline;

        }


        public async void GoogleMapRahul()
        {
            try
            {
                List<ActivityOnMap> test = await _activityOnMapInterface.GetAllLocationList(USERID,string.Empty);
                string json = JsonSerializer.Serialize(test);

                string markers = json.Replace("TrackTimeStamp", "title");
                string Drawline = json;

                ViewBag.Markers = markers;
                ViewBag.drawline = Drawline;
            }
            catch (Exception ex)
            {

                throw;
            }


            //ViewBag.Markers = markers;
            //ViewBag.drawline = Drawline;

        }
        #endregion Google Map End

        #region Using Table View For Google Map Location start
        [HttpGet]
        public IActionResult ViewAllLocationList(int uid)
        {
            try
            {
                List<ActivityOnMap> dataSet = _activityOnMapInterface.GetAllLocationList(uid, string.Empty).Result;

                if (dataSet.Count > 0)
                {
                    return View("Index", dataSet);
                }
                else
                    return View("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetLocationData()
        {
            try
            {
                List<ActivityOnMap> test = _activityOnMapInterface.GetAllLocationList(USERID, string.Empty).Result;
                var cc = Json(new { data = test }, JsonRequestBehavior.AllowGet);
                ViewBag.Markers = cc;
                return cc;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Using Table View For Google Map Location end
    }
}
