using Business.Entities.DevelopmentArea.DynamicFormM;
using Business.SQL;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.DevelopmentArea.IDynamicFormService
{
    public interface IDynamicFormService
    {
        Task<bool> AddUpdateTable(DataTable dataTable, string tableDescription, string userName);
        Task<string> GenerateModelProperties(string tableName);
        PagedDataTable<DatabaseTable> GetAllDatabaseTables();
        PagedDataTable<DataTypeMaster> GetAllDataTypes();
        Task<DataTable> GetDataTableStructure(string tableName);
        Task<List<string>> GetSqlParams(string tableName);
    }
}
