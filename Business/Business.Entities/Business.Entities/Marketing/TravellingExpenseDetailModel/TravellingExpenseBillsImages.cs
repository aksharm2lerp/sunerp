using Business.Entities.ProductPhotoPath;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Marketing.TravellingExpenseDetailModel
{
    public class TravellingExpenseBillsImages
    {
        public int SrNo { get; set; }
        public int TravellingExpenseBillsImagesTxnID { get; set; }
        public int TravellingExpenseDetailID { get; set; }
        public string TravellingExpenseBillsImagesText { get; set; }
        public string TravellingExpenseBillsImagesPath { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public List<TravellingExpenseBillsImages> listTravellingExpenseBillsImages { get; set; } = new List<TravellingExpenseBillsImages>();
    }
}
