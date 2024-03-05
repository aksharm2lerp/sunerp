using System.Collections.Generic;

namespace Business.Entities.AddNewFeedback
{
    public class AddNewFeedback
    {
        public int? PositiveNoteID { get; set; }
        public string Note { get; set; }
        public List<AddNewFeedback> AddMoreFeedback { get; set;}
    }
}
