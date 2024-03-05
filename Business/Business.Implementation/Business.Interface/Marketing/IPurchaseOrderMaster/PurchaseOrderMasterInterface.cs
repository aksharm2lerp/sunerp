using Business.Entities.Marketing.PurchaseOrderMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IPurchaseOrderMaster
{
    public interface PurchaseOrderMasterInterface
    {        
        Task<PagedDataTable<PurchaseOrderMaster>> GetAllPurchaseOrderMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "PurchaseOrderMasterID", string sortBy = "ASC");

        Task<PurchaseOrderMaster> GetPurchaseOrderMasterAsync(int PurchaseOrderMasterID);
        Task<PagedDataTable<PurchaseOrderDetail>> GetPurchaseOrderDetailAsync(int PurchaseOrderMasterID);
        Task<int> AddOrUpdatePurchaseOrderMaster(PurchaseOrderMaster model,DataTable dataTable);
        Task<CustomerAddressTxn> GetCustomerAddressDetail(int addressTypeID, int customerId);
        Task<int> PurchaseOrderDetailItemDeactivationAsync(int PurchaseOrderDetailId, int PurchaseOrderId, int userId);
    }
}
