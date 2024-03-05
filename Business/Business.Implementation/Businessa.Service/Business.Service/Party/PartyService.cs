using Business.Interface.IParty;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;
using Business.Entities.Party;
using Business.Entities.PartyMasterModel;

namespace Business.Service.Party
{
    public class PartyService : IPartyService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public PartyService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        public async Task<PagedDataTable<PartyMaster>> GetAllPartyAsync(int pageNo = 1, int pageSize = 10, string searchString = "", string orderBy = "PartyID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        };

                

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyMaster", param))
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
                    PagedDataTable<PartyMaster> lst = table.ToPagedDataTableList<PartyMaster>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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

        public async Task<PartyMaster> GetPartyAsync(int PartyId)
        {
            PartyMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@PartyID", PartyId) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyMaster>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUpdateParty(PartyMaster PartyMaster)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyID", PartyMaster.PartyID),
                    new SqlParameter("@PartyCode", PartyMaster.PartyCode),
                    new SqlParameter("@PartyName", PartyMaster.PartyName),
                    new SqlParameter("@Email", PartyMaster.Email),
                    new SqlParameter("@GroupName", PartyMaster.GroupName),
                    new SqlParameter("@OwnerName", PartyMaster.OwnerName),
                    new SqlParameter("@UnitNoName", PartyMaster.UnitNoName),
                    new SqlParameter("@ContactPhone1", PartyMaster.ContactPhone1),
                    new SqlParameter("@Mobile1", PartyMaster.Mobile1),
                    new SqlParameter("@FaxNo", PartyMaster.FaxNo),
                    new SqlParameter("@IndustryTypeID", PartyMaster.IndustryTypeID),
                    new SqlParameter("@BusinessTypeID", PartyMaster.BusinessTypeID),
                    new SqlParameter("@IsActive", PartyMaster.IsActive),
                    new SqlParameter("@CreatedOrModifiedBy", PartyMaster.CreatedOrModifiedBy),
                    new SqlParameter("@PartyTypeID", PartyMaster.PartyTypeID),
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdatePartyLogoImage(PartyLogoImage PartyLogoImage)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@PartyID", PartyLogoImage.PartyID),
                new SqlParameter("@LogoImageName", PartyLogoImage.LogoImageName),
                new SqlParameter("@LogoImagePath", PartyLogoImage.LogoImagePath),
                new SqlParameter("@IsActive", PartyLogoImage.IsActive),
                new SqlParameter("@CreatedOrModifiedBy", PartyLogoImage.CreatedOrModifiedBy ),

                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyLogoImage", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Contact Person Detail
        public async Task<PagedDataTable<PartyContactTxn>> GetPartyAllContactPerson(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        ,new SqlParameter("@PartyID",PartyId)
                        };

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyContactTxn", param))
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
                    PagedDataTable<PartyContactTxn> lst = table.ToPagedDataTableList<PartyContactTxn>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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

        public async Task<PartyContactTxn> GetPartyContactPerson(int PartyContactID, int PartyId)
        {
            PartyContactTxn result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyContactID", PartyContactID),
                    new SqlParameter("@PartyID", PartyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyContactTxn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyContactTxn>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUpdatePartyContactPerson(PartyContactTxn PartyContactTxn)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyContactID", PartyContactTxn.PartyContactID)
                    ,new SqlParameter("@PartyID", PartyContactTxn.PartyID)
                    ,new SqlParameter("@Prefix", PartyContactTxn.Prefix)
                    ,new SqlParameter("@ContactPerson", PartyContactTxn.ContactPersonName)
                    ,new SqlParameter("@DesignationID", PartyContactTxn.DesignationID)
                    ,new SqlParameter("@DepartmentID", PartyContactTxn.DepartmentID)
                    ,new SqlParameter("@PersonalMobile", PartyContactTxn.PersonalMobile)
                    ,new SqlParameter("@OfficeMobile", PartyContactTxn.OfficeMobile)
                    ,new SqlParameter("@PersonalEmailID", PartyContactTxn.PersonalEmailID)
                    ,new SqlParameter("@OfficeEmailID", PartyContactTxn.OfficeEmailID)
                    ,new SqlParameter("@AlternativeMobile", PartyContactTxn.AlternativeMobile)
                    ,new SqlParameter("@EmailGroupName", PartyContactTxn.EmailGroupName)
                    ,new SqlParameter("@BirthDate", PartyContactTxn.BirthDate)
                    ,new SqlParameter("@Religion", PartyContactTxn.Religion)
                    ,new SqlParameter("@IsActive", PartyContactTxn.IsActive)
                    ,new SqlParameter("@Notes", PartyContactTxn.Notes)/*
                    ,new SqlParameter("@CreatedOrModifiedBy", PartyContactTxn.CreatedOrModifiedBy)*/
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyContactTxn", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }
        #endregion Contact Person Detail

        #region Address detail
        public async Task<PagedDataTable<PartyAddressTxn>> GetPartyAllAddressAsync(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        ,new SqlParameter("@PartyID",PartyId)
                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyAddressTxn", param))
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
                    PagedDataTable<PartyAddressTxn> lst = table.ToPagedDataTableList<PartyAddressTxn>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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
        public async Task<int> AddUpdateCustomeAddress(PartyAddressTxn PartyAddressTxn)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyAddressTxnID", PartyAddressTxn.PartyAddressTxnID)
                    ,new SqlParameter("@PartyID", PartyAddressTxn.PartyID)
                    ,new SqlParameter("@Address1", PartyAddressTxn.PlotNoName)
                    ,new SqlParameter("@Address2", PartyAddressTxn.StreetNoName)
                    //,new SqlParameter("@Address3", PartyAddressTxn.Address3)
                    ,new SqlParameter("@Landmark", PartyAddressTxn.Landmark)
                    ,new SqlParameter("@Area", PartyAddressTxn.Area)
                    ,new SqlParameter("@ZIPCode", PartyAddressTxn.ZIPCode)
                    ,new SqlParameter("@IsActive", PartyAddressTxn.IsActive)
                    ,new SqlParameter("@City", PartyAddressTxn.City)
                    ,new SqlParameter("@District", PartyAddressTxn.District)
                    ,new SqlParameter("@Taluka", PartyAddressTxn.Taluka)
                    ,new SqlParameter("@AddressTypeID", PartyAddressTxn.AddressTypeID)
                    ,new SqlParameter("@CountryID", PartyAddressTxn.CountryID)
                    ,new SqlParameter("@StateID", PartyAddressTxn.StateID)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyAddressTxn", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PartyAddressTxn> GetPartyAddressTxn(int customeAddressTxnId, int PartyId)
        {
            PartyAddressTxn result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyAddressTxnID", customeAddressTxnId),
                    new SqlParameter("@PartyID", PartyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyAddressTxn", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyAddressTxn>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Address detail

        #region Party Contact Detail
        public async Task<PartyContactDetail> GetPartyContactDetail(int PartyId)
        {
            PartyContactDetail result = null;
            try
            {
                SqlParameter[] param = {
                    //new SqlParameter("@EmployeeFamilyDetailID", employeeFamilyId),
                    new SqlParameter("@PartyID", PartyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyContactDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyContactDetail>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUpdatePartyContactDetail(PartyContactDetail PartyContactDetail)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyContactDetailID",PartyContactDetail.PartyContactDetailID)
                    ,new SqlParameter("@PartyID",PartyContactDetail.PartyID)
                    ,new SqlParameter("@OfficePhone",PartyContactDetail.OfficePhone)
                    ,new SqlParameter("@MobileNo",PartyContactDetail.MobileNo)
                    ,new SqlParameter("@Website",PartyContactDetail.Website)
                };
                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyContactDetail", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }
        #endregion Party Contact Detail

        #region Party Registration

        public async Task<PartyRegistration> GetPartyRegistration(int PartyId)
        {
            PartyRegistration result = null;
            try
            {
                SqlParameter[] param = {
                    //new SqlParameter("@EmployeeFamilyDetailID", employeeFamilyId),
                    new SqlParameter("@PartyID", PartyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyRegistration", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyRegistration>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUpdatePartyRegistration(PartyRegistration PartyRegistration)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyRegistrationID", PartyRegistration.PartyRegistrationID)
                    ,new SqlParameter("@PartyID", PartyRegistration.PartyID)
                    ,new SqlParameter("@PANNo", PartyRegistration.PANNo)
                    ,new SqlParameter("@GSTINNo", PartyRegistration.GSTINNo)
                    ,new SqlParameter("@GSTINType", PartyRegistration.GSTINType)
                    ,new SqlParameter("@FactoryLicenseNo", PartyRegistration.FactoryLicenseNo)
                    ,new SqlParameter("@FactoryRegNo", PartyRegistration.FactoryRegNo)
                    ,new SqlParameter("@ARNNo", PartyRegistration.ARNNo)
                    ,new SqlParameter("@ECCNo", PartyRegistration.ECCNo)
                    ,new SqlParameter("@MSMENo", PartyRegistration.MSMENo)
                    ,new SqlParameter("@SSINo", PartyRegistration.SSINo)
                    ,new SqlParameter("@TANNo", PartyRegistration.TANNo)
                    ,new SqlParameter("@ExportNo", PartyRegistration.ExportNo)
                    ,new SqlParameter("@ImportNo", PartyRegistration.ImportNo)
                    ,new SqlParameter("@TaxRange", PartyRegistration.TaxRange)
                    ,new SqlParameter("@TaxDivisio", PartyRegistration.TaxDivisio)
                    ,new SqlParameter("@TaxCommisionerate", PartyRegistration.TaxCommisionerate)
                    ,new SqlParameter("@CreatedByORModifiedBy", PartyRegistration.CreatedOrModifiedBy)
                };
                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyRegistration", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }

        #endregion Party Registration

        #region Party banking detail
        public async Task<PagedDataTable<PartyBankDetails>> GetPartyAllBankAccount(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        ,new SqlParameter("@PartyID",PartyId)
                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyBankDetails", param))
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
                    PagedDataTable<PartyBankDetails> lst = table.ToPagedDataTableList<PartyBankDetails>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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

        public async Task<PartyBankDetails> GetPartyBankAccount(int PartyBankDetailsId, int PartyId)
        {
            PartyBankDetails result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyBankDetailsID", PartyBankDetailsId),
                    new SqlParameter("@PartyID", PartyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyBankDetails", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyBankDetails>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUpdatePartyBankDetails(PartyBankDetails PartyBankDetails)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyBankDetailsID", PartyBankDetails.PartyBankDetailsID)
                    ,new SqlParameter("@PartyID", PartyBankDetails.PartyID)
                    ,new SqlParameter("@BankName", PartyBankDetails.BankName)
                    ,new SqlParameter("@AccountName", PartyBankDetails.AccountName)
                    ,new SqlParameter("@IFSCCode", PartyBankDetails.IFSCCode)
                    ,new SqlParameter("@AccountNO", PartyBankDetails.AccountNO)
                    ,new SqlParameter("@BranchLocation", PartyBankDetails.BranchLocation)
                    ,new SqlParameter("@City", PartyBankDetails.City)
                    ,new SqlParameter("@BankCode", PartyBankDetails.BankCode)
                    ,new SqlParameter("@BICSwiftCode", PartyBankDetails.BICSwiftCode)
                    ,new SqlParameter("@CountryID", PartyBankDetails.CountryID)
                    ,new SqlParameter("@IsDefaultBankAccount" , PartyBankDetails.IsDefaultBankAccount)
                    ,new SqlParameter("@IsActive", PartyBankDetails.IsActive)
                    ,new SqlParameter("@CreatedOrModifiedBy", PartyBankDetails.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyBankDetails", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }
        #endregion Party banking detail

        #region Party document
        public async Task<PagedDataTable<PartyDocument>> GetPartysAllDocuments(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "", string sortBy = "ASC", int PartyId = 0)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        ,new SqlParameter("@PartyID",PartyId)
                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyDocument", param))
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
                    PagedDataTable<PartyDocument> lst = table.ToPagedDataTableList<PartyDocument>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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

        public async Task<PartyDocument> GetPartyDocument(int PartyDocumentId, int PartyId)
        {
            PartyDocument result = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyDocumentID", PartyDocumentId),
                    new SqlParameter("@PartyID", PartyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartyDocument", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartyDocument>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUpdatePartyDocument(PartyDocument PartyDocument)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyDocumentID", PartyDocument.PartyDocumentID)
                    ,new SqlParameter("@PartyID", PartyDocument.PartyID)
                    ,new SqlParameter("@DocumentName", PartyDocument.DocumentName)
                    ,new SqlParameter("@DocumentExtension", PartyDocument.DocumentExtension)
                    ,new SqlParameter("@DocumentTypeID", PartyDocument.DocumentTypeID)
                    //,new SqlParameter("@IsDeleted", PartyDocument.IsDeleted)
                    ,new SqlParameter("@DocumentDescription", PartyDocument.DocumentDescription)
                    ,new SqlParameter("@DocumentPath", PartyDocument.DocumentPath)
                    ,new SqlParameter("@IsActive", PartyDocument.IsActive)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartyDocument", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> ActiveInActivePartyDocument(PartyDocument PartyDocument)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyDocumentID", PartyDocument.PartyDocumentID)
                    ,new SqlParameter("@PartyID", PartyDocument.PartyID)
                    ,new SqlParameter("@CreatedOrModifiedBy", PartyDocument.CreatedOrModifiedBy)
                    ,new SqlParameter("@IsActive", PartyDocument.IsActive == true ? 1 : 0)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_U_PartyDocumentIsActive", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }
        #endregion Party document

        #region Party Setting
        public async Task<PartySetting> GetPartySetting(int PartyId)
        {
            PartySetting result = null;
            try
            {
                SqlParameter[] param = {
                    //new SqlParameter("@EmployeeFamilyDetailID", employeeFamilyId),
                    new SqlParameter("@PartyID", PartyId)
                };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartySetting", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<PartySetting>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUpdatePartySetting(PartySetting PartySetting)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartySettingID",PartySetting.PartySettingID)
                    ,new SqlParameter("@PartyID",PartySetting.PartyID)
                    ,new SqlParameter("@CreditLimit",PartySetting.CreditLimit)
                    ,new SqlParameter("@CommitementLimit",PartySetting.CommitementLimit)
                    ,new SqlParameter("@PaymentTerm",PartySetting.PaymentTerm)
                    ,new SqlParameter("@AllowDiscountPerPO",PartySetting.AllowDiscountPerPO)
                };
                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_PartySetting", param);

                return obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch
            {
                throw;
            }
        }
        #endregion Party Setting


        #region Party Summary for activity display
        public async Task<PagedDataTable<PartyMaster>> GetAllPartySummaryAsync(int pageNo = 1, int pageSize = 10, string searchString = "", string orderBy = "PartyID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        };

                //    using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeMaster", param))     Change SP to Partys

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PartySummary", param))
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
                    PagedDataTable<PartyMaster> lst = table.ToPagedDataTableList<PartyMaster>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
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
       
        #endregion Party Summary for activity display

    }
}
