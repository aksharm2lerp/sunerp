#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "fece1ba335307cd9b90a2bce63460025350795610a1e8ed188bc996023ca9116"
// <auto-generated/>
#pragma warning disable 1591
namespace GridBlazor.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\_Imports.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
using GridBlazor.Resources;

#line default
#line hidden
#nullable disable
    public partial class BooleanFilterComponent<
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
T

#line default
#line hidden
#nullable disable
    > : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
 if (Visible)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "dropdown dropdown-menu grid-dropdown opened");
            __builder.AddAttribute(2, "style", "display:block;position:relative;" + (
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                  "margin-left:" + _offset.ToString() + "px;"

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "onkeyup", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                                            FilterKeyup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventStopPropagationAttribute(4, "onclick", true);
            __builder.AddEventStopPropagationAttribute(5, "onkeyup", true);
            __builder.AddElementReferenceCapture(6, (__value) => {
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                      boolFilter = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.AddMarkupContent(7, "\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "grid-dropdown-arrow");
            __builder.AddAttribute(10, "style", 
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                              "margin-left:" + (-_offset).ToString() + "px;"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "grid-dropdown-inner");
            __builder.AddMarkupContent(14, "\r\n        ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "grid-popup-widget");
            __builder.AddMarkupContent(17, "\r\n            ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "grid-filter-body");
            __builder.AddMarkupContent(20, "\r\n                ");
            __builder.OpenElement(21, "label");
            __builder.OpenElement(22, "b");
#nullable restore
#line 12 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(23, Strings.FilterValueLabel);

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, ":");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                ");
            __builder.OpenElement(26, "ul");
            __builder.AddAttribute(27, "class", "menu-list");
            __builder.AddMarkupContent(28, "\r\n                    ");
            __builder.OpenElement(29, "li");
            __builder.AddMarkupContent(30, "\r\n                        ");
            __builder.OpenElement(31, "a");
            __builder.AddAttribute(32, "class", "grid-filter-choose" + (
#nullable restore
#line 15 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                      _filterValue != null && _filterValue.ToLower() == "true" ? " choose-selected" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "data-value", "true");
            __builder.AddAttribute(34, "href", "javascript:void(0);");
            __builder.AddAttribute(35, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                                                                  ApplyTrueButtonClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(36, "\r\n                            ");
#nullable restore
#line 16 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(37, Strings.BoolTrueLabel);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(38, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                    ");
            __builder.OpenElement(41, "li");
            __builder.AddMarkupContent(42, "\r\n                        ");
            __builder.OpenElement(43, "a");
            __builder.AddAttribute(44, "class", "grid-filter-choose" + (
#nullable restore
#line 20 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                      _filterValue != null && _filterValue.ToLower() == "false" ? " choose-selected" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(45, "data-value", "false");
            __builder.AddAttribute(46, "href", "javascript:void(0);");
            __builder.AddAttribute(47, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                                                                                                                                    ApplyFalseButtonClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(48, "\r\n                            ");
#nullable restore
#line 21 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(49, Strings.BoolFalseLabel);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(50, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n        ");
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "grid-popup-additional");
            __builder.AddMarkupContent(58, "\r\n");
#nullable restore
#line 28 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
             if (_clearVisible)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(59, "                ");
            __builder.OpenElement(60, "ul");
            __builder.AddAttribute(61, "class", "menu-list");
            __builder.AddMarkupContent(62, "\r\n                    ");
            __builder.OpenElement(63, "li");
            __builder.AddMarkupContent(64, "\r\n                        ");
            __builder.OpenElement(65, "a");
            __builder.AddAttribute(66, "class", "grid-filter-clear");
            __builder.AddAttribute(67, "href", "javascript:void(0);");
            __builder.AddAttribute(68, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 32 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
                                                                                          ClearButtonClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(69, "\r\n                            ");
#nullable restore
#line 33 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
__builder.AddContent(70, Strings.ClearFilterLabel);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(71, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n");
#nullable restore
#line 37 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(75, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(78, "\r\n");
#nullable restore
#line 41 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\BooleanFilterComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
