using Business.Entities.PartyMasterModel;
using Business.Interface.Marketing.IPartiesListbyNote;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Business.Service.Marketing.SPartiesListbyNote
{
    public class PartiesListbyNoteService : PartiesListbyNoteInterface

    {
        #region Database Connection
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public PartiesListbyNoteService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        #endregion Database Connection

        #region Party list notes
        public async Task<PagedDataTable<PartyMaster>> GetAllNotificationTest(int UserID = 0, int PartyID = 0, int PositiveNoteID = 0)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<PartyMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PartyID",PartyID),
                        new SqlParameter("@PositiveNoteID", PositiveNoteID),
                        new SqlParameter("@UserID", UserID)
                        //new SqlParameter("@SearchString", SearchString),
                        //new SqlParameter("@PageNo", 1),
                        //new SqlParameter("@PageSize", 10),
                        //new SqlParameter("@OrderBy","NotificationID"),
                        //new SqlParameter("@SortBy",0)
                        };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_PartiesListbyNote", param);
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
                    lst = table.ToPagedDataTableList<PartyMaster>(1, 1000, totalItemCount);
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
        #endregion Party list notes
    }
}
