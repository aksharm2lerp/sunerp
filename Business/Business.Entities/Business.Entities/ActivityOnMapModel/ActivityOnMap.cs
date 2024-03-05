using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.ActivityOnMapModel
{
    public class ActivityOnMap
    {
        //public int UserGeoLocationID { get; set; }
        //public int UserID { get; set; }
        public DateTime TrackTimeStamp { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }

    
}
