#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\Views\MasterPacking\_printMultipleQrCode .cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0b6021471e36e163a55efea9808f206884dceb96e659f4a88a57daaf43a487eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Production_Views_MasterPacking__printMultipleQrCode_), @"mvc.1.0.view", @"/Areas/Production/Views/MasterPacking/_printMultipleQrCode .cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using ERP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using ERP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using Business.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using Business.SQL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using ERP.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using ERP.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using ERP.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\_ViewImports.cshtml"
using Business.Entities.Dynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\Views\MasterPacking\_printMultipleQrCode .cshtml"
using Business.Entities.Production.MasterPackingModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0b6021471e36e163a55efea9808f206884dceb96e659f4a88a57daaf43a487eb", @"/Areas/Production/Views/MasterPacking/_printMultipleQrCode .cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/Production/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Production_Views_MasterPacking__printMultipleQrCode_ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedDataTable<MasterPacking>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade bd-example-modal-xl"" id=""masterPackageMultipleQRCode"" tabindex=""-1"" aria-labelledby=""myExtraLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-xl"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h1 class=""modal-title fs-5"" id=""exampleMasterPackageModalLabel"">Master Packing Multiple QR Code</h1>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div>
                </p>
            </div>
            <div class=""modal-body"">
                <fieldset>
                    <div class=""text-center"" id=""printAbleAreaMultipleQRCodeMasterPacking"">
                        <div class=""row"">
");
#nullable restore
#line 17 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\Views\MasterPacking\_printMultipleQrCode .cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-4 printMultipleMasterPackageQRCode py-2\">\r\n                                    <div>\r\n");
#nullable restore
#line 21 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\Views\MasterPacking\_printMultipleQrCode .cshtml"
                                          
                                            string imgUrl = "https://chart.googleapis.com/chart?cht=qr&chl=" + item.MasterPackingCode + "&chs=200x200&chld=L|0";
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <img");
            BeginWriteAttribute("src", " src=\"", 1393, "\"", 1406, 1);
#nullable restore
#line 24 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\Views\MasterPacking\_printMultipleQrCode .cshtml"
WriteAttributeValue("", 1399, imgUrl, 1399, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"qr-code img-thumbnail\" />\r\n\r\n                                    </div>\r\n                                    <div>\r\n                                        <label");
            BeginWriteAttribute("for", " for=\"", 1577, "\"", 1583, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"col-form-label text-dark h1\">");
#nullable restore
#line 28 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\Views\MasterPacking\_printMultipleQrCode .cshtml"
                                                                                     Write(item.UserBatchCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                                    </div>\r\n\r\n                                </div>\r\n");
#nullable restore
#line 32 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\Production\Views\MasterPacking\_printMultipleQrCode .cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </fieldset>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" onclick=""printDiv(printAbleAreaMultipleQRCodeMasterPacking)"">Print</button>
                <button type=""button"" class=""btn btn-secondary"" onclick=""fnCloseModal()"" data-bs-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">

    function printDiv(divName) {        
        window.print();
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedDataTable<MasterPacking>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
