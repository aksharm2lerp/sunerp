using Business.Entities.DevelopmentArea.FormDatabaseTableModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.DevelopmentArea.IFormDatabaseTable
{
    public interface FormDatabaseTableInterface
    {
        Task<PagedDataTable<FormDatabaseTable>> GetAllFormDatabaseTableAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "FormDatabaseTableID", string sortBy = "ASC");

        Task<FormDatabaseTable> GetFormDatabaseTableAsync(int FormDatabaseTableID);

        Task<int> AddOrUpdateFormDatabaseTable(FormDatabaseTable model);

    }
}
