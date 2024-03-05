using Business.Entities.Employee;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.HR
{
    public interface IUserProfile
    {
        #region User Profile Basic Details
        Task<PagedDataTable<AddUpdateEmployee>> GetUserProfileBasicDetails(int id);
        #endregion User Profile Basic Details

        #region User Profile Address Details
        Task<PagedDataTable<EmployeeAddressTxn>> GetUserProfileAddressDetails(int id);
        int GetEmployeeID(int id);
        #endregion User Profile Address Details
    }
}
