#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "913e19ad0d6b28bddb4dd7a23cfe7271c003b2e288ef095c52595216a12d7da1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_MasterEntity_P_list), @"mvc.1.0.view", @"/Areas/Admin/Views/MasterEntity/P_list.cshtml")]
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

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"913e19ad0d6b28bddb4dd7a23cfe7271c003b2e288ef095c52595216a12d7da1", @"/Areas/Admin/Views/MasterEntity/P_list.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_MasterEntity_P_list : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"portlet light\">\r\n    <div class=\"portlet-title\">\r\n        <div class=\"caption\">\r\n            <i class=\"fa fa-list-alt\"></i>\r\n            <span class=\"caption-subject bold uppercase\"> Master Key List ");
            Write(
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                            !string.IsNullOrEmpty(ViewBag.Name) ? " - " + ViewBag.Name : ""

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"</span>
        </div>
        <div class=""actions"">
            <a href=""javascript:showValueForm();defaultValueSet();"" class=""btn btn-default btn-sm"">
                <i class=""fa fa-plus-circle""></i> Add Master Entry
            </a>
        </div>
    </div>
    <div class=""portlet-body form"">
        <div class=""form-horizontal"" role=""form"">
            <div class=""form-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <table class=""table table-striped table-bordered table-hover"" id=""ListValueTable"">
                            <thead>
                                <tr>
                                    <th class=""text-center"">ID</th>
                                    <th class=""text-left"">Value</th>
                                    <th class=""text-center"">Active</th>
                                    <th class=""text-center"">Default Selected</th>
                                    <th class=""text-center"">Entry Type");
            WriteLiteral(@"</th>
                                    <th class=""text-center"">Display Order</th>
                                    <th style=""width:150px"" class=""text-center"">Action</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 31 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                 if (ViewBag.ValueMasterList != null)
                                {
                                    foreach (var item in ViewBag.ValueMasterList)
                                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                        <tr>\r\n                                            <td class=\"text-center\">");
            Write(
#nullable restore
#line 36 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                     item.MasterListID

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                            <td class=\"text-left\">");
            Write(
#nullable restore
#line 37 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                   item.Value

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
            Write(
#nullable restore
#line 38 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                      item.IsActive ? "Yes" : "No"

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
            Write(
#nullable restore
#line 39 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                      item.IsDefaultSelected ? "Yes" : "No"

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
            Write(
#nullable restore
#line 40 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                     item.EntryTypeName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
            Write(
#nullable restore
#line 41 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                     item.SortOrder

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">\r\n                                                <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2598, "\"", 2643, 3);
            WriteAttributeValue("", 2608, "EditMasterList(", 2608, 15, true);
            WriteAttributeValue("", 2623, 
#nullable restore
#line 43 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                                                       item.MasterListID

#line default
#line hidden
#nullable disable
            , 2623, 18, false);
            WriteAttributeValue("", 2641, ");", 2641, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success btn-sm\">Edit</a>\r\n\r\n                                                <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2765, "\"", 2812, 3);
            WriteAttributeValue("", 2775, "DeleteMasterList(", 2775, 17, true);
            WriteAttributeValue("", 2792, 
#nullable restore
#line 45 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                                                                                         item.MasterListID

#line default
#line hidden
#nullable disable
            , 2792, 18, false);
            WriteAttributeValue("", 2810, ");", 2810, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\">Delete</a>\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 48 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"                            </tbody>
                            <tfoot>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
            <div class=""form-actions right"">
                <button type=""button"" class=""btn btn-default"" onclick=""window.location.reload();"">Back</button>
            </div>
        </div>
    </div>
</div>

<script>
    try {
        $(document).ready(function () {
            defaultType = '");
            Write(
#nullable restore
#line 67 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                            ViewBag.DefaultType

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n            defaultName = \'");
            Write(
#nullable restore
#line 68 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Admin\Views\MasterEntity\P_list.cshtml"
                            ViewBag.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n        });\r\n    } catch (e) {\r\n\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
