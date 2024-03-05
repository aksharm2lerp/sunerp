using Business.Entities.Marketing.RequestForQuotTypeMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IRequestForQuotTypeMaster
{
    public interface RequestForQuotTypeMasterInterface
    {        
        Task<PagedDataTable<RequestForQuotTypeMaster>> GetAllRequestForQuotTypeMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "RequestForQuotTypeMasterID", string sortBy = "ASC");

        Task<RequestForQuotTypeMaster> GetRequestForQuotTypeMasterAsync(int RequestForQuotTypeMasterID);

        Task<int> AddOrUpdateRequestForQuotTypeMaster(RequestForQuotTypeMaster model);

    }
}
