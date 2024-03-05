using Business.Entities.EmployeeGatepass;
using Business.Interface.IEmployeeAttendanceSummary;
using Business.Interface.IGatePassService;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Reporting.NETCore;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace ERP.Areas.ReportViewer
{
    [Area("ReportViewer"), Authorize]
    [DisplayName("Report")]
    public class ReportViewerController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IGatePassService _gatePassService;
        private readonly IEmployeeAttendanceSummaryService _employeeAttendanceSummaryService;
        public ReportViewerController(IWebHostEnvironment hostEnvironment, IGatePassService gatePassService, IEmployeeAttendanceSummaryService employeeAttendanceSummaryService)
        {

            _hostEnvironment = hostEnvironment;
            _gatePassService = gatePassService;
            _employeeAttendanceSummaryService = employeeAttendanceSummaryService;
        }
        //public IActionResult OnPostGetPDF() => PrepareReport("PDF", "pdf", "application/pdf");
        [HttpPost]
        public IActionResult OnPostGetHTML(int employeeGatepassId) => PrepareReport("HTML5", "html", "text/html", employeeGatepassId);
        
        [HttpPost]
        public IActionResult OnPostGetSalarySummaryReportHTML(int employeeId, int month, int year, int companyId, int employeeCategoryId) => PrepareSalarySummaryReport("HTML5", "html", "text/html", employeeId,month,year,companyId,employeeCategoryId);
        
        //public IActionResult OnPostGetDOCX() => PrepareReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        //public IActionResult OnPostGetXLSX() => PrepareReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        private IActionResult PrepareReport(string renderFormat, string extension, string mimeType, int employeeGatepassId)
        {
            try
            {
                //var report = new LocalReport();
                string rptpath = _hostEnvironment.WebRootPath;
                rptpath = rptpath + "\\Reports\\EmployeeGatePass.rdl";
                //Report.Load(report, WidgetPrice, GizmoPrice);
                var parameters = new[] {
                  //  new ReportParameter("EmployeeID", Convert.ToString(11721)),
                new ReportParameter("EmployeeGatePassID", Convert.ToString(employeeGatepassId))
            };
                //using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("ReportViewerCore.Sample.AspNetCore.Reports.Report.rdlc");
                //var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream( rptpath );

                //report.LoadReportDefinition(rs);
                //report.DataSources.Add(new ReportDataSource("Items", items));

                DataTable employeeGatePass = _gatePassService.GetEmployeeGatePassAsyncForPrint(employeeGatepassId).Result;



                System.IO.StreamReader rptStream = new System.IO.StreamReader(rptpath);



                LocalReport report = new LocalReport();
                report.DataSources.Add(new ReportDataSource("DataSetGatePass", employeeGatePass));
                report.LoadReportDefinition(rptStream);
                report.SetParameters(parameters);
                report.Refresh();
                var pdf = report.Render(renderFormat);

                FileContentResult file = File(pdf, mimeType, "report." + extension);

                byte[] byteArray = file.FileContents; // Assuming you have a byte array

                string result = Encoding.UTF8.GetString(byteArray);

                return Json(new { status = true, data = result });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //public IActionResult Index()
        //{

        //    return View();
        //}
        private IActionResult PrepareSalarySummaryReport(string renderFormat, string extension, string mimeType, int employeeId, int month, int year, int companyId, int employeeCategoryId)
        {
            try
            {
                //var report = new LocalReport();
                string rptpath = _hostEnvironment.WebRootPath;

                //  Please change below path according to your rdl file.
                rptpath = rptpath + "\\Reports\\EmployeeGatePass.rdl";
                //Report.Load(report, WidgetPrice, GizmoPrice);
                var parameters = new[] {
                  //  new ReportParameter("EmployeeID", Convert.ToString(11721)),
                new ReportParameter("EmployeeId", Convert.ToString(employeeId))
                ,new ReportParameter("Month", Convert.ToString(month))
                ,new ReportParameter("Year", Convert.ToString(year))
                ,new ReportParameter("CompanyId", Convert.ToString(companyId))
            };
                //using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("ReportViewerCore.Sample.AspNetCore.Reports.Report.rdlc");
                //var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream( rptpath );

                //report.LoadReportDefinition(rs);
                //report.DataSources.Add(new ReportDataSource("Items", items));

                DataTable employeeSalaryBreakup = _employeeAttendanceSummaryService.GetEmployeeSalarySummaryEdit(employeeId, year, month, companyId).Result;



                System.IO.StreamReader rptStream = new System.IO.StreamReader(rptpath);

                LocalReport report = new LocalReport();
                //Change below name according to its data set from "DataSetGatePass" to "Your dataset name".
                report.DataSources.Add(new ReportDataSource("DataSetGatePass", employeeSalaryBreakup));
                report.LoadReportDefinition(rptStream);
                report.SetParameters(parameters);
                report.Refresh();
                var pdf = report.Render(renderFormat);

                FileContentResult file = File(pdf, mimeType, "report." + extension);

                byte[] byteArray = file.FileContents; // Assuming you have a byte array

                string result = Encoding.UTF8.GetString(byteArray);

                return Json(new { status = true, data = result });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}