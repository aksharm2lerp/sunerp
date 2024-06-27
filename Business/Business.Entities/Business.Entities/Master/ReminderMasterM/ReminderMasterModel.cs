using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Master.ReminderMasterM
{
    public class ReminderMasterModel
    {
        public int ReminderID { get; set; }
        public DateTime ReminderDate { get; set; }
        public TimeSpan ReminderTime { get; set; }
        public string ReminderSubject { get; set; }
        public string ReminderText { get; set; }
    }
}