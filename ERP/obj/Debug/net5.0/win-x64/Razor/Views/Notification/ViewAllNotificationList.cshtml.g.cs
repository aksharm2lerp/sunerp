#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "90d124d8c536c70513be5d2cfb44d9c46f7f0e38adf5779358c918550b225553"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_ViewAllNotificationList), @"mvc.1.0.view", @"/Views/Notification/ViewAllNotificationList.cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using ERP

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using Business.Entities

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using Business.SQL

#nullable disable
    ;
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Enums

#nullable disable
    ;
#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Extensions

#nullable disable
    ;
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Helpers

#nullable disable
    ;
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
using Business.Entities.Dynamic

#nullable disable
    ;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
 using Business.Entities.NotificationModel;

#nullable disable
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
 using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"90d124d8c536c70513be5d2cfb44d9c46f7f0e38adf5779358c918550b225553", @"/Views/Notification/ViewAllNotificationList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"9af2a5bd844c76fa2170a48777822dbd4537e1a6e69a69cabcf43956cc6762c3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Notification_ViewAllNotificationList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMaster.cshtml";
    ViewBag.Title = "Notification List..";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
#nullable restore
#line 14 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
  
    List<string> strTimeforRow = new List<string>();
    //int empCatId = ViewBag.EmployeeCategoryID;
    //int deptId = ViewBag.DepartmentID;

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"container\" id=\"notificationListSummary\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12 col-md-12 col-lg-12 mx-auto\">\r\n            <div class=\"card border-0 shadow rounded-3\">\r\n                <div class=\"card-body\">\r\n\r\n");
            WriteLiteral("\r\n                    <div class=\"row pt-1\">\r\n                        <div class=\"col-md-12\">\r\n                            <div class=\"row\">\r\n");
            WriteLiteral(@"
                                <div class=""row"">
                                    <label class=""col-sm-3 col-form-label"">Start Date</label>
                                    <div class=""col-sm-3"">
                                        <input type=""date"" class=""form-control"" id=""StartDate"" name=""StartDate"">
                                        <span class=""text-danger""></span>
                                    </div>

                                    <label class=""col-sm-3 col-form-label"">Search Keyword</label>
                                    <div class=""col-sm-3"">
                                        <input type=""text"" class=""form-control"" id=""SearchString"" placeholder=""Search by string.""");
            BeginWriteAttribute("value", " value=\"", 2551, "\"", 2580, 1);
            WriteAttributeValue("", 2559, 
#nullable restore
#line 56 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                                                                                                          ViewBag.SearchString

#line default
#line hidden
#nullable disable
            , 2559, 21, false);
            EndWriteAttribute();
            WriteLiteral(@">
                                    </div>
                                </div>

                                <div class=""row"">
                                    <label class=""col-sm-3 col-form-label"">End Date</label>
                                    <div class=""col-sm-3"">
                                        <input type=""date"" class=""form-control"" id=""EndDate"" name=""EndDate"">
                                        <span class=""text-danger""></span>
                                    </div>

                                    <div class=""text-end mb-3 col-sm-6"">

                                        <!--<button id=""btnExportEmployeeDetail"" type=""button"" onclick=""fnSearchEmployeeDetail(true)"" class=""btn btn-outline-primary px-5 btn-sm"">Export to Excel</button>-->

                                        <button id=""btnSearchEmployeeDetail"" type=""button"" onclick=""fnSearchNotification(false)"" class=""btn btn-outline-primary px-5 btn-sm"">Search</button>
                         ");
            WriteLiteral("           </div>\r\n                                </div>\r\n\r\n");
            WriteLiteral("                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n                    <div id=\"NotificationListTable\">\r\n");
#nullable restore
#line 82 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                         if (Model.Tables[0].Rows.Count > 0)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral(@"                            <div class=""row"" style=""overflow:auto; height:auto; width:100%;"">
                                <table class=""table table-striped"" style=""white-space: nowrap; font-size:inherit !important;"">
                                    <!--style=""display:block; overflow: auto; white-space: nowrap;""-->

                                    <thead style=""position: sticky; top: 0; background-color:#e9ecf8; color:black; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"">
                                        <tr>
");
#nullable restore
#line 90 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                             foreach (DataColumn dataColumn in Model.Tables[0].Columns)
                                            {
                                                

#line default
#line hidden
#nullable disable

#nullable restore
#line 92 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                 if (dataColumn.ColumnName.Equals("SrNo") || dataColumn.ColumnName.Equals("NotificationText") || dataColumn.ColumnName.Equals("IsView"))
                                                {
                                                    strTimeforRow.Add(dataColumn.ToString());

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                    <th>");
            Write(
#nullable restore
#line 95 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                         dataColumn.ToString().Replace("SrNo","Sr No.").Replace("NotificationText","Notification").Replace("IsView","Status")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</th>\r\n");
#nullable restore
#line 96 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                }

#line default
#line hidden
#nullable disable

#nullable restore
#line 96 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                 

                                            }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                        </tr>\r\n                                    </thead>\r\n\r\n");
#nullable restore
#line 104 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                     foreach (DataRow row in Model.Tables[0].Rows)
                                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                        <tr>\r\n");
#nullable restore
#line 107 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                             foreach (var timeRow in strTimeforRow)
                                            {
                                                

#line default
#line hidden
#nullable disable

#nullable restore
#line 109 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                 if (!string.IsNullOrEmpty(row[timeRow].ToString()))
                                                {
                                                    

#line default
#line hidden
#nullable disable

#nullable restore
#line 111 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                     if (timeRow.Equals("SrNo") || timeRow.Equals("IsView"))
                                                    // @if (timeRow.Equals("SrNo") || timeRow.Equals("IsView") || timeRow.Equals("NotificationText"))
                                                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                        <td>");
            Write(
#nullable restore
#line 114 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                             row[timeRow].ToString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" </td>\r\n");
#nullable restore
#line 115 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                        //<td>@Html.Raw(row[timeRow].ToString()) </td>
                                                    }
                                                    else
                                                    {
                                                        

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                        <td>\r\n");
            WriteLiteral("                                                            <div class=\"flex-grow-1\">\r\n                                                                <h6 class=\"msg-name my-0\">\r\n                                                                    ");
            Write(
#nullable restore
#line 130 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                                     row[4].ToString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n");
            WriteLiteral("                                                                </h6>\r\n");
            WriteLiteral("                                                                <p class=\"msg-info my-0\">");
            Write(
#nullable restore
#line 134 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                                                          row[5].ToString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n                                                                <p class=\"my-0\">");
            Write(
#nullable restore
#line 135 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                                                 row[7].ToString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n                                                            </div>\r\n                                                        </td>\r\n");
#nullable restore
#line 138 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                    }

#line default
#line hidden
#nullable disable

#nullable restore
#line 138 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                     
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                                    <td>-</td>\r\n");
#nullable restore
#line 143 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                }

#line default
#line hidden
#nullable disable

#nullable restore
#line 143 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                        </tr>\r\n");
#nullable restore
#line 149 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                    }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                </table>\r\n\r\n                            </div>\r\n");
#nullable restore
#line 153 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
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
#line 160 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                        }

#line default
#line hidden
#nullable disable

            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            Write(
#nullable restore
#line 167 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
 await Html.PartialAsync("_ValidationScriptsPartial")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"
<script type=""text/javascript"">
    function fnSearchNotification(obj) {
       
        var startDate = $('#StartDate').val();
        var endDate = $('#EndDate').val();
        var searchString = $('#SearchString').val();
        var notificationurl = '");
            Write(
#nullable restore
#line 174 "D:\GitHub\SUN\sunerpm2l\ERP\Views\Notification\ViewAllNotificationList.cshtml"
                                Url.Action("ViewAllNotificationList","Notification")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\';\r\n        var isdownload = obj;\r\n        var empDetailUrl = notificationurl + \'?startDate=\' + startDate + \'&endDate=\' + endDate + \'&searchString=\' + searchString;\r\n       \r\n        window.location.href = empDetailUrl;\r\n    };\r\n\r\n    \r\n\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public 
#nullable restore
#line 14 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
IAuthorizationService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 14 "D:\GitHub\SUN\sunerpm2l\ERP\Views\_ViewImports.cshtml"
AuthorizationService

#line default
#line hidden
#nullable disable
         { get; private set; }
         = default!;
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
