using Business.Entities.SalesDistribution.TermsMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.SalesDistribution.ITermsMaster
{
    public interface TermsMasterInterface
    {        
        Task<PagedDataTable<TermsMaster>> GetAllTermsMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "TermsMasterID", string sortBy = "ASC");

        Task<TermsMaster> GetTermsMasterAsync(int TermsMasterID);

        Task<int> AddOrUpdateTermsMaster(TermsMaster model);

    }
}
