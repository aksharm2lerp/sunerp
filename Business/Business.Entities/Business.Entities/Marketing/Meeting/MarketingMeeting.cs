using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Marketing.Meeting
{
    public class MarketingMeeting
    {
        public int MarketingMeetingID { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MeetingDuration { get; set; }
        public bool Remainder { get; set; }
        public int RemainderTimeBeforeMeeting { get; set; }
        public string Description { get; set; }
        public int MeetingStatusID { get; set; }
        public string MeetingStatusTypeText { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonName { get; set; }
        public string MeetingRelatedTo { get; set; }
        public string MeetingLocation { get; set; }
        public string AssignTo { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public object SrNo { get; set; }
        public string ColorId { get; set; }
        public string MeetingRequestTitle { get; set; }

        [Required(ErrorMessage = "Please enter reason for meeting")]
        public string PurposeOfMeeting { get; set; }
        public string MeetToWhomPersonEmail { get; set; }

        [Required(ErrorMessage = "Please enter name of person to whom you want to meet")]
        public string MeetToWhomPersonName { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [RegularExpression("^[a-zA-Z\\-'_]+$", ErrorMessage = "Please enter a valid first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [RegularExpression("^[a-zA-Z\\-'_]+$", ErrorMessage = "Please enter a valid last name")]
        public string LastName { get; set; }

    }
}
