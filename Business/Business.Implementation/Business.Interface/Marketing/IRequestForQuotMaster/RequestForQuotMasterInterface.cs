using Business.Entities.Marketing.RequestForQuotMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IRequestForQuotMaster
{
    public interface RequestForQuotMasterInterface
    {        
        Task<PagedDataTable<RequestForQuotMaster>> GetAllRequestForQuotMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "RequestForQuotMasterID", string sortBy = "ASC");

        Task<RequestForQuotMaster> GetRequestForQuotMasterAsync(int RequestForQuotMasterID);
        Task<PagedDataTable<RequestForQuotDetail>> GetRequestForQuotDetailAsync(int RequestForQuotMasterID);
        Task<int> AddOrUpdateRequestForQuotMaster(RequestForQuotMaster model,DataTable dataTable);
        Task<PartyAddressTxn> GetPartyAddressDetail(int addressTypeID, int partyId);
        Task<int> RequestForQuotDetailItemDeactivationAsync(int RequestForQuotDetailId, int RequestForQuotId, int userId);
        Task<PagedDataTable<RequestForQuotMaster>> GetAllRequestForQuotPendingQuotationAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "RequestForQuotMasterID", string sortBy = "ASC");
    }
}
