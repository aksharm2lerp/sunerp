using Business.Entities.Admin.UserActivityLogModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IUserActivityLogService
{
    public interface UserActivityLogInterface
    {        
        Task<PagedDataTable<UserActivityLog>> GetAllUserActivityLogAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "UserActivityLogID", string sortBy = "ASC");

        Task<UserActivityLog> GetUserActivityLogAsync(int UserActivityLogID);

        Task<int> AddOrUpdateUserActivityLog(UserActivityLog model);

    }
}
