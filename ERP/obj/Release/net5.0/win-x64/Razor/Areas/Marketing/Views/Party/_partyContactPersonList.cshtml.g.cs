#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f51de93f6110d8cb3a7c1f4b6fd8edda36dd3f079394a7d4342c15668b39b4f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Marketing_Views_Party__partyContactPersonList), @"mvc.1.0.view", @"/Areas/Marketing/Views/Party/_partyContactPersonList.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
using Business.Entities.Party;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f51de93f6110d8cb3a7c1f4b6fd8edda36dd3f079394a7d4342c15668b39b4f2", @"/Areas/Marketing/Views/Party/_partyContactPersonList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Marketing/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Marketing_Views_Party__partyContactPersonList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<PartyContactTxn>>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f51de93f6110d8cb3a7c1f4b6fd8edda36dd3f079394a7d4342c15668b39b4f26450", async() => {
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
<div id=""PartyContactPersonTable"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <h6 class=""cards-title"">
                Party Contact List
            </h6>
        </div>
        <div class=""col-lg-12 text-align-right"">
            <a onclick=""fnPartyContactDetail(0)""
               class=""btn btn-primary px-5""
               href=""javascript:void(0)""
               data-id=""0""
               data-bs-toggle=""offcanvas""
               data-bs-target=""#canvasPartyContactDetail""
               aria-controls=""canvasPartyContactDetail"">
                Add New
            </a>
        </div>
    </div>
    <div class=""row"">
        <table class=""table table-striped"" id=""tblPartyContactPersonTable"">
            <thead>
                <tr>
                    <td>Sr No.</td>
                    <td>Contact Person</td>
                    <td>EmailID</td>
                    <td>Mobile</td>
                    <td>Department</td>
                    <td>Designation");
            WriteLiteral("</td>\r\n                    <td>IsActive</td>\r\n                    <td>Detail</td>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 38 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                     foreach (var item in Model)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 44 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                           Write(item.SrNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 45 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                           Write(item.ContactPersonName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 46 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                           Write(item.OfficeEmailID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 47 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                           Write(item.OfficeMobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 48 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                           Write(item.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 49 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                           Write(item.Designation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 50 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                           Write(item.IsActive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a class=\'btn editPartyContact\'");
            BeginWriteAttribute("onclick", " onclick=\"", 1976, "\"", 2028, 3);
            WriteAttributeValue("", 1986, "fnPartyContactDetail(", 1986, 21, true);
#nullable restore
#line 52 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
WriteAttributeValue("", 2007, item.PartyContactID, 2007, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2027, ")", 2027, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"
                           href=""javascript:void(0)""
                           data-bs-toggle=""offcanvas""
                           data-bs-target=""#canvasPartyContactDetail""
                           aria-controls=""canvasPartyContactDetail""
                           data-id=""");
#nullable restore
#line 57 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                               Write(item.PartyContactID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("Partyid", "\r\n                           Partyid=\"", 2337, "\"", 2388, 1);
#nullable restore
#line 58 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
WriteAttributeValue("", 2375, item.PartyID, 2375, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\'bx bx-edit\'></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 61 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvasPartyContactDetail"" style=""visibility: visible; width : 80% !important"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"" id=""canvasHeaderNameBank""></h5>
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvInfoPartyContact"">
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f51de93f6110d8cb3a7c1f4b6fd8edda36dd3f079394a7d4342c15668b39b4f214584", async() => {
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
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    var urlAddUpdatePartyContactPerson = \'");
#nullable restore
#line 80 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Party\_partyContactPersonList.cshtml"
                                     Write(Url.Action("AddUpdatePartyContactPerson", "Party"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    function fnPartyContactDetail(PartyContactID) {
        var _id = PartyContactID;//$(this).data('id');
        var _PartyId = $(""#PartyID"").val();
        if (_id > 0) {
            document.getElementById(""canvasHeaderNameBank"").innerHTML = ""Update Party Contact Person"";
        }
        else {
            document.getElementById(""canvasHeaderNameBank"").innerHTML = ""Add Party Contact Person"";
        }
        var _parameters = { PartyContactID: _id, PartyId: _PartyId };
        $.ajax({
            url: urlAddUpdatePartyContactPerson,
            type: ""GET"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $(""#canvasPartyContactDetail"").show();//('hide');
                $('#dvInfoPartyContact').html(data);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<PartyContactTxn>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
