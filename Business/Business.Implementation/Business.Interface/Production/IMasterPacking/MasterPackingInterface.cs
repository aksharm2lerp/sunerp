using Business.Entities.Production.MasterPackingModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMasterPacking
{
    public interface MasterPackingInterface
    {
        Task<PagedDataTable<MasterPacking>> GetAllMasterPackingAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MasterPackingID", string sortBy = "ASC");
        Task<PagedDataTable<MasterPacking>> GetMultiplePrintMasterPackingAsync(string MasterPackingID, int userId);
        Task<(MasterPacking, PagedDataTable<ScannedItemDetail>)> GetMasterPackingAsync(int MasterPackingID);
        Task<int> AddOrUpdateMasterPacking(MasterPacking model, DataTable dataTable);
        Task<ScannedItemDetail> GetScannedItemDetailAsync(string scannedQrCode);
        Task<MasterPacking> GetMasterPackingCodeReturnAsync(int userId);
    }
}
