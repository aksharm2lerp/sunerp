#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "cf5989454095688db91ee5dba0b9670601a9547a0858353a56ee49c2e4ab3184"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Customer__customerDocumentList), @"mvc.1.0.view", @"/Areas/Admin/Views/Customer/_customerDocumentList.cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
 using Business.Entities.Customer

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
 using DocumentFormat.OpenXml.Office2010.Excel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"cf5989454095688db91ee5dba0b9670601a9547a0858353a56ee49c2e4ab3184", @"/Areas/Admin/Views/Customer/_customerDocumentList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Customer__customerDocumentList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<CustomerDocument>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/vendors/simple-datatables/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-check-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("docActiveInactive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/vendors/simple-datatables/simple-datatables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cf5989454095688db91ee5dba0b9670601a9547a0858353a56ee49c2e4ab31847119", async() => {
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
<div id=""CustomerDocumentTable"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <h6 class=""cards-title"">
                Document List
            </h6>
        </div>
        <div class=""col-lg-12 text-align-right"">
            <a onclick=""fnCustomerDocument(0)""
               class=""btn btn-primary px-5""
               href=""javascript:void(0)""
               data-id=""0""
               data-bs-toggle=""offcanvas""
               data-bs-target=""#canvasCustomerDocument""
               aria-controls=""canvasCustomerDocument"">
                Add Document
            </a>
        </div>
    </div>
");
#nullable restore
#line 24 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
     if (TempData["message"] != null)
    {
        var test = TempData["message"];

#line default
#line hidden
#nullable disable

            WriteLiteral("        <div class=\"alert alert-success\">\r\n            <strong>");
            Write(
#nullable restore
#line 28 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                     TempData["message"]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</strong>\r\n        </div>\r\n");
#nullable restore
#line 30 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"    <div class=""row"">
        <div class=""table-responsive"">
            <table class=""table table-striped"" id=""tblBankAccounts"">
                <thead>
                    <tr>
                        <td>Sr No</td>
                        <td>Document Name</td>
                        <td>Description</td>
                        <td>IsActive</td>
                        <td>Open</td>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 44 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                     if (Model != null)
                    {
                        

#line default
#line hidden
#nullable disable

#nullable restore
#line 46 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <tr>\r\n                                <td>");
            Write(
#nullable restore
#line 49 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                     item.SrNo

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 50 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                     item.DocumentName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 51 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                     item.DocumentDescription

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cf5989454095688db91ee5dba0b9670601a9547a0858353a56ee49c2e4ab318411913", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => 
#nullable restore
#line 53 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                                                                              item.IsActive

#line default
#line hidden
#nullable disable
            );
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onchange", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2048, "fnCustomerDocumentActiveInactive(", 2048, 33, true);
            AddHtmlAttributeValue("", 2081, 
#nullable restore
#line 53 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                                                                                                                                         item.CustomerDocumentID

#line default
#line hidden
#nullable disable
            , 2081, 24, false);
            AddHtmlAttributeValue("", 2105, ")", 2105, 1, true);
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
            WriteLiteral("                                </td>\r\n\r\n                                <td>\r\n                                    <a class=\'btn editaddress\'");
            BeginWriteAttribute("onclick", " onclick=\"", 2842, "\"", 2896, 3);
            WriteAttributeValue("", 2852, "fnCustomerDocument(", 2852, 19, true);
            WriteAttributeValue("", 2871, 
#nullable restore
#line 64 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                                                                            item.CustomerDocumentID

#line default
#line hidden
#nullable disable
            , 2871, 24, false);
            WriteAttributeValue("", 2895, ")", 2895, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"
                                       href=""javascript:void(0)""
                                       data-bs-toggle=""offcanvas""
                                       data-bs-target=""#canvasCustomerDocument""
                                       aria-controls=""canvasCustomerDocument""
                                       data-id=""");
            Write(
#nullable restore
#line 69 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                                 item.CustomerDocumentID

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\"");
            BeginWriteAttribute("customerid", "\r\n                                       customerid=\"", 3265, "\"", 3334, 1);
            WriteAttributeValue("", 3318, 
#nullable restore
#line 70 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                                    item.CustomerID

#line default
#line hidden
#nullable disable
            , 3318, 16, false);
            EndWriteAttribute();
            WriteLiteral("><i class=\'bx bx-edit\'></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 73 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                        }

#line default
#line hidden
#nullable disable

#nullable restore
#line 73 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable

            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvasCustomerDocument"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"" id=""canvasHeaderNameDocument""></h5>
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvInfoDocument"">
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf5989454095688db91ee5dba0b9670601a9547a0858353a56ee49c2e4ab318417841", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    //var urlDeleteCompanyFromUser = \'Url.Action(\"DeleteBankAccount\", \"Customer\")\';\r\n    var urlAddUpdateDocument = \'");
            Write(
#nullable restore
#line 96 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                 Url.Action("AddUpdateCustomerDocument", "Customer")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n    var urlisActiveInActive = \'");
            Write(
#nullable restore
#line 97 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                                Url.Action("ActiveInActiveCustomerDocument", "Customer")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"';

    function fnCustomerDocument(customerDocumentId) {
        var _id = customerDocumentId;//$(this).data('id');
        var _customerId = $(""#CustomerID"").val();
        if (_id > 0) {
            document.getElementById(""canvasHeaderNameDocument"").innerHTML = ""Update customer document details"";
        }
        else {
            document.getElementById(""canvasHeaderNameDocument"").innerHTML = ""Add customer document details"";
        }
        var _parameters = { customerDocumentId: _id, customerId: _customerId };
        $.ajax({
            url: urlAddUpdateDocument,
            type: ""GET"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $(""#canvasCustomerDocument"").show();//('hide');
                $('#dvInfoDocument').html(data);
            }
        });
    }

    function fnCustomerDocumentActiveInactive(customerDocumentId) {
        var _empDocId = customerDocumentId;//$(this).data('id');
        var customerId =");
            WriteLiteral(@" $(""#CustomerID"").val();
        var _checkBox = $(""#docActiveInactive"").is(':checked');
        var _docParameters = { customerDocumentId: _empDocId, customerId: customerId, isActive: _checkBox };
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
                }
                else {
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
              ");
            WriteLiteral("          continueDelayOnInactiveTab: false,\r\n                        position: \'bottom right\',\r\n                        msg: \'");
            Write(
#nullable restore
#line 147 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
                               MessageHelper.Error

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"'
                    });
                }
                $(""#CustomerDocumentTable"").load(window.location.href + "" #CustomerDocumentTable"");
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
#line 160 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\Customer\_customerDocumentList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<CustomerDocument>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
