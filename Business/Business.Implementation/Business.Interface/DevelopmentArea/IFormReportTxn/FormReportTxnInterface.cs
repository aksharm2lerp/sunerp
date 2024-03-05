using Business.Entities.DevelopmentArea.FormReportTxnModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.DevelopmentArea.IFormReportTxn
{
    public interface FormReportTxnInterface
    {
        Task<PagedDataTable<FormReportTxn>> GetAllFormReportTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "FormReportTxnID", string sortBy = "ASC");

        Task<FormReportTxn> GetFormReportTxnAsync(int FormReportTxnID);

        Task<int> AddOrUpdateFormReportTxn(FormReportTxn model);

    }
}
