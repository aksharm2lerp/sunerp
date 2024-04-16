using Microsoft.AspNetCore.Http;
using System;

namespace Business.Entities.ProductPhotoPath
{
    public class ProductPhotoPath
    {
        public int ProductImageID { get; set; }
        public string ProductImageText { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ProductPhoto { get; set; }
        //public List<HttpPostedFileBase> Images { get; set; }
        public int UOMID { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductCategoryText { get; set; }
        public string Warehouse { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}