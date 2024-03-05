using Business.Entities.Production.MachineryShutDownTxnModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineryShutDownTxn
{
    public interface MachineryShutDownTxnInterface
    {        
        Task<PagedDataTable<MachineryShutDownTxn>> GetAllMachineryShutDownTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryShutDownTxnID", string sortBy = "ASC");

        Task<MachineryShutDownTxn> GetMachineryShutDownTxnAsync(int MachineryShutDownTxnID);

        Task<int> AddOrUpdateMachineryShutDownTxn(MachineryShutDownTxn model);

    }
}
