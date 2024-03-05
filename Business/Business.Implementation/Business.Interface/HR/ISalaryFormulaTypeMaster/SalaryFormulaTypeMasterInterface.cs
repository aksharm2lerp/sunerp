using Business.Entities.HR.SalaryFormulaTypeMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.HR.ISalaryFormulaTypeMaster
{
    public interface SalaryFormulaTypeMasterInterface
    {        
        Task<PagedDataTable<SalaryFormulaTypeMaster>> GetAllSalaryFormulaTypeMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "SalaryFormulaTypeMasterID", string sortBy = "ASC");

        Task<SalaryFormulaTypeMaster> GetSalaryFormulaTypeMasterAsync(int SalaryFormulaTypeMasterID);

        Task<int> AddOrUpdateSalaryFormulaTypeMaster(SalaryFormulaTypeMaster model);

    }
}
