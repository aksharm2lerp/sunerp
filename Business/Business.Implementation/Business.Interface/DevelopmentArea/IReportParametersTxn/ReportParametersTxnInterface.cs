using Business.Entities.DevelopmentArea.ReportParametersTxnModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.DevelopmentArea.IReportParametersTxn
{
    public interface ReportParametersTxnInterface
    {
        Task<PagedDataTable<ReportParametersTxn>> GetAllReportParametersTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ReportParametersTxnID", string sortBy = "ASC");

        Task<ReportParametersTxn> GetReportParametersTxnAsync(int ReportParametersTxnID);

        Task<int> AddOrUpdateReportParametersTxn(ReportParametersTxn model);

    }
}
