using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Party
{
    public class PartyContactTxn
    {
        public int PartyContactID { get; set; }
        public int PartyID { get; set; }
        public string Prefix { get; set; }

        [Required(ErrorMessage = "Contact person name is required.")]
        public string ContactPersonName { get; set; }

        public int DesignationID { get; set; }

        public int DepartmentID { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

        
        public string PersonalMobile { get; set; }

        public string OfficeMobile { get; set; }
        public string PersonalEmailID { get; set; }
        public string OfficeEmailID { get; set; }
        public string AlternativeMobile { get; set; }
        public string EmailGroupName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Religion { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsResigned { get; set; }
        public string Notes { get; set; }
        public int SrNo { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}
