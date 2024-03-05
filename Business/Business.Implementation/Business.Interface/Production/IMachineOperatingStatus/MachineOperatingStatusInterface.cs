using Business.Entities.Production.MachineOperatingStatusModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineOperatingStatus
{
    public interface MachineOperatingStatusInterface
    {        
        Task<PagedDataTable<MachineOperatingStatus>> GetAllMachineOperatingStatusAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineOperatingStatusID", string sortBy = "ASC");

        Task<MachineOperatingStatus> GetMachineOperatingStatusAsync(int MachineOperatingStatusID);

        Task<int> AddOrUpdateMachineOperatingStatus(MachineOperatingStatus model);

    }
}
