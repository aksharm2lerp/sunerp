#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\SolarCable.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73f13403f02dbd6d2289137c75bc15c3b6a2b91a42582e62a9a2b8746ee36397"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SolarCable), @"mvc.1.0.view", @"/Views/Home/SolarCable.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"73f13403f02dbd6d2289137c75bc15c3b6a2b91a42582e62a9a2b8746ee36397", @"/Views/Home/SolarCable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"9af2a5bd844c76fa2170a48777822dbd4537e1a6e69a69cabcf43956cc6762c3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_SolarCable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Business.Entities.ProductPhotoPath.ProductPhotoPath>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetPdf", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\SolarCable.cshtml"
  
    ViewData["Title"] = "Solar Cable Wire Information";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container margin-top-80\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12 col-md-12 col-lg-12 mx-auto\">\r\n            <div class=\"card border-0 shadow rounded-3\">\r\n                <div class=\"card-body\">\r\n");
            WriteLiteral("                    <div class=\"ProductImage\">\r\n                        <h1 class=\"text-center pt-3\">SOLAR CABLE</h1>\r\n                        <div class=\"row mb-5\" id=\"imagesLoop\">\r\n");
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\SolarCable.cshtml"
                             foreach(var items in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-sl-12 col-md-4 col-lg-4 col-xl-4 my-3\">\r\n                                <div class=\"card\">\r\n                                    <img id=\"img01\"");
            BeginWriteAttribute("src", " src=\"", 2735, "\"", 2787, 1);
#nullable restore
#line 47 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\SolarCable.cshtml"
WriteAttributeValue("", 2741, Html.DisplayFor(modelItem => items.ImagePath), 2741, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""card-img-top rounded mx-auto d-block"" alt=""Solar Cable"" style=""width:150px; height:150px;"">
                                    <div class=""card-body text-center"">
                                        <button type=""button"" class=""btn btn-primary px-5 my-3"">RFQ</button>
                                        <h4 class=""card-title"">");
#nullable restore
#line 50 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\SolarCable.cshtml"
                                                          Write(Html.DisplayFor(modelItem => items.ProductImageText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                        <p class=\"card-text\">");
#nullable restore
#line 51 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\SolarCable.cshtml"
                                                        Write(Html.DisplayFor(modelItem => items.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 55 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\SolarCable.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            
                        </div>


                        <p><b>Application:</b> Solar cable is the interconnection cable used in photovoltaic power generation device and which interconnects solar panels and other electrical components of a photovoltaic system.</p>

                        <p><b>Conductor:</b> The photovoltaic power system means outdoor green electric generation, so solar cables are designed for</p>

                        <ul style=""list-style-type:circle;"">
                            <li>High temperatures resistance</li>
                            <li>High UV radiation resistance</li>
                            <li>Dry or Wet weather resistance</li>
                            <li>Salty moisture resistant.</li>
                            <li>High temperatures resistance</li>
                        </ul>

                        <p>Single-core cables with a maximum permissible DC voltage of 600 V to 2000 V and a temperature range from -40°C t");
            WriteLiteral(@"o +105°C are generally used.</p>

                        <p>A three-core cable is used for connection to the grid if a single-phase inverter is used, and a five-core cable is used for three-phase feed-in</p>

                        <p><b>Conductor :</b> EC Grade Annealed Tinned Copper (ATC) with 99.90 % to 99.97 % purity, which offer low conductor resistance, lower heating which help maximum current follow with less resistance to storage device or high tension connected line.</p>

                        <p>On demand EC grade bare copper can be used with 99.90% to 99.97% purity</p>

                        <div class=""row"">
                            <img src=""../../assets/images/wireImages/Products/Solar Cable/Solar Cable.jpg"" alt=""Solar Cable""");
            BeginWriteAttribute("class", " class=\"", 5252, "\"", 5260, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <!--\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("                         -->\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached2.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 19252, "\"", 19260, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached3.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 19492, "\"", 19500, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached4.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 19732, "\"", 19740, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached5.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 19972, "\"", 19980, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached6.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 20212, "\"", 20220, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached7.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 20452, "\"", 20460, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached8.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 20692, "\"", 20700, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"height:100%;\">\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <img src=\"../../assets/images/wireImages/Products/Solar Cable/Picture-attached9.jpg\" alt=\"Solar Cable\"");
            BeginWriteAttribute("class", " class=\"", 20932, "\"", 20940, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""height:100%;"">
                        </div>

                        <div class=""text-center"">
                            <div class=""download-part-all"">
                                <div class=""download-btn"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73f13403f02dbd6d2289137c75bc15c3b6a2b91a42582e62a9a2b8746ee3639714543", async() => {
                WriteLiteral("\r\n                                        <img src=\"../../assets/images/wireImages/Brochure/dn-brochure.png\" alt=\"Download Brochure\" class=\"ProductBrochure\">\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type=""text/javascript"">
    for (int i = 0; i < ViewBag.Image.Count(); i++)
    {
        debugger
        document.getElementById(""imagesLoop"").innerHTML += ""<div>col"" + i + ""</div>"";
        //var test = imgPath.
        //    $(document).ready(function() {
        //        function() {
        //            document.getElementById('img01').src = myJsVariable.Count()[i];
        //            //document.getElementById('personEmailToMeet').value = data.officeEmail;
        //        };
        //    });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Business.Entities.ProductPhotoPath.ProductPhotoPath>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591