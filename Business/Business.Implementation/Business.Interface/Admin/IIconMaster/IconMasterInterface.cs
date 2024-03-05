using Business.Entities.Admin.IconMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IIconMasterService
{
    public interface IconMasterInterface
    {        
        Task<PagedDataTable<IconMaster>> GetAllIconMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "IconMasterID", string sortBy = "ASC");

        Task<IconMaster> GetIconMasterAsync(int IconMasterID);

        Task<int> AddOrUpdateIconMaster(IconMaster model);

    }
}
