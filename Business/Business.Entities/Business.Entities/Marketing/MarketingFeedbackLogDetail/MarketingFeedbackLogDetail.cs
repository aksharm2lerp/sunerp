namespace Business.Entities.Marketing
{
    public class MarketingFeedbackLogDetail
    {
        public int MarketingFeedbackDetailID { get; set; } = 0;
        public int MarketingFeedbackID { get; set; } = 0;
        public int PositiveNoteID { get; set; }
        public string Response { get; set; }
    }
}
