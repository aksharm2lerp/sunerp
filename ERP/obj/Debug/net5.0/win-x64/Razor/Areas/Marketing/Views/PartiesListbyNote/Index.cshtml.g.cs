#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "dc584f4a1038605321eb619f39939955e60ff8c1aff3c71b3da0bf020c06f23a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Marketing_Views_PartiesListbyNote_Index), @"mvc.1.0.view", @"/Areas/Marketing/Views/PartiesListbyNote/Index.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
using Business.Entities.PartyMasterModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"dc584f4a1038605321eb619f39939955e60ff8c1aff3c71b3da0bf020c06f23a", @"/Areas/Marketing/Views/PartiesListbyNote/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Marketing/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Marketing_Views_PartiesListbyNote_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PartyMaster>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("PartyID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PartyID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("PositiveNoteID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PositiveNoteID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMaster.cshtml";
    ViewBag.Title = "Party Note..";
    var test = Model;
    List<string> strTimeforRow = new List<string>();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"" id=""partyListSummary"">
    <div class=""row"">
        <div class=""col-sm-12 col-md-12 col-lg-12 mx-auto"">
            <div class=""card border-0 shadow rounded-3"">
                <div class=""card-body"">


                    <div class=""row pt-1"">
                        <div class=""col-md-12"">
                            <div class=""row"">
                                <div class=""row"">
");
            WriteLiteral("                                    <div class=\"col-sm-4\">\r\n                                        <label class=\"col-form-label\">Party</label>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc584f4a1038605321eb619f39939955e60ff8c1aff3c71b3da0bf020c06f23a8733", async() => {
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc584f4a1038605321eb619f39939955e60ff8c1aff3c71b3da0bf020c06f23a9061", async() => {
                    WriteLiteral("Select Party");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 28 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = MarketingExtension.GetAllPartyName();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n\r\n                                    <div class=\"col-sm-4\">\r\n                                        <label class=\"col-form-label\">Positive Note</label>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc584f4a1038605321eb619f39939955e60ff8c1aff3c71b3da0bf020c06f23a12193", async() => {
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc584f4a1038605321eb619f39939955e60ff8c1aff3c71b3da0bf020c06f23a12522", async() => {
                    WriteLiteral("Select Positive Note");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 35 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = MarketingExtension.GetAllMarketingClientFeedbackNote();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n");
            WriteLiteral(@"                                    
                                    <div class=""text-end mb-3 col-sm-4"">
                                        <button id=""btnSearchEmployeeDetail"" type=""button"" onclick=""fnSearchParty(true)"" class=""btn btn-outline-primary px-5 btn-sm"">Search</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div id=""partyListTable"">
");
#nullable restore
#line 53 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                         if (Model != null && Model.Count > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""row"" style=""overflow:auto; height:auto; width:100%;"">
                                <table class=""table table-striped"" style=""white-space: nowrap; font-size:inherit !important;"">
                                    <thead class=""userProfileTableTHead"">
                                        <tr>
                                            <th>Party Name</th>
                                            <th>Email</th>
                                            <th>Mobile</th>
                                            <th>Date</th>
                                            <th>Note</th>
                                            <th>Reply</th>
                                        </tr>

");
            WriteLiteral("                                    </thead>\r\n");
#nullable restore
#line 77 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 80 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                               Write(item.PartyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 81 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 82 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                               Write(item.MobileNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 83 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                               Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 84 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                               Write(item.Note);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 85 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                               Write(item.Reply);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 87 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   \r\n");
            WriteLiteral("                                </table>\r\n                            </div>\r\n");
#nullable restore
#line 123 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
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
#line 130 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 139 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    function fnSearchParty(obj) {

        let partyId = $('#PartyID').val();
        let positiveNoteId = $('#PositiveNoteID').val();
        // var searchString = $('#SearchString').val();
        let partyListUrl = '");
#nullable restore
#line 146 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Areas\Marketing\Views\PartiesListbyNote\Index.cshtml"
                       Write(Url.Action("ViewAllNotificationList","PartiesListbyNote"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        let istrue = obj;
        let viewAllPartyList = partyListUrl + '?partyid=' + partyId + '&positivenoteid=' + positiveNoteId + '&isTrue=' + istrue;
        window.location.href = viewAllPartyList;
    };

    $(document).ready(function () {

        var multipleCancelButtonParty = new Choices('#PartyID', {
            removeItemButton: false,
            maxItemCount: 10,
            searchResultLimit: 10,
            renderChoiceLimit: 10
        });

        var multipleCancelButtonPositiveNote = new Choices('#PositiveNoteID', {
            removeItemButton: false,
            maxItemCount: 10,
            searchResultLimit: 10,
            renderChoiceLimit: 10
        });
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PartyMaster>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
