using Business.Entities.HR.MachineResourceSummaryModel;
using Business.Entities.OurProduct;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.HR.IMachineResourceSummary
{
    public interface MachineResourceSummaryInterface
    {
        Task<PagedDataTable<EmployeeDetails>> GetDetailMachineryResourceLogDetailAsync(DateTime date, int machineryid, int cardNo);
        Task<MachineResourceSummary> GetEmployeeCount(DateTime date, int shiftid, int departmentid, int machineryid);
        
    }
}
