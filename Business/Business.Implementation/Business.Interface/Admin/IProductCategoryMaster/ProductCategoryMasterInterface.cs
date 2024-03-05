using Business.Entities.Admin.ProductCategoryMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IProductCategoryMasterService
{
    public interface ProductCategoryMasterInterface
    {        
        Task<PagedDataTable<ProductCategoryMaster>> GetAllProductCategoryMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ProductCategoryMasterID", string sortBy = "ASC");

        Task<ProductCategoryMaster> GetProductCategoryMasterAsync(int ProductCategoryMasterID);

        Task<int> AddOrUpdateProductCategoryMaster(ProductCategoryMaster model);

    }
}
