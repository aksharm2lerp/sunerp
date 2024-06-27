using Business.Interface.Marketing.ITravellingExpenseDetail;
using Business.Entities.Marketing.TravellingExpenseDetailModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Business.Entities.Employee.EmploymentType;
using Business.Entities.Marketing.QuotationMasterModel;

namespace Business.Service.Marketing.STravellingExpenseDetail
{
    public class TravellingExpenseDetailService : TravellingExpenseDetailInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public TravellingExpenseDetailService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<TravellingExpenseDetail>> GetAllTravellingExpenseDetailAsyncOld(int pageNo, int pageSize, string searchString = "", string orderBy = "TravellingExpenseDetailID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<TravellingExpenseDetail> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_TravellingExpenseDetail", param))
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
                    lst = table.ToPagedDataTableList<TravellingExpenseDetail>(pageNo, pageSize, totalItemCount);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        #endregion Index page

        #region Get Singal Record
        public async Task<TravellingExpenseDetail> GetTravellingExpenseDetailAsync(int TravellingExpenseDetailID)
        {
            TravellingExpenseDetail result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@TravellingExpenseDetailID", TravellingExpenseDetailID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_TravellingExpenseDetail", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<TravellingExpenseDetail>();
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
        #endregion Get Singal Record

        #region Add or Update Positive Note
        public async Task<int> AddOrUpdateTravellingExpenseDetail(TravellingExpenseDetail model, DataTable dataTable)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@TravellingExpenseDetailID", model.TravellingExpenseDetailID)
                    ,new SqlParameter("@TravellingDate", model.TravellingDate)
                    ,new SqlParameter("@FromLocation", model.FromLocation)
                    ,new SqlParameter("@ToLocation", model.ToLocation)
                    ,new SqlParameter("@Via", model.Via)
                    ,new SqlParameter("@DistanceInKM", model.DistanceInKM)
                    ,new SqlParameter("@Amount", model.Amount)
                    ,new SqlParameter("@PartyID", model.PartyID)
                    ,new SqlParameter("@IsActive", model.IsActive)
                    ,new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy)
                    ,new SqlParameter("@TravellingExpenseBillsImagesTxn",dataTable)
                };

                param[10].Direction = ParameterDirection.Input;
                param[10].SqlDbType = SqlDbType.Structured;
                param[10].ParameterName = "@TravellingExpenseBillsImagesTxn";
                param[10].TypeName = "UDTT_TravellingExpenseBillsImagesTxn";
                param[10].Value = dataTable;

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_TravellingExpenseDetail", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update Positive Note

        #region New Index Page
        public async Task<TravellingExpenseDetail> GetAllTravellingExpenseDetailAsync(int userid)
        {
            TravellingExpenseDetail result = new TravellingExpenseDetail();
            try
            {
                SqlParameter[] param = { new SqlParameter("@UserID", userid) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_TravellingExpenseDetail", param);


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        List<TravellingExpenseDetail> listTravellingExpenseDetail = new List<TravellingExpenseDetail>();

                        foreach (DataRow item in ds.Tables["Table"].Rows)
                        {
                            TravellingExpenseDetail travellingExpenseDetail = new TravellingExpenseDetail();
                            travellingExpenseDetail.SrNo = item["SrNo"].ToInt();
                            travellingExpenseDetail.TravellingExpenseDetailID = item["TravellingExpenseDetailID"].ToInt();
                            travellingExpenseDetail.TravellingExpenseStatusID = item["TravellingExpenseStatusID"].ToInt();
                            travellingExpenseDetail.PartyID = item["PartyID"].ToInt();
                            travellingExpenseDetail.PartyName = item["PartyName"].ToString();
                            travellingExpenseDetail.TravellingDate = Convert.ToDateTime(item["TravellingDate"]);
                            travellingExpenseDetail.FromLocation = item["FromLocation"].ToString();
                            travellingExpenseDetail.ToLocation = item["ToLocation"].ToString();
                            travellingExpenseDetail.Via = item["Via"].ToString();
                            travellingExpenseDetail.DistanceInKM = item["DistanceInKM"].ToString();
                            travellingExpenseDetail.MarketingPerson = item["MarketingPerson"].ToString();
                            travellingExpenseDetail.Amount = item["Amount"].ToString();
                            travellingExpenseDetail.IsActive = item["IsActive"].ToBoolDefaultTrue();
                            listTravellingExpenseDetail.Add(travellingExpenseDetail);
                        }
                        result.listTravellingExpenseDetail = listTravellingExpenseDetail;


                        List<TravellingExpenseBillsImages> listProductImagesTxn = new List<TravellingExpenseBillsImages>();

                        foreach (DataRow item in ds.Tables["Table1"].Rows)
                        {
                            TravellingExpenseBillsImages travellingExpenseBillsImages = new TravellingExpenseBillsImages();
                            travellingExpenseBillsImages.SrNo = item["SrNo"].ToInt();
                            travellingExpenseBillsImages.TravellingExpenseBillsImagesTxnID = item["TravellingExpenseBillsImagesTxnID"].ToInt();
                            travellingExpenseBillsImages.TravellingExpenseDetailID = item["TravellingExpenseDetailID"].ToInt();
                            travellingExpenseBillsImages.TravellingExpenseBillsImagesText = item["TravellingExpenseBillsImagesText"].ToString();
                            travellingExpenseBillsImages.TravellingExpenseBillsImagesPath = item["TravellingExpenseBillsImagesPath"].ToString();
                            travellingExpenseBillsImages.IsActive = item["IsActive"].ToBoolDefaultTrue();
                            listProductImagesTxn.Add(travellingExpenseBillsImages);
                        }
                        result.listTravellingExpenseBillsImages = listProductImagesTxn;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion New Index Page

        #region Employment Type change by Hr
        public async Task<TravellingExpenseStatus> TravellingExpenseStatus(int TEDID)
        {
            TravellingExpenseStatus result = null;
            try
            {
                SqlParameter[] param = {
                    //new SqlParameter("@EmployeeFamilyDetailID", employeeFamilyId),
                    new SqlParameter("@TravellingExpenseDetailID", TEDID)
        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_TravellingExpenseDetail", param);
                //if (ds != null)
                //{
                //    if (ds.Tables.Count > 0)
                //    {
                //        if (ds.Tables[0].Rows.Count > 0)
                //        {
                //            DataRow dr = ds.Tables[0].Rows[0];
                //            result = dr.ToPagedDataTableList<TravellingExpenseStatus>();
                //        }
                //    }
                //}

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        result = dr.ToPagedDataTableList<TravellingExpenseStatus>();

                        List<TravellingExpenseStatus> listTravellingExpenseStatus = new List<TravellingExpenseStatus>();

                        foreach (DataRow item in ds.Tables["Table1"].Rows)
                        {
                            TravellingExpenseStatus travellingExpenseStatus = new TravellingExpenseStatus();
                            travellingExpenseStatus.SrNo = item["SrNo"].ToInt();
                            travellingExpenseStatus.TravellingExpenseStatusID = item["TravellingExpenseStatusID"].ToInt();
                            travellingExpenseStatus.TravellingExpenseDetailID = item["TravellingExpenseDetailID"].ToInt();
                            travellingExpenseStatus.UserFullName = item["UserFullName"].ToString();
                            travellingExpenseStatus.StatusText = item["StatusText"].ToString();
                            travellingExpenseStatus.TravellingExpenseStatusDate = Convert.ToDateTime(item["TravellingExpenseStatusDate"]);
                            travellingExpenseStatus.StatusNote = item["StatusNote"].ToString();
                            listTravellingExpenseStatus.Add(travellingExpenseStatus);
                        }
                        result.listTravellingExpenseStatus = listTravellingExpenseStatus;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Update Quotation Approval Type
        public async Task<int> AddTravellingExpenseStatus(TravellingExpenseStatus model)
        {
            
            try
            {
                var obj = new object();
                obj = null;
                if (model.StatusID.ToInt() > 0)
                {
                    SqlParameter[] param = {
                    new SqlParameter("@TravellingExpenseStatusID",model.TravellingExpenseStatusID),
                    new SqlParameter("@TravellingExpenseDetailID",model.TravellingExpenseDetailID),
                    new SqlParameter("@TravellingExpenseStatusDate",model.TravellingExpenseStatusDate),
                    new SqlParameter("@StatusID",model.StatusID),
                    new SqlParameter("@StatusNote",model.StatusNote),
                    new SqlParameter("@IsActive", 1),
                    new SqlParameter("@CreatedOrModifiedBy",model.CreatedOrModifiedBy)
                    //new SqlParameter("@QuotationCode",model.QuotationCode),
                    //new SqlParameter("@ApprovedBy",model.ApprovedBy),
                    //new SqlParameter("@Amount",model.Amount),
                    //new SqlParameter("@AuthenticatedDate",model.AuthenticatedDate),
                    //new SqlParameter("@Comment",model.Comment),
                };
                    obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_TravellingExpenseStatus", param);

                }
                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add Update Quotation Approval Type

    }
}


