#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73abf41c64d60d4cf927453803d28eef2c8ae6cd0010c6867c13e9825b83b540"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Marketing_Views_Party__partyBankAccountList), @"mvc.1.0.view", @"/Areas/Marketing/Views/Party/_partyBankAccountList.cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.Entities

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.SQL

#nullable disable
    ;
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Enums

#nullable disable
    ;
#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Extensions

#nullable disable
    ;
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Helpers

#nullable disable
    ;
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.Entities.Dynamic

#nullable disable
    ;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
 using Business.Entities.Party

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"73abf41c64d60d4cf927453803d28eef2c8ae6cd0010c6867c13e9825b83b540", @"/Areas/Marketing/Views/Party/_partyBankAccountList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Marketing/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Marketing_Views_Party__partyBankAccountList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<PartyBankDetails>>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "73abf41c64d60d4cf927453803d28eef2c8ae6cd0010c6867c13e9825b83b5405845", async() => {
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
<div id=""PartyBankAccountTable"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <h6 class=""cards-title"">
                Bank Account List
            </h6>
        </div>
        <div class=""col-lg-12 text-align-right"">
            <a onclick=""fnPartyBankAccount(0)""
               class=""btn btn-primary px-5""
               href=""javascript:void(0)""
               data-id=""0""
               data-bs-toggle=""offcanvas""
               data-bs-target=""#canvasPartyBankAccount""
               aria-controls=""canvasPartyBankAccount"">
                Add Bank Account
            </a>
        </div>
    </div>
    <div class=""row"">
        <div class=""table-responsive"">
            <table class=""table table-striped"" id=""tblPartyBankAccounts"">
                <thead>
                    <tr>
                        <td>SrNo</td>
                        <td>Bank Name</td>
                        <td>Bank Code</td>
                        <td>Account No</td>
               ");
            WriteLiteral(@"         <td>Account Name</td>
                        <td>IFSC Code</td>
                        <td>Branch</td>
                        <td>Country</td>
                        <td>IsActive</td>
                        <td>Update</td>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 41 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                     if (Model != null)
                    {
                        

#line default
#line hidden
#nullable disable

#nullable restore
#line 43 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
#nullable disable

            WriteLiteral("                            <tr>\r\n                                <td>");
            Write(
#nullable restore
#line 47 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.SrNo

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 48 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.BankName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 49 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.BankCode

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 50 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.AccountNO

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 51 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.AccountName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 52 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.IFSCCode

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 53 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.BranchLocation

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 54 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.CountryName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>");
            Write(
#nullable restore
#line 55 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                     item.IsActive

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a class=\'btn editaddress\'");
            BeginWriteAttribute("onclick", " onclick=\"", 2304, "\"", 2358, 3);
            WriteAttributeValue("", 2314, "fnPartyBankAccount(", 2314, 19, true);
            WriteAttributeValue("", 2333, 
#nullable restore
#line 57 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                                                                            item.PartyBankDetailsID

#line default
#line hidden
#nullable disable
            , 2333, 24, false);
            WriteAttributeValue("", 2357, ")", 2357, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"
                                       href=""javascript:void(0)""
                                       data-bs-toggle=""offcanvas""
                                       data-bs-target=""#canvasPartyBankAccount""
                                       aria-controls=""canvasPartyBankAccount""
                                       data-id=""");
            Write(
#nullable restore
#line 62 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                                 item.PartyBankDetailsID

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\"");
            BeginWriteAttribute("Partyid", "\r\n                                       Partyid=\"", 2727, "\"", 2790, 1);
            WriteAttributeValue("", 2777, 
#nullable restore
#line 63 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                                 item.PartyID

#line default
#line hidden
#nullable disable
            , 2777, 13, false);
            EndWriteAttribute();
            WriteLiteral("><i class=\'bx bx-edit\'></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 66 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                        }

#line default
#line hidden
#nullable disable

#nullable restore
#line 66 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>
<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvasPartyBankAccount"" style=""visibility: visible; width : 75% !important"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"" id=""canvasHeaderNamePartyBank""></h5>
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvInfoPartyBank"">
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73abf41c64d60d4cf927453803d28eef2c8ae6cd0010c6867c13e9825b83b54015020", async() => {
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
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    //var urlDeleteCompanyFromUser = \'Url.Action(\"DeleteBankAccount\", \"Party\")\';\r\n    var urlAddUpdateBankAccount = \'");
            Write(
#nullable restore
#line 87 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Party\_partyBankAccountList.cshtml"
                                    Url.Action("AddUpdatePartyBankAccount", "Party")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"';
    function fnPartyBankAccount(PartyBankDetailId) {
        var _id = PartyBankDetailId;//$(this).data('id');
        var _PartyId = $(""#PartyID"").val();
        if (_id > 0) {
            document.getElementById(""canvasHeaderNamePartyBank"").innerHTML = ""Update Party bank details"";
        }
        else {
            document.getElementById(""canvasHeaderNamePartyBank"").innerHTML = ""Add Party bank details"";
        }
        var _parameters = { PartyBankDetailId: _id, PartyId: _PartyId };
        $.ajax({
            url: urlAddUpdateBankAccount,
            type: ""GET"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $(""#canvasPartyBankAccount"").show();//('hide');
                $('#dvInfoPartyBank').html(data);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<PartyBankDetails>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
