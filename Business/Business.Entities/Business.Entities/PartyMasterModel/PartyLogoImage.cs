namespace Business.Entities.Party
{
    public class PartyLogoImage
    {
        public int PartyLogoImageID { get; set; }
        public int PartyID { get; set; }
        public string LogoImageName { get; set; }
        public string LogoImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public int? CreatedOrModifiedBy { get; set; }
    }
}
