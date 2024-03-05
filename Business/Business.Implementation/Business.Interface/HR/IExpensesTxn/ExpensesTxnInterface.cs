using Business.Entities.HR.ExpensesTxnModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.HR.IExpensesTxn
{
    public interface ExpensesTxnInterface
    {        
        Task<PagedDataTable<ExpensesTxn>> GetAllExpensesTxnAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "ExpensesTxnID", string sortBy = "ASC");

        Task<ExpensesTxn> GetExpensesTxnAsync(int ExpensesTxnID);

        Task<int> AddOrUpdateExpensesTxn(ExpensesTxn model);

    }
}
