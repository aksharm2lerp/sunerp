using Business.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.NotificationModel
{
    public class Notification
    {
        public int SrNo { get; set; }
        public int NotificationID { get; set; }
        public int? PackageID { get; set; }
        public int? UserID { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationSubject { get; set; }
        public string NotificationText { get; set; }
        public string PlainNotificationText { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public bool IsView { get; set; }
        public DateTime ViewDateTime { get; set; }
        public bool IsSent { get; set; }
        public DateTime SentDateTime { get; set; }
        public string sentToEmail { get; set; }
        public int TotalCount { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedOrModifiedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
