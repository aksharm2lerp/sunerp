#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f4ecccdb8ad31bc38887ae648c280f216e38c841f61a137ef0ede6c3caf4f252"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CompanySetting__listOfContact), @"mvc.1.0.view", @"/Areas/Admin/Views/CompanySetting/_listOfContact.cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
 using Business.SQL

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"f4ecccdb8ad31bc38887ae648c280f216e38c841f61a137ef0ede6c3caf4f252", @"/Areas/Admin/Views/CompanySetting/_listOfContact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_CompanySetting__listOfContact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<CompanyContactTxnMetadata>>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f4ecccdb8ad31bc38887ae648c280f216e38c841f61a137ef0ede6c3caf4f2525649", async() => {
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
                Contacts
            </h6>
        </div>
        <div class=""col-lg-6 text-align-right"">
            <a onclick=""fnAddContact()""
               class=""btn btn-primary px-5""
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
        <table class=""table table-striped"" id=""tblContact"">
            <thead>
                <tr>
                    <th>Sr. No.</th>
                    <th>Designation</th>
                    <th>Contact Person</th>
                    <th>Email</th>
                    <th>Mobile</th>
                    <th>Department</th>

         ");
            WriteLiteral("       </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 38 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                 if(Model!=null)
                {
                foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <tr>\r\n                        <td>");
            Write(
#nullable restore
#line 43 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                             item.SrNo

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 44 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                             item.DesignationText

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 45 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                             item.PersonName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 46 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                             item.PersonEmail

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 47 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                             item.PersonalMobileNo

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 48 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                             item.DepartmentName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a class=\'btn deletecontact\' href=\"#!\"");
            BeginWriteAttribute("id", " id=\"", 1790, "\"", 1824, 1);
            WriteAttributeValue("", 1795, 
#nullable restore
#line 50 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                                                                        item.CompanyContactPersonsID

#line default
#line hidden
#nullable disable
            , 1795, 29, false);
            EndWriteAttribute();
            BeginWriteAttribute("compnayid", " compnayid=\"", 1825, "\"", 1852, 1);
            WriteAttributeValue("", 1837, 
#nullable restore
#line 50 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                                                                                                                  item.CompanyID

#line default
#line hidden
#nullable disable
            , 1837, 15, false);
            EndWriteAttribute();
            WriteLiteral("><i class=\'icon dripicons-trash\'></i></a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 53 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                }
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
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvContactInfo"">
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4ecccdb8ad31bc38887ae648c280f216e38c841f61a137ef0ede6c3caf4f25212146", async() => {
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
            Write(
#nullable restore
#line 72 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                                     Url.Action("DeleteContact", "CompanySetting")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n    var urlAddContact = \'");
            Write(
#nullable restore
#line 73 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\CompanySetting\_listOfContact.cshtml"
                          Url.Action("AddContact", "CompanySetting")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"';
    $(document).ready(function () {
        let table1 = document.querySelector('#tblContact');
        let dataTable = new simpleDatatables.DataTable(table1);

        ////Unbind the original image 'href' set by the controller...
        // $('.deletecontact').attr('href', 'javascript://');
        // $('#tblstore').on('click', 'a.deleteStore', function () {
        //    var _id = $(this).attr('id');
        //     var _compnayid = $(this).attr('compnayid');

        //     var _parameters = { id: _id, companyid: _compnayid };
        //    $.ajax({
        //        url: urlDeleteCompanyFromUser,
        //        type: ""GET"",
        //        data: _parameters,
        //        success: function (data, textStatus, jqXHR) {
        //            $('#CompanyTable').html(data);
        //        }
        //    });
        //});


    });
    function fnAddContact() {
        var _id = $(this).data('id');
        var _cid=$(""#CompanyID"").val();
        var _parameters = { id: ");
            WriteLiteral(@"_id, compnayid: _cid };
        $.ajax({
            url: urlAddContact,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
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
