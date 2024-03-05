using Business.Entities.Production.MachineryOperationDetailModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineryOperationDetail
{
    public interface MachineryOperationDetailInterface
    {        
        Task<PagedDataTable<MachineryOperationDetail>> GetAllMachineryOperationDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryOperationDetailID", string sortBy = "ASC");

        Task<MachineryOperationDetail> GetMachineryOperationDetailAsync(int MachineryOperationDetailID);

        Task<int> AddOrUpdateMachineryOperationDetail(MachineryOperationDetail model, DataTable dataTable);

    }
}
