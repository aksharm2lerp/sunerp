using Business.Entities.Production.MachineryPurchaseDetailModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachineryPurchaseDetail
{
    public interface MachineryPurchaseDetailInterface
    {        
        Task<PagedDataTable<MachineryPurchaseDetail>> GetAllMachineryPurchaseDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachineryPurchaseDetailID", string sortBy = "ASC");

        Task<MachineryPurchaseDetail> GetMachineryPurchaseDetailAsync(int MachineryPurchaseDetailID);

        Task<int> AddOrUpdateMachineryPurchaseDetail(MachineryPurchaseDetail model);

    }
}
