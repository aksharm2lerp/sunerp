using Business.Entities;
using Business.Entities.Master;
using Business.Entities.User;
using Business.Entities.Department;
using Business.Entities.Designation;
using Business.SQL;
using Business.Entities.Employee;
using Business.Entities.Gender;
using Business.Entities.SecurityOfficer;
using Business.Entities.UOMID;
using Business.Entities.ItemCategory;
using Business.Entities.ContactChannelType;
using Business.Entities.VanueType;
using Business.Entities.Master.MeetingStatus;
using Business.Entities.Master.MarketingCompanyFinancialYearMaster;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Entities.Master.Package;
using Business.Entities.Master.FormType;
using Business.Entities.Master.InquiryType;
using Business.Entities.Master.EmployementType;
using Business.Entities.Master.EmployeeCategory;
using System;
using Business.Entities.SalaryFormula;
using Business.Entities.Contractor;
using Business.Entities.Master.MenuMasterM;
using Business.Entities.Admin.ProductCategoryMasterModel;
using Business.Entities.ProductPhotoPath;

namespace Business.Interface
{
    public interface IMasterService
    {
        PagedDataTable<IdentityProofTypeMetaData> GetIdentityProofTypeAsync();
        PagedDataTable<VehicleTypeMasterMetaData> GetVehicleTypeAsync();
        PagedDataTable<ZipCodeMaster> GetZipCodeAsync(string search);
        PagedDataTable<FeedbackQuestionMasterMetaData> GetFeedbackQuestions();
        PagedDataTable<IndustryTypeMaster> GetIndustryTypeMasterAsync();
        PagedDataTable<BusinessTypeMaster> GetBusinessTypeMasterAsync();
        PagedDataTable<UserRoleMaster> GetUserRoleMasterAsync();
        PagedDataTable<DepartmentGroupMaster> GetDepartmentGroupsMasterAsync();
        PagedDataTable<DepartmentMaster> GetAllDepartments();
        PagedDataTable<DesignationMaster> GetAllDesignations();
        PagedDataTable<EmployeeMaster> GetAllEmployees();
        PagedDataTable<GenderMaster> GetAllGenders();
        PagedDataTable<EmailGroupMaster> GetAllEmailGroupMaster();
        PagedDataTable<DepartmentMaster> GetDepartment(int departmentId);
        PagedDataTable<DesignationMaster> GetDesignation(int designationID);
        PagedDataTable<EmployeeMaster> GetEmployee(int employeeID);
        PagedDataTable<GenderMaster> GetGender(int genderID);
        PagedDataTable<EmailGroupMaster> GetEmailGroupMaster(int emailGroupID);
        PagedDataTable<SecurityOfficerMaster> GetAllSecurityOfficers();
        PagedDataTable<DesignationGroupMaster> GetDesignationGroupMasterAsync();
        PagedDataTable<PartyTypeMaster> GetPartyTypeMasterAsync();
        PagedDataTable<UOMIDMetadata> GetAllUOMID();
        PagedDataTable<ProductCategoryMaster> GetAllItemCategory();
        /*02-11-22*/
        PagedDataTable<ContactChannelTypeMaster> GetContactChannelMasterAsync();
        PagedDataTable<VanueTypeMaster> GetVanueTypeMasterAsync();
        /*02-11-22*/

        List<EmployeeFamilyDetail> GetMaritalStatusMaster();
        Task<PagedDataTable<DocumentTypeMaster>> GetAllDocumentTypeAsync(int pageNo = 0, int pageSize = 0, string searchString = "", string orderBy = "DocumentTypeText", string sortBy = "ASC");
        Task<PagedDataTable<BloodGroupMaster>> GetAllBloodGroupMaster(int pageNo = 0, int pageSize = 0, string searchString = "", string orderBy = "BloodGroupText", string sortBy = "ASC");

        /*11-11-2022*/
        PagedDataTable<StatusTypeMaster> GetAllMeetingStatusTypeMasterAsync();

        PagedDataTable<DurationTypeMaster> GetAllMeetingDurationTypeMasterAsync();
        /*11-11-2022*/

        /*30-11-2022*/
        PagedDataTable<FinancialYearMaster> GetAllFinancialYearMasterAsync();
        /*30-11-2022*/

        /*01-12-2022*/
        PagedDataTable<CompanyMasterMetadata> GetAllCompanyMasterAsync();
        PagedDataTable<CustomerMasterMetadata> GetAllCustomerMasterAsync();
        /*01-12-2022*/

        /*07-12-2022*/

        PagedDataTable<FormTypeMaster> GetAllFormTypeMasterAsync();
        PagedDataTable<PackageMaster> GetAllPackageMasterAsync();
        /*07-12-2022*/

        /*08-12-2022*/
        PagedDataTable<PackageMaster> GetAllPackageTypeMasterAsync();

        /*08-12-2022*/

        /*20-12-2022*/
        PagedDataTable<IndustryTypeMaster> GetAllIndustryTypeMaster();
        PagedDataTable<BusinessTypeMaster> GetAllBusinessTypeMaster();
        /*20-12-2022*/

        /*30-12-2022*/
        PagedDataTable<InquiryTypeMaster> GetAllInquiryTypeMasterAsync();

        /*30-12-2022*/

        /*03-01-2023*/
        PagedDataTable<EmploymentLocationTypeMaster> GetAllEmploymentLocationTypeMaster();
        /*PagedDataTable<EmploymentTypeMaster> GetAllEmploymentTypeMaster();*/
        

        /*03-01-2023*/

        /*03-02-2023*/
        PagedDataTable<EmploymentType> GetAllIdentityTypeMaster();
        /*03-02-2023*/

        /*07-02-2023*/
        PagedDataTable<EmploymentType> GetAllEmploymentTypeMaster();
        PagedDataTable<EmployeeCategory> GetAllEmployeeCategoryMaster();
        PagedDataTable<EmployeeMaster> GetEmployeesByName(string employeeName);
        PagedDataTable<EmployeePresentList> GetAllEmployeesTimeSheet(int Companyid, int Departmentid, DateTime? PresenceDate, string serachString, int UID);
        Task<PagedDataTable<StateMasterMetadata>> GetAllStateAsync(string search);
        /*07-02-2023*/

        /*22-02-2023*/
        PagedDataTable<SalaryHead> GetAllSalaryHead();
        PagedDataTable<SalaryTypeMaster> GetAllSalaryType();
        /*22-02-2023*/

        #region Contractor List
        /*11-03-2023*/
        PagedDataTable<ContractorMaster> GetAllContractorList();
        /*11-03-2023*/
        #endregion Contractor List

        #region
        PagedDataTable<UserMasterMetadata> GetAllUsersByCompanyId(int Companyid, int pageNo = 0, int pageSize = 0, string searchString = "", int roleBy = 0, string orderBy = "FirstName", string sortBy = "ASC");
        Task<PagedDataTable<EmployeeMaster>> EmployeeNameByDepartmentID(int departmentId);
        Task<PagedDataTable<ParentMenuM>> GetMainMenu(int id);
        Task<PagedDataTable<MenuMasterM>> MainMenu(int id);
        PagedDataTable<MenuMasterM> GetAllParentMenuListAsync();
        PagedDataTable<MenuMasterM> GetAllMenuListAsync();

        #endregion

        #region "Item Master"
        Task<PagedDataTable<ItemSubGroupMaster>> GetAllItemTypes();
        Task<PagedDataTable<ItemGroupMaster>> GetAllItemGroupTypes();
        Task<PagedDataTable<LocationMaster>> GetAllLocations();
        Task<PagedDataTable<WareHouseMaster>> GetAllWarehouse();
        Task<PagedDataTable<ProductPhotoPath>> ProductGroupDescriptionByProductGroupID(int productGroupID);
        #endregion

    }
}
