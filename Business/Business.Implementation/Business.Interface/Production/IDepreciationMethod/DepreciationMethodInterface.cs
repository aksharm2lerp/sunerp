using Business.Entities.Production.DepreciationMethodModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IDepreciationMethod
{
    public interface DepreciationMethodInterface
    {        
        Task<PagedDataTable<DepreciationMethod>> GetAllDepreciationMethodAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "DepreciationMethodID", string sortBy = "ASC");

        Task<DepreciationMethod> GetDepreciationMethodAsync(int DepreciationMethodID);

        Task<int> AddOrUpdateDepreciationMethod(DepreciationMethod model);

    }
}
