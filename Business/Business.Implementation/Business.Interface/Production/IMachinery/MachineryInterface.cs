using Business.Entities.Production.MachineryModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachinery
{
    public interface MachineryInterface
    {        
        Task<PagedDataTable<Machinery>> GetAllMachineryAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryID", string sortBy = "ASC");

        Task<Machinery> GetMachineryAsync(int MachineryID);

        Task<int> AddOrUpdateMachinery(Machinery model);

    }
}
