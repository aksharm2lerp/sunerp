#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e5525a5ebbd150730c1c423a91dfccf2379ba2788800ec4099befcc8cea337d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Employee__employeeDocumentList), @"mvc.1.0.view", @"/Areas/Admin/Views/Employee/_employeeDocumentList.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Business.Entities

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Business.SQL

#nullable disable
    ;
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Enums

#nullable disable
    ;
#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Extensions

#nullable disable
    ;
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using ERP.Helpers

#nullable disable
    ;
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\_ViewImports.cshtml"
using Business.Entities.Dynamic

#nullable disable
    ;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
 using Business.Entities.Employee

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
 using DocumentFormat.OpenXml.Office2010.Excel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"e5525a5ebbd150730c1c423a91dfccf2379ba2788800ec4099befcc8cea337d4", @"/Areas/Admin/Views/Employee/_employeeDocumentList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Employee__employeeDocumentList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<EmployeeDocument>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/vendors/simple-datatables/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-check-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("docActiveInactive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn editaddress IndexPagebtnEidtPadding"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OpenImage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/vendors/simple-datatables/simple-datatables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e5525a5ebbd150730c1c423a91dfccf2379ba2788800ec4099befcc8cea337d48539", async() => {
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
<div id=""EmployeeDocumentTable"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <h6 class=""cards-title"">
                Document List
            </h6>
        </div>
        <div class=""col-lg-6 text-align-right"">
            <a onclick=""fnEmployeeDocument(0)""
               class=""btn btn-primary px-5""
               href=""javascript:void(0)""
               data-id=""0""
               data-bs-toggle=""offcanvas""
               data-bs-target=""#canvasEmployeeDocument""
               aria-controls=""canvasEmployeeDocument"">
                Add Document
            </a>
        </div>
    </div>
");
#nullable restore
#line 24 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
     if (TempData["message"] != null)
    {
        var test = TempData["message"];

#line default
#line hidden
#nullable disable

            WriteLiteral("        <div class=\"alert alert-success\">\r\n            <strong>");
            Write(
#nullable restore
#line 28 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                     TempData["message"]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</strong>\r\n        </div>\r\n");
#nullable restore
#line 30 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"    <div class=""row"">
        <table class=""table table-striped"" id=""tblBankAccounts"">
            <thead>
                <tr>
                    <td>Sr No</td>
                    <td>Document Type</td>
                    <td>Document Name</td>
                    <td>Description</td>
                    <td>IsActive</td>
                    <td>Edit</td>
                    <td>Open</td>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 45 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#nullable disable

#nullable restore
#line 47 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <tr>\r\n                            <td>");
            Write(
#nullable restore
#line 50 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                 item.SrNo

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                            <td>");
            Write(
#nullable restore
#line 51 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                 item.DocumentTypeName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                            <td>");
            Write(
#nullable restore
#line 52 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                 item.DocumentName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                            <td>");
            Write(
#nullable restore
#line 53 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                 item.Description

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e5525a5ebbd150730c1c423a91dfccf2379ba2788800ec4099befcc8cea337d413590", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => 
#nullable restore
#line 55 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                                                                          item.IsActive

#line default
#line hidden
#nullable disable
            );
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onchange", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2055, "fnEmployeeDocumentActiveInactive(", 2055, 33, true);
            AddHtmlAttributeValue("", 2088, 
#nullable restore
#line 55 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                                                                                                                                     item.EmployeeDocumentID

#line default
#line hidden
#nullable disable
            , 2088, 24, false);
            AddHtmlAttributeValue("", 2112, ")", 2112, 1, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                            </td>\r\n\r\n                            <td>\r\n                                <a class=\'btn editaddress IndexPagebtnEidtPadding\'");
            BeginWriteAttribute("onclick", " onclick=\"", 2833, "\"", 2887, 3);
            WriteAttributeValue("", 2843, "fnEmployeeDocument(", 2843, 19, true);
            WriteAttributeValue("", 2862, 
#nullable restore
#line 66 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                                                                                                item.EmployeeDocumentID

#line default
#line hidden
#nullable disable
            , 2862, 24, false);
            WriteAttributeValue("", 2886, ")", 2886, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"
                                   href=""javascript:void(0)""
                                   data-bs-toggle=""offcanvas""
                                   data-bs-target=""#canvasEmployeeDocument""
                                   aria-controls=""canvasEmployeeDocument""
                                   data-id=""");
            Write(
#nullable restore
#line 71 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                             item.EmployeeDocumentID

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\"");
            BeginWriteAttribute("employeeid", "\r\n                                   employeeid=\"", 3236, "\"", 3301, 1);
            WriteAttributeValue("", 3285, 
#nullable restore
#line 72 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                                item.EmployeeID

#line default
#line hidden
#nullable disable
            , 3285, 16, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\'bx bx-edit\'></i>\r\n                                </a>\r\n                            </td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e5525a5ebbd150730c1c423a91dfccf2379ba2788800ec4099befcc8cea337d418578", async() => {
                WriteLiteral("\r\n                                    <iconify-icon icon=\"emojione-monotone:open-file-folder\"></iconify-icon>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-fileName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 77 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                                                                                                                                                          item.DocumentName

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["fileName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-fileName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["fileName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("download", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 82 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                    }

#line default
#line hidden
#nullable disable

#nullable restore
#line 82 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                     
                }

#line default
#line hidden
#nullable disable

            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvasEmployeeDocument"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"" id=""canvasHeaderNameDocument""></h5>
        <button type=""button"" class=""btn-close text-reset"" data-bs-dismiss=""offcanvas"" aria-label=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvInfoDocument"">
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e5525a5ebbd150730c1c423a91dfccf2379ba2788800ec4099befcc8cea337d422956", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    //var urlDeleteCompanyFromUser = \'Url.Action(\"DeleteBankAccount\", \"Employee\")\';\r\n    var urlAddUpdateDocument = \'");
            Write(
#nullable restore
#line 104 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                 Url.Action("AddUpdateEmployeeDocument", "Employee")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n    var urlisActiveInActive = \'");
            Write(
#nullable restore
#line 105 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                                Url.Action("ActiveInActiveEmployeeDocument","Employee")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"';

    function fnEmployeeDocument(employeeDocumentId) {
        //alert('fnEmployeeDocument invoked Added by dravesh for check');
        var _id = employeeDocumentId;//$(this).data('id');
        var _employeeId = $(""#EmployeeID"").val();
        if (_id > 0) {
            document.getElementById(""canvasHeaderNameDocument"").innerHTML = ""Update employee document details"";
        }
        else {
            document.getElementById(""canvasHeaderNameDocument"").innerHTML = ""Add employee document details"";
        }
        var _parameters = { employeeDocumentId: _id, employeeId: _employeeId };
        $.ajax({
            url: urlAddUpdateDocument,
            type: ""GET"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $(""#canvasEmployeeDocument"").show();//('hide');
                $('#dvInfoDocument').html(data);
            }
        });
    }

    function fnEmployeeDocumentActiveInactive(employeeDocumentId) {
        var _em");
            WriteLiteral(@"pDocId = employeeDocumentId;//$(this).data('id');
        var employeeId = $(""#EmployeeID"").val();
        var _checkBox = $(""#docActiveInactive"").is(':checked');
        var _docParameters = { employeeDocumentId: _empDocId, employeeId: employeeId, isActive: _checkBox };
        $.ajax({
            url: urlisActiveInActive,
            type: 'POST',
            data: _docParameters,
            success: function (data) {
                if (data.status) {
                    var test = Lobibox.notify('success', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message,
                    });
                    setTimeout(
                        function () {
                            window.location.reload();
                            //$(""#EmployeeAd");
            WriteLiteral(@"dessTable"").load(window.location.href + "" #EmployeeAddessTable"");
                        }, 3000);
                }
                else {
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: '");
            Write(
#nullable restore
#line 161 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                               MessageHelper.Error

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"'
                    });
                }
                $(""#EmployeeDocumentTable"").load(window.location.href + "" #EmployeeDocumentTable"");
            },
            error: function (error) {
                laddaStop(ls);
                Lobibox.notify('error', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom right',
                    msg: '");
            Write(
#nullable restore
#line 174 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Employee\_employeeDocumentList.cshtml"
                           MessageHelper.Error

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\'\r\n                });\r\n            }\r\n        }).always(function () {\r\n            hideloader();\r\n        });\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<EmployeeDocument>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
