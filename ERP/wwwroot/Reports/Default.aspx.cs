//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StiHydraAksharSource"].ConnectionString);
    SqlCommand command = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<Employee> employees = new List<Employee>();
            string query = "EmployeeID, CONCAT(PrefixName,' ',FirstName, ' ', LastName) EmployeeName , count(1)over() as TotalCount FROM dbo.EmployeeMaster EM WITH (NOLOCK)";

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                //while (reader.Read())
                //{
                //    Employee employee = new Employee();
                //    employee.EmployeeID = Convert.ToInt32(reader[0].ToString());
                //    employee.EmployeeName = reader[1].ToString();
                //    employee.TotalCount = Convert.ToInt32(reader[2].ToString());
                //    employees.Add(employee);
                //}
                connection.Close();

                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/Report1.rdlc");
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("C:\\Users\\Lenovo\\Documents\\GitHub\\aksharm2l\\ERPReports\\Reports\\employeeRpt.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rdc = new ReportDataSource("dsEmployee", dt);
                //report.DataSources.Add(new ReportDataSource("dsEmployee", dt));
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.DataBind();
        }
        }
        catch
        {
            throw;
        }
    }
}
public class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public int TotalCount { get; set; }
}
