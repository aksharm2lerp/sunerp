#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6ea13b545800cb7c6f3985e079de312e6976d57dd8d86867ab1536a383f833ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HR_Views_ReportsHR_GetEmployeeAttendanceSummary), @"mvc.1.0.view", @"/Areas/HR/Views/ReportsHR/GetEmployeeAttendanceSummary.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Business.Entities

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Business.SQL

#nullable disable
    ;
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Enums

#nullable disable
    ;
#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Extensions

#nullable disable
    ;
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Helpers

#nullable disable
    ;
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Business.Entities.Dynamic

#nullable disable
    ;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
 using System.Data;

#nullable disable
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
 using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6ea13b545800cb7c6f3985e079de312e6976d57dd8d86867ab1536a383f833ab", @"/Areas/HR/Views/ReportsHR/GetEmployeeAttendanceSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/HR/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_HR_Views_ReportsHR_GetEmployeeAttendanceSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataSet>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "HR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ReportsHR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetEmployeeAttendanceSummary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("EmployeeCategoryID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "EmployeeCategoryID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("DepartmentID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "DepartmentID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
  
    ViewData["Title"] = "Employee Attendance Summury Report";
    Layout = "~/Views/Shared/_LayoutMaster.cshtml";

#line default
#line hidden
#nullable disable

#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
  
    List<string> strTimeforRow = new List<string>();
    DateTime date = ViewBag.MonthYear;
    //string monthyear = string.Concat(date.Year + "-" + date.Month);
    string monthyear = date.ToString("yyyy-MM");
    int empCatId = ViewBag.EmployeeCategoryID;
    int deptId = ViewBag.DepartmentID;


#line default
#line hidden
#nullable disable

            WriteLiteral(@"
<div class=""container"" id=""employeePresent"">
    <div class=""row"">
        <div class=""col-sm-12 col-md-12 col-lg-12 mx-auto"">
            <div class=""card border-0 shadow rounded-3"">
                <div class=""card-body"">

                    <div class=""col-sm-12 col-md-6 col-lg-6"">
                        <div class=""page-breadcrumb align-items-center"">
                            <div class=""p-2"">
                                <nav aria-label=""breadcrumb"">
                                    <ol class=""breadcrumb mb-0 p-0"">
                                        <li class=""breadcrumb-item"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea13b545800cb7c6f3985e079de312e6976d57dd8d86867ab1536a383f833ab9351", async() => {
                WriteLiteral("<i class=\"bx bx-home-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </li>
                                        <li class=""breadcrumb-item active"" aria-current=""page"">Employee Attendance</li>
                                    </ol>
                                </nav>
                            </div>
                        </div>
                    </div>


                    <hr />

                    <div class=""row mb-1"">
                        <label class=""col-3 col-form-label"">Employee Category</label>
                        <div class=""col-3"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea13b545800cb7c6f3985e079de312e6976d57dd8d86867ab1536a383f833ab11556", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea13b545800cb7c6f3985e079de312e6976d57dd8d86867ab1536a383f833ab11873", async() => {
                    WriteLiteral("Select Category");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = 
#nullable restore
#line 45 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                                                                                       EmployeeExtension.GetAllEmployeeCategoryMaster()

#line default
#line hidden
#nullable disable
            ;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => 
#nullable restore
#line 45 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                                                                                                                                                   empCatId

#line default
#line hidden
#nullable disable
            );
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <label class=\"col-3 col-form-label\">Select Month & Year</label>\r\n                        <div class=\"col-3\">\r\n                            <input type=\"month\" class=\"form-control\" id=\"month\"");
            BeginWriteAttribute("value", " value=\"", 2402, "\"", 2420, 1);
            WriteAttributeValue("", 2410, 
#nullable restore
#line 51 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                                                        monthyear

#line default
#line hidden
#nullable disable
            , 2410, 10, false);
            EndWriteAttribute();
            WriteLiteral(@">
                        </div>
                    </div>

                    <div class=""row mb-1"">
                        <label class=""col-sm-3 col-form-label"">Search Keyword</label>
                        <div class=""col-sm-3"" id=""idForDropdown"">
                            <input type=""hidden"" id=""EmployeeID"" class=""form-control"" />
                            <input type=""text"" class=""form-control bs-autocomplete"" id=""employeeText"" name=""EmployeeName"" placeholder=""Enter Searching text.""");
            BeginWriteAttribute("value", " value=\"", 2931, "\"", 2960, 1);
            WriteAttributeValue("", 2939, 
#nullable restore
#line 59 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                                                                                                                                      ViewBag.SearchString

#line default
#line hidden
#nullable disable
            , 2939, 21, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    \r\n\r\n                        </div>\r\n                        <label class=\"col-3 col-form-label\">Department</label>\r\n                        <div class=\"col-3\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea13b545800cb7c6f3985e079de312e6976d57dd8d86867ab1536a383f833ab17727", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea13b545800cb7c6f3985e079de312e6976d57dd8d86867ab1536a383f833ab18044", async() => {
                    WriteLiteral("Select Department");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = 
#nullable restore
#line 65 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                                                                           EmployeeExtension.GetAllDepartmentText()

#line default
#line hidden
#nullable disable
            ;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => 
#nullable restore
#line 65 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                                                                                                                               deptId

#line default
#line hidden
#nullable disable
            );
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>

                    <div class=""text-end mb-3"">
                        <input type=""button"" value=""Export to excel"" class=""btn btn-outline-primary px-5 btn-sm"" onclick=""fnSearch(true)"" />

                        <button id=""btnSearchEmployeePresent"" type=""button"" onclick=""fnSearch(false)"" class=""btn btn-outline-primary px-5 btn-sm"">Search</button>
                    </div>

                    <div id=""EmployeeAddessTable"">
");
#nullable restore
#line 78 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                         if (Model.Tables[0].Columns.Count > 2)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral(@"                            <div class=""row"" style=""overflow:auto; height:350px; width:100%;"">
                                <table class=""table table-striped w-auto"" style=""white-space: nowrap; font-size:inherit !important;"">
                                    <!--style=""display:block; overflow: auto; white-space: nowrap;""-->
                                    <thead style=""position: sticky; top: 0; background-color:#e9ecf8; color:black; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"">
                                        <tr>
");
#nullable restore
#line 85 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                             foreach (DataColumn dataColumn in Model.Tables[0].Columns)
                                            {
                                                if (@dataColumn.ColumnName.ToString() == "EName")
                                                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                    <th >");
            Write(
#nullable restore
#line 89 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                          dataColumn.ToString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</th>\r\n");
#nullable restore
#line 90 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                    <th >");
            Write(
#nullable restore
#line 93 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                          dataColumn.ToString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</th>\r\n");
#nullable restore
#line 94 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                }
                                                strTimeforRow.Add(dataColumn.ToString());
                                            }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                        </tr>\r\n                                    </thead>\r\n");
#nullable restore
#line 99 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                     foreach (DataRow row in Model.Tables[0].Rows)
                                    {
                                        if (row["Desc"].ToString() == "TotalTime")
                                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                            <tr style=\"background-color:azure; color:black; font-family:\'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif;\">\r\n");
#nullable restore
#line 104 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                 foreach (string timeRow in strTimeforRow)
                                                {
                                                    

#line default
#line hidden
#nullable disable

#nullable restore
#line 106 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                     if (!string.IsNullOrEmpty(row[timeRow].ToString()))
                                                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                            <td>");
            Write(
#nullable restore
#line 108 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                                 row[timeRow]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n");
#nullable restore
#line 109 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                        <td>-</td>\r\n");
#nullable restore
#line 113 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                    }

#line default
#line hidden
#nullable disable

#nullable restore
#line 113 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                     
                                                }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                            </tr>\r\n");
#nullable restore
#line 116 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                            <tr>\r\n");
#nullable restore
#line 120 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                 foreach (string timeRow in strTimeforRow)
                                                {
                                                    

#line default
#line hidden
#nullable disable

#nullable restore
#line 122 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                     if (!string.IsNullOrEmpty(row[timeRow].ToString()))
                                                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                        <td>");
            Write(
#nullable restore
#line 124 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                             row[timeRow]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n");
#nullable restore
#line 125 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                        <td>-</td>\r\n");
#nullable restore
#line 129 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                    }

#line default
#line hidden
#nullable disable

#nullable restore
#line 129 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                                     
                                                }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                            </tr>\r\n");
#nullable restore
#line 132 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                </table>\r\n                            </div>\r\n");
#nullable restore
#line 136 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral(@"                            <div class=""text-center"">
                                <h1><iconify-icon icon=""mdi:text-box-remove-outline"" style=""color: #37569d;"" width=""100""></iconify-icon></h1>
                                <h3 style=""color: red;"">No Data Found</h3>
                            </div>
");
#nullable restore
#line 143 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                        }

#line default
#line hidden
#nullable disable

            WriteLiteral("                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            Write(
#nullable restore
#line 153 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
 await Html.PartialAsync("_ValidationScriptsPartial")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"
<script type=""text/javascript"">
    function fnSearch(obj) {

        var employeeCategoryId = $('#EmployeeCategoryID').val();

        var departmentId = $('#DepartmentID').val();

        var employeeId = $('#employeeText').val();

        var monthDate = $('#month').val();
        //const dateString = ""2023-03-16"";
        const year = monthDate.slice(0, 4); // ""2023""
        const month = monthDate.slice(5, 7);

        var isdownload = obj;

        var url = '");
            Write(
#nullable restore
#line 170 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\HR\Views\ReportsHR\GetEmployeeAttendanceSummary.cshtml"
                    Url.Action("GetEmployeeAttendanceSummary","ReportsHR")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"';

        var newurl = url + '?employeeCategoryId=' + employeeCategoryId + '&employeeId=' + employeeId + '&month=' + month + '&year=' + year + '&departmentId=' + departmentId + '&searchString=' + employeeId + '&isDownload=' + isdownload;

        window.location.href = newurl;
    };
</script>


<!--    Important Code Block
");
            WriteLiteral("-->\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataSet> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
