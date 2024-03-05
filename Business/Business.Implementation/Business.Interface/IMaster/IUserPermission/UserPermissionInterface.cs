using Business.Entities.Master.UserPermissionMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.IMaster.UserPermissionInterface
{
    public interface UserPermissionInterface
    {
        Task<int> AddUpdatePackageFormAssignToUser(DataTable dataTable);

        Task<PagedDataTable<UserPermissionMaster>> GetAllPackageDetailAsync(int packageID, int pageNo, int pageSize, string searchString = "", string orderBy = "PackageName", string sortBy = "ASC");

        Task<PagedDataTable<UserPermissionMaster>> GetPackageDetailSummary(int PackageId = 0, int userId = 0);
    }
}
