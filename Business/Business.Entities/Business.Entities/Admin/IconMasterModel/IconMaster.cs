using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Admin.IconMasterModel
{
    public class IconMaster
    {
        public int SrNo { get; set; }
        public int IconMasterID { get; set; }
        public string IconName { get; set; }
        public string IconHTMLTag { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}