#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4093acfaf65c0063bb669c4a0a36f3534e0573b94525b012391ff3b60858bc16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Marketing_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Marketing/Views/Dashboard/Index.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
using Business.Entities.Marketing.Dashboard;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4093acfaf65c0063bb669c4a0a36f3534e0573b94525b012391ff3b60858bc16", @"/Areas/Marketing/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Marketing/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Marketing_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Marketing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMaster.cshtml";
    ViewBag.Title = "Dashboard..";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""page-breadcrumb d-none d-sm-flex align-items-center pb-3 border-bottom"">
    <div class=""ps-3 col-md-6"">
        <nav aria-label=""breadcrumb"">
            <ol class=""breadcrumb mb-0 p-0"">
                <li class=""breadcrumb-item"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4093acfaf65c0063bb669c4a0a36f3534e0573b94525b012391ff3b60858bc166700", async() => {
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
            WriteLiteral("\r\n                </li>\r\n                <li class=\"breadcrumb-item active\" aria-current=\"page\">Dashboard</li>\r\n            </ol>\r\n        </nav>\r\n    </div>\r\n");
            WriteLiteral(@"</div>
<div class=""container"" id=""partyListSummary"">
    <div class=""row"">
        <div class=""col-sm-12 col-md-12 col-lg-12 mx-auto"">
            <div class=""card border-0 shadow rounded-3"">
                <div class=""card-body"">


                    <div class=""row"">
");
            WriteLiteral(@"                        <div class=""col-sm-4"">
                            <label class=""col-form-label"">Start Date</label>
                            <input type=""date"" class=""form-control"" id=""StartDate"" name=""StartDate"">
                            <span class=""text-danger""></span>
                        </div>

                        <div class=""col-sm-4"">
                            <label class=""col-form-label"">End Date</label>
                            <input type=""date"" class=""form-control"" id=""EndDate"" name=""EndDate"">
                            <span class=""text-danger""></span>
                        </div>
");
            WriteLiteral(@"
                        <div class=""col-sm-4 text-center marketingDashboardPaddingTop"">
                            <button id=""btnSearchUserDetailForDashboard"" type=""button"" onclick=""fnSearchUserCount(true)"" class=""btn btn-outline-primary btn-sm"">Search</button>
                        </div>
                    </div>

                    <hr />
                    <div>
");
#nullable restore
#line 60 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                         if (Model != null && Model.ListLoginHistoryModels.Count > 0)
                        {
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <!--Card box-->
                            <div class=""row my-3"">
                                <div class=""col-sm-4 text-center"">
                                    <div class=""column"">
                                        <div class=""card bgColorDashboard"">
");
            WriteLiteral("                                            <div class=\"container my-3\">\r\n                                                <h2>Total Login</h2>\r\n                                                <h4>");
#nullable restore
#line 71 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                               Write(Model.TotalLogin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
            WriteLiteral(@"                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col-sm-4 text-center"">
                                    <div class=""column"">
                                        <div class=""card bgColorDashboard"">
");
            WriteLiteral("                                            <div class=\"container my-3\">\r\n                                                <h2>Total Visit\'s</h2>\r\n                                                <h4>");
#nullable restore
#line 83 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                               Write(Model.TotalVisits);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
            WriteLiteral(@"                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col-sm-4 text-center"">
                                    <div class=""column"">
                                        <div class=""card bgColorDashboard"">
");
            WriteLiteral("                                            <div class=\"container my-3\">\r\n                                                <h2>Total Calls</h2>\r\n                                                <h4>");
#nullable restore
#line 95 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                               Write(Model.TotalCalls);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
            WriteLiteral(@"                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--Card box-->
                            <!--Table-->
                            <div class=""row my-3"">
                                <div class=""row"" style=""overflow:auto; width:100%;"">
                                    <table class=""table table-striped"" style=""white-space: nowrap; font-size:inherit !important;"">

                                        <thead style=""position: sticky; top: 0; background-color:#e9ecf8; color:black; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"">
                                            <tr>
                                                <th>Sr No.</th>
                                                <th>Name</th>
                                                <th>Login Date</th>
               ");
            WriteLiteral("                                 <th>Time</th>\r\n                                                <th>Browser</th>\r\n                                            </tr>\r\n                                        </thead>\r\n");
#nullable restore
#line 117 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                          
                                            int SrNo = 1;
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tbody>\r\n");
#nullable restore
#line 121 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                             foreach (var item in Model.ListLoginHistoryModels)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <th>");
#nullable restore
#line 124 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                                   Write(SrNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                    <td>");
#nullable restore
#line 125 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                                   Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 126 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                                   Write(item.LoginDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 127 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                                   Write(item.LoginTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 128 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                                   Write(item.Browser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
#nullable restore
#line 130 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                                                SrNo++;
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </tbody>\r\n                                    </table>\r\n                                </div>\r\n                            </div>\r\n                            <!--Table-->\r\n");
#nullable restore
#line 137 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>

                </div>
            </div>
        </div>
    </div>

    <script type=""text/javascript"">
        var xValues = [""Rahul Mistry"", ""Dravesh Lokhande"", ""Sagar Parmar"", ""Sandip Patel"", ""Virat Gajjar""];
        var yValues = [55, 49, 44, 24, 15];
        var barColors = [""red"", ""green"", ""blue"", ""orange"", ""brown""];

        new Chart(""myChart"", {
            type: ""bar"",
            data: {
                labels: xValues,
                datasets: [{
                    backgroundColor: barColors,
                    data: yValues
                }]
            },
            options: {
                legend: { display: false },
                title: {
                    display: true,
                    text: ""Total login counts""
                }
            }
        });


        function fnSearchUserCount() {

            let StartDate = $('#StartDate').val();
            let EndDate = $('#EndDate').val();
            //alert(`S");
            WriteLiteral("tartDate----${StartDate} && EndDate----${EndDate}`)\r\n            let UserCountListUrl = \'");
#nullable restore
#line 174 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\Marketing\Views\Dashboard\Index.cshtml"
                               Write(Url.Action("Index","Dashboard"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
            //alert('UserCountListUrl-- ' + UserCountListUrl);
            //let istrue = obj;
            let viewUserLoginList = UserCountListUrl + '?startDate=' + StartDate + '&endDate=' + EndDate;
            window.location.href = viewUserLoginList;
        };

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
