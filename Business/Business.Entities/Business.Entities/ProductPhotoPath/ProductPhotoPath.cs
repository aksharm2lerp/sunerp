using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.ProductPhotoPath
{
    public class ProductPhotoPath
    {
        public int ProductImageID { get; set; }
        public string ProductImageText { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Select Multiple Product Images.")]
        public IFormFile ProductPhoto { get; set; }
        //public List<HttpPostedFileBase> Images { get; set; }
        public int UOMID { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string SearchKey { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductCategoryText { get; set; }
        [Required(ErrorMessage = "Select Warehouse.")]
        public string Warehouse { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public List<ProductPhotoPath> listItemDocument { get; set; } = new List<ProductPhotoPath>();
        public List<ProductImagesTxn> listProductImagesTxn { get; set; } = new List<ProductImagesTxn>();
        [Required(ErrorMessage = "Select Multiple Product Images.")]
        public List<IFormFile> MultipleFiles { get; set; } = new List<IFormFile>();
        public string ProductImageTxnText { get; set; }
        public string ProductImageTxnPath { get; set; }
        public List<ProductPhotoPath> Result { get; set; }
    }
}