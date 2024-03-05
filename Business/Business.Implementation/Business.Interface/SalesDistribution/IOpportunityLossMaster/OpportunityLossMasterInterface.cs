using Business.Entities.SalesDistribution.OpportunityLossMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.SalesDistribution.IOpportunityLossMaster
{
    public interface OpportunityLossMasterInterface
    {        
        Task<PagedDataTable<OpportunityLossMaster>> GetAllOpportunityLossMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "OpportunityLossMasterID", string sortBy = "ASC");

        Task<OpportunityLossMaster> GetOpportunityLossMasterAsync(int OpportunityLossMasterID);
        Task<PagedDataTable<OpportunityLossDetail>> GetOpportunityLossDetailAsync(int OpportunityLossMasterID);
        Task<int> AddOrUpdateOpportunityLossMaster(OpportunityLossMaster model,DataTable dataTable);
        Task<CustomerAddressTxn> GetCustomerAddressDetail(int addressTypeID, int customerId);
        Task<int> OpportunityLossDetailItemDeactivationAsync(int OpportunityLossDetailId, int OpportunityLossId, int userId);
    }
}
