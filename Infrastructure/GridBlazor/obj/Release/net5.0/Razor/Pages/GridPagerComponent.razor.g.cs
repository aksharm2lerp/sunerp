#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "93e823e6b474eacf8df9a72003715664996d2818c0b0e664e0023496a6789b30"
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
using GridBlazor.Resources;

#line default
#line hidden
#nullable disable
    public partial class GridPagerComponent<
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
T

#line default
#line hidden
#nullable disable
    > : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "grid-pager-sizer");
            __builder.AddMarkupContent(2, "\r\n");
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
     if (GridPager != null && GridPager.PageCount > 1)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "        ");
            __builder.OpenElement(4, "nav");
            __builder.AddAttribute(5, "class", "grid-pager");
            __builder.AddMarkupContent(6, "\r\n            ");
            __builder.OpenElement(7, "ul");
            __builder.AddAttribute(8, "class", "pagination");
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                 if (GridPager.CurrentPage > 1)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(10, "                    ");
            __builder.OpenElement(11, "li");
            __builder.AddAttribute(12, "class", "page-item");
            __builder.AddMarkupContent(13, "\r\n                        ");
            __builder.OpenElement(14, "button");
            __builder.AddAttribute(15, "type", "button");
            __builder.AddAttribute(16, "class", "page-link");
            __builder.AddAttribute(17, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                          () => PagerButtonClicked(GridPager.CurrentPage - 1)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(18, "«");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n");
#nullable restore
#line 14 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                 if (GridPager.StartDisplayedPage > 1)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(21, "                    ");
            __builder.OpenElement(22, "li");
            __builder.AddAttribute(23, "class", "page-item");
            __builder.AddMarkupContent(24, "\r\n                        ");
            __builder.OpenElement(25, "button");
            __builder.AddAttribute(26, "type", "button");
            __builder.AddAttribute(27, "class", "page-link");
            __builder.AddAttribute(28, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                          () => PagerButtonClicked(1)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(29, "1");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n");
#nullable restore
#line 20 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                     if (GridPager.StartDisplayedPage > 2)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "                        ");
            __builder.OpenElement(33, "li");
            __builder.AddAttribute(34, "class", "page-item");
            __builder.AddMarkupContent(35, "\r\n                            ");
            __builder.OpenElement(36, "button");
            __builder.AddAttribute(37, "type", "button");
            __builder.AddAttribute(38, "class", "page-link");
            __builder.AddAttribute(39, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                              () => PagerButtonClicked(GridPager.StartDisplayedPage - 1)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(40, "...");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n");
#nullable restore
#line 25 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                 for (int i = GridPager.StartDisplayedPage; i <= GridPager.EndDisplayedPage; i++)
                {
                    if (i == GridPager.CurrentPage)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(43, "                        ");
            __builder.OpenElement(44, "li");
            __builder.AddAttribute(45, "class", "page-item active");
            __builder.AddMarkupContent(46, "\r\n                            ");
            __builder.OpenElement(47, "button");
            __builder.AddAttribute(48, "type", "button");
            __builder.AddAttribute(49, "class", "page-link");
#nullable restore
#line 32 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
__builder.AddContent(50, i);

#line default
#line hidden
#nullable disable
            __builder.AddContent(51, " ");
            __builder.AddMarkupContent(52, "<span class=\"sr-only\">(current)</span>");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n");
#nullable restore
#line 34 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                    }
                    else
                    {
                        int j = i;

#line default
#line hidden
#nullable disable
            __builder.AddContent(55, "                        ");
            __builder.OpenElement(56, "li");
            __builder.AddAttribute(57, "class", "page-item");
            __builder.AddMarkupContent(58, "\r\n                            ");
            __builder.OpenElement(59, "button");
            __builder.AddAttribute(60, "type", "button");
            __builder.AddAttribute(61, "class", "page-link");
            __builder.AddAttribute(62, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                              async () => await PagerButtonClicked(j)

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 39 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
__builder.AddContent(63, j);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n");
#nullable restore
#line 41 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                    }
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                 if (GridPager.EndDisplayedPage < GridPager.PageCount)
                {
                    if (GridPager.EndDisplayedPage < GridPager.PageCount - 1)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(66, "                        ");
            __builder.OpenElement(67, "li");
            __builder.AddAttribute(68, "class", "page-item");
            __builder.AddMarkupContent(69, "\r\n                            ");
            __builder.OpenElement(70, "button");
            __builder.AddAttribute(71, "type", "button");
            __builder.AddAttribute(72, "class", "page-link");
            __builder.AddAttribute(73, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 48 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                              async () => await PagerButtonClicked(GridPager.EndDisplayedPage + 1)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(74, "...");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\r\n");
#nullable restore
#line 50 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(77, "                    ");
            __builder.OpenElement(78, "li");
            __builder.AddAttribute(79, "class", "page-item");
            __builder.AddMarkupContent(80, "\r\n                        ");
            __builder.OpenElement(81, "button");
            __builder.AddAttribute(82, "type", "button");
            __builder.AddAttribute(83, "class", "page-link");
            __builder.AddAttribute(84, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                          async () => await PagerButtonClicked(GridPager.PageCount)

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 52 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
__builder.AddContent(85, GridPager.PageCount);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n");
#nullable restore
#line 54 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                 if (GridPager.CurrentPage < GridPager.PageCount)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(88, "                    ");
            __builder.OpenElement(89, "li");
            __builder.AddAttribute(90, "class", "page-item");
            __builder.AddMarkupContent(91, "\r\n                        ");
            __builder.OpenElement(92, "button");
            __builder.AddAttribute(93, "type", "button");
            __builder.AddAttribute(94, "class", "page-link");
            __builder.AddAttribute(95, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 58 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                          async () => await PagerButtonClicked(GridPager.CurrentPage + 1)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(96, "»");
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n");
#nullable restore
#line 60 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(99, "            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n");
            __builder.AddContent(102, "        ");
            __builder.OpenElement(103, "div");
            __builder.AddAttribute(104, "class", "grid-goto-page form-group");
            __builder.AddMarkupContent(105, "\r\n            ");
            __builder.OpenElement(106, "label");
            __builder.AddAttribute(107, "class", "control-label");
            __builder.OpenElement(108, "b");
#nullable restore
#line 65 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
__builder.AddContent(109, Strings.Goto);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\r\n            ");
            __builder.OpenElement(111, "div");
            __builder.AddMarkupContent(112, "\r\n                ");
            __builder.OpenElement(113, "input");
            __builder.AddAttribute(114, "class", "form-control grid-goto-page-input");
            __builder.AddAttribute(115, "onkeyup", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 67 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                                                GoToKeyup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(116, "onblur", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.FocusEventArgs>(this, 
#nullable restore
#line 67 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                                                                    GoToBlur

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventStopPropagationAttribute(117, "onclick", true);
            __builder.AddAttribute(118, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 67 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                        _currentPage

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(119, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _currentPage = __value, _currentPage));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(120, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(121, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(122, "\r\n");
#nullable restore
#line 70 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(123, "\r\n");
#nullable restore
#line 72 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
     if (GridComponent.Grid.EnablePaging && GridComponent.Grid.Pager.ChangePageSize)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(124, "        ");
            __builder.OpenElement(125, "div");
            __builder.AddAttribute(126, "class", "grid-change-page-size form-group");
            __builder.AddAttribute(127, "data-change-page-size-url", 
#nullable restore
#line 74 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                                  GridComponent.ChangePageSizeUrl

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(128, "\r\n            ");
            __builder.OpenElement(129, "label");
            __builder.AddAttribute(130, "class", "control-label");
            __builder.OpenElement(131, "b");
#nullable restore
#line 75 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
__builder.AddContent(132, Strings.Show);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(133, "\r\n            ");
            __builder.OpenElement(134, "div");
            __builder.AddMarkupContent(135, "\r\n                ");
            __builder.OpenElement(136, "input");
            __builder.AddAttribute(137, "class", "form-control grid-change-page-size-input");
            __builder.AddAttribute(138, "onkeyup", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 77 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                                                                                                    GridComponent.InputPageSizeKeyup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(139, "onblur", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.FocusEventArgs>(this, 
#nullable restore
#line 77 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                                                                                                                                               GridComponent.InputPageSizeBlur

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventStopPropagationAttribute(140, "onclick", true);
            __builder.AddAttribute(141, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 77 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                                                                                                                  GridComponent.PageSize

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(142, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => GridComponent.PageSize = __value, GridComponent.PageSize));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddElementReferenceCapture(143, (__value) => {
#nullable restore
#line 77 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
                             GridComponent.PageSizeInput = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(144, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(145, "\r\n            ");
            __builder.OpenElement(146, "label");
            __builder.AddAttribute(147, "class", "control-label");
            __builder.OpenElement(148, "b");
#nullable restore
#line 79 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
__builder.AddContent(149, Strings.Items);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(150, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(151, "\r\n");
#nullable restore
#line 81 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridPagerComponent.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
