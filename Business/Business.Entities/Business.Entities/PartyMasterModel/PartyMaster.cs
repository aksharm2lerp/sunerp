using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.PartyMasterModel
{
    public class PartyMaster
    {
        public int SrNo { get; set; }
        public int PartyID { get; set; }
        public string PartyCode { get; set; }
        [Required(ErrorMessage ="Party Name is required! Please Enter")]
        public string PartyName { get; set; }
        public string UnitNoName { get; set; }
        public string GroupName { get; set; }
        [Required(ErrorMessage ="Owner Name is required! Please Enter")]
        public string OwnerName { get; set; }
        public string ContactPhone1 { get; set; }
        [Required(ErrorMessage ="Mobile Number is required! Please Enter")]
        public string Mobile1 { get; set; }

        public string FaxNo { get; set; }
        public int? IndustryTypeID { get; set; }
        public int? BusinessTypeID { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public string Email { get; set; }
        public string LogoImageName { get; set; }
        public string LogoImagePath { get; set; }
        public IFormFile LogoImage { get; set; }
        public int PartyLogoImageID { get; set; }
        public string Note { get; set; }
        public string Reply { get; set; }
        public DateTime? Date { get; set; }
        public string MobileNo { get; set; }

        [Required(ErrorMessage ="Please Select Party type from list!")]
        public int? PartyTypeID { get; set; }

    }
}
