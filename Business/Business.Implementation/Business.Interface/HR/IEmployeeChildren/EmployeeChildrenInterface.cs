using Business.Entities.HR.EmployeeChildrenModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IEmployeeChildrenService
{
    public interface EmployeeChildrenInterface
    {        
        Task<PagedDataTable<EmployeeChildren>> GetAllEmployeeChildrenAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "EmployeeChildrenID", string sortBy = "ASC");

        Task<EmployeeChildren> GetEmployeeChildrenAsync(int EmployeeChildrenID);

        Task<int> AddOrUpdateEmployeeChildren(EmployeeChildren model);

    }
}
