using Business.Entities.Production.MachineCategoryMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineCategoryMaster
{
    public interface MachineCategoryMasterInterface
    {        
        Task<PagedDataTable<MachineCategoryMaster>> GetAllMachineCategoryMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineCategoryMasterID", string sortBy = "ASC");

        Task<MachineCategoryMaster> GetMachineCategoryMasterAsync(int MachineCategoryMasterID);

        Task<int> AddOrUpdateMachineCategoryMaster(MachineCategoryMaster model);

    }
}
