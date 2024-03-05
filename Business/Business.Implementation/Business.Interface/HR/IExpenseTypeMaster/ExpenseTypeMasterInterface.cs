using Business.Entities.HR.ExpenseTypeMasterModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.HR.IExpenseTypeMaster
{
    public interface ExpenseTypeMasterInterface
    {        
        Task<PagedDataTable<ExpenseTypeMaster>> GetAllExpenseTypeMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ExpenseTypeMasterID", string sortBy = "ASC");

        Task<ExpenseTypeMaster> GetExpenseTypeMasterAsync(int ExpenseTypeMasterID);

        Task<int> AddOrUpdateExpenseTypeMaster(ExpenseTypeMaster model);

    }
}
