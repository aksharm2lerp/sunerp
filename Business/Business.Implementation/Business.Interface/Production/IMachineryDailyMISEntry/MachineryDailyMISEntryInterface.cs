using Business.Entities.Production.MachineryDailyMISEntryModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineryDailyMISEntry
{
    public interface MachineryDailyMISEntryInterface
    {        
        Task<PagedDataTable<MachineryDailyMISEntry>> GetAllMachineryDailyMISEntryAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryDailyMISEntryID", string sortBy = "ASC");

        Task<MachineryDailyMISEntry> GetMachineryDailyMISEntryAsync(int MachineryDailyMISEntryID);

        Task<int> AddOrUpdateMachineryDailyMISEntry(MachineryDailyMISEntry model, DataTable dataTable);

    }
}
