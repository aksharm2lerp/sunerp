#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\Shared\_meetingNotificationModal.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ea614dee83ef2f0e1ad9e0be646f518a2e7752f264c1ef1818ce93528bd1643f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__meetingNotificationModal), @"mvc.1.0.view", @"/Views/Shared/_meetingNotificationModal.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ea614dee83ef2f0e1ad9e0be646f518a2e7752f264c1ef1818ce93528bd1643f", @"/Views/Shared/_meetingNotificationModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"9af2a5bd844c76fa2170a48777822dbd4537e1a6e69a69cabcf43956cc6762c3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__meetingNotificationModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\Shared\_meetingNotificationModal.cshtml"
  
    int reminderId = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal fade"" id=""ModalReminder"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h1 class=""modal-title fs-5"" id=""exampleModalLabel""><span id=""reminderTitle""></span></h1>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">

                <div class=""row mb-3"">
                    <div class=""col-12"">
");
            WriteLiteral(@"                        <span id=""reminderSubject""></span>
                    </div>
                </div>

            </div>
            <div class=""modal-footer"">
                <input type=""hidden"" id=""reminderId"" />
                <button type=""button"" class=""btn btn-secondary"" onclick=""fnReviewReminder()"">Got it!</button>
                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Close</button>

            </div>
        </div>
    </div>
</div>

<script>

    var reminderId;

    $(function () {
        setInterval(function () {
            let reminderUrl = '");
#nullable restore
#line 37 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\Shared\_meetingNotificationModal.cshtml"
                          Write(Url.Action("GetReminder", "Notification"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
            $.ajax({
                url: reminderUrl,
                type: 'GET',
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    if (data.status) {
                        document.getElementById('reminderSubject').innerHTML = data.reminderModel.reminderSubject;
                        document.getElementById('reminderTitle').innerHTML = data.reminderModel.reminderTitle;
                        document.getElementById('reminderId').value = data.reminderModel.reminderID;
                        //reminderId =  data.reminderModel.reminderSubject;
                        //alert(reminderId);
                        //debugger;
                        //$(""#ModalReminder"").show();
                        $(""#ModalReminder"").modal(""show"");
                        //Lobibox.notify('success', {
                        //    pauseDelayOnHover: true,
                        //    size: 'mini',
                        //    icon");
            WriteLiteral(@": 'bx bx-check-circle',
                        //    continueDelayOnInactiveTab: false,
                        //    position: 'bottom right',
                        //    msg: data.message
                        //});
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
#line 70 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\Shared\_meetingNotificationModal.cshtml"
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
        }, 10000);
    });

    function fnReviewReminder() {
        let id = document.getElementById('reminderId').value;
        let reminderReviweUrl = '");
#nullable restore
#line 81 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\Shared\_meetingNotificationModal.cshtml"
                            Write(Url.Action("ReviewReminder", "Notification"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        let params = { reminderId: id };
        $.ajax({
            url: reminderReviweUrl,
            type: 'POST',
            data: params,
            dataType: 'json',
            success: function (data, textStatus, jqXHR) {
                if (data.status) {
                    $(""#ModalReminder"").modal(""hide"");
                    Lobibox.notify('success', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                }
                else {
                    $(""#ModalReminder"").modal(""hide"");
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        conti");
            WriteLiteral(@"nueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                }
            },
            error: function (error) {
                $(""#ModalReminder"").modal(""hide"");
                laddaStop(l);
                Lobibox.notify('error', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom right',
                    msg: """);
#nullable restore
#line 121 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Views\Shared\_meetingNotificationModal.cshtml"
                     Write(MessageHelper.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                });\r\n            }\r\n        }).always(function () {\r\n            hideLoader();\r\n        });\r\n    };\r\n</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; } = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
