using System;

namespace Business.Entities.Master.PartyMasterModel
{
    public class PartyMaster
    {
        public int SrNo { get; set; }
        public int PartyID { get; set; }
        public string PartyCode { get; set; }
        public string PartyName { get; set; }
        public string UnitNoName { get; set; }
        public string GroupName { get; set; }
        public string OwnerName { get; set; }
        public string ContactPhone1 { get; set; }
        public string Mobile1 { get; set; }
        public string FaxNo { get; set; }
        public int? IndustryTypeID { get; set; }
        public int? BusinessTypeID { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public string Email { get; set; }
        public string LogoImageName { get; set; }
        public string LogoImagePath { get; set; }

    }
}
