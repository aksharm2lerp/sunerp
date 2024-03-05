using Business.Entities.Production.UtilityMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IUtilityMaster
{
    public interface UtilityMasterInterface
    {        
        Task<PagedDataTable<UtilityMaster>> GetAllUtilityMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "UtilityMasterID", string sortBy = "ASC");

        Task<UtilityMaster> GetUtilityMasterAsync(int UtilityMasterID);

        Task<int> AddOrUpdateUtilityMaster(UtilityMaster model);

    }
}
