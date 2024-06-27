using Business.Entities.Admin.TicketManagementStatusMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Admin.ITicketManagementStatusMaster
{
    public interface TicketManagementStatusMasterInterface
    {        
        Task<PagedDataTable<TicketManagementStatusMaster>> GetAllTicketManagementStatusMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "TicketManagementStatusMasterID", string sortBy = "ASC");

        Task<TicketManagementStatusMaster> GetTicketManagementStatusMasterAsync(int TicketManagementStatusMasterID);

        Task<int> AddOrUpdateTicketManagementStatusMaster(TicketManagementStatusMaster model);

    }
}
