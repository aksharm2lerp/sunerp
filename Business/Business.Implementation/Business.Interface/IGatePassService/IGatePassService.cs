using Business.Entities.EmployeeGatepass;
using Business.SQL;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.IGatePassService
{
    public interface IGatePassService
    {
        Task<int> AddRemoveApprovalAsync(int employeeGatepassId, bool isApproved, string approvalName, int UID);
        Task<int> AddUpdateEmployeeGatePassAsync(EmployeeGatePass employeeGatePass);
        Task<PagedDataTable<EmployeeGatePass>> GetAllEmployeeGatePassAsync(int pageNo = 1, int pageSize = 20, string searchString = "", string orderBy = "EmployeeID", string sortBy = "ASC");
        Task<EmployeeGatePass> GetEmployeeGatePassAsync(int employeeId, int employeeGatePassID);
        Task<DataTable> GetEmployeeGatePassAsyncForPrint(int employeeGatePassID);
        Task<int> UpdateGatePassInOutTimeAsync(int employeeGatepassId, bool isChecked, DateTime? inTime, DateTime? outTime, int UID);
    }
}