#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b9fb5d9e545fe1c52e044f79ccc0d7e3362f38e7fa44948f750237a7fab1cad1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SuperAdmin_Views_Company__listOfContact), @"mvc.1.0.view", @"/Areas/SuperAdmin/Views/Company/_listOfContact.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b9fb5d9e545fe1c52e044f79ccc0d7e3362f38e7fa44948f750237a7fab1cad1", @"/Areas/SuperAdmin/Views/Company/_listOfContact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/SuperAdmin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_SuperAdmin_Views_Company__listOfContact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<CompanyContactTxnMetadata>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/vendors/simple-datatables/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b9fb5d9e545fe1c52e044f79ccc0d7e3362f38e7fa44948f750237a7fab1cad15828", async() => {
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
        <div class=""col-sm-12 text-align-right"">
            <a onclick=""fnAddContact(0)""
               class=""btn btn-outline-primary px-5 btn-sm""
               href=""javascript:void(0)""
               offcanvas-title=""Add Contact""
               data-id=""0""
               data-bs-toggle=""offcanvas""
               data-bs-target=""#canvas_contact""
               aria-controls=""canvas_contact"">
                Add Contact
            </a>
        </div>
    </div>
    <div class=""row"">
        <table class=""table table-striped"" id=""tblContact"" >
            <thead style=""position: sticky; top: 0; background-color:#e9ecf8; color:black; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: x-small;"">
                <tr>
                    <th>Sr. No.</th>
                    <th>Designation</th>
                    <th>Contact Person</th>
                    <th>Email</th>
                    <th>Mobile</th>
           ");
            WriteLiteral("         <th>Department</th>\r\n                    <th></th>\r\n\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 34 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 39 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                           Write(item.SrNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                           Write(item.DesignationText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 41 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                           Write(item.PersonName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 42 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                           Write(item.PersonEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                           Write(item.PersonalMobileNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 44 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                           Write(item.DepartmentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a class=\'btn\'");
            BeginWriteAttribute("onclick", " onclick=\"", 1886, "\"", 1939, 3);
            WriteAttributeValue("", 1896, "fnAddContact(", 1896, 13, true);
#nullable restore
#line 46 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
WriteAttributeValue("", 1909, item.CompanyContactPersonsID, 1909, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1938, ")", 1938, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"
                                   href=""javascript:void(0)""
                                   data-bs-toggle=""offcanvas""
                                   data-bs-target=""#canvas_contact""
                                   aria-controls=""canvas_contact""
                                   data-id=""");
#nullable restore
#line 51 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                                       Write(item.CompanyContactPersonsID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("compnayid", "\r\n                                   compnayid=\"", 2277, "\"", 2340, 1);
#nullable restore
#line 52 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
WriteAttributeValue("", 2325, item.CompanyID, 2325, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\'bx bx-edit\'></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 55 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                     }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvas_contact"" aria-labelledby=""offcanvascontactLabel"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"" id=""offcanvascontactLabel"">Contact</h5>
        <button type=""button"" class=""btn-close text-reset"" data-bs-dismiss=""offcanvas"" aria-label=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvContactInfo"">
        </div>
    </div>
</div>

");
            WriteLiteral("<script>\r\n    //var urlDeleteCompanyFromUser = \'");
#nullable restore
#line 73 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                                 Write(Url.Action("DeleteContact", "Company"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var urlAddContact = \'");
#nullable restore
#line 74 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\Company\_listOfContact.cshtml"
                    Write(Url.Action("AddContact", "Company"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    function fnAddContact(id) {
        var _id = id; //$(this).data('id');
        var _cid = $(""#CompanyID"").val();
        var _parameters = { id: _id, compnayid: _cid };
        $.ajax({
            url: urlAddContact,
            type: ""GET"",
            data: _parameters,
            success: function(data, textStatus, jqXHR) {
                $('#dvContactInfo').html(data);
                $(""#canvas_contact"").show();//('hide');
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<CompanyContactTxnMetadata>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
