#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2f928b8f3bb8cb2a8cf12690a488fbb9efeb4e284782e1595d36b96f35e1f0ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HR_Views_GatePass_Index), @"mvc.1.0.view", @"/Areas/HR/Views/GatePass/Index.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
using GridCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"2f928b8f3bb8cb2a8cf12690a488fbb9efeb4e284782e1595d36b96f35e1f0ac", @"/Areas/HR/Views/GatePass/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/HR/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_HR_Views_GatePass_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISGrid>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "HR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "GatePass", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
  
    ViewData["Title"] = "Canteen Charges Master";
    Layout = "~/Views/Shared/_LayoutMaster.cshtml";

    var userlogin = UserManager.GetUserAsync(User).Result;
    var roles = UserManager.GetRolesAsync(userlogin).Result;
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-sm-12 col-md-12 col-lg-12 mx-auto"">
    <div class=""card border-1 shadow rounded-7 p-1"">
        <div class=""row border-bottom"">
            <div class=""col-sm-12 col-md-6 col-lg-6"">
                <div class=""page-breadcrumb align-items-center"">
                    <div class=""p-2"">
                        <nav aria-label=""breadcrumb"">
                            <ol class=""breadcrumb mb-0 p-0"">
                                <li class=""breadcrumb-item"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f928b8f3bb8cb2a8cf12690a488fbb9efeb4e284782e1595d36b96f35e1f0ac7115", async() => {
                WriteLiteral("<i class=\"bx bx-home-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">Employee Gatepass List</li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>

            <div class=""col-sm-12 col-md-6 col-lg-6 text-end my-2"">
");
#nullable restore
#line 39 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                 if (ViewBag.DisplayName != "Security")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <a class=""btn btn-primary px-5"" onclick=""fnEmployeeGatepass(this)""
                    href=""javascript:void(0)""
                    data-id=""0""
                    data-key=""0""
                    data-bs-toggle=""offcanvas""
                    data-bs-target=""#canvasEmployeeGatepass""
                    aria-controls=""canvasEmployeeGatepass"">
                        Add Gatepass
                    </a>
");
#nullable restore
#line 50 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("grid", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2f928b8f3bb8cb2a8cf12690a488fbb9efeb4e284782e1595d36b96f35e1f0ac10193", async() => {
            }
            );
            __GridMvc_TagHelpers_GridTagHelper = CreateTagHelper<global::GridMvc.TagHelpers.GridTagHelper>();
            __tagHelperExecutionContext.Add(__GridMvc_TagHelpers_GridTagHelper);
#nullable restore
#line 56 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
__GridMvc_TagHelpers_GridTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
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

        <div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvasEmployeeGatepass"">
            <div class=""offcanvas-header"">
                <h5 class=""offcanvas-title"" id=""canvasHeaderNameEmployeeGatepass""></h5>
                <button type=""button"" class=""btn-close te  xt-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
            </div>
            <div class=""offcanvas-body pt-3 pb-5"">
                <div id=""dvInfoEmployeeGatepass"">
                </div>
            </div>
        </div>

    </div>
</div>
<script type=""text/javascript"">
    var urlAddUpdateEmployeeGatepass = '");
#nullable restore
#line 74 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                                   Write(Url.Action("AddUpdateEmployeeGatepass", "GatePass"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    function fnEmployeeGatepass(obj) {
        var _id = $(obj).data('id');
        var _empId = $(obj).data('key');
        //var _id = leaveTypeId;//$(this).data('id');
        //var _employeeId = $(""#LeaveTypeID"").val();
        if (_id > 0) {
            document.getElementById(""canvasHeaderNameEmployeeGatepass"").innerHTML = ""Update Employee Gatepass"";
        }
        else {
            document.getElementById(""canvasHeaderNameEmployeeGatepass"").innerHTML = ""Add Employee Gatepass"";
        }
        var _parameters = { employeeId: _empId, employeeGatePassID: _id };
        $.ajax({
            url: urlAddUpdateEmployeeGatepass,
            type: ""GET"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $(""#canvasEmployeeGatepass"").show();//('hide');
                $('#dvInfoEmployeeGatepass').html(data);
            }
        });
    }


    //  Print Function
    function fnPrint(obj) {
        let _id = $(obj).data('i");
            WriteLiteral(@"d');
        //let _empId = $(obj).data('key');

        var currentUrl = window.location.href;
        var newUrl = currentUrl.replace('/HR/GatePass', '/ReportViewer/');
        let url = newUrl + 'ReportViewer/OnPostGetHTML';
        debugger;
        let parameters = { employeeGatepassId: _id };
        $.ajax({
            type: 'POST',
            url: url,
            data: parameters,
            dataType: 'json',
            success: function (data) {
                if (data.status) {
                    var newTab = window.open();
                    newTab.document.open();
                    newTab.document.write(data.data);
                    newTab.document.close();
                }
                else {
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                       ");
            WriteLiteral(@" position: 'bottom right',
                        msg: 'Error to load report.'
                    });
                }
            },
            error: function (error) {
                laddaStop(l);
                Lobibox.notify('error', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom right',
                    msg: """);
#nullable restore
#line 140 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                     Write(MessageHelper.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                });
            }
        }).always(function () {
            hideLoader();
        });
    };

    //// Print Function


    //// HOD active inactive Function.
    ////function fnHODApprove(obj) {
    ////    alert('fnHODApprove function invoked');
    ////    let _id = $(obj).data('id');
    ////    //let _empId = $(obj).data('key');
    ////    let rowid = $(obj).data('rowid');
    ////    alert('row id is ' + rowid);
    ////    var currentUrl = window.location.href;
    ////    var newUrl = currentUrl.replace('/HR/GatePass', '/ReportViewer/');
    ////    let url = newUrl + 'ReportViewer/OnPostGetHTML';
    ////    return true;
    ////    debugger;
    ////    let parameters = { employeeGatepassId: _id };
    ////    $.ajax({
    ////        type: 'POST',
    ////        url: url,
    ////        data: parameters,
    ////        dataType: 'json',
    ////        success: function (data) {
    ////            if (data.status) {
    ////                var");
            WriteLiteral(@" newTab = window.open();
    ////                newTab.document.open();
    ////                newTab.document.write(data.data);
    ////                newTab.document.close();
    ////            }
    ////            else {
    ////                Lobibox.notify('error', {
    ////                    pauseDelayOnHover: true,
    ////                    size: 'mini',
    ////                    icon: 'bx bx-check-circle',
    ////                    continueDelayOnInactiveTab: false,
    ////                    position: 'bottom right',
    ////                    msg: 'Error to load report.'
    ////                });
    ////            }
    ////        },
    ////        error: function (error) {
    ////            laddaStop(l);
    ////            Lobibox.notify('error', {
    ////                pauseDelayOnHover: true,
    ////                size: 'mini',
    ////                icon: 'bx bx-check-circle',
    ////                continueDelayOnInactiveTab: false,
    ////");
            WriteLiteral(@"                position: 'bottom right',
    ////                msg: ""MessageHelper.Error""
    ////            });
    ////        }
    ////    }).always(function () {
    ////        hideLoader();
    ////    });
    ////};

    //// HOD active inactive Function.

    //// HR Approve function.

    //function fnHRApprove(obj) {
    //    alert('fnHRApprove function invoked');
    //    let _id = $(obj).data('id');
    //    //let _empId = $(obj).data('key');
    //    let rowid = $(obj).data('rowid');
    //    alert('row id is ' + rowid);
    //};

    //// HR Approve function.

    //// Security Approve function.

    //function fnSecurityApprove(obj) {
    //    alert('fnSecurityApprove function invoked');
    //    let _id = $(obj).data('id');
    //    //let _empId = $(obj).data('key');
    //    let rowid = $(obj).data('rowid');
    //    alert('row id is ' + rowid);
    //};

    //// Security Approve function.

    // Active Inactive HOD, HR Access.

    functi");
            WriteLiteral("on fnActiveInactiveApproval(obj) {\r\n      \r\n        var urlAddRemoveApproval = \'");
#nullable restore
#line 233 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                               Write(Url.Action("AddRemoveApproval", "GatePass"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        let rowid = $(obj).data('rowid');
        let _isApproved = document.getElementById(rowid).checked;
        let approval = $(obj).data('approval');
        let _id = $(obj).data('id');
        let parameters = { employeeGatepassId: _id, isApproved: _isApproved, approvalName: approval };
        //debugger;
        //let isfalse = isTrue.is(':checked');
        //debugger;
        //let _isAccess = $('#' + rowid).is(':checked');
        //let _empId = $(obj).data('key');
        
        $.ajax({
            type: 'POST',
            url: urlAddRemoveApproval,
            data: parameters,
            dataType: 'json',
            success: function (data) {
                if (data.status) {
                    //var newTab = window.open();
                    //newTab.document.open();
                    //newTab.document.write(data.data);
                    //newTab.document.close();

                    Lobibox.notify('success', {
                        pauseDelayOnHove");
            WriteLiteral(@"r: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                    //setTimeout(
                    //    function () {
                    //        window.location.reload();
                    //    }, 3000);

                }
                else {
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: 'Error to load report.'
                    });
                }
            },
            error: function (error) {
                laddaStop(l);
                Lobibox.notify('error', {
 ");
            WriteLiteral(@"                   pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom right',
                    msg: """);
#nullable restore
#line 290 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                     Write(MessageHelper.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                });
            }
        }).always(function () {
            hideLoader();
        });
    };

    // Active Inactive HOD, HR Approval.


    // Update in and Out Time by Security.

    function fnUpdateInOutTime(obj){
        var urlUpdateGatePassInOutTime = '");
#nullable restore
#line 304 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                                     Write(Url.Action("UpdateGatePassInOutTime", "GatePass"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        let rowid = $(obj).data('rowid');
        let checked = document.getElementById(rowid).checked;
        let time = $(obj).data('time');
        let _id = $(obj).data('id');
        let parameters = { employeeGatepassId: _id, isChecked: checked, time: time, };
        $.ajax({
            type: 'POST',
            url: urlUpdateGatePassInOutTime,
            data: parameters,
            dataType: 'json',
            success: function (data) {
                if (data.status) {
                    //var newTab = window.open();
                    //newTab.document.open();
                    //newTab.document.write(data.data);
                    //newTab.document.close();

                    Lobibox.notify('success', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
           ");
            WriteLiteral(@"             msg: data.message
                    });
                    //setTimeout(
                    //    function () {
                    //        window.location.reload();
                    //    }, 3000);

                }
                else {
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: 'Error to update time.'
                    });
                }
            },
            error: function (error) {
                laddaStop(l);
                Lobibox.notify('error', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom r");
            WriteLiteral("ight\',\r\n                    msg: \"");
#nullable restore
#line 355 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\HR\Views\GatePass\Index.cshtml"
                     Write(MessageHelper.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                });\r\n            }\r\n        }).always(function () {\r\n            hideLoader();\r\n        });\r\n    };\r\n\r\n    // Update in and Out Time by Security.\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<UserMasterMetadata> UserManager { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<UserMasterMetadata> SignInManager { get; private set; } = default!;
        #nullable disable
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
