using Business.Entities.Employee.EmploymentType;
using Business.Entities.Marketing.QuotationMasterModel;
using Business.Entities.Marketing.TravellingExpenseDetailModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.ITravellingExpenseDetail
{
    public interface TravellingExpenseDetailInterface
    {        
        Task<PagedDataTable<TravellingExpenseDetail>> GetAllTravellingExpenseDetailAsyncOld(int pageNo, int pageSize, string searchString = "", string orderBy = "TravellingExpenseDetailID", string sortBy = "ASC");
        Task<TravellingExpenseDetail> GetTravellingExpenseDetailAsync(int TravellingExpenseDetailID);
        Task<int> AddOrUpdateTravellingExpenseDetail(TravellingExpenseDetail model, DataTable dataTable);
        Task<TravellingExpenseDetail> GetAllTravellingExpenseDetailAsync(int userid);
        Task<TravellingExpenseStatus> TravellingExpenseStatus(int TEDID);
        Task<int> AddTravellingExpenseStatus(TravellingExpenseStatus model);

    }
}
