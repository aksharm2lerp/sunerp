using Business.Entities;
using Business.Entities.ContactChannelType;
using Business.Entities.Contractor;
using Business.Entities.Department;
using Business.Entities.Designation;
using Business.Entities.Employee;
using Business.Entities.Gender;
using Business.Entities.ItemCategory;
using Business.Entities.Master;
using Business.Entities.Master.EmployeeCategory;
using Business.Entities.Master.EmployementType;
using Business.Entities.Master.FormType;
using Business.Entities.Master.InquiryType;
using Business.Entities.Master.MarketingCompanyFinancialYearMaster;
using Business.Entities.Master.MeetingStatus;
using Business.Entities.Master.MenuMasterM;
using Business.Entities.Master.Package;
using Business.Entities.SalaryFormula;
using Business.Entities.PartyMasterModel;
using Business.Entities.UOMID;
using Business.Entities.User;
using Business.Entities.VanueType;
using Business.Interface;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Business.Entities.Marketing.RequestForQuotTypeMasterModel;
using Business.Entities.HR.MachineryResourceAllocationModel;
//$AddUsing$

namespace Business.Service
{
    public class CommonMasterService : ICommonMasterService
    {
        private IConfiguration _config { get; set; }

        private string connection = string.Empty;
        public CommonMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }


        public async Task<PagedDataTable<ZipCodeMaster>> GetZipCodeAsync(string search)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ZipCodeMaster> lst = new PagedDataTable<ZipCodeMaster>();
            try
            {
                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", search) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ZipCodeMasterForVisitorAddress", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<ZipCodeMaster>
                           (1, 20, totalItemCount, null, "ZipCode", "ASC");
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<DepartmentMaster>> GetAllDepartmentAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DepartmentMaster> lst = new PagedDataTable<DepartmentMaster>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_DepartmentMaster", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }



                        lst = table.ToPagedDataTableList<DepartmentMaster>();
                    }
                    return lst;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }

        }

        public async Task<PagedDataTable<DesignationMaster>> GetAllDesignationAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DesignationMaster> lst = new PagedDataTable<DesignationMaster>();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PageNo", 1),
                    new SqlParameter("@PageSize", "0"),
                };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_DesignationMaster", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<DesignationMaster>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<EmployeeMaster>> GetAllEmployeeAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeMaster> lst = new PagedDataTable<EmployeeMaster>();
            try
            {
                // SqlParameter[] param = {
                //         new SqlParameter("@PageNo",1)
                //         ,new SqlParameter("@PageSize","0")
                //         ,new SqlParameter("@SearchString","")
                //         ,new SqlParameter("@OrderBy","")
                //         ,new SqlParameter("@SortBy","")
                //         };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeMasterForDropDown"))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<EmployeeMaster>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<EmployeeMaster>> GetAllEmployeeByUserandCompanyAsync(int? userid, int? companyid)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeMaster> lst = new PagedDataTable<EmployeeMaster>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@UserID",userid)
                        ,new SqlParameter("@CompanyID",companyid)

                        };

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeByDepartment", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<EmployeeMaster>
                            (1, 10, totalItemCount, "", "", "");
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<EmployeeMaster>> GetAllEmployeeByDepartmentAsync(int? departmentid)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeMaster> lst = new PagedDataTable<EmployeeMaster>();
            try
            {
                SqlParameter[] param = { new SqlParameter("@DepartmentID", departmentid) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeByDepartmentId", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<EmployeeMaster>
                             (1, 10, totalItemCount, "", "", "");
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }


        public async Task<PagedDataTable<UOMIDMetadata>> GetAllUOMAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<UOMIDMetadata> lst = new PagedDataTable<UOMIDMetadata>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_UOMID", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }


                        lst = table.ToPagedDataTableList<UOMIDMetadata>();
                    }
                    return lst;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<ItemCategory>> GetAllItemCategoryAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ItemCategory> lst = new PagedDataTable<ItemCategory>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ItemCategory", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<ItemCategory>();
                    }
                    return lst;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<FinancialYearMaster>> GetAllFinancialYearAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<FinancialYearMaster> lst = new PagedDataTable<FinancialYearMaster>();
            try
            {
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_FinancialYearMasterForDropdown"))

                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }


                        lst = table.ToPagedDataTableList<FinancialYearMaster>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<CompanyMasterMetadata>> GetAllCompanyAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<CompanyMasterMetadata> lst = new PagedDataTable<CompanyMasterMetadata>();
            try
            {
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_CompanyMaster"))

                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<CompanyMasterMetadata>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<CustomerMasterMetadata>> GetAllCustomerAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<CustomerMasterMetadata> lst = new PagedDataTable<CustomerMasterMetadata>();
            try
            {
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_CustomerMasterForDropdown"))

                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<CustomerMasterMetadata>();
                    }
                    return lst;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<PartyMaster>> GetAllPartyAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<PartyMaster> lst = new PagedDataTable<PartyMaster>();
            try
            {
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyMasterForDropdown"))

                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<PartyMaster>();
                    }
                    return lst;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<StateMasterMetadata>> GetAllStateAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<StateMasterMetadata> lst = new PagedDataTable<StateMasterMetadata>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_StateMaster", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<StateMasterMetadata>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }







        public async Task<PagedDataTable<CityMasterModelDropdown>> GetAllCityAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<CityMasterModelDropdown> lst = new PagedDataTable<CityMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_CityMaster", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<CityMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<AddressMasterModelDropdown>> GetAllAddressAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<AddressMasterModelDropdown> lst = new PagedDataTable<AddressMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_AddressMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<AddressMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<RoleMasterModelDropdown>> GetAllRoleAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<RoleMasterModelDropdown> lst = new PagedDataTable<RoleMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_RoleMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<RoleMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<ExpenseTypeMasterModelDropdown>> GetAllExpenseTypeAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ExpenseTypeMasterModelDropdown> lst = new PagedDataTable<ExpenseTypeMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ExpenseTypeMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<ExpenseTypeMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<ItemGroupMasterModelDropdown>> GetAllItemGroupAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ItemGroupMasterModelDropdown> lst = new PagedDataTable<ItemGroupMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ItemGroupMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<ItemGroupMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<ItemSubGroupMasterModelDropdown>> GetAllItemSubGroupAsync(int itemGroupID)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ItemSubGroupMasterModelDropdown> lst = new PagedDataTable<ItemSubGroupMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@ItemGroupID", itemGroupID) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ItemSubGroupMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<ItemSubGroupMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<MachineOperatingStatusMasterModelDropdown>> GetAllMachineOperatingStatusAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineOperatingStatusMasterModelDropdown> lst = new PagedDataTable<MachineOperatingStatusMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineOperatingStatusForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<MachineOperatingStatusMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<MachineCategoryMasterModelDropdown>> GetAllMachineCategoryAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineCategoryMasterModelDropdown> lst = new PagedDataTable<MachineCategoryMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineCategoryMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<MachineCategoryMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<MachineryMasterModelDropdown>> GetAllMachineryAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryMasterModelDropdown> lst = new PagedDataTable<MachineryMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<MachineryMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<DepreciationMethodMasterModelDropdown>> GetAllDepreciationMethodAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DepreciationMethodMasterModelDropdown> lst = new PagedDataTable<DepreciationMethodMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_DepreciationMethodForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<DepreciationMethodMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<UtilityMasterModelDropdown>> GetAllUtilityAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<UtilityMasterModelDropdown> lst = new PagedDataTable<UtilityMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_UtilityMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<UtilityMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<ShiftMasterModelDropdown>> GetAllShiftAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ShiftMasterModelDropdown> lst = new PagedDataTable<ShiftMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ShiftMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<ShiftMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<ItemMasterModelDropdown>> GetAllItemAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ItemMasterModelDropdown> lst = new PagedDataTable<ItemMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ItemMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<ItemMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<ReportMasterModelDropdown>> GetAllReportAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ReportMasterModelDropdown> lst = new PagedDataTable<ReportMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_ReportMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<ReportMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<FormMasterModelDropdown>> GetAllFormAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<FormMasterModelDropdown> lst = new PagedDataTable<FormMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_FormMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<FormMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<SAPItemModelDropdown>> GetAllSAPItemAsyncByItemGroup(string itemGroupName)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<SAPItemModelDropdown> lst = new PagedDataTable<SAPItemModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@ItemGroupName", itemGroupName) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SAPItemStockByItemGroup", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<SAPItemModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<AddressTypeMasterModelDropdown>> GetAllAddressTypeAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<AddressTypeMasterModelDropdown> lst = new PagedDataTable<AddressTypeMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_AddressTypeMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<AddressTypeMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<SalaryFormulaTypeMasterDropdown>> GetAllSalaryFormulaTypeMasterAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<SalaryFormulaTypeMasterDropdown> lst = new PagedDataTable<SalaryFormulaTypeMasterDropdown>();
            try
            {
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_SalaryFormulaTypeMaster"))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<SalaryFormulaTypeMasterDropdown>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }


        public async Task<PagedDataTable<DatabaseTables>> GetAllDatabaseTablesAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DatabaseTables> lst = new PagedDataTable<DatabaseTables>();
            try
            {
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_DatabaseTables"))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            //if (table.ContainColumn("TotalCount"))
                            //    totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            //else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<DatabaseTables>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<DatabaseTableColumns>> GetAllDatabaseTableColumnsAsync(string objectID)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DatabaseTableColumns> lst = new PagedDataTable<DatabaseTableColumns>();
            try
            {
                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Object_Id", objectID) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_DatabaseTableColums", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<DatabaseTableColumns>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<EmployeeMaster>> GetAllAvailableEmployeesForMachineryAsync(DateTime? todayDate)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeMaster> lst = new PagedDataTable<EmployeeMaster>();
            try
            {
                SqlParameter[] param = {
                 new SqlParameter("@TodayDate",todayDate)
                 //,new SqlParameter("@ShiftID",shiftId)
                 //,new SqlParameter("@DepartmentID",departmentId)
                 //,new SqlParameter("@MachineryID",machineryId)
                 };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_AvialableEmployeesForMachinery", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<EmployeeMaster>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<LocationMasterModelDropdown>> GetAllLocationAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<LocationMasterModelDropdown> lst = new PagedDataTable<LocationMasterModelDropdown>();
            try
            {

                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", null) };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_LocationMasterForDropdown", sp))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                        lst = table.ToPagedDataTableList<LocationMasterModelDropdown>(0, 0, totalItemCount);
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        public async Task<PagedDataTable<EmployeeMaster>> GetAllEmployeesAccordingToDesignation(string WorkType)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeMaster> lst = new PagedDataTable<EmployeeMaster>();
            try
            {
                SqlParameter[] param = {
                         new SqlParameter("@WorkType",WorkType)
                //        new SqlParameter("@PageNo",1)
                //         ,new SqlParameter("@PageSize","0")
                //         ,new SqlParameter("@SearchString","")
                //         ,new SqlParameter("@OrderBy","")
                //         ,new SqlParameter("@SortBy","")
                         };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeesAccordingToDesignation", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<EmployeeMaster>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<PagedDataTable<RequestForQuotTypeMaster>> GetAllRequestForQuotTypeAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<RequestForQuotTypeMaster> lst = new PagedDataTable<RequestForQuotTypeMaster>();
            try
            {
                 
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_RequestForQuotTypeMaster"))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }

                        lst = table.ToPagedDataTableList<RequestForQuotTypeMaster>();
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        #region Machine name by DepartmentID, Method Added by Dravesh Lokhande  on 22-Feb-2024.

        public async Task<PagedDataTable<MachineryResourceAllocation>> MachineNameByDepartmentID(int departmentId)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<MachineryResourceAllocation> lst = new PagedDataTable<MachineryResourceAllocation>();
            try
            {
                SqlParameter[] param = { new SqlParameter("@DepartmentID", departmentId) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_MachineryDropdownFromDepartment", param);
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                    }
                    lst = table.ToPagedDataTableList<MachineryResourceAllocation>();
                }

                return lst;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        #endregion Machine name by DepartmentID, Method Added by Dravesh Lokhande  on 22-Feb-2024.



        //$AddCommonMasterServiceMethod$
    }
}