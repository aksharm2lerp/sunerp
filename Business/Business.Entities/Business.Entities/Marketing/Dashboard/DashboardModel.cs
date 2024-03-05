using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Marketing.Dashboard
{
    public class DashboardModel
    {
        //public int SrNo { get; set; }
        //public int UserLoginID { get; set; }
        //public int UserID { get; set; }
        //public DateTime? InTime { get; set; }
        //public DateTime? OutTime { get; set; }
        //public string SessionID { get; set; }
        //public decimal? Latitude { get; set; }
        //public decimal? longitude { get; set; }
        //public string DeviceIP { get; set; }
        //public string BrowserName { get; set; }
        //public int CreatedOrModifiedBy { get; set; }

        public int? TotalLogin { get; set; }
        public int? TotalVisits { get; set; }
        public int? TotalCalls { get; set; }
        public List<LoginHistoryModel> ListLoginHistoryModels { get; set; }

    }
    public class LoginHistoryModel
    {
        public int SrNo { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string LoginDate { get; set; }
        public string LoginTime { get; set; }
        public string Browser { get; set; }
        public decimal Latitude { get; set; }
        public decimal longitude { get; set; }
        public string DeviceIP { get; set; }
    }
}