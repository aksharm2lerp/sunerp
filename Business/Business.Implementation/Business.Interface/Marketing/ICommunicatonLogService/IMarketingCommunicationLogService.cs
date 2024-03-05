using Business.Entities.Marketing.CommunicationLog;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.CommunicatonLog
{
    public interface IMarketingCommunicationLogService
    {
        Task<PagedDataTable<CommunicationLog>> GetAllMarketingCommunicationLogAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MarketingCommunicationLogID", string sortBy = "ASC", int userId = 0);
        Task<int> MarketingCommunicationLogInsertOrUpdateAsync(CommunicationLog communicationLog, DataTable dataTable);
        Task<CommunicationLog> GetMarketingCommunicationLogAsync(int MarketingCommunicationLogID);
    }
}
