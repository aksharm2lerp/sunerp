using Business.Entities.Production.ItemQRCodeDetailModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IItemQRCodeDetail
{
    public interface ItemQRCodeDetailInterface
    {        
        Task<PagedDataTable<ItemQRCodeDetail>> GetAllItemQRCodeDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ItemQRCodeDetailID", string sortBy = "ASC");

        Task<ItemQRCodeDetail> GetItemQRCodeDetailAsync(int ItemQRCodeDetailID);

        Task<int> AddOrUpdateItemQRCodeDetail(ItemQRCodeDetail model);

    }
}
