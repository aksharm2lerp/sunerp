using Business.Entities.Department;
using Business.Entities.Designation;
using Business.Entities.Employee;
using Business.Entities.ItemCategory;
using Business.Entities.Master.MarketingCompanyFinancialYearMaster;
using Business.Entities.Master;
using Business;
using Business.Entities.UOMID;
using Business.Entities;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities.PartyMasterModel;
using Business.Entities.Marketing.RequestForQuotTypeMasterModel;
using Business.Entities.HR.MachineryResourceAllocationModel;
using Business.Entities.Marketing.QuotationApprovalStatusModel;
using Business.Entities.Marketing.SAPItem;
using Business.Entities.Admin.ProductCategoryMasterModel;
//$AddUsing$

namespace Business.Interface
{
    public interface ICommonMasterService
    {
        Task<PagedDataTable<ZipCodeMaster>> GetZipCodeAsync(string search);


        Task<PagedDataTable<DepartmentMaster>> GetAllDepartmentAsync();
        Task<PagedDataTable<DesignationMaster>> GetAllDesignationAsync();

        Task<PagedDataTable<EmployeeMaster>> GetAllEmployeeAsync();
        Task<PagedDataTable<EmployeeMaster>> GetAllEmployeeByUserandCompanyAsync(int? userid, int? companyid);
        Task<PagedDataTable<EmployeeMaster>> GetAllEmployeeByDepartmentAsync(int? departmentid);
        Task<PagedDataTable<UOMIDMetadata>> GetAllUOMAsync();
        Task<PagedDataTable<ProductCategoryMaster>> GetAllItemCategoryAsync();
        Task<PagedDataTable<FinancialYearMaster>> GetAllFinancialYearAsync();
        Task<PagedDataTable<CompanyMasterMetadata>> GetAllCompanyAsync();
        Task<PagedDataTable<CustomerMasterMetadata>> GetAllCustomerAsync();
        Task<PagedDataTable<StateMasterMetadata>> GetAllStateAsync();
        Task<PagedDataTable<CityMasterModelDropdown>> GetAllCityAsync();

        Task<PagedDataTable<AddressMasterModelDropdown>> GetAllAddressAsync();

        Task<PagedDataTable<RoleMasterModelDropdown>> GetAllRoleAsync();

        Task<PagedDataTable<ExpenseTypeMasterModelDropdown>> GetAllExpenseTypeAsync();

        Task<PagedDataTable<ItemGroupMasterModelDropdown>> GetAllItemGroupAsync();

        Task<PagedDataTable<MachineOperatingStatusMasterModelDropdown>> GetAllMachineOperatingStatusAsync();

        Task<PagedDataTable<ItemSubGroupMasterModelDropdown>> GetAllItemSubGroupAsync(int itemGroupID);
        Task<PagedDataTable<MachineCategoryMasterModelDropdown>> GetAllMachineCategoryAsync();

        Task<PagedDataTable<MachineryMasterModelDropdown>> GetAllMachineryAsync();

        Task<PagedDataTable<DepreciationMethodMasterModelDropdown>> GetAllDepreciationMethodAsync();

        Task<PagedDataTable<UtilityMasterModelDropdown>> GetAllUtilityAsync();
        Task<PagedDataTable<ShiftMasterModelDropdown>> GetAllShiftAsync();
        Task<PagedDataTable<ItemMasterModelDropdown>> GetAllItemAsync();

        Task<PagedDataTable<ReportMasterModelDropdown>> GetAllReportAsync();

        Task<PagedDataTable<FormMasterModelDropdown>> GetAllFormAsync();
        Task<PagedDataTable<SAPItemModelDropdown>> GetAllSAPItemAsyncByItemGroup(string itemGroupName);

        Task<PagedDataTable<AddressTypeMasterModelDropdown>> GetAllAddressTypeAsync();
        Task<PagedDataTable<SalaryFormulaTypeMasterDropdown>> GetAllSalaryFormulaTypeMasterAsync();
        Task<PagedDataTable<DatabaseTables>> GetAllDatabaseTablesAsync();
        Task<PagedDataTable<DatabaseTableColumns>> GetAllDatabaseTableColumnsAsync(string objectID);
        Task<PagedDataTable<EmployeeMaster>> GetAllAvailableEmployeesForMachineryAsync(DateTime? todayDate);

        Task<PagedDataTable<LocationMasterModelDropdown>> GetAllLocationAsync();
        Task<PagedDataTable<PartyMaster>> GetAllPartyAsync();
        Task<PagedDataTable<EmployeeMaster>> GetAllEmployeesAccordingToDesignation(string WorkType);
        Task<PagedDataTable<RequestForQuotTypeMaster>> GetAllRequestForQuotTypeAsync();

        Task<PagedDataTable<MachineryResourceAllocation>> MachineNameByDepartmentID(int departmentId);
        Task<PagedDataTable<QuotationApprovalStatus>> GetAllQuotationApprovalStatusAsync();
        Task<PagedDataTable<SAPItemSearchKeywordLog>> GetAllMostUsedSAPItemSearchKeywordAsync();
         


        //$AddICommonMasterServiceMethod$

    }
}
