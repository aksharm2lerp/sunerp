#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\BuildingWire.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ec057481e615017d8182872c1891228dd98cac133858b282d7926c116cebdf1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BuildingWire), @"mvc.1.0.view", @"/Views/Home/BuildingWire.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ec057481e615017d8182872c1891228dd98cac133858b282d7926c116cebdf1d", @"/Views/Home/BuildingWire.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"9af2a5bd844c76fa2170a48777822dbd4537e1a6e69a69cabcf43956cc6762c3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_BuildingWire : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharerp\aksharm2l\ERP\Views\Home\BuildingWire.cshtml"
  
    ViewData["Title"] = "Building Wire Wire Information";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container margin-top-80\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12 col-md-12 col-lg-12 mx-auto\">\r\n            <div class=\"card border-0 shadow rounded-3\">\r\n                <div class=\"card-body\">\r\n");
            WriteLiteral("                    <div class=\"hero-container\">\r\n                        <div id=\"heroCarousel\" class=\"carousel slide carousel-fade\" data-bs-ride=\"carousel\" data-bs-interval=\"2500\">\r\n\r\n");
            WriteLiteral(@"
                            <div class=""carousel-inner"" role=""listbox"">
                                <div class=""carousel-item active"">
                                    <img src=""../../assets/images/wireImages/Products/BuildingWire/SLBuildingWire.jpg""
                                         class=""rounded mx-auto d-block"" alt=""Building Wire"">
                                </div>
                                <div class=""carousel-item"">
                                    <img src=""../../assets/images/wireImages/Products/BuildingWire/building-wire.png""
                                         class=""rounded mx-auto d-block"" alt=""Building Wire"">
                                </div>
                                <div class=""carousel-item"">
                                    <img src=""../../assets/images/wireImages/Products/BuildingWire/building-wire2.png""
                                         class=""rounded mx-auto d-block"" alt=""Building Wire"">
                                </d");
            WriteLiteral(@"iv>
                            </div>
                            <a class=""carousel-control-prev"" href=""#heroCarousel"" role=""button"" data-bs-slide=""prev"">
                                <span class=""carousel-control-prev-icon bi bi-chevron-left"" aria-hidden=""true""></span>
                            </a>
                            <a class=""carousel-control-next"" href=""#heroCarousel"" role=""button"" data-bs-slide=""next"">
                                <span class=""carousel-control-next-icon bi bi-chevron-right"" aria-hidden=""true""></span>
                            </a>
                        </div>
                    </div>
                    <div class=""ProductImage"">
                        <h1 class=""text-center pt-3"">BUILDING WIRE<span class=""building-span""><b> (FR / FR-LSH / HFFR)</b></span></h1>

                        <p><b>SRiNi LiNK</b> Fire Retardant (FR) <b>Building Wires,</b> are one of the best protector against current sparking and fire.</p>

                        <p><b>");
            WriteLiteral(@"SRiNi LiNK</b> FR <b>Building Wires</b> are manufactured by keeping all the aspects & specification of ISI & International standards, which makes our cable one of the best product for your home & office.</p>

                        <p>Use <b>SRiNi LiNK</b> FR <b>Building Wires</b> for durability & safety.</p>
");
            WriteLiteral(@"
                        <div class=""column one column_column"">
                            <div class=""building-txt-all"">

                                <div class=""building-txt-hdr"">
                                    <p>FR WIRES: Fire Retardant - RoHS PVC Insulated <b>Building Wires</b></p>
                                </div>

                                <div class=""building-txt"">
                                    <p><b>Application:</b> FR <b>Building wires</b> are mainly used in House, Commercial &amp; Industrial Building, etc for internal, external &amp; concealed wiring and also in panel boards wiring &amp; electricity distribution board wiring. </p>

                                    <p><b>Conductor:</b> With Bright-annealed EC grade copper with <span class=""building-span"">99.90 to 99.97% purity</span>, which offers low conductor resistance, lower heating and save the power consumption. </p>

                                    <p><b>RoHS Insulation :</b> The FR PVC insulatio");
            WriteLiteral(@"n formulation is of TYPE A, TYPE C &amp; TYPED category. Along with maintaining Standard required concentration of oxygen &amp; temperature index along with better insulation resistance and di-electric strength, which helps in: </p>

                                    <p>- Where ever due to electrical spark flame take place, its Oxygen index and temperature index doesn't allow flame to prolong further.</p>
                                </div>

                                <div class=""building-txt-hdr"">
                                    Technical Specification as per IS : 694 : 2010: (Generally conforming to IS: 694 : 2010)
                                </div>
                            </div>
                        </div>

                        <table class=""table table-bordered text-center mt-3"">

                            <tbody>
                                <tr class=""bg-warning"">
                                    <th colspan=""8"" class=""tech-heading"">Technical Specificat");
            WriteLiteral(@"ion as per IS: 694:2010 </th>
                                </tr>


                                <tr class=""bg-warning"">
                                    <th>
                                        Nominal Area Of
                                        Conductor
                                    </th>
                                    <th>
                                        Number /
                                        Diameter Of
                                        Wire
                                    </th>
                                    <th>
                                        Nominal Thickness
                                        of Insulation
                                    </th>
                                    <th>
                                        Max Conductor
                                        Resistance Per Km
                                        ");
            WriteLiteral(@"@ 20' C ( Max )
                                    </th>
                                    <th colspan=""4"">
                                        Current Carrying Capacity
                                        in Amps.as per IS:3961
                                    </th>
                                </tr>


                                <tr>
                                    <td rowspan=""2"">Sq.mm</td>
                                    <td rowspan=""2"">mm</td>
                                    <td rowspan=""2"">mm</td>
                                    <td rowspan=""2"">Ohms</td>
                                    <td colspan=""2"">On Cable Tray</td>
                                    <td colspan=""2"">Concealed Wiring</td>
                                </tr>

                                <tr>
                                    <td>Single Phase</td>
                                    <td>Three Phase</td>
                                    <td>Single Phase</td>
    ");
            WriteLiteral(@"                                <td>Three Phase</td>
                                </tr>

                                <tr>
                                    <td>0.50</td>
                                    <td>16/0.2</td>
                                    <td>0.6</td>
                                    <td>39.00/5</td>
                                    <td>4</td>
                                    <td>-</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>

                                <tr>
                                    <td>0.75</td>
                                    <td>24/0.2</td>
                                    <td>0.6</td>
                                    <td>39.00</td>
                                    <td>7</td>
                                    <td>7</td>
                                    <td>-</td>
                                    <td>-</td>
              ");
            WriteLiteral(@"                  </tr>

                                <tr>
                                    <td>1.00</td>
                                    <td>14/0.3</td>
                                    <td>0.7</td>
                                    <td>26.00</td>
                                    <td>12</td>
                                    <td>12</td>
                                    <td>11</td>
                                    <td>9</td>
                                </tr>

                                <tr>
                                    <td>1.50</td>
                                    <td>22/0.3</td>
                                    <td>0.7</td>
                                    <td>19.50</td>
                                    <td>16</td>
                                    <td>15</td>
                                    <td>13</td>
                                    <td>11</td>
                                </tr>

                                <tr>");
            WriteLiteral(@"
                                    <td>2.50</td>
                                    <td>36/0.3</td>
                                    <td>0.8</td>
                                    <td>13.50</td>
                                    <td>22</td>
                                    <td>20</td>
                                    <td>18</td>
                                    <td>16</td>
                                </tr>

                                <tr>
                                    <td>4.00</td>
                                    <td>56/0.3</td>
                                    <td>0.8</td>
                                    <td>7.98</td>
                                    <td>29</td>
                                    <td>26</td>
                                    <td>24</td>
                                    <td>20</td>
                                </tr>

                                <tr>
                                    <td>6.00</td>
          ");
            WriteLiteral(@"                          <td>84/0.4</td>
                                    <td>0.8</td>
                                    <td>4.95</td>
                                    <td>37</td>
                                    <td>33</td>
                                    <td>31</td>
                                    <td>25</td>
                                </tr>

                                <tr>
                                    <td>10.00</td>
                                    <td>140/0.3</td>
                                    <td>1.0</td>
                                    <td>3.30</td>
                                    <td>51</td>
                                    <td>45</td>
                                    <td>42</td>
                                    <td>35</td>
                                </tr>

                                <tr>
                                    <td>16.00</td>
                                    <td>126/0.4</td>
                 ");
            WriteLiteral(@"                   <td>1.0</td>
                                    <td>3.30</td>
                                    <td>68</td>
                                    <td>61</td>
                                    <td>57</td>
                                    <td>48</td>
                                </tr>
                            </tbody>
                        </table>

                        <div class=""building-txt-hdr"">
                            TYPE TEST: FOR FR PVC
                        </div>

                        <table class=""table table-bordered text-center mt-3"">
                            <tbody>
                                <tr class=""bg-warning"">
                                    <th>Test</th>
                                    <th>Function</th>
                                    <th>Specification</th>
                                    <th>Typical Values - Flame guard</th>
                                </tr>

                                <tr");
            WriteLiteral(@">
                                    <td>Critical Oxygen Index</td>
                                    <td>
                                        To determine percentage of oxygen required for supporting
                                        combustion of insulating material at room temperature
                                    </td>
                                    <td>IS 694</td>
                                    <td>More than 29%</td>
                                </tr>

                                <tr>
                                    <td>Temperature Index</td>
                                    <td>
                                        To determine at what temperature normal oxygen content 21%
                                        in air will support combustion of insulating material
                                    </td>
                                    <td>IS 694</td>
                                    <td>More than 250ºC.</td>
                      ");
            WriteLiteral(@"          </tr>
                            </tbody>
                        </table>

                        <div class=""tbl-last-txt"">
                            <p>SRiNi LiNK ® (FR) 1.00 SQ.MM UP TO 1100 V IS : 694 RoHS</p>
                        </div>

                        <div class=""text-center"">
                            <div class=""download-part-all"">

                                <div class=""download-txt"">
                                    <p>Working Voltage : <b>upto 1100 V</b></p>
                                    <p>Colour Code : <b><span class=""text-danger"">RED</span>, BLACK, <span class=""text-primary"">BLUE</span>, <span class=""text-warning"">YELLOW</span>, <span class=""text-success"">GREEN</span> &amp; <span class=""text-muted"">GREY</span></b></p>
                                    <p>Packing for FR Wires: <b>90 Mtrs. box packing upto 4.00 SQ.MM / 45 Mtrs. / 200 Mtrs. / 300 Mtrs. / as per requirement</b></p>
                                </div>

                 ");
            WriteLiteral("               <div");
            BeginWriteAttribute("class", " class=\"", 14527, "\"", 14535, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec057481e615017d8182872c1891228dd98cac133858b282d7926c116cebdf1d20951", async() => {
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

                        <div class=""building-txt-hdr"">
                            <p>TYPE TEST: FOR FR-LSH PVC</p>
                        </div>

                        <table class=""table table-bordered text-center mt-3"">
                            <tbody>
                                <tr class=""bg-warning"">
                                    <th>Test</th>
                                    <th>Function</th>
                                    <th>Specification</th>
                                    <th>Typical Values - Flame guard</th>
                                </tr>

                                <tr>
                                    <td>Critical Oxygen Index</td>
                                    <td>
                                        To determine percentage of oxygen required for supporting
                                        combustion of insu");
            WriteLiteral(@"lating material at room temperature
                                    </td>
                                    <td>IS 694</td>
                                    <td>More than 29%</td>
                                </tr>

                                <tr>
                                    <td>Temperature Index</td>
                                    <td>
                                        To determine at what temperature normal oxygen content 21%
                                        in air will support combustion of insulating material
                                    </td>
                                    <td>IS 694</td>
                                    <td>More than 250ºC</td>
                                </tr>

                                <tr>
                                    <td>Smoke density (Light Transmission)</td>
                                    <td>
                                        To determine the visibility (light transmission) un");
            WriteLiteral(@"der fire of
                                        insulation material
                                    </td>
                                    <td>ASTM-D 2843</td>
                                    <td>More than 40%</td>
                                </tr>

                                <tr>
                                    <td>Acid Gas Generation</td>
                                    <td>
                                        To ascertain the amount of hydro chlorine acid gas evolved from
                                        insulation of the cable under fire
                                    </td>
                                    <td>IS 694</td>
                                    <td>Less than 20%</td>
                                </tr>
                            </tbody>
                        </table>

                        <div class=""building-txt-hdr"">
                            <p>HFFR WIRES: Halogen Free Fire Retardant PVC Insulated <b>Building");
            WriteLiteral(@" Wires</b></p>
                        </div>

                        <div class=""building-txt"">
                            <p><b>Application:</b> These Cables are mainly used &amp; recommended where more number of people are their or where different kinds of modern electrical equpments are used like <b>Hospital, School &amp; College, Malls, Hotels, Commercial Buildings &amp; Govt. Offices or as per users.</b></p>

                            <p><b>Conductor:</b> With Bright-annealed EC grade copper with <span class=""building-span""> 99.90 to 99.97% purity</span>, which offer low conductor resistance, lower heating and save the power consumption.</p>

                            <p><b>RoHS Insulation :</b></p>

                            <p>FR-LSH PVC insulation formula is of TYPE-A or TYPE-D (C2 Category) and so well developed by us because of which, it maintain s more than the required IS:694 physical, chemical &amp; mechanical properties. </p>

                            <p>Wherever due to a");
            WriteLiteral(@"ny unavoidable circumstance fire take place at that time because of its properties, these cable doesn't support flame where Oxygen index is below 29% or temperature index of that particular cable reaches to 2500C and beyond this if fire is at very massive level than its low smoke density and negligible smoke &amp; halogen gas release properties helps people to stay conscious and evacuate easily by themselves or by fire safety people </p>

                            <p>In short fire fighting becomes easy with SRiNi LiNK HFFR Wires. </p>
                        </div>

                        <div class=""building-txt-hdr"">
                            <p>TYPE TEST: FOR HFFR INSULATION</p>
                        </div>

                        <table class=""table table-bordered text-center mt-3"">
                            <tbody>
                                <tr class=""bg-warning"">
                                    <th>Test</th>
                                    <th>Function</th>
        ");
            WriteLiteral(@"                            <th>Specification</th>
                                    <th>Typical Values - Flame guard</th>
                                </tr>

                                <tr>
                                    <td>Critical Oxygen Index </td>
                                    <td>To determine percentage of oxygen required for supporting combustion of insulating material at room temperature </td>
                                    <td>ASTM-D 2863 </td>
                                    <td>More than 29% </td>
                                </tr>

                                <tr>
                                    <td>Temperature Index</td>
                                    <td>To determine at what temperature normal oxygen content 21 % in air will support combustion of insulating material </td>
                                    <td>ASTM-D 2863 </td>
                                    <td>More than 2500°C.</td>
                                </tr>

  ");
            WriteLiteral(@"                              <tr>
                                    <td>Smoke density (Light Transmission)</td>
                                    <td>To determine the visibility (light transmission) under fire of insulation material </td>
                                    <td>ASTM-D 2863 </td>
                                    <td>More than 80% </td>
                                </tr>

                                <tr>
                                    <td>Halogen Acid Gas Generation </td>
                                    <td>To ascertain the amount of hydrochloric acid gas evolved from insulation of cable under fire </td>
                                    <td>IEC 60754-1 </td>
                                    <td>Less than 0.50% </td>
                                </tr>
                            </tbody>
                        </table>

                        <div class=""text-center"">
                            <div class=""download-part-all"">
                ");
            WriteLiteral(@"                <div class=""download-txt"">
                                    <p>Working Voltage : <b>upto 1100 V</b></p>
                                    <p>Colour Code : <b><span class=""text-danger"">RED</span>, BLACK, <span class=""text-primary"">BLUE</span>, <span class=""text-warning"">YELLOW</span>, <span class=""text-success"">GREEN</span> &amp; <span class=""text-muted"">GREY</span></b></p>
");
            WriteLiteral("                                    <p>Packing : <b> 90 Mtrs. / 100 Mtrs. /  45 Mtrs. / 200 Mtrs. / 300 Mtrs. / as per requirement</b></p>\r\n                                </div>\r\n\r\n                                <div class=\"download-btn\">\r\n");
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec057481e615017d8182872c1891228dd98cac133858b282d7926c116cebdf1d30792", async() => {
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
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
