#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2117bd83ddce908f207729c283c5deb8b0ef1eb5335da3b41947618efaec40a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SuperAdmin_Views_MasterEntity_Index), @"mvc.1.0.view", @"/Areas/SuperAdmin/Views/MasterEntity/Index.cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Enums

#nullable disable
    ;
#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Extensions

#nullable disable
    ;
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Helpers

#nullable disable
    ;
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities.Dynamic

#nullable disable
    ;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
 using Business.SQL

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
 using GridCore

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2117bd83ddce908f207729c283c5deb8b0ef1eb5335da3b41947618efaec40a6", @"/Areas/SuperAdmin/Views/MasterEntity/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/SuperAdmin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_SuperAdmin_Views_MasterEntity_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISGrid>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MasterEntity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::GridMvc.TagHelpers.GridTagHelper __GridMvc_TagHelpers_GridTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
  
    ViewData["Title"] = "Master Entity";
    Layout = "~/Views/Shared/_LayoutMaster.cshtml";


#line default
#line hidden
#nullable disable

            WriteLiteral(@"<div class=""page-breadcrumb d-none d-sm-flex align-items-center pb-3 border-bottom"">
    <div class=""ps-3 col-md-6"">
        <nav aria-label=""breadcrumb"">
            <ol class=""breadcrumb mb-0 p-0"">
                <li class=""breadcrumb-item"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2117bd83ddce908f207729c283c5deb8b0ef1eb5335da3b41947618efaec40a66531", async() => {
                WriteLiteral("<i class=\"bx bx-home-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 18 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                 if (Model.CommonSettings != null)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <li class=\"breadcrumb-item active\" aria-current=\"page\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2117bd83ddce908f207729c283c5deb8b0ef1eb5335da3b41947618efaec40a68508", async() => {
                WriteLiteral("Master Entity");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
            WriteLiteral("                    <li class=\"breadcrumb-item active\" aria-current=\"page\">");
            Write(
#nullable restore
#line 22 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                                                                            Model.CommonSettings.QueryString

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</li>\r\n");
#nullable restore
#line 23 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <li class=\"breadcrumb-item active\" aria-current=\"page\">Master Entity</li>\r\n");
#nullable restore
#line 27 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                }

#line default
#line hidden
#nullable disable

            WriteLiteral("            </ol>\r\n        </nav>\r\n    </div>\r\n    <div class=\"col-md-6 text-align-right\">\r\n");
#nullable restore
#line 32 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
         if (Model.CommonSettings != null)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <a class=\"btn btn-primary px-5\" onclick=\"fnMasterEntity(this)\"\r\n           href=\"javascript:void(0)\"\r\n           data-key=\"");
            Write(
#nullable restore
#line 36 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                      Model.CommonSettings.QueryString

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\"\r\n           data-bs-toggle=\"offcanvas\"\r\n           data-bs-target=\"#canvas_masterentity\"\r\n           aria-controls=\"canvas_masterentity\">\r\n                Add Master Entry\r\n            </a>\r\n");
#nullable restore
#line 42 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable

            WriteLiteral(@"            <a class=""btn btn-primary px-5"" onclick=""fnMasterEntity(this)""
           href=""javascript:void(0)""
           data-key=""0""
           data-bs-toggle=""offcanvas""
           data-bs-target=""#canvas_masterentity""
           aria-controls=""canvas_masterentity"">
                Add Master Entry
            </a>
");
#nullable restore
#line 53 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </div>\r\n</div>\r\n<div class=\"row pt-1\">\r\n    <div class=\"col-md-12\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("grid", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2117bd83ddce908f207729c283c5deb8b0ef1eb5335da3b41947618efaec40a612974", async() => {
            }
            );
            __GridMvc_TagHelpers_GridTagHelper = CreateTagHelper<global::GridMvc.TagHelpers.GridTagHelper>();
            __tagHelperExecutionContext.Add(__GridMvc_TagHelpers_GridTagHelper);
            __GridMvc_TagHelpers_GridTagHelper.Model = 
#nullable restore
#line 58 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                      Model

#line default
#line hidden
#nullable disable
            ;
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __GridMvc_TagHelpers_GridTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvas_masterentity"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"">Add Master Entry</h5>
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvInfo"">
        </div>
    </div>
</div>
<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvas_master"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"">Add Master Key</h5>
        <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvInfoKey"">
        </div>
    </div>
</div>
<script type=""text/javascript"">
    var urladd = '");
            Write(
#nullable restore
#line 82 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                   Url.Action("Get", "MasterEntity")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n    var urldeletebyid = \'");
            Write(
#nullable restore
#line 83 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                          Url.Action("DeleteMasterList", "MasterEntity")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n    var urldeletebykey = \'");
            Write(
#nullable restore
#line 84 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                           Url.Action("DeleteMasterListByName", "MasterEntity")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"';
    function fnMasterEntity(obj) {
        var _key = $(obj).data('key');
        var _id = $(obj).data('id');
        var _parameters = { id: _id, key: _key };
        $.ajax({
            url: urladd,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $('#dvInfo').html(data);
                $(""#canvas_masterentity"").show();//('hide');
            }
        });
    }

    function fnDeleteMasterEntity(obj) {
        var _key = $(obj).data('key');
        var _id = $(obj).data('id');
        var _parameters = { id: _id };
        $.ajax({
            url: urldeletebyid,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {

                if (data.status) {
                    //notification
                    Lobibox.notify('success', {
                        pauseDelayOnHover: true,
                        size: 'mini',
           ");
            WriteLiteral(@"             icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                    window.location.reload().delay(3000);
                }
                else {
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                }
            }
            , error: function (error) {
                laddaStop(l);
                Lobibox.notify('error', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,");
            WriteLiteral("\r\n                    position: \'bottom right\',\r\n                    msg: \"");
            Write(
#nullable restore
#line 141 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                           MessageHelper.Error

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"""
                });
            }
        });
    }

    function fnDeleteMasterEntityByKey(obj) {
        var _key = $(obj).data('key');
        var _id = $(obj).data('id');
        var _parameters = { name: _key };
        $.ajax({
            url: urldeletebykey,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                if (data.status) {
                    //notification
                    Lobibox.notify('success', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                    window.location.reload().delay(3000);
                }
                else {
                    Lobibox.notify('error', {
                        pauseDelay");
            WriteLiteral(@"OnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                }
            }
            , error: function (error) {
                laddaStop(l);
                Lobibox.notify('error', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom right',
                    msg: """);
            Write(
#nullable restore
#line 187 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\MasterEntity\Index.cshtml"
                           MessageHelper.Error

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\"\r\n                });\r\n            }\r\n        });\r\n    }\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISGrid> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
