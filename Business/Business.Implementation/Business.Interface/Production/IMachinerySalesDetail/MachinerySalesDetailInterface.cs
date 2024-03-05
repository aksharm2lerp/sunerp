using Business.Entities.Production.MachinerySalesDetailModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Production.IMachinerySalesDetail
{
    public interface MachinerySalesDetailInterface
    {        
        Task<PagedDataTable<MachinerySalesDetail>> GetAllMachinerySalesDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MachinerySalesDetailID", string sortBy = "ASC");

        Task<MachinerySalesDetail> GetMachinerySalesDetailAsync(int MachinerySalesDetailID);

        Task<int> AddOrUpdateMachinerySalesDetail(MachinerySalesDetail model);

    }
}
