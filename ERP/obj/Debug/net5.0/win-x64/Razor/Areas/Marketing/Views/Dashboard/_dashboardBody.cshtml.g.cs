#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Dashboard\_dashboardBody.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "486c6ee083bf56b08f48f8f92ed1a9dd278b6a39734fce1ed5794966dbe313b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Marketing_Views_Dashboard__dashboardBody), @"mvc.1.0.view", @"/Areas/Marketing/Views/Dashboard/_dashboardBody.cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Dashboard\_dashboardBody.cshtml"
 using Business.Entities.Marketing.Dashboard;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"486c6ee083bf56b08f48f8f92ed1a9dd278b6a39734fce1ed5794966dbe313b3", @"/Areas/Marketing/Views/Dashboard/_dashboardBody.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Marketing/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Marketing_Views_Dashboard__dashboardBody : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!--Card box-->\r\n<div class=\"row my-3\">\r\n    <div class=\"col-sm-4 text-center\">\r\n        <div class=\"column\">\r\n            <div class=\"card\">\r\n");
            WriteLiteral("                <div class=\"container my-3\">\r\n                    <h2>Total Login</h2>\r\n                    <h4>");
            Write(
#nullable restore
#line 11 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Marketing\Views\Dashboard\_dashboardBody.cshtml"
                         Model.TotalLogin

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h4>\r\n");
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-sm-4 text-center\">\r\n        <div class=\"column\">\r\n            <div class=\"card\">\r\n");
            WriteLiteral("                <div class=\"container my-3\">\r\n                    <h2>Total Visit\'s</h2>\r\n                    <h4>10</h4>\r\n");
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-sm-4 text-center\">\r\n        <div class=\"column\">\r\n            <div class=\"card\">\r\n");
            WriteLiteral("                <div class=\"container my-3\">\r\n                    <h2>Total Calls</h2>\r\n                    <h4>50</h4>\r\n");
            WriteLiteral(@"                </div>
            </div>
        </div>
    </div>
</div>
<!--Card box-->
<!--Table-->
<div class=""row my-3"">
    <div class=""table-responsive"">
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th scope=""col"">Sr No.</th>
                    <th scope=""col"">Name</th>
                    <th scope=""col"">Login Date</th>
                    <th scope=""col"">Time</th>
                    <th scope=""col"">Browser</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope=""row"">1</th>
                    <td>Rahul Mistry</td>
                    <td>19-10-2023</td>
                    <td>11:30</td>
                    <td>Google Chrome</td>
                </tr>
                <tr>
                    <th scope=""row"">2</th>
                    <td>Dravesh Lokhande</td>
                    <td>18-10-2023</td>
                    <td>14:35</td>
          ");
            WriteLiteral(@"          <td>Microsoft Edge</td>
                </tr>
                <tr>
                    <th scope=""row"">3</th>
                    <td>Sagar Parmar</td>
                    <td>17-10-2023</td>
                    <td>09:30</td>
                    <td>FireFox</td>
                </tr>
                <tr>
                    <th scope=""row"">4</th>
                    <td>Sandip Patel</td>
                    <td>16-10-2023</td>
                    <td>21:40</td>
                    <td>Opera</td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
<!--Table-->
<!--Bar Graph-->
<div class=""row my-3"">
    <canvas id=""myChart"" style=""width:100%;max-width:700px""></canvas>
</div>
<!--Bar Graph-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
