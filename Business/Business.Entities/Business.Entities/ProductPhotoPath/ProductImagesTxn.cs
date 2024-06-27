using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.ProductPhotoPath
{
    public class ProductImagesTxn
    {
        public int SrNo { get; set; }
        public int ProductImageTxnID { get; set; }
        public int ProductImageID { get; set; }
        public string ProductImageTxnText { get; set; }
        public string ProductImageTxnPath { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public string carouselProductImageTxnActive { get; set; }
        public List<ProductImagesTxn> listProductImagesTxn { get; set; } = new List<ProductImagesTxn>();
    }
}
