#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b174ff2a93b40a46a2254824758e1eaa2761cc3eb54ce7310d3ddefce3bf2252"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SuperAdmin_Views_FinishGoodItem_Index), @"mvc.1.0.view", @"/Areas/SuperAdmin/Views/FinishGoodItem/Index.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
using Business.Entities.Master;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
using GridCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b174ff2a93b40a46a2254824758e1eaa2761cc3eb54ce7310d3ddefce3bf2252", @"/Areas/SuperAdmin/Views/FinishGoodItem/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/SuperAdmin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_SuperAdmin_Views_FinishGoodItem_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISGrid>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("uiactions", new global::Microsoft.AspNetCore.Html.HtmlString("manipulationchange"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("grid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::GridMvc.TagHelpers.GridTagHelper __GridMvc_TagHelpers_GridTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
  
    ViewData["Title"] = "Finish Good Item";
    Layout = "~/Views/Shared/_LayoutMaster.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" integrity=""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin=""anonymous"" />
<script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"" integrity=""sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"" crossorigin=""anonymous""></script>
<style>
    .btn .disabled {
        cursor: not-allowed;
        pointer-events: none;
        opacity: 0.4;
    }
</style>
");
            WriteLiteral("<div class=\"row pt-2\">\r\n    <div class=\"col-md-12\">\r\n        <div id=\"dvInfo\">\r\n");
#nullable restore
#line 47 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
              
                Html.RenderPartial("_add", new ItemTableCollection());
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n    <div class=\"row pt-2\">\r\n        <div class=\"col-md-12\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("grid", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b174ff2a93b40a46a2254824758e1eaa2761cc3eb54ce7310d3ddefce3bf22527899", async() => {
            }
            );
            __GridMvc_TagHelpers_GridTagHelper = CreateTagHelper<global::GridMvc.TagHelpers.GridTagHelper>();
            __tagHelperExecutionContext.Add(__GridMvc_TagHelpers_GridTagHelper);
#nullable restore
#line 55 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
__GridMvc_TagHelpers_GridTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __GridMvc_TagHelpers_GridTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        </div>
    </div>

<div class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""canvas_fgitem"">
    <div class=""offcanvas-header"">
        <h5 class=""offcanvas-title"">Item</h5>
        <button type=""button"" class=""btn-close text-reset"" data-bs-dismiss=""offcanvas"" aria-l abel=""Close""></button>
    </div>
    <div class=""offcanvas-body pt-3 pb-5"">
        <div id=""dvInfo"">
        </div>
    </div>
</div>
<div id=""finishGoodItemAddControls"">
</div>
<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""exampleModal"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">");
#nullable restore
#line 75 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
                                   Write(ViewBag.TableName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <!-- Preloader -->
            <div id=""modal-preloader"" style=""display:none;"">
                <div class=""modal-preloader_status"">
                    <div class=""modal-preloader_spinner"">
                        <div class=""d-flex justify-content-center"">
                            <div class=""spinner-border"" role=""status""></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Preloader -->
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b174ff2a93b40a46a2254824758e1eaa2761cc3eb54ce7310d3ddefce3bf225211191", async() => {
                WriteLiteral(@"
                    <input type=""hidden"" id=""ItemTableCollectionID"" />
                    <div class=""form-group"">
                        <label id=""lbl1""></label>
                        <input id=""txt1"" class=""form-control"" />
                        <textarea id=""txtA1"" class=""form-control""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label id=""lbl2""></label>
                        <input id=""txt2"" class=""form-control"" />
                        <textarea id=""txtA2"" class=""form-control""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label id=""lbl3""></label>
                        <input id=""txt3"" class=""form-control"" />
                        <textarea id=""txtA3"" class=""form-control""></textarea>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
                              Write(Url.Action("AddControls","FinishGoodItem"));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-action", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""clear"">&nbsp;</div>
                <div class=""divTblData"" style=""height:250px; overflow-y: scroll;""></div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" id=""postbackBtn"" data-save=""modal"">Save changes - Done</button>
                <button type=""button"" class=""btn btn-secondary"" id=""closeBtn"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>

");
#nullable restore
#line 121 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    var urlAdd = \'");
#nullable restore
#line 123 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
             Write(Url.Action("Get", "FinishGoodItem"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var urlDelete = \'");
#nullable restore
#line 124 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
                Write(Url.Action("Delete","FinishGoodItem"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var urlAddControls = \'");
#nullable restore
#line 125 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
                     Write(Url.Action("AddControls","FinishGoodItem"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var urlGetData = \'");
#nullable restore
#line 126 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
                 Write(Url.Action("GetData","FinishGoodItem"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var urlMyPartialView = \'");
#nullable restore
#line 127 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\Index.cshtml"
                       Write(Url.Action("MyPartialView","FinishGoodItem"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    function fnDelete(obj) {
        var _id = $(obj).data('id');
        var act = $(obj).data('act');
        act = act == ""True"" ? false : true;
        var _parameters = { id: _id, active: act };
        $.ajax({
            url: urlDelete,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {

                //$(""#canvas_fgitem"").show();//('hide');
                Lobibox.notify('success', {
                    pauseDelayOnHover: true,
                    size: 'mini',
                    icon: 'bx bx-check-circle',
                    continueDelayOnInactiveTab: false,
                    position: 'bottom right',
                    msg: data.message
                });
                window.location.reload();
            }
        });
    }

    function fnFinishGoodItem(obj, id = 0) {
        var _id = 0;
        if (obj == undefined && id > 0) {
            _id = id;
        }
        else {
           ");
            WriteLiteral(@" _id = $(obj).data('id');
        }
        var _parameters = { id: _id };
        console.log(_parameters);
        $.ajax({
            url: urlAdd,
            type: ""POST"",
            data: _parameters,
            success: function (data, textStatus, jqXHR) {
                $('#dvInfo').html(data);
                //$(""#canvas_fgitem"").show();//('hide');
            }
        });
    }

    function fnAddRecordsToTable(obj) {
        var _id = $(obj).data('id');
        var _parameters = { id: _id };
        console.log(_id);
        $.ajax({
            url: urlGetData,
            type: 'POST',
            data: _parameters,
            success: function (data) {
                console.table(data)
                $('#exampleModal:visible').find('.modal-title').html(data.TableName);
                $frm = $('#exampleModal:visible').find('form');
                $frm.find(""#ItemTableCollectionID"").val(data.ItemTableCollectionID);
                $frm.find(""#lbl1"").html(data");
            WriteLiteral(@".Column1);
                if (data.Column1Type == ""TextArea"") {
                    $frm.find(""#txt1"").remove();
                    $frm.find(""#txtA1"").attr(""asp-items"", data.Column1);
                    $frm.find(""#txtA1"").attr(""type"", data.Column1Type);
                    $frm.find(""#txtA1"").attr(""rows"", 5);
                    $frm.find(""#txtA1"").attr(""cols"", 20);
                    $frm.find(""#lbl1"").attr(""for"", ""txtA1"");
                }
                else {
                    $frm.find(""#txtA1"").remove();
                    $frm.find(""#txt1"").attr(""asp-items"", data.Column1);
                    $frm.find(""#txt1"").attr(""type"", data.Column1Type);
                    $frm.find(""#lbl1"").attr(""for"", ""txt1"");
                    $frm.find(""#txt1"").attr(""required"", ""required"");
                }
                $frm.find(""#lbl2"").html(data.Column2);
                if (data.Column2Type == ""TextArea"") {
                    $frm.find(""#txt2"").remove();
                    $frm.find(""");
            WriteLiteral(@"#txtA2"").attr(""asp-items"", data.Column2);
                    $frm.find(""#txtA2"").attr(""type"", data.Column2Type);
                    $frm.find(""#txtA2"").attr(""rows"", 5);
                    $frm.find(""#txtA2"").attr(""cols"", 20);
                    $frm.find(""#lbl2"").attr(""for"", ""txtA2"");
                }
                else {
                    $frm.find(""#txtA2"").remove();
                    $frm.find(""#txt2"").attr(""asp-items"", data.Column2);
                    $frm.find(""#txt2"").attr(""type"", data.Column2Type);
                    $frm.find(""#lbl2"").attr(""for"", ""txt2"");
                    $frm.find(""#txt2"").attr(""required"", ""required"");
                }
                $frm.find(""#lbl3"").html(data.Column3);
                if (data.Column3Type == ""TextArea"") {
                    $frm.find(""#txt3"").remove();
                    $frm.find(""#txtA3"").attr(""asp-items"", data.Column3);
                    $frm.find(""#txtA3"").attr(""type"", data.Column3Type);
                    $frm.find(""#");
            WriteLiteral(@"txtA3"").attr(""rows"", 5);
                    $frm.find(""#txtA3"").attr(""cols"", 20);
                    $frm.find(""#lbl3"").attr(""for"", ""txtA3"");
                }
                else {
                    $frm.find(""#txtA3"").remove();
                    $frm.find(""#txt3"").attr(""asp-items"", data.Column3);
                    $frm.find(""#txt3"").attr(""type"", data.Column3Type);
                    $frm.find(""#lbl3"").attr(""for"", ""txt3"");
                    $frm.find(""#txt3"").attr(""required"", ""required"");
                }

                $('#exampleModal:visible').find('.modal-body').find('div.divTblData').empty();
                // Load the partial view content using jQuery AJAX
                // Load the list partial view content into the modal body
                $.ajax({
                    url: '/SuperAdmin/FinishGoodItem/MyPartialView',
                    type: 'GET',
                    data: { id: $('#exampleModal:visible').find('.modal-body').find(""#ItemTableCollectionID"").val() }");
            WriteLiteral(@",
                    success: function (data) {
                        $('#exampleModal:visible').find('.modal-body').find('div.divTblData').html(data);
                    },
                    error: function (xhr, status, error) {
                        console.error('Error loading list partial view: ' + error);
                    }
                });
            }
        });

    }

    $(function (e) {
        $(""#modal-preloader"").hide();
        //$('button[data-save=""modal""]').on('click', function (data) {
        //    console.log('click')
        //    $frm = $(this).parent().prev().find('form');
        //    var actionUrl =  $frm.attr(""action"");
        //    console.log(actionUrl)
        //    var sendData = $frm.serialize();
        //    $.post(actionUrl, sendData).done(function (data) {
        //        $modal.modal('hide');
        //    })
        //});

        $('#exampleModal').on('show.bs.modal', function (event) {
            var modal = $(this);

 ");
            WriteLiteral(@"           // Load the add/edit partial view content into the modal body
            //$.ajax({
            //    url: '/SuperAdmin/FinishGoodItem/AddControls',
            //    type: 'GET',
            //    success: function (data) {
            //        modal.find('.modal-body').html(data);
            //    },
            //    error: function (xhr, status, error) {
            //        console.error('Error loading add/edit partial view: ' + error);
            //    }
            //});
            // Load the list partial view content into the modal body
            //modal.find('.modal-body').find('div.divTblData').empty();
            console.log(""HTML "" + modal.find('.modal-body').find('div.divTblData').find(""table.TFtable tr"").length)
            if (modal.find('.modal-body').find('div.divTblData').find(""table.TFtable tr"").length <= 1) {
                $.ajax({
                    url: '/SuperAdmin/FinishGoodItem/MyPartialView',
                    type: 'GET',
                 ");
            WriteLiteral(@"   data: { id: modal.find('.modal-body').find(""#ItemTableCollectionID"").val() },
                    success: function (data) {
                        modal.find('.modal-body').find('div.divTblData').html(data);
                    },
                    error: function (xhr, status, error) {
                        console.error('Error loading list partial view: ' + error);
                    }
                });
            }
        });

        $('#postbackBtn').on('click', function () {
            // Make the AJAX call
            $this = $(this);
            $frm = $this.parent().prev().find('form');
            var actionUrl = urlAddControls;
            console.log(actionUrl)
            var finishGoodItemDynamic = {
                TableName: $this.parents().find('.modal-title').html(),
                ItemTableCollectionID: $frm.find(""#ItemTableCollectionID"").val(),
                aList: [
                    { name: $frm.find(""label[id='lbl1']"").text(), value: $frm.find(""i");
            WriteLiteral(@"nput[type='text']"").eq(0).val() },
                    { name: $frm.find(""label[id='lbl2']"").text(), value: $frm.find(""input[type='text']"").eq(1).val() },
                    { name: $frm.find(""label[id='lbl3']"").text(), value: $frm.find(""textarea"").val() }
                ]
            }
            $this.parents().find('.modal-body').find('div.divTblData').empty();
            $.ajax({
                url: actionUrl,
                type: 'POST',
                data: finishGoodItemDynamic,
                success: function (data) {
                    // Close the modal
                    console.log(data.length)
                    if (data.length) {

                        //$this.parents("".modal"").modal('hide');
                    }
                }
            });
            $this.parents().find('.modal-body').find(""form"").find(""input[class='form-control']"").val("""");
            $this.parents().find('.modal-body').find(""form"").find(""textarea[class='form-control']"").val("""");
  ");
            WriteLiteral(@"          //$(""#modal-preloader"").delay(5000).fadeOut(100);
            $('#exampleModal:visible').find(""#closeBtn"").trigger(""click"");
            // Load the list partial view content into the modal body
            //$.ajax({
            //    url: '/SuperAdmin/FinishGoodItem/MyPartialView',
            //    type: 'GET',
            //    data: { id: $this.parents().find('.modal-body').find(""#ItemTableCollectionID"").val() },
            //    success: function (dataVal) {
                    
            //        $this.parents().find('.modal-body').find('div.divTblData').empty();

            //        $this.parents().find('.modal-body').find('div.divTblData').html(dataVal);
            //        $(""#modal-preloader"").hide();
            //    },
            //    error: function (xhr, status, error) {
            //        console.error('Error loading list partial view: ' + error);
            //    }
            //});
        });
    });
</script>");
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