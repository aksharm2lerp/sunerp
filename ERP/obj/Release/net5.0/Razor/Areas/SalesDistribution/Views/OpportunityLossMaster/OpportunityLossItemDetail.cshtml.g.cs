#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ccc6893c3c0ef637dd701c4a9ff4cebbfc3c54bc893a8b25f3e48cb14779e11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SalesDistribution_Views_OpportunityLossMaster_OpportunityLossItemDetail), @"mvc.1.0.view", @"/Areas/SalesDistribution/Views/OpportunityLossMaster/OpportunityLossItemDetail.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
using Business.Entities.SalesDistribution.OpportunityLossMasterModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4ccc6893c3c0ef637dd701c4a9ff4cebbfc3c54bc893a8b25f3e48cb14779e11", @"/Areas/SalesDistribution/Views/OpportunityLossMaster/OpportunityLossItemDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/SalesDistribution/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_SalesDistribution_Views_OpportunityLossMaster_OpportunityLossItemDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataSet>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 17 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
  
    List<string> strTimeforRow = new List<string>();
    int OpportunityLossId = ViewBag.OpportunityLossID;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"EmployeeSummaryTable\">\r\n");
#nullable restore
#line 22 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                         if (Model.Tables[0].Rows.Count > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""row"" style=""overflow:auto; height:auto; width:100%;"">
                                <table class=""table table-striped w-auto"" style=""white-space: nowrap; font-size:inherit !important;"">
                                    <!--style=""display:block; overflow: auto; white-space: nowrap;""-->
                                    <thead style=""position: sticky; top: 0; background-color:#e9ecf8; color:black; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"">
                                        <tr>
");
#nullable restore
#line 29 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                             foreach (DataColumn dataColumn in Model.Tables[0].Columns)
                                            {
                                                strTimeforRow.Add(dataColumn.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>");
#nullable restore
#line 32 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                               Write(dataColumn.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 33 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </tr>\r\n                                    </thead>\r\n");
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                     foreach (DataRow row in Model.Tables[0].Rows)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n");
#nullable restore
#line 39 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                             foreach (string timeRow in strTimeforRow)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                                 if (!string.IsNullOrEmpty(row[timeRow].ToString()))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>");
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                                   Write(row[timeRow]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 44 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>-</td>\r\n");
#nullable restore
#line 48 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </tr>\r\n");
#nullable restore
#line 51 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </table>\r\n                            </div>\r\n");
#nullable restore
#line 54 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
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
#line 61 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
#nullable restore
#line 65 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SalesDistribution\Views\OpportunityLossMaster\OpportunityLossItemDetail.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataSet> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
