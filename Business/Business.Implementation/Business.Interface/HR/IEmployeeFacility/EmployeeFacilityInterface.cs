using Business.Entities.HR.EmployeeFacilityModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.HR.IEmployeeFacility
{
    public interface EmployeeFacilityInterface
    {        
        Task<PagedDataTable<EmployeeFacility>> GetAllEmployeeFacilityAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "EmployeeFacilityID", string sortBy = "ASC");

        Task<EmployeeFacility> GetEmployeeFacilityAsync(int EmployeeFacilityID);

        Task<int> AddOrUpdateEmployeeFacility(EmployeeFacility model);

    }
}
