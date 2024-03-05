using Business.Entities.HR.MachineryResourceAllocationModel;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.HR.IMachineryResourceAllocation
{
    public interface MachineryResourceAllocationInterface
    {        
        Task<PagedDataTable<MachineryResourceAllocation>> GetAllMachineryResourceAllocationAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryResourceAllocationID", string sortBy = "ASC");

        Task<MachineryResourceAllocation> GetMachineryResourceAllocationAsync(int MachineryResourceAllocationID);

        Task<int> AddOrUpdateMachineryResourceAllocation(MachineryResourceAllocation model);

        Task<List<DailyMachineryResourceLog>> GetDailyMachineryResourceLogAsync(DateTime? todayDate, int shiftId, int departmentId, int machineryId);

        Task<int> AddUpdateMachineryResourceLogAsync(DailyMachineryResourceTxn dailyMachineryResourceTxn, DataTable dataTable);
    }
}
