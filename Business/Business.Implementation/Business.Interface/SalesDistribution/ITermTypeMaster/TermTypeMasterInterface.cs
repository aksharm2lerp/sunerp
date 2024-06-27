using Business.Entities.SalesDistribution.TermTypeMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.SalesDistribution.ITermTypeMaster
{
    public interface TermTypeMasterInterface
    {        
        Task<PagedDataTable<TermTypeMaster>> GetAllTermTypeMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "TermTypeMasterID", string sortBy = "ASC");

        Task<TermTypeMaster> GetTermTypeMasterAsync(int TermTypeMasterID);

        Task<int> AddOrUpdateTermTypeMaster(TermTypeMaster model);

    }
}
