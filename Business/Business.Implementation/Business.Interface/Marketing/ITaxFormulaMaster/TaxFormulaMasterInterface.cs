using Business.Entities.Marketing.TaxFormulaMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.ITaxFormulaMaster
{
    public interface TaxFormulaMasterInterface
    {        
        Task<PagedDataTable<TaxFormulaMaster>> GetAllTaxFormulaMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "TaxFormulaMasterID", string sortBy = "ASC");

        Task<TaxFormulaMaster> GetTaxFormulaMasterAsync(int TaxFormulaMasterID);

        Task<int> AddOrUpdateTaxFormulaMaster(TaxFormulaMaster model);

    }
}
