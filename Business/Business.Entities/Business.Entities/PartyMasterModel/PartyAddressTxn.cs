using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Party
{
    public class PartyAddressTxn
    {
        public int SrNo { get; set; }
        
        public string AddressType { get; set; }

        [Required(ErrorMessage = "Enter this detail!")]
        public string PlotNoName { get; set; }
        public string StreetNoName { get; set; }
        public string MainAddress { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public int PartyAddressTxnID { get; set; }
        public int PartyID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Area { get; set; }
        public string ZIPCode { get; set; }
        public bool IsActive { get; set; } = true;
        public string City { get; set; }

        [Required(ErrorMessage = "Enter this detail!")]
        public string District { get; set; }
        [Required(ErrorMessage = "Enter this detail!")]
        public string Taluka { get; set; }
        public string Landmark { get; set; }
        [Required(ErrorMessage = "Select state from list!")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "Select country from list!")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Select address type from list!")]
        public int AddressTypeID { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public string DistrictName { get; set; }
    }
}
