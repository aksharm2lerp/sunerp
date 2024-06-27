namespace Business.Entities.Marketing
{
    public class MarketingCommunicationLogDetail
    {
        public int MarketingFeedbackDetailID { get; set; } = 0;
        public int MarketingFeedbackID { get; set; } = 0;
        public int MarketingCommunicationLogDetailID { get; set; } = 0;
        public int MarketingCommunicationLogID { get; set; } = 0;
        public int PositiveNoteID { get; set; }
        public string Response { get; set; }
    }
    public class MarketingCommunicationLogSearch
    {
        public string keyword { get; set; }
        public int CompanyID { get; set; }

    }
}
