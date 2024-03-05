using Business.Entities.Admin.EndUserTypeMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IEndUserTypeMasterService
{
    public interface EndUserTypeMasterInterface
    {        
        Task<PagedDataTable<EndUserTypeMaster>> GetAllEndUserTypeMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "EndUserTypeMasterID", string sortBy = "ASC");

        Task<EndUserTypeMaster> GetEndUserTypeMasterAsync(int EndUserTypeMasterID);

        Task<int> AddOrUpdateEndUserTypeMaster(EndUserTypeMaster model);

    }
}
