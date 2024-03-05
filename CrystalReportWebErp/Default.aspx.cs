using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Data.SqlClient;
using System.Web.Caching;
using System.CodeDom;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.IO;

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (Request.QueryString.Count > 0)
                    {

                        DataSet dsGlobal = new DataSet();
                        SqlDataAdapter sqlda = new SqlDataAdapter();
                        SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["consPros"].ConnectionString.ToString());

                        SqlCommand sqlComm = new SqlCommand("[dbo].[Usp_Report_GetEmployeeSalaryDetail]", SqlConn);

                        try
                        {
                            string ReportKey = Request.QueryString["reportkey"].ToString();
                            sqlComm.CommandType = CommandType.StoredProcedure;
                            sqlComm.Parameters.AddWithValue("@ReportID", ReportKey);

                            sqlda = new SqlDataAdapter(sqlComm);
                            sqlda.Fill(dsGlobal, "ReportDetail");

                        }
                        catch (SqlException ex)
                        {
                            Response.Write("<script>alert(" + ex.Message + ")</script>");
                            goto exitPoint;
                        }
                        finally
                        {
                            SqlConn.Close();
                            sqlComm.Dispose();
                            sqlda.Dispose();
                            SqlConn.Dispose();
                        }

                        if (dsGlobal.Tables.Count > 0)
                        {
                            CrystalReportViewer1.DisplayGroupTree = false;
                            CrystalReportViewer1.HasCrystalLogo = false;
                            string path = "";
                            if (dsGlobal.Tables[0].Rows.Count > 0)
                            {
                                string Rootpath = string.Concat("~/", dsGlobal.Tables[0].Rows[0]["ReportPath"].ToString(), dsGlobal.Tables[0].Rows[0]["ReportName"].ToString());
                                path = Server.MapPath(Rootpath).ToString();
                            }
                            else
                            {
                                Response.Write("<script>alert('Report Location is not found!')</script>");
                                goto exitPoint;

                            }
                            ReportDocument myreportdocument = new ReportDocument();
                            myreportdocument.Load(path);




                            DataSet ds = new DataSet();
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                            SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["consPros"].ConnectionString.ToString());
                            SqlCommand sqlCommand = new SqlCommand();

                            if (dsGlobal.Tables[0].Rows[0]["CommandType"].ToString() == "StoredProcedure")
                            {
                                string spName = dsGlobal.Tables[0].Rows[0]["CommandText"].ToString();
                                sqlCommand = new SqlCommand(spName, SqlCon);
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                            }
                            else if (dsGlobal.Tables[0].Rows[0]["CommandType"].ToString() == "Text")
                            {
                                string spName = dsGlobal.Tables[0].Rows[0]["CommandText"].ToString();
                                sqlCommand = new SqlCommand(spName, SqlCon);
                                sqlCommand.CommandType = CommandType.Text;
                            }
                            else if (dsGlobal.Tables[0].Rows[0]["CommandType"].ToString() == "TableDirect")
                            {
                                string spName = dsGlobal.Tables[0].Rows[0]["CommandText"].ToString();
                                sqlCommand = new SqlCommand(spName, SqlCon);
                                sqlCommand.CommandType = CommandType.TableDirect;
                            }

                            if (dsGlobal.Tables[1].Rows.Count > 0)
                            {
                                if (dsGlobal.Tables[1].Rows[0]["ParameterType"].ToString() == "SQL")
                                {
                                    for (int i = 0; i < dsGlobal.Tables[1].Rows.Count; i++)
                                    {
                                        sqlCommand.Parameters.AddWithValue(dsGlobal.Tables[1].Rows[i]["ParameterName"].ToString(),
                                             Request.QueryString[dsGlobal.Tables[1].Rows[i]["ParameterName"].ToString().Replace("@", "")].ToString());
                                    }
                                    //sqlCommand.Parameters.AddWithValue("@EmployeeID", 63);
                                    //sqlCommand.Parameters.AddWithValue("@Year", 2023);
                                    //sqlCommand.Parameters.AddWithValue("@Month", 3);
                                    //sqlCommand.Parameters.AddWithValue("@CompanyID", 1);
                                    //sqlCommand.Parameters.AddWithValue("@IsVerified", 1);
                                }
                                else if (dsGlobal.Tables[1].Rows[0]["ParameterType"].ToString() == "Report")
                                {
                                    for (int i = 0; i < dsGlobal.Tables[1].Rows.Count; i++)
                                    {
                                        myreportdocument.SetParameterValue(dsGlobal.Tables[1].Rows[i]["ParameterName"].ToString(),
                                             Request.QueryString[dsGlobal.Tables[1].Rows[i]["ParameterName"].ToString().Replace("@", "")].ToString());
                                    }
                                    //myreportdocument.SetParameterValue("Sdt", date);
                                    //myreportdocument.SetParameterValue("Edt", date);
                                    //myreportdocument.SetParameterValue("Displdate", DateTime.Now.Date);
                                }
                            }


                            Random rnd = new Random();
                            string TableName = dsGlobal.Tables[0].Rows[0]["ReportName"].ToString().Replace(".rpt", rnd.Next(1000, 100000).ToString());




                            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                            sqlDataAdapter.Fill(ds, TableName);

                            myreportdocument.SetDataSource(ds.Tables[TableName]);


                            myreportdocument.SetDatabaseLogon((string)ConfigurationManager.AppSettings["Uid"], (string)ConfigurationManager.AppSettings["Password"]);
                            myreportdocument.Refresh();
                            CrystalReportViewer1.EnableParameterPrompt = true;
                            CrystalReportViewer1.ReportSource = myreportdocument;
                            CrystalReportViewer1.AutoDataBind = true;
                            CrystalReportViewer1.RefreshReport();

                        }
                    }
                    else
                    {
                        ReportDocument myreportdocument = new ReportDocument();
                        string path = Server.MapPath("LandingReport.rpt").ToString();
                        myreportdocument.Load(path);
                        myreportdocument.SetDatabaseLogon((string)ConfigurationManager.AppSettings["Uid"], (string)ConfigurationManager.AppSettings["Password"]);
                        myreportdocument.Refresh();
                        CrystalReportViewer1.ReportSource = myreportdocument;
                    }
                exitPoint:;
                }
                catch (SqlException ex)
                {
                    Response.Write("<script>alert(" + ex.Message + ")</script>");

                }
                finally
                {

                }
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {


        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            try
            {
                CrystalReportViewer1.Dispose();
                CrystalReportViewer1 = null;
                //CrystalRpt.Close();
                //CrystalRpt.Dispose();
                //CrystalRpt = null;
                //mySubRepDoc.Close();
                //mySubRepDoc.Dispose();
                //mySubRepDoc = null;
                //ReportObject.Close();
                //ReportObject.Dispose();
                //ReportObject = null;
                GC.Collect();
                //File.Delete(tmpReportName);



            }
            catch
            { }
        }
    }
 