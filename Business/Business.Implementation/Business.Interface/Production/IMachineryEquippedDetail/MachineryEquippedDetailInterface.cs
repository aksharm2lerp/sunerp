using Business.Entities.Production.MachineryEquippedDetailModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineryEquippedDetail
{
    public interface MachineryEquippedDetailInterface
    {        
        Task<PagedDataTable<MachineryEquippedDetail>> GetAllMachineryEquippedDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryEquippedDetailID", string sortBy = "ASC");

        Task<MachineryEquippedDetail> GetMachineryEquippedDetailAsync(int MachineryEquippedDetailID);

        Task<int> AddOrUpdateMachineryEquippedDetail(MachineryEquippedDetail model);

    }
}
