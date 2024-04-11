using AspNetCoreHero.ToastNotification.Helpers;
using Business.Entities.EmployeeAttendanceSummary;
using Business.Entities.HR.ReportsHR;
using Business.Entities.Master.EmployeeCategory;
using Business.Entities.Master.EmployementType;
using Business.Interface;
using Business.Interface.IEmployee;
using Business.Interface.IEmployeeAttendanceSummary;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using ERP.Controllers;
using ERP.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Reporting.NETCore;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.HR.Controllers
{
    [Area("HR"), Authorize]
    public class ReportsHRController : SettingsController
    {
        private readonly IEmployeeAttendanceSummaryService _employeeAttendanceSummaryService;
        private readonly IMasterService _masterService;
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportsHRController(IEmployeeAttendanceSummaryService employeeAttendanceSummaryService, IMasterService masterService, IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeAttendanceSummaryService = employeeAttendanceSummaryService;
            _masterService = masterService;
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetEmployeeAttendanceSummary(int employeeCategoryId, int employeeId, int month, int year, int departmentId, string searchString, bool isDownload)

        {
            try
            {
                int userId = USERID;
                month = month <= 0 ? DateTime.Now.Month : month;
                year = year <= 0 ? DateTime.Now.Year : year;

                ViewData["EmployeeCategoryID"] = employeeCategoryId;
                ViewData["MonthYear"] = new DateTime(year, month, 1);
                ViewData["DepartmentID"] = departmentId;
                ViewData["SearchString"] = searchString;

                System.Data.DataSet dataSet = _employeeAttendanceSummaryService.GetEmployeeAllAttendanceSummary(employeeCategoryId, userId, month, year, departmentId, searchString).Result;

                if (dataSet.Tables.Count > 0)
                {
                    if (isDownload)
                    {
                        return ExportToExcel(dataSet, "EmployeesAttendanceList");
                    }
                    else
                    {
                        return View(dataSet);
                    }
                }
                else
                {
                    return View("GetEmployeeAttendanceSummary");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IActionResult GetEmployeeDetailSummary(int employeeCategoryId, int departmentId, string searchstring, bool isDownload, int employmentStatusid)

        {
            try
            {
                ViewData["EmployeeCategoryID"] = employeeCategoryId;
                ViewData["DepartmentID"] = departmentId;
                ViewData["SearchString"] = searchstring;
                ViewData["employmentStatusid"] = employmentStatusid;
                System.Data.DataSet dataSet = _employeeAttendanceSummaryService.GetEmployeeAllDetailSummary(employeeCategoryId, departmentId, searchstring, employmentStatusid).Result;

                if (dataSet.Tables.Count > 0)
                {
                    if (isDownload)
                    {
                        return ExportToExcel(dataSet, "EmployeesList");
                    }
                    else
                    {
                        return View(dataSet);
                    }
                }
                else
                {
                    return View("GetEmployeeDetailSummary");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public JsonResult GetEmployees(string empString)
        {
            try
            {
                var employees = _masterService.GetEmployeesByName(empString);
                var employeeresult = employees.Select(x => new { label = x.EmployeeName, val = x.EmployeeID });
                return Json(employeeresult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //[HttpGet]
        //public JsonResult GetEmployeeslist(string empString)
        //{
        //    try
        //    {
        //        var employeesData = _masterService.GetEmployeesByName(empString);
        //        var EmpIds = (from emp in employeesData
        //                        where emp.EmployeeName.StartsWith(empString)
        //                        select new
        //                        {
        //                            label = emp.EmployeeName,
        //                            val = emp.EmployeeID
        //                        }).ToList();
        //        return Json(EmpIds);
        //    }
        //    catch
        //    {
        //        return Json(false);
        //    }
        //}

        #region Export to excel 
        public IActionResult ExportToExcel(System.Data.DataSet dataSet, string filename)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataSet);
                using (MemoryStream stream = new MemoryStream())
                {

                    wb.SaveAs(stream);

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename + DateTime.Now + ".xlsx");
                }
            }

        }
        #endregion Export to excel


        #region Employee Salary Summuary

        [HttpGet]
        public IActionResult GetEmployeeSalarySummary(int employeeCategoryId, int companyId, int month, int year, int employeeId, bool isDownload, int employmentTypeId, DateTime salaryDate, int isSalProcess)
        {
            //int employmentTypeId,DateTime salaryDate
            try
            {
                //string dateString = "Tue Apr 04 2023 16:44:09 GMT+0530 (India Standard Time)";
                //DateTime dateTime = DateTime.Parse(salaryDate, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

                int userId = USERID;
                month = month <= 0 ? DateTime.Now.Month : month;
                year = year <= 0 ? DateTime.Now.Year : year;

                ViewData["EmployeeCategoryID"] = employeeCategoryId;
                ViewData["MonthYear"] = new DateTime(year, month, 1);
                ViewData["EmployeeID"] = employeeId;
                ViewData["CompanyID"] = companyId == 0 ? COMPANYID : companyId;
                ViewData["EmploymentTypeID"] = employmentTypeId;

                if (isSalProcess == 1)
                {
                    System.Data.DataSet dataSet = _employeeAttendanceSummaryService.ProcesSalary(year, month, companyId, employmentTypeId, employeeCategoryId, userId, salaryDate).Result;
                    var test = dataSet;
                    return View(dataSet);
                }
                else
                {
                    System.Data.DataSet dataSet = _employeeAttendanceSummaryService.GetEmployeeSalarySummary(employeeCategoryId, userId, companyId, month, year, employeeId).Result;
                    if (dataSet.Tables.Count > 0)
                    {
                        if (isDownload)
                        {
                            return ExportToExcel(dataSet, "GetEmployeeSalarySummary");
                        }
                        else
                        {
                            return View(dataSet);
                        }
                    }
                    else
                    {
                        return View("GetEmployeeSalarySummary");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Employee Salary Summuary

        #region Salary Process
        [HttpPost]
        public IActionResult RunSalaryProcess()
        {
            return View("GetEmployeeSalarySummary");
        }

        #endregion Salary Process

        #region Salary Process Edit
        [HttpGet]
        public IActionResult Edit(int editId, int month, int year, int companyId, int employeeCategoryId)
        {
            // _employeeAttendanceSummaryService.GetEmployeeSalarySummaryEdit(editId);
            //return View("EditEmployeeSalaryRecord");
            try
            {
                month = month <= 0 ? DateTime.Now.Month : month;
                year = year <= 0 ? DateTime.Now.Year : year;
                ViewData["EmployeeID"] = editId;
                ViewData["CompanyID"] = companyId;
                ViewData["Month"] = month;
                ViewData["Year"] = year;
                ViewData["EmployeeCategoryID"] = employeeCategoryId;
                DataTable employeeSalaryBreakup = _employeeAttendanceSummaryService.GetEmployeeSalarySummaryEdit(editId, year, month, companyId).Result;
                return View("EditEmployeeSalaryBreakup", employeeSalaryBreakup);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> ApproveSaveEmployeeSalary(string employeeFinalSalaryJson, int employeeId, int month, int year, int companyId, int employeeCategoryId)
        {
            try
            {
                DataTable dataTable = new DataTable();
                List<EmployeeFinalSalaryCalculationModel> employeeSalaryBreakupList = JsonConvert.DeserializeObject<List<EmployeeFinalSalaryCalculationModel>>(employeeFinalSalaryJson);

                EmployeeFinalSalaryCalculationModel employeeFinalSalaryCalculationModel = new EmployeeFinalSalaryCalculationModel
                {
                    EmployeeID = employeeId,
                    CompanyID = companyId,
                    Month = month,
                    Year = year,
                    EmployeeCategoryID = employeeCategoryId,
                    UserId = USERID,
                    IsVerified = true,
                };
                #region Creating DataTable.

                dataTable.Columns.Clear();
                //dataTable.Columns.Add(new DataColumn("EmployeeSalaryBreakupID", typeof(int)));
                //dataTable.Columns.Add(new DataColumn("EmployeeID", typeof(int)));
                //dataTable.Columns.Add(new DataColumn("SalaryHeadID", typeof(int)));
                //dataTable.Columns.Add(new DataColumn("SalaryHeadValue", typeof(decimal)));

                dataTable.Columns.Add(new DataColumn("EmployeeFinalSalaryCalculationID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("Year", typeof(int)));
                dataTable.Columns.Add(new DataColumn("Month", typeof(int)));
                dataTable.Columns.Add(new DataColumn("CompanyID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("EmployeeID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("SalaryHeadName", typeof(string)));
                dataTable.Columns.Add(new DataColumn("SalaryHeadLabel", typeof(string)));
                dataTable.Columns.Add(new DataColumn("SalaryFormula", typeof(string)));
                dataTable.Columns.Add(new DataColumn("CalculatedValue", typeof(decimal)));

                foreach (var item in employeeSalaryBreakupList)
                {
                    DataRow dataRow = dataTable.NewRow();

                    dataRow["EmployeeFinalSalaryCalculationID"] = 0;
                    dataRow["Year"] = year;
                    dataRow["Month"] = month;
                    dataRow["CompanyID"] = companyId;
                    dataRow["EmployeeID"] = employeeId;
                    dataRow["SalaryHeadName"] = item.SalaryHeadName;
                    dataRow["SalaryHeadLabel"] = item.SalaryHeadLabel;
                    dataRow["SalaryFormula"] = item.SalaryFormula;
                    dataRow["CalculatedValue"] = item.CalculatedValue;

                    dataTable.Rows.Add(dataRow);
                }

                #endregion Creating DataTable.

                int salaryId = await _employeeAttendanceSummaryService.ApproveSaveEmployeeSalaryAsync(employeeFinalSalaryCalculationModel, dataTable);
                if (salaryId > 0)
                {
                    return Json(new { status = true, message = "Employee salary updated successfully." });
                }
                else
                    return Json(new { status = false, message = MessageHelper.Error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion Salary Process Edit

        #region Varify Salary

        [HttpPost]
        public async Task<JsonResult> VerifySalary(int year, int month, int companyId, int employeeId, int employeeCategoryId)
        {
            try
            {
                int userId = USERID;
                var result = await _employeeAttendanceSummaryService.VerifyEmplyeeSalary(year, month, companyId, employeeId, employeeCategoryId, userId);

                if (result > 0)
                    return Json(new { status = true, MessageHelper.Updated });

                else
                    return Json(new { status = true, MessageHelper.Error });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateVerifiedSalaryTable(List<UpdateSalary> dataTable)
        {
            try
            {
                var list = dataTable;
                //var test1 = JsonConvert.DeserializeObject<DataTable>(dataTable);
                //DataTable data = JsonConvert.DeserializeObject<DataTable>(dataTable);
                //var emp = data;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Varify Salary


        #region Report print

        public IActionResult LoadDefaultASPX()
        {
            string path = "C:\\Users\\Lenovo\\Documents\\GitHub\\aksharm2l\\ERP\\Areas\\HR\\Views\\ReportsHR";
            FileInfo fileInfo = new FileInfo("C:\\Users\\Lenovo\\Documents\\GitHub\\aksharm2l\\ERP\\Areas\\HR\\Views\\ReportsHR\\Default.aspx");
            if (fileInfo.Exists)
                return View("C:/Users/Lenovo/Documents/GitHub/aksharm2l/ERP/Areas/HR/Views/ReportsHR/Default.aspx");
            else
                return View();
        }
        public IActionResult ReportPrint(bool isPrint)
        {
            try
            {
                if (isPrint)
                {
                    string renderFormat = "PDF";
                    string extension = "pdf";
                    string mimetype = "text/html";
                    using var report = new LocalReport();

                    var dt = new DataTable();

                    dt = EmployeeList();

                    report.DataSources.Add(new ReportDataSource("dsEmployee", dt));

                    var parameters = new[] { new ReportParameter("param1", "RDLC Employee Report Example") };
                    //C:\Users\Lenovo\Documents\GitHub\aksharm2l\ERP\wwwroot\Reports\employeeRpt.rdlc
                    report.ReportPath = $"{_webHostEnvironment.WebRootPath}\\Reports\\employeeRpt.rdlc";
                    report.SetParameters(parameters);
                    var pdf = report.Render(renderFormat);
                    report.Refresh();

                    //report.SubreportProcessing += new SubreportProcessingEventHandler(SubReportProcessing);

                    var file = File(pdf, mimetype, "NewReport." + extension);

                    return File(pdf, mimetype, "NewReport." + extension);
                }
                else
                    return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            try
            {

                string renderFormat = "PDF";
                string extension = "pdf";
                string mimetype = "text/html";
                using var report = new LocalReport();

                var dt = new DataTable();

                dt = EmployeeList();

                report.DataSources.Add(new ReportDataSource("dsEmployee", dt));

                var parameters = new[] { new ReportParameter("param1", "RDLC Employee Report Example") };
                //C:\Users\Lenovo\Documents\GitHub\aksharm2l\ERP\wwwroot\Reports\employeeRpt.rdlc
                report.ReportPath = $"{_webHostEnvironment.WebRootPath}\\Reports\\employeeRpt.rdlc";
                report.SetParameters(parameters);
                var pdf = report.Render(renderFormat);

                report.SubreportProcessing += new SubreportProcessingEventHandler(SubReportProcessing);

                var file = File(pdf, mimetype, "NewReport." + extension);
                return View(file);
                //return File(pdf, mimetype, "NewReport." + extension);
            }
            catch (Exception)
            {

                throw;
            }
        }

        void SubReportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            int empId = int.Parse(e.Parameters["EmployeeID"].Values[0].ToString());
            ReportDataSource reportDataSource = new ReportDataSource();

        }
        public DataTable EmployeeList()
        {
            try
            {
                var dataTable = new DataTable();

                dataTable.Columns.Add("EmployeeID");
                dataTable.Columns.Add("EmployeeName");
                dataTable.Columns.Add("TotalCount");

                var empList = _employeeService.GetAllEmployeesForDropDown(0, COMPANYID).Result;

                foreach (var emp in empList)
                {
                    var row = dataTable.NewRow();
                    row["EmployeeID"] = emp.EmployeeID;
                    row["EmployeeName"] = emp.EmployeeName;
                    row["TotalCount"] = 1;

                    dataTable.Rows.Add(row);
                }

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Report print

        #region Employee Verified Salary list
        
        

        [HttpGet]
        public IActionResult VerifyEmployeeSalaryList(int employeeCategoryId, int companyId, int month, int year, int employeeId, bool isDownload, int employmentTypeId, DateTime salaryDate, int isSalProcess, int departmentID)
        {
            //int employmentTypeId,DateTime salaryDate   
            try
            {
                //string dateString = "Tue Apr 04 2023 16:44:09 GMT+0530 (India Standard Time)";
                //DateTime dateTime = DateTime.Parse(salaryDate, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

                int userId = USERID;
                month = month <= 0 ? DateTime.Now.Month : month;
                year = year <= 0 ? DateTime.Now.Year : year;

                ViewData["EmployeeCategoryID"] = employeeCategoryId;
                ViewData["MonthYear"] = new DateTime(year, month, 1);
                ViewData["EmployeeID"] = employeeId;
                ViewData["CompanyID"] = companyId == 0 ? COMPANYID : companyId;
                ViewData["EmploymentTypeID"] = employmentTypeId;
                ViewData["DepartmentID"] = departmentID;


                if (isSalProcess == 2)
                {
                    System.Data.DataSet dataSet = _employeeAttendanceSummaryService.GetVerifiedEmployeeSalarySummary(employeeCategoryId, userId, companyId, month, year, employeeId, employmentTypeId, departmentID).Result;
                    if (dataSet.Tables.Count > 0)
                    {
                        if (isDownload)
                        {
                            return ExportToExcel(dataSet, "VerifyEmployeeSalaryList");
                        }
                        else
                        {
                            return View(dataSet);
                        }
                    }
                    else
                    {
                        return View("VerifyEmployeeSalaryList");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult GetVerifyEmployeeSalaryList()
        {
            return View("VerifyEmployeeSalaryList");
        }
        #endregion Employee Verified Salary list

    }
    public class UpdateSalary
    {
        public string SalaryHeadLabel { get; set; }
        public string SalaryHeadName { get; set; }
        public string CalculatedValue { get; set; }
        public string SalaryFormula { get; set; }
    }
}
