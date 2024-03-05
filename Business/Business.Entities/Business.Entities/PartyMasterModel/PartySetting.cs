namespace Business.Entities.Party
{
    public class PartySetting
    {
        public int PartySettingID { get; set; }
        public int PartyID { get; set; }
        public string CreditLimit { get; set; }
        public string CommitementLimit { get; set; }
        public string PaymentTerm { get; set; }
        public string AllowDiscountPerPO { get; set; }
    }
}
