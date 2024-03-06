using Business.Entities.Marketing.QuotationMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IQuotationMaster
{
    public interface QuotationMasterInterface
    {        
        Task<PagedDataTable<QuotationMaster>> GetAllQuotationMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "QuotationMasterID", string sortBy = "ASC");

        Task<QuotationMaster> GetQuotationMasterAsync(int QuotationMasterID,int RequestforQuotId);
        Task<PagedDataTable<QuotationDetail>> GetQuotationDetailAsync(int QuotationMasterID, int RequestForQuotID);
        Task<int> AddOrUpdateQuotationMaster(QuotationMaster model,DataTable dataTable);
        Task<PartyAddressTxn> GetPartyAddressDetail(int addressTypeID, int partyId);
        Task<int> QuotationDetailItemDeactivationAsync(int QuotationDetailId, int QuotationId, int userId);
    }
}
