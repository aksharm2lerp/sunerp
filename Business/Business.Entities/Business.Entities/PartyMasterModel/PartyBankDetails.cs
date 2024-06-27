using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Party
{
    public class PartyBankDetails
    {
        public int SrNo { get; set; }
        public int PartyBankDetailsID { get; set; }
        public int PartyID { get; set; }

        [Required(ErrorMessage = "Enter this detail!")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Enter this detail!")]
        public string IFSCCode { get; set; }

        [Required(ErrorMessage = "Enter this detail!")]
        public string AccountNO { get; set; }

        [Required(ErrorMessage = "Enter this detail!")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Enter this detail!")]
        public string BranchLocation { get; set; }
        public string City { get; set; }
        public string BankCode { get; set; }
        public string BICSwiftCode { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public bool IsDefaultBankAccount { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
    }
}
