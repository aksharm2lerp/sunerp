using Business.Entities.Marketing.OfferAcceptedMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IOfferAcceptedMaster
{
    public interface OfferAcceptedMasterInterface
    {        
        Task<PagedDataTable<OfferAcceptedMaster>> GetAllOfferAcceptedMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "OfferAcceptedMasterID", string sortBy = "ASC");

        Task<OfferAcceptedMaster> GetOfferAcceptedMasterAsync(int OfferAcceptedMasterID);
        Task<PagedDataTable<OfferAcceptedDetail>> GetOfferAcceptedDetailAsync(int OfferAcceptedMasterID);
        Task<int> AddOrUpdateOfferAcceptedMaster(OfferAcceptedMaster model,DataTable dataTable);
        Task<CustomerAddressTxn> GetCustomerAddressDetail(int addressTypeID, int customerId);
        Task<int> OfferAcceptedDetailItemDeactivationAsync(int OfferAcceptedDetailId, int OfferAcceptedId, int userId);
    }
}
