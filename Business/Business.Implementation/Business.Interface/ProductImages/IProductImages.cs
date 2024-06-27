using Business.Entities.Employee.EmploymentType;
using Business.Entities.ProductPhotoPath;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.ProductImages
{
    public interface IProductImages
    {
        Task<PagedDataTable<ProductPhotoPath>> GetImagePath();
        Task<ProductPhotoPath> IndexProductDisplay();
        Task<int> AddOrEditProductImages(ProductPhotoPath productPhotoPath, DataTable dataTable);
        Task<int> UpdateProductPhoto(ProductPhotoPath productPhotoPath);

        Task<ProductPhotoPath> GetProductImageDetailAsync(int ProductImageID);
        //public Task<ProductPhotoPath> GetImagePath();
    }
}
