using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities.Marketing.CommunicationLog
{
    public class CommunicationLog
    {
        public int MarketingCommunicationLogID { get; set; }
        [Required(ErrorMessage = "Please enter contact by person name.")]
        public string ContactByPerson { get; set; }
        [Required(ErrorMessage = "Please enter contact to name.")]
        public string ContactTo { get; set; }
        public int PartyID { get; set; }
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Please enter contact by person name.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please select contact channel.")]
        public int ContactChannelTypeID { get; set; }
        public string ContactChannelTypeText { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter mobile number.")]
        public string MobileNo { get; set; }
        public int? VenueTypeID { get; set; }
        public string VenueTypeText { get; set; }
        public int? PartyTypeID { get; set; }
        public string PartyTypeText { get; set; }
        public DateTime CommunicationLogDate { get; set; } = DateTime.Now;
        public string PlaceOfMeeting { get; set; }
        public bool IsSentDocument { get; set; }
        public bool IsSentMarketingDocument { get; set; }
        public bool ReferenceBetterBusiness { get; set; }
        public string ReferenceMobileOrEmail { get; set; }
        public string Note { get; set; }
        public string Feedback { get; set; }
        public string FeedbackNoteID { get; set; }
        public string FeedbackNoteText { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public int SrNo { get; set; }
        public string PositiveNotesArray { get; set; }
        [NotMapped]
        public string EncryptedId { get; set; }
        public List<MarketingCommunicationLogDetail> marketingCommunicationLogDetails { get; set; } = new List<MarketingCommunicationLogDetail>();
        public string keyword { get; set; }
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }
    }
}
