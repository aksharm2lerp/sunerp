namespace Business.Entities.Party
{
    public class PartyContactDetail
    {
        public int PartyContactDetailID { get; set; }
        public int? PartyID { get; set; }
        public string OfficePhone { get; set; }
        public string MobileNo { get; set; }
        public string Website { get; set; }
    }
}
