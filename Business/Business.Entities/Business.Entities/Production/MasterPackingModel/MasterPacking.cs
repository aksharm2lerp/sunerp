using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using GridCore;

namespace Business.Entities.Production.MasterPackingModel
{
    public class MasterPacking
    {
        public int SrNo { get; set; }
        public int MasterPackingID { get; set; }
        public string MasterPackingCode { get; set; }
        public string QRCode { get; set; }
        public int? BatchNo { get; set; }
        public string UserBatchCode { get; set; }
        public string ScannedBy { get; set; }
        public int NoOfItems { get; set; } = 0;
        public bool IsTakenPrint { get; set; }
        public bool IsSelect { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public ISGrid iSGrid { get; set; }
        public string ScannedItemsArray { get; set; }
        public string MasterPackingAutoGen { get; set; }
        public string BatchNumber { get; set; }
        public string UserPrintCode { get; set; }

    }


    public class ScannedItemDetail
    {
        public int MasterPackingDetailID { get; set; }
        public int MasterPackingID { get; set; }
        public int SrNo { get; set; }
        public double DocEntry { get; set; }
        public DateTime? PostDate { get; set; }
        public double DocTime { get; set; }
        public double Production_No { get; set; }
        public double Goods_Receipt_No { get; set; }
        public string Warehouse { get; set; }
        public string DrumNo { get; set; }
        public string Pallet_No { get; set; }
        public double OrderQty { get; set; }
        public string ItemCode { get; set; }
        public string ProdName { get; set; }
        public double BatchQty { get; set; }
        public string BatchNum { get; set; }
        public double Sales_Order { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public double U_mtrs { get; set; }
        public string U_FIM { get; set; }
        public string U_SZCOND { get; set; }
        public double U_INOS { get; set; }
        public string U_ICOND { get; set; }
        public string WhsCode { get; set; }
        public string QRCode { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }

    public class MasterPackingSearch
    {
        public string keyword { get; set; }
        public int CompanyID { get; set; }
    }

    public class MasterPackingDetail
    {
        public int SrNo { get; set; }
        public int MasterPackingDetailID { get; set; }
        public int MasterPackingID { get; set; }
        public decimal? GoodsReceiptNo { get; set; }
        public string BatchNum { get; set; }
        public string ItemCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}