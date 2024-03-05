using Business.Entities.DevelopmentArea.ReportMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.DevelopmentArea.IReportMaster
{
    public interface ReportMasterInterface
    {
        Task<PagedDataTable<ReportMaster>> GetAllReportMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ReportMasterID", string sortBy = "ASC");

        Task<ReportMaster> GetReportMasterAsync(int ReportMasterID);

        Task<int> AddOrUpdateReportMaster(ReportMaster model);

    }
}
