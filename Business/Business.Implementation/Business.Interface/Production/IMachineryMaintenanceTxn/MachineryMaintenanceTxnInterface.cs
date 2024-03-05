using Business.Entities.Production.MachineryMaintenanceTxnModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineryMaintenanceTxn
{
    public interface MachineryMaintenanceTxnInterface
    {        
        Task<PagedDataTable<MachineryMaintenanceTxn>> GetAllMachineryMaintenanceTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryMaintenanceTxnID", string sortBy = "ASC");

        Task<MachineryMaintenanceTxn> GetMachineryMaintenanceTxnAsync(int MachineryMaintenanceTxnID);

        Task<int> AddOrUpdateMachineryMaintenanceTxn(MachineryMaintenanceTxn model);

    }
}
