#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b2c38ccec685d6c7f9ef647ed5305af6ada5e8362d5dbdd01635395b1824b67a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Employee__employeeemployeeEducationList), @"mvc.1.0.view", @"/Areas/Admin/Views/Employee/_employeeemployeeEducationList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
using Business.Entities.Employee;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b2c38ccec685d6c7f9ef647ed5305af6ada5e8362d5dbdd01635395b1824b67a", @"/Areas/Admin/Views/Employee/_employeeemployeeEducationList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Employee__employeeemployeeEducationList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<EmployeeEducation>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/vendors/simple-datatables/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/vendors/simple-datatables/simple-datatables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b2c38ccec685d6c7f9ef647ed5305af6ada5e8362d5dbdd01635395b1824b67a6447", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<div id=""EmployeeEducationTable"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <h6 class=""cards-title"">
                Education List
            </h6>
        </div>
        <div class=""col-lg-12 text-align-right"">
            <a onclick=""fnEmployeeEducation(0)""
               class=""btn btn-primary px-5""
               href=""javascript:void(0)""
               data-id=""0""
               data-bs-toggle=""offcanvas""
               data-bs-target=""#canvasEmployeeEducation""
               aria-controls=""canvasEmployeeEducation"">
                Add Education
            </a>
        </div>
    </div>
    <div class=""row"">
        <table class=""table table-striped"" id=""tblEmployeeEducations"">
            <thead>
                <tr>
                    <td>SrNo</td>
                    <td>School/University</td>
                    <td>Degree</td>
                    <td>Grade</td>
                    <td>Start Year</td>
                    <td>End Year</td>
");
            WriteLiteral("                    <td>Is Current Eduction</td>\r\n                    <td>Update</td>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 39 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                     foreach (var item in Model)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 45 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                           Write(item.SrNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 46 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                           Write(item.SchoolOrUniversity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 47 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                           Write(item.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 48 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                           Write(item.Grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 49 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                           Write(item.StartDate.ToDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 50 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                           Write(item.EndDate.ToDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 52 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                             if (@item.IsCurrentEducation)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Pursuing</td>\r\n");
#nullable restore
#line 55 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Completed</td>\r\n");
#nullable restore
#line 59 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                <a class=\'btn editeducation\'");
            BeginWriteAttribute("onclick", " onclick=\"", 2417, "\"", 2473, 3);
            WriteAttributeValue("", 2427, "fnEmployeeEducation(", 2427, 20, true);
#nullable restore
#line 61 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
WriteAttributeValue("", 2447, item.EmployeeEducationID, 2447, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2472, ")", 2472, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"
                           href=""javascript:void(0)""
                           data-bs-toggle=""offcanvas""
                           data-bs-target=""#canvasEmployeeEducation""
                           aria-controls=""canvasEmployeeEducation""
                           data-id=""");
#nullable restore
#line 66 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                               Write(item.EmployeeEducationID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("employeeid", "\r\n                           employeeid=\"", 2785, "\"", 2842, 1);
#nullable restore
#line 67 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
WriteAttributeValue("", 2826, item.EmployeeID, 2826, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\'bx bx-edit\'></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 70 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvasEmployeeEducation"" style=""visibility: visible; width : 75% !important"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"" id=""canvasHeaderEducation""></h5>
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"" >
        <div id=""dvInfoEducation"">
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2c38ccec685d6c7f9ef647ed5305af6ada5e8362d5dbdd01635395b1824b67a15380", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    //var urlDeleteCompanyFromUser = \'Url.Action(\"DeleteEmployeeEducation\", \"Employee\")\';\r\n    var urlAddUpdateEmployeeEducation = \'");
#nullable restore
#line 90 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\Employee\_employeeemployeeEducationList.cshtml"
                                    Write(Url.Action("AddUpdateEmployeeEducation", "Employee"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    function fnEmployeeEducation(employeeEducationId) {
        var _id = employeeEducationId;//$(this).data('id');
        var _employeeId = $(""#EmployeeID"").val();
        if (_id > 0) {
            document.getElementById(""canvasHeaderEducation"").innerHTML = ""Update employee education"";
        }
        else {
            document.getElementById(""canvasHeaderEducation"").innerHTML = ""Add employee education"";
        }
        var _parameters = { employeeEducationId: _id, employeeId: _employeeId };
        $.ajax({
            url: urlAddUpdateEmployeeEducation,
            type: ""GET"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $(""#canvasEmployeeEducation"").show();//('hide');
                $('#dvInfoEducation').html(data);
            }
        });
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<EmployeeEducation>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
