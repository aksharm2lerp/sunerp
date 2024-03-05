using Business.Entities.Party;
using Business.Entities.PartyMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IParty
{
    public interface IPartyService
    {
        Task<int> ActiveInActivePartyDocument(PartyDocument PartyDocument);
        Task<int> AddUpdateCustomeAddress(PartyAddressTxn PartyAddressTxn);
        Task<int> AddUpdateParty(PartyMaster PartyMaster);
        Task<int> AddUpdatePartyBankDetails(PartyBankDetails PartyBankDetails);
        Task<int> AddUpdatePartyContactDetail(PartyContactDetail PartyContactDetail);
        Task<int> AddUpdatePartyContactPerson(PartyContactTxn PartyContactTxn);
        Task<int> AddUpdatePartyDocument(PartyDocument PartyDocument);
        Task<int> AddUpdatePartyRegistration(PartyRegistration PartyRegistration);
        Task<int> AddUpdatePartySetting(PartySetting PartySetting);
        Task<PagedDataTable<PartyMaster>> GetAllPartyAsync(int pageNo = 1, int pageSize = 10, string searchString = "", string orderBy = "PartyID", string sortBy = "ASC");
        Task<PagedDataTable<PartyMaster>> GetAllPartySummaryAsync(int pageNo = 1, int pageSize = 10, string searchString = "", string orderBy = "PartyID", string sortBy = "ASC");
        Task<PartyAddressTxn> GetPartyAddressTxn(int customeAddressTxnId, int PartyId);
        Task<PagedDataTable<PartyAddressTxn>> GetPartyAllAddressAsync(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0);
        Task<PagedDataTable<PartyBankDetails>> GetPartyAllBankAccount(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0);
        Task<PagedDataTable<PartyContactTxn>> GetPartyAllContactPerson(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0);
        Task<PartyMaster> GetPartyAsync(int PartyId);
        Task<PartyBankDetails> GetPartyBankAccount(int PartyBankDetailsId, int PartyId);
        Task<PartyContactDetail> GetPartyContactDetail(int PartyId);
        Task<PartyContactTxn> GetPartyContactPerson(int PartyContactID, int PartyId);
        Task<PartyDocument> GetPartyDocument(int PartyDocumentId, int PartyId);
        Task<PartyRegistration> GetPartyRegistration(int PartyId);
        Task<PagedDataTable<PartyDocument>> GetPartysAllDocuments(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0);
        Task<PartySetting> GetPartySetting(int PartyId);
        Task<int> UpdatePartyLogoImage(PartyLogoImage PartyLogoImage);
    }
}
