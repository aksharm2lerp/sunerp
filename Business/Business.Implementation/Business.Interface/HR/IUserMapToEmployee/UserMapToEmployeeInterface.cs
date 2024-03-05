using Business.Entities.HR.UserMapToEmployeeModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IUserMapToEmployeeService
{
    public interface UserMapToEmployeeInterface
    {        
        Task<PagedDataTable<UserMapToEmployee>> GetAllUserMapToEmployeeAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "UserMapToEmployeeID", string sortBy = "ASC");

        Task<UserMapToEmployee> GetUserMapToEmployeeAsync(int UserMapToEmployeeID);

        Task<int> AddOrUpdateUserMapToEmployee(UserMapToEmployee model);

    }
}
