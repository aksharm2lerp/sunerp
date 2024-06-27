using Business.Interface.Marketing.ITaxFormulaMaster;
using Business.Entities.Marketing.TaxFormulaMasterModel;

using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Business.Service.Marketing.STaxFormulaMaster
{
    public class TaxFormulaMasterService : TaxFormulaMasterInterface
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public TaxFormulaMasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #region Index page
        public async Task<PagedDataTable<TaxFormulaMaster>> GetAllTaxFormulaMasterAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "TaxFormulaMasterID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<TaxFormulaMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_TaxFormulaMaster", param))
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
                    lst = table.ToPagedDataTableList<TaxFormulaMaster>(pageNo, pageSize, totalItemCount);
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
        public async Task<TaxFormulaMaster> GetTaxFormulaMasterAsync(int TaxFormulaMasterID)
        {
            TaxFormulaMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@TaxFormulaMasterID", TaxFormulaMasterID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_TaxFormulaMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<TaxFormulaMaster>();
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

        #region Add or Update
        public async Task<int> AddOrUpdateTaxFormulaMaster(TaxFormulaMaster model)
        {
            try
            {
                SqlParameter[] param = {
				 new SqlParameter("@TaxFormulaID", model.TaxFormulaID), new SqlParameter("@CustomerID", model.CustomerID), new SqlParameter("@FormulaTypeID", model.FormulaTypeID), new SqlParameter("@FormulaHead", model.FormulaHead), new SqlParameter("@FormulaLabel", model.FormulaLabel), new SqlParameter("@Formula", model.Formula), new SqlParameter("@FormulaPercentage", model.FormulaPercentage), new SqlParameter("@FormulaValue", model.FormulaValue),new SqlParameter("@IsActive", model.IsActive),
					new SqlParameter("@CreatedOrModifiedBy", model.CreatedOrModifiedBy) };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_TaxFormulaMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Add or Update
    }
}


