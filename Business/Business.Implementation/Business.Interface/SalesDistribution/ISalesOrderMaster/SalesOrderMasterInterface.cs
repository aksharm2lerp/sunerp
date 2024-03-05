using Business.Entities.SalesDistribution.SalesOrderMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.SalesDistribution.ISalesOrderMaster
{
    public interface SalesOrderMasterInterface
    {        
        Task<PagedDataTable<SalesOrderMaster>> GetAllSalesOrderMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "SalesOrderMasterID", string sortBy = "ASC");

        Task<SalesOrderMaster> GetSalesOrderMasterAsync(int SalesOrderMasterID);
        Task<PagedDataTable<SalesOrderDetail>> GetSalesOrderDetailAsync(int SalesOrderMasterID);
        Task<int> AddOrUpdateSalesOrderMaster(SalesOrderMaster model,DataTable dataTable);
        Task<CustomerAddressTxn> GetCustomerAddressDetail(int addressTypeID, int customerId);
        Task<int> SalesOrderDetailItemDeactivationAsync(int salesOrderDetailId, int salesOrderId, int userId);
    }
}
