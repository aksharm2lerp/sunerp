#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Shared\_remainder.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "cf83c4eb3dcbe6107b7db0c4467b91e6f9c9d4f45f19c6d95728313cc28a049b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__remainder), @"mvc.1.0.view", @"/Views/Shared/_remainder.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cf83c4eb3dcbe6107b7db0c4467b91e6f9c9d4f45f19c6d95728313cc28a049b", @"/Views/Shared/_remainder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"9af2a5bd844c76fa2170a48777822dbd4537e1a6e69a69cabcf43956cc6762c3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__remainder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<a class=""nav-link dropdown-toggle dropdown-toggle-nocaret position-relative"" href=""#"" role=""button"" data-bs-toggle=""dropdown"" aria-expanded=""false"">

    <div onclick=""fnOpenReminderDRP()"">
        <span class=""alert-count"" id=""reminderAlertCount""></span>
        <iconify-icon icon=""fluent-mdl2:reminder-time""></iconify-icon>
    </div>
</a>
<div class=""dropdown-menu dropdown-menu-end"">
    <a href=""javascript:;"">
        <div class=""msg-header"">
            <label class=""msg-header-title"">Reminder</label>
");
            WriteLiteral("        </div>\r\n    </a>\r\n    <div class=\"header-message-list\">\r\n        <div id=\"reminderLists\">\r\n");
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n    \r\n\r\n    <div class=\"msg-footer row\">\r\n");
            WriteLiteral(@"        <a class=""col-12 text-end"" data-bs-toggle=""modal"" data-bs-target=""#ModalAddReminder"" onclick=""fnRemainderAddDetailsModal()"">
            Add New Remainder
        </a>
    </div>
</div>


<div class=""modal fade"" id=""ModalAddReminder"" data-bs-backdrop=""static"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-top"">
        <div class=""modal-content"">
            <div class=""modal-header"" style=""background-color:aliceblue;"">
                <h1 class=""modal-title fs-5"" id=""exampleModalLabel""><iconify-icon icon=""fluent-mdl2:reminder-time""></iconify-icon><span>&nbsp; &nbsp; Add Reminder</span></h1>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">

                <div class=""row"">
                    <div class="".col-sm-4"">
                        <h6 for=""reminderDate"">Date:</h6>
                    </div>
   ");
            WriteLiteral("                 <div class=\".col-sm-8\">\r\n                        <input type=\"date\" class=\"form-control h6\" id=\"reminderDate\" name=\"reminderDate\" placeholder=\"dd-mm-yyyy\"");
            BeginWriteAttribute("value", " value=\"", 2655, "\"", 2663, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
                <div class=""row"">
                    <div class="".col-sm-4"">
                        <h6 for=""reminderTime"">Time:</h6>
                    </div>
                    <div class="".col-sm-8"">
                        <input type=""time"" class=""form-control h6"" id=""reminderTime"" name=""reminderTime"">
                    </div>
                </div>
                <div class=""row"">
                    <div class="".col-sm-6"">
                        <h6 for=""reminderText"">Subject</h6>
                    </div>
                    <div class="".col-sm-6"">
                        <input type=""text"" class=""form-control h6"" id=""reminderSubject"">
                    </div>
                </div>
                <div class=""row"">
                    <div class="".col-sm-4"">
                        <h6 for=""reminderText"">Description</h6>
                    </div>
                    <div class="".col-sm-8"">
                        ");
            WriteLiteral(@"<textarea class=""form-control h6"" id=""reminderText"" rows=""3""></textarea>
                    </div>
                </div>

            </div>
            <div class=""modal-footer"" style=""background-color:aliceblue;"">
                <button type=""button"" class=""btn h6 btn-primary"" onclick=""fnAddReminder()"">Save</button>
                <button type=""button"" class=""btn h6 btn-secondary"" data-bs-dismiss=""modal"">Back</button>
            </div>
        </div>
    </div>
</div>


<script>

    //var urlGetReminder = 'Url.Action(""GetReminderCount"", ""Notification"")';
    $(function () {

        // Call the updateNotificationCount function every 3 seconds
        setInterval(function () {
            //alert('GetReminderCount fn invoked');
            //alert('GetNotificationCount ajax invoked ""urlGetReminder"" - ' + urlGetReminder);
            // code to be executed
            $.ajax({
                url: '/Notification/GetReminderCount',
                type: 'GET',
                d");
            WriteLiteral(@"ataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    //debugger;
                    var reminderCount = data.count.length;
                    if (reminderCount > 0) {
                        $('#reminderAlertCount').text(reminderCount);
                    }
                    else {
                        $('#reminderAlertCount').text('');
                        $('#reminderAlertCount').removeClass('alert-count');
                    }
                    // Get the element with the class you want to disable
                    var element = document.getElementById('alert-count');

                    // Disable the class by adding a disabled class
                    element.classList.add('disabled');

                    //// Create an Audio object with the path to your sound file
                    //var notificationSound = new Audio('C:/Users/Lenovo/Documents/GitHub/aksharm2l/ERP/wwwroot/audio/notification/Simple-notification.mp3');
");
            WriteLiteral(@"
                    //// Call the play() method when you want to play the sound
                    //notificationSound.play();

                    //notificationSound.addEventListener('error', function () {
                    //    alert('Notification sound not paly');
                    //    // Code to be executed if there is an error playing the sound
                    //});
                },
                Error: function () {
                    alert('error function occured.');
                }
            });
        }, 3000); // 3000 milliseconds = 3 seconds
    });

    var urlViewAllReminder = '");
#nullable restore
#line 144 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Shared\_remainder.cshtml"
                         Write(Url.Action("ViewAllReminder","Notification"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    function fnViewAllReminder() {

        var l = laddaStart('viewAllReminder');
        console.log('l-- ' + l);
        modeldata = $(""#viewAllReminder"").serialize();
        alert(""urlViewAllReminder---"" + urlViewAllReminder);
        $.ajax({
            url: urlViewAllReminder,
            type: 'POST',
            dataType: 'json',
            data: modeldata,
            beforeSend: function () { },
            success: function (data) {
                if (data.status) {
                    //alert('Viewed All Notification');
                    //notification
                    //$(""#canvas_masterentity2"").hide();//('hide');
                    //Lobibox.notify('success', {
                    //    pauseDelayOnHover: true,
                    //    size: 'mini',
                    //    icon: 'bx bx-check-circle',
                    //    continueDelayOnInactiveTab: false,
                    //    position: 'bottom right',
                    //    msg: data.message");
            WriteLiteral(@"
                    //});
                }
                else {
                    //alert('error - 1');
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                }
            },
            error: function (error) {
                //alert('error - 2');
                laddaStop(l);
                Lobibox.notify('error', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom right',
                    msg: """);
#nullable restore
#line 192 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Shared\_remainder.cshtml"
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

    function fnRemainderAddDetailsModal() {
        $(""#ModalAddReminder"").modal(""show"");
    }

    function fnAddReminder() {
        // alert('fnAddReminder invoked');
        let reminderDate = $('#reminderDate').val();
        let reminderTime = $('#reminderTime').val();
        let reminderSubject = $('#reminderSubject').val();
        let reminderText = $('#reminderText').val();
        // alert(`reminderDate ${reminderDate},reminderTime ${reminderTime}, reminderText ${reminderText}, reminderSubject ${reminderSubject} `);
        //let addReminderUrl = 'Url.Action(""AddReminder"",""Notification"")';
        //alert('addReminderUrl-- ' + addReminderUrl)
        let _parameters = { reminderDate: reminderDate, reminderTime: reminderTime, reminderText: reminderText, reminderSubject: reminderSubject }
        $.ajax({
            type: 'POST',
            //url: addReminder");
            WriteLiteral(@"Url,
            url: '/Notification/AddReminder',
            data: _parameters,
            dataType: 'json',
            beforeSend: function () { },
            success: function (data) {
                if (data.status) {
                    //Remainder
                    Lobibox.notify('success', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelayOnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                    $(""#ModalAddReminder"").modal(""hide"");
                    window.location.reload().delay(5000);
                }
                else {
                    Lobibox.notify('error', {
                        pauseDelayOnHover: true,
                        size: 'mini',
                        icon: 'bx bx-check-circle',
                        continueDelay");
            WriteLiteral(@"OnInactiveTab: false,
                        position: 'bottom right',
                        msg: data.message
                    });
                }
                //window.location.reload().delay(5000);
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
#line 256 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Shared\_remainder.cshtml"
                     Write(MessageHelper.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                });\r\n            }\r\n        }).always(function () {\r\n            hideLoader();\r\n        });\r\n    };\r\n\r\n</script>\r\n");
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
