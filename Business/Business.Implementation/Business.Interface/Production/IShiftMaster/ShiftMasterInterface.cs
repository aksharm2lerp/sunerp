using Business.Entities.Production.ShiftMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IShiftMaster
{
    public interface ShiftMasterInterface
    {        
        Task<PagedDataTable<ShiftMaster>> GetAllShiftMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ShiftMasterID", string sortBy = "ASC");

        Task<ShiftMaster> GetShiftMasterAsync(int ShiftMasterID);

        Task<int> AddOrUpdateShiftMaster(ShiftMaster model);

    }
}
