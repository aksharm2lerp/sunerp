using Business.Entities.Production.MachineryDepreciationTxnModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineryDepreciationTxn
{
    public interface MachineryDepreciationTxnInterface
    {        
        Task<PagedDataTable<MachineryDepreciationTxn>> GetAllMachineryDepreciationTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryDepreciationTxnID", string sortBy = "ASC");

        Task<MachineryDepreciationTxn> GetMachineryDepreciationTxnAsync(int MachineryDepreciationTxnID);

        Task<int> AddOrUpdateMachineryDepreciationTxn(MachineryDepreciationTxn model);
        Task<DataSet> MachineryDepreciationReportAsync(string searchString);
    }
}
