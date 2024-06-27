using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Marketing.TravellingExpenseDetailModel
{
    public class TravellingExpenseDetail
    {
        public int SrNo { get; set; }
        public int TravellingExpenseDetailID { get; set; }
        public int TravellingExpenseStatusID { get; set; }
        public DateTime TravellingDate { get; set; } = DateTime.Now;
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string Via { get; set; }
        public string DistanceInKM { get; set; }
        public string Amount { get; set; }
        public int? PartyID { get; set; }
        public string PartyName { get; set; }
        public string MarketingPerson { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public List<TravellingExpenseDetail> listTravellingExpenseDetail { get; set; } = new List<TravellingExpenseDetail>();
        public List<TravellingExpenseBillsImages> listTravellingExpenseBillsImages { get; set; } = new List<TravellingExpenseBillsImages>();
        public List<IFormFile> TravelExpenseImage { get; set; } = new List<IFormFile>();
        public string TravellingExpenseBillsImagesText { get; set; }


    }
}