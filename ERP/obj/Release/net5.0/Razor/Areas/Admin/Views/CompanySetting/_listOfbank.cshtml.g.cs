#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "62cc3b87899dadb39313d16f534889af933e60c8c22e6c2ade819ff819dead3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CompanySetting__listOfbank), @"mvc.1.0.view", @"/Areas/Admin/Views/CompanySetting/_listOfbank.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"62cc3b87899dadb39313d16f534889af933e60c8c22e6c2ade819ff819dead3a", @"/Areas/Admin/Views/CompanySetting/_listOfbank.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_CompanySetting__listOfbank : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<CompanyBankingMetadata>>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "62cc3b87899dadb39313d16f534889af933e60c8c22e6c2ade819ff819dead3a6168", async() => {
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
<div id=""CompanyTable"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <h6 class=""cards-title"">
                Banks
            </h6>
        </div>
        <div class=""col-lg-6 text-align-right"">
            <a onclick=""fnAddBank(0)""
               class=""btn btn-primary px-5""
               href=""javascript:void(0)""
               data-id=""0""
               data-bs-toggle=""offcanvas""
               data-bs-target=""#canvas_bank""
               aria-controls=""canvas_bank"">
                Add Bank
            </a>
        </div>
    </div>
    <div class=""row"">

        <table class=""table table-striped"" id=""tblbank"">
                    <thead>
                        <tr>
                            <th>Sr. No.</th>
                            <th>Bank Name</th>
                            <th>Branch Code</th>
                            <th>Account No.</th>
                            <th>Account Name</th>
                            <th>IFCI Code</th>
  ");
            WriteLiteral("                          <th>Country</th>\r\n                            <th>Status</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 39 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                         if (Model != null)
                        {
                            foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 44 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.SrNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 45 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.BankName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 46 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.BankCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 47 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.AccountNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 48 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.AccountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 49 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.IFCICode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 50 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.CountryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 51 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                                   Write(item.IsActive.ToYesOrNo());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <a class=\'btn editbank\'");
            BeginWriteAttribute("onclick", " onclick=\"", 2160, "\"", 2203, 3);
            WriteAttributeValue("", 2170, "fnAddBank(", 2170, 10, true);
#nullable restore
#line 53 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
WriteAttributeValue("", 2180, item.CompanyBankingID, 2180, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2202, ")", 2202, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"
                           href=""javascript:void(0)""
                           data-bs-toggle=""offcanvas""
                           data-bs-target=""#canvas_bank""
                           aria-controls=""canvas_bank""
                           data-id=""");
#nullable restore
#line 58 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                               Write(item.CompanyBankingID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("compnayid", "\r\n                           compnayid=\"", 2488, "\"", 2543, 1);
#nullable restore
#line 59 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
WriteAttributeValue("", 2528, item.CompanyID, 2528, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\'bx bx-edit\'></i></a>\r\n\r\n");
            WriteLiteral("                         </td>\r\n                                </tr>\r\n");
#nullable restore
#line 65 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
           
    </div>
</div>
<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvas_bank"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"">Bank</h5>
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvbankInfo"">
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62cc3b87899dadb39313d16f534889af933e60c8c22e6c2ade819ff819dead3a14245", async() => {
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
            WriteLiteral("\r\n<script>\r\n    var urlDeleteCompanyFromUser = \'");
#nullable restore
#line 85 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                               Write(Url.Action("DeleteBank", "CompanySetting"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var urlAddBank = \'");
#nullable restore
#line 86 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                 Write(Url.Action("AddBank", "CompanySetting"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var urlDeleteBank = \'");
#nullable restore
#line 87 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfbank.cshtml"
                    Write(Url.Action("DeleteBank", "CompanySetting"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    $(document).ready(function () {
        let table1 = document.querySelector('#tblbank');
        let dataTable = new simpleDatatables.DataTable(table1);

    });
    function fnDeleteBank()
    {
        var _id = $(this).data('id');
        var _parameters = { id: _id };
        $.ajax({
            url: urlDeleteBank,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $('#dvbankInfo').html(data);
            }
            , error: function (error) {
                console.log(error);
            }
        });
    }
    function fnAddBank(id) {
        var _id = id;//$(this).data('id');
        //var _cid = $(""#CompanyID"").val();
        var _parameters = { id: _id };
        $.ajax({
            url: urlAddBank,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                console.log(data);
                $(""#canvas_ban");
            WriteLiteral("k\").show();//(\'hide\');\r\n                $(\'#dvbankInfo\').html(data);\r\n            }\r\n            ,error: function (error) {\r\n                console.log(error);\r\n            }\r\n        });\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<CompanyBankingMetadata>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
