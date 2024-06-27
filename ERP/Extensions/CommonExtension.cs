using Business.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Business.Interface.SalesDistribution.ISalesOrderMaster;
using System.Data;

namespace ERP.Extensions
{
    public class CommonExtension
    {
        private static HttpContext Current => new HttpContextAccessor().HttpContext;
        public static ICommonMasterService _commonmasterService => (ICommonMasterService)Current.RequestServices.GetService(typeof(ICommonMasterService));
        public static IMasterService _masterService => (IMasterService)Current.RequestServices.GetService(typeof(IMasterService));
        public static SalesOrderMasterInterface _salesOrderMasterInterface => (SalesOrderMasterInterface)Current.RequestServices.GetService(typeof(SalesOrderMasterInterface));

        #region GetZipCodeAsync
        public static SelectList GetZipCodeAsync(string SearchString)
        {
            try
            {
                var listZipcode = _commonmasterService.GetZipCodeAsync(SearchString).Result;
                return new SelectList(listZipcode, "ZipCodeID", "BaseAddress");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetZipCodeAsync

        #region GetAllDepartmentAsync
        public static SelectList GetAllDepartmentAsync()
        {
            try
            {
                var listDepartment = _commonmasterService.GetAllDepartmentAsync().Result;
                return new SelectList(listDepartment, "DepartmentID", "DepartmentName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllDepartmentAsync

        #region GetAllDesignationAsync
        public static SelectList GetAllDesignationAsync()
        {
            try
            {
                var listDesignation = _commonmasterService.GetAllDesignationAsync().Result;
                return new SelectList(listDesignation, "DesignationID", "DesignationText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllDesignationAsync

        #region GetAllEmployeeAsync
        public static SelectList GetAllEmployeeAsync()
        {
            try
            {
                var listEmployees = _commonmasterService.GetAllEmployeeAsync().Result;
                return new SelectList(listEmployees, "EmployeeID", "EmployeeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllEmployeeAsync

        #region GetAllEmployeeByUserandCompanyAsync - Employee Dropdown List filter by UserID and Company

        public static SelectList GetAllEmployeeByUserAndCompanyAsync(int? userid, int? companyid)
        {
            try
            {
                var employeeList = _commonmasterService.GetAllEmployeeByUserandCompanyAsync(userid, companyid).Result;
                return new SelectList(employeeList, "EmployeeID", "EmployeeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllEmployeeByUserandCompanyAsync - Employee Dropdown List

        #region GetAllEmployeeByDepartmentAsync - Employee Dropdown List filter by Department

        public static SelectList GetAllEmployeeByDepartmentAsync(int? departmentid)
        {
            try
            {
                var DeptemployeeList = _commonmasterService.GetAllEmployeeByDepartmentAsync(departmentid).Result;
                return new SelectList(DeptemployeeList, "EmployeeID", "EmployeeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllEmployeeByDepartmentAsync - Employee Dropdown List

        #region GetAllUOMAsync - Unit od Mesuarement Dropdown List  

        public static SelectList GetAllUOMAsync()
        {
            try
            {
                var UOMList = _commonmasterService.GetAllUOMAsync().Result;
                return new SelectList(UOMList, "UOMID", "UOMText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllUOMAsync - Unit od Mesuarement Dropdown List  

        #region GetAllItemCategoryAsync - Item Category Dropdown List  

        public static SelectList GetAllItemCategoryAsync()
        {
            try
            {
                var itemCategoryList = _commonmasterService.GetAllItemCategoryAsync().Result;
                return new SelectList(itemCategoryList, "ProductCategoryID", "ProductCategoryText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllItemCategoryAsync - Item Category Dropdown List  

        #region GetAllFinancialYearAsync - Financial Year Dropdown List  

        public static SelectList GetAllFinancialYearAsync()
        {
            try
            {
                var FYList = _commonmasterService.GetAllFinancialYearAsync().Result;
                return new SelectList(FYList, "FinancialYearID", "FinYearDesc");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllFinancialYearAsync - Financial Year Dropdown List  

        #region GetAllCompanyAsync - Company List for dropdown list

        public static SelectList GetAllCompanyAsync()
        {
            try
            {
                var companyList = _commonmasterService.GetAllCompanyAsync().Result;
                return new SelectList(companyList, "CompanyID", "CompanyName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllCompanyAsync - Company List for dropdown list

        #region GetAllCustomerAsync - Customer List for dropdown list

        public static SelectList GetAllCustomerAsync()
        {
            try
            {
                var customerList = _commonmasterService.GetAllCustomerAsync().Result;
                return new SelectList(customerList, "CustomerID", "CustomerName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllCustomerAsync - Customer List for dropdown list

        #region GetAllPartyAsync - Party List for dropdown list

        public static SelectList GetAllPartyAsync()
        {
            try
            {
                var PartyList = _commonmasterService.GetAllPartyAsync().Result;
                return new SelectList(PartyList, "PartyID", "PartyName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllPartyAsync - Party List for dropdown list


        #region GetAllStateAsync - State List for dropdown list

        public static SelectList GetAllStateAsync()
        {
            try
            {
                var StateList = _commonmasterService.GetAllStateAsync().Result;
                return new SelectList(StateList, "StateID", "StateName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllStateAsync - State List for dropdown list



        #region GetAllCityAsync - City List for dropdown list

        public static SelectList GetAllCityAsync()
        {
            try
            {
                var CityList = _commonmasterService.GetAllCityAsync().Result;
                return new SelectList(CityList, "CityID", "CityName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllCityAsync -  City List for dropdown list;


        #region GetAllAddressAsync - Address List for dropdown list

        public static SelectList GetAllAddressAsync()
        {
            try
            {
                var AddressList = _commonmasterService.GetAllAddressAsync().Result;
                return new SelectList(AddressList, "AddressID", "AddressName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllAddressAsync -  Address List for dropdown list;


        #region GetAllRoleAsync - Role List for dropdown list

        public static SelectList GetAllRoleAsync()
        {
            try
            {
                var RoleList = _commonmasterService.GetAllRoleAsync().Result;
                return new SelectList(RoleList, "RoleID", "RoleName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllRoleAsync -  Role List for dropdown list;


        #region GetAllExpenseTypeAsync - ExpenseType List for dropdown list

        public static SelectList GetAllExpenseTypeAsync()
        {
            try
            {
                var ExpenseTypeList = _commonmasterService.GetAllExpenseTypeAsync().Result;
                return new SelectList(ExpenseTypeList, "ExpenseTypeID", "ExpenseTypeText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllExpenseTypeAsync -  ExpenseType List for dropdown list;


        #region GetAllItemGroupAsync - ItemGroup List for dropdown list

        public static SelectList GetAllItemGroupAsync()
        {
            try
            {
                var ItemGroupList = _commonmasterService.GetAllItemGroupAsync().Result;
                return new SelectList(ItemGroupList, "ItemGroupID", "ItemGroupName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllItemGroupAsync -  ItemGroup List for dropdown list;

        #region GetAllItemSubGroupAsync - ItemSubGroup List for dropdown list

        public static SelectList GetAllItemSubGroupAsync(int itemGroupID)
        {
            try
            {
                var ItemSubGroupList = _commonmasterService.GetAllItemSubGroupAsync(itemGroupID).Result;
                return new SelectList(ItemSubGroupList, "ItemSubGroupID", "ItemSubGroupText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllItemSubGroupAsync -  ItemSubGroup List for dropdown list; 

        #region GetAllMachineOperatingStatusAsync - MachineOperatingStatus List for dropdown list

        public static SelectList GetAllMachineOperatingStatusAsync()
        {
            try
            {
                var MachineOperatingStatusList = _commonmasterService.GetAllMachineOperatingStatusAsync().Result;
                return new SelectList(MachineOperatingStatusList, "MachineOperatingStatusID", "MachineOperatingStatusText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllMachineOperatingStatusAsync -  MachineOperatingStatus List for dropdown list;

        #region GetAllMachineCategoryAsync - MachineCategory List for dropdown list

        public static SelectList GetAllMachineCategoryAsync()
        {
            try
            {
                var MachineCategoryList = _commonmasterService.GetAllMachineCategoryAsync().Result;
                return new SelectList(MachineCategoryList, "MachineCategoryID", "MachineCategoryName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllMachineCategoryAsync -  MachineCategory List for dropdown list;




        #region GetAllMachineryAsync - Machinery List for dropdown list

        public static SelectList GetAllMachineryAsync()
        {
            try
            {
                var MachineryList = _commonmasterService.GetAllMachineryAsync().Result;
                return new SelectList(MachineryList, "MachineryID", "MachineryName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllMachineryAsync -  Machinery List for dropdown list;


        #region GetAllDepreciationMethodAsync - DepreciationMethod List for dropdown list

        public static SelectList GetAllDepreciationMethodAsync()
        {
            try
            {
                var DepreciationMethodList = _commonmasterService.GetAllDepreciationMethodAsync().Result;
                return new SelectList(DepreciationMethodList, "DepreciationMethodID", "MethodName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllDepreciationMethodAsync -  DepreciationMethod List for dropdown list;


        #region GetAllUtilityAsync - Utility List for dropdown list

        public static SelectList GetAllUtilityAsync()
        {
            try
            {
                var UtilityList = _commonmasterService.GetAllUtilityAsync().Result;
                return new SelectList(UtilityList, "UtilityID", "UtilityName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllUtilityAsync -  Utility List for dropdown list;

        #region GetAllShiftAsync - Shift List for dropdown list

        public static SelectList GetAllShiftAsync()
        {
            try
            {
                var ShiftList = _commonmasterService.GetAllShiftAsync().Result;
                return new SelectList(ShiftList, "ShiftID", "ShiftName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllShiftAsync -  Shift List for dropdown list;

        #region GetAllItemAsync - Item List for dropdown list

        public static SelectList GetAllItemAsync()
        {
            try
            {
                var ItemList = _commonmasterService.GetAllItemAsync().Result;
                return new SelectList(ItemList, "ItemID", "ItemName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllItemAsync -  Item List for dropdown list;

        #region GetAllLocations - Location List for dropdown list
        public static SelectList GetAllLocations()
        {
            try
            {
                var itemLocation = _masterService.GetAllLocations().Result;
                return new SelectList(itemLocation, "LocationID", "LocationName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllLocations -  Location List for dropdown list;

        #region GetAllReportAsync - Report List for dropdown list

        public static SelectList GetAllReportAsync()
        {
            try
            {
                var ReportList = _commonmasterService.GetAllReportAsync().Result;
                return new SelectList(ReportList, "ReportID", "ReportName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllReportAsync -  Report List for dropdown list;


        #region GetAllFormAsync - Form List for dropdown list

        public static SelectList GetAllFormAsync()
        {
            try
            {
                var FormList = _commonmasterService.GetAllFormAsync().Result;
                return new SelectList(FormList, "FormID", "FormName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllFormAsync -  Form List for dropdown list;

        #region GetAllSAPItemAsyncByItemGroup - Item List By Group Name for dropdown list

        public static SelectList GetAllSAPItemAsyncByItemGroup(string itemGroupName)
        {
            try
            {
                var ItemList = _commonmasterService.GetAllSAPItemAsyncByItemGroup(itemGroupName).Result;
                return new SelectList(ItemList, "ItemCode", "FinishGoodName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllSAPItemAsyncByItemGroup - Item List By Group Name for dropdown list


        #region GetAllAddressTypeAsync - AddressType List for dropdown list

        public static SelectList GetAllAddressTypeAsync()
        {
            try
            {
                var AddressTypeList = _commonmasterService.GetAllAddressTypeAsync().Result;
                return new SelectList(AddressTypeList, "AddressTypeID", "AddressTypeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllAddressTypeAsync -  AddressType List for dropdown list;


        #region GetAllSalaryFormulaTypeMaster - Salary Formula Type Master List for dropdown list
        public static SelectList GetAllSalaryFormulaTypeMaster()
        {
            try
            {
                var itemLocation = _commonmasterService.GetAllSalaryFormulaTypeMasterAsync().Result;
                return new SelectList(itemLocation, "SalaryFormulaTypeID", "SalaryFormulaTypeText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllSalaryFormulaTypeMaster - Salary Formula Type Master List for dropdown list


        #region GetDatabaseTable List  
        public static SelectList GetAllDatabaseTablesAsync()
        {
            try
            {
                var itemLocation = _commonmasterService.GetAllDatabaseTablesAsync().Result;
                return new SelectList(itemLocation, "TableName", "TableName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetDatabaseTable List  

        #region GetDatabaseTable List  
        public static SelectList GetAllDatabaseTableColumnsAsync(string ObjectID)
        {
            try
            {
                var itemLocation = _commonmasterService.GetAllDatabaseTableColumnsAsync(ObjectID).Result;
                return new SelectList(itemLocation, "Column_Name", "Column_Name");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetDatabaseTable List  

        #region GetAllAvailableEmployeesForMachineryAsync - Available Employee List for machinery for dropdown list

        public static SelectList GetAllAvailableEmployeesForMachineryAsync(DateTime? todayDate)
        {
            try
            {
                var listEmployees = _commonmasterService.GetAllAvailableEmployeesForMachineryAsync(todayDate).Result;
                return new SelectList(listEmployees, "EmployeeID", "EmployeeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllAvailableEmployeesForMachineryAsync - Employee List by present date for dropdown list


        #region GetAllLocationAsync - Location List for dropdown list

        public static SelectList GetAllLocationAsync()
        {
            try
            {
                var LocationList = _commonmasterService.GetAllLocationAsync().Result;
                return new SelectList(LocationList, "LocationID", "LocationName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllLocationAsync -  Location List for dropdown list;

        #region GetAllEmployeesAccordingToDesignation
        public static SelectList GetAllEmployeesAccordingToDesignation(string WorkType)
        {
            try
            {
                var listEmployees = _commonmasterService.GetAllEmployeesAccordingToDesignation(WorkType).Result;
                return new SelectList(listEmployees, "EmployeeID", "EmployeeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllEmployeesAccordingToDesignation

        #region GetAllRequestForQuotTypeAsync - RequestForQuotType List for dropdown list

        public static SelectList GetAllRequestForQuotTypeAsync()
        {
            try
            {
                var RequestForQuotTypeList = _commonmasterService.GetAllRequestForQuotTypeAsync().Result;
                return new SelectList(RequestForQuotTypeList, "RequestForQuotTypeID", "RequestForQuotTypeText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllRequestForQuotTypeAsync -  RequestForQuotType List for dropdown list;

        #region GetAllQuotationApprovalStatusAsync - Quotation Approval Status Dropdown List  

        public static SelectList GetAllQuotationApprovalStatusAsync(string useFor)
        {
            try
            {
                var FYList = _commonmasterService.GetAllQuotationApprovalStatusAsync(useFor).Result;
                return new SelectList(FYList, "QuotationApprovalStatusID", "QuotationApprovalStatusName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllQuotationApprovalStatusAsync - Financial Year Dropdown List

        #region GetAllMostUsedSAPItemSearchKeywordAsync - Displayed in List  

        public static SelectList GetAllMostUsedSAPItemSearchKeywordAsync()
        {
            try
            {
                var FYList = _commonmasterService.GetAllMostUsedSAPItemSearchKeywordAsync().Result;
                return new SelectList(FYList, "MostUsedSAPItemSearchKeywordID", "MostUsedSAPItemSearchKeywordName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllMostUsedSAPItemSearchKeywordAsync - Displayed in List  


        #region GetAllTermTypeAsync - TermType List for dropdown list

        public static SelectList GetAllTermTypeAsync()
        {
            try
            {
                var TermTypeList = _commonmasterService.GetAllTermTypeAsync().Result;
                return new SelectList(TermTypeList, "TermTypeID", "TermTypeText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllTermTypeAsync -  TermType List for dropdown list;

        #region GetAllEmployeeAsync For select reference in SalesOrder page
        public static SelectList GetAllEmployeeAsyncForReferenceDropDown()
        {
            try
            {
                var listEmployees = _commonmasterService.GetAllEmployeeAsync(19).Result;
                return new SelectList(listEmployees, "EmployeeID", "EmployeeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllEmployeeAsync For select reference in SalesOrder page



        #region Get formula for calculate taxes and amounts(GetFormulaMasterByCustomerID)
        public static DataTable GetFormulaMasterByCustomerID(int? customerId)
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (customerId > 0)
                    dataTable = _salesOrderMasterInterface.GetFormulaByCustomerIdAsync(customerId).Result;

                if (dataTable.Rows.Count > 0)
                    return dataTable;
                else return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Get formula for calculate taxes and amounts(GetFormulaMasterByCustomerID)

        #region GetAllTermsMasterAsync - TermType List for dropdown list

        public static SelectList GetAllTermsMasterAsync(string term)
        {
            try
            {
                var TermTypeList = _commonmasterService.GetAllTermsMasterAsync(term).Result;
                return new SelectList(TermTypeList, "TermsID", "TermText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion  GetAllTermsMasterAsync -  TermType List for dropdown list;


        #region Get formula for calculate taxes and amounts(GetFormulaMasterByCustomerID)
        public static DataTable GetFormulaMasterForQuotationByPartyID(int? partyId, int? quotationId)
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (partyId > 0)
                    dataTable = _commonmasterService.GetFormulaMasterForQuotationByPartyIDAsync(partyId, quotationId).Result;

                if (dataTable.Rows.Count > 0)
                    return dataTable;
                else return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion Get formula for calculate taxes and amounts(GetFormulaMasterByCustomerID)

        //$AddCommonExtensionMethod$




    }
}
