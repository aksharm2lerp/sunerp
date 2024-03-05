using System;

namespace Business.Entities.Master
{
    public class ReminderModel
    {
        public int SrNo { get; set; }
        public int ReminderID { get; set; }
        public int? PackageID { get; set; }
        public int? UserID { get; set; }
        public string ReminderTitle { get; set; }
        public string ReminderSubject { get; set; }
        public string ReminderText { get; set; }
        public DateTime? ReminderDateTime { get; set; }
        public bool? IsView { get; set; }
        public DateTime? ViewDateTime { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string SourceTable { get; set; }
        public int? SourceTableID { get; set; }
        public string SourceField { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}
