using Business.Entities.EmployeeAdvances;
using Business.Entities.OtherDeductionModel;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.IOtherDeductionService
{
    public interface IOtherDeductionService
    {
        #region Index Page
        Task<PagedDataTable<OtherDeduction>> GetAllOtherDeductionAsync(int pageNo = 1, int pageSize = 20, string searchString = "", string orderBy = "SrNo", string sortBy = "ASC");
        #endregion Index Page

        #region Slider Page
        Task<OtherDeduction> GetOtherDeductionAsync(int employeeAdvancesID);
        #endregion Slider Page

        #region Add Or Updater
        Task<int> AddOrUpdateOtherDeductionAsync(OtherDeduction model);
        #endregion Add Or Updater


    }
}
