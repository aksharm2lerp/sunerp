#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "cca81661ed9049256a4f43c210df1849ff7afb74d62e989e076e1ef4ab032d7f"
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
    public partial class GridBodyComponent<
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
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
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
 if (GridComponent.Grid.DisplayingItemsCount == 0)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "tr");
            __builder.AddAttribute(2, "class", 
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                GridComponent.GridEmptyTextCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(3, "\r\n");
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
         if (GridComponent.HasSubGrid)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "            ");
            __builder.OpenElement(5, "td");
            __builder.AddAttribute(6, "class", 
#nullable restore
#line 8 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                        GridComponent.GridCellCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(7, "data-name", true);
            __builder.AddAttribute(8, "style", "width:36.5px;");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
         if ((GridComponent.Grid.ReadEnabled || ((CGrid<T>)GridComponent.Grid).FuncReadEnabled != null) && !GridComponent.HeaderCrudButtons)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(10, "            ");
            __builder.OpenElement(11, "td");
            __builder.AddAttribute(12, "class", 
#nullable restore
#line 12 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                        GridComponent.GridButtonCellCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(13, "data-name", true);
            __builder.AddAttribute(14, "style", "width:35px;");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n");
#nullable restore
#line 13 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
         if ((GridComponent.Grid.UpdateEnabled || ((CGrid<T>)GridComponent.Grid).FuncUpdateEnabled != null) && !GridComponent.HeaderCrudButtons)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(16, "            ");
            __builder.OpenElement(17, "td");
            __builder.AddAttribute(18, "class", 
#nullable restore
#line 16 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                        GridComponent.GridButtonCellCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(19, "data-name", true);
            __builder.AddAttribute(20, "style", "width:35px;");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n");
#nullable restore
#line 17 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
         if ((GridComponent.Grid.DeleteEnabled || ((CGrid<T>)GridComponent.Grid).FuncDeleteEnabled != null) && !GridComponent.HeaderCrudButtons)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(22, "            ");
            __builder.OpenElement(23, "td");
            __builder.AddAttribute(24, "class", 
#nullable restore
#line 20 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                        GridComponent.GridButtonCellCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(25, "data-name", true);
            __builder.AddAttribute(26, "style", "width:35px;");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n");
#nullable restore
#line 21 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
         if (GridComponent.RequiredTotalsColumn)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(28, "            ");
            __builder.OpenElement(29, "td");
            __builder.AddAttribute(30, "class", 
#nullable restore
#line 24 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                        GridComponent.GridCellCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(31, "data-name", true);
            __builder.AddAttribute(32, "style", "width:90px;");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n");
#nullable restore
#line 25 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(34, "        ");
            __builder.OpenElement(35, "td");
            __builder.AddAttribute(36, "colspan", 
#nullable restore
#line 26 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                      GridComponent.Grid.Columns.Count()

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(37, "\r\n            ");
#nullable restore
#line 27 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
__builder.AddContent(38, GridComponent.Grid.EmptyGridText);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(39, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n");
#nullable restore
#line 30 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
}
else
{
    int i = 0;
    if (GridComponent.Grid.GroupingEnabled)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(42, "        ");
            __builder.OpenComponent<global::GridBlazor.Pages.GridGroupRowsComponent<T>>(43);
            __builder.AddAttribute(44, "Grid", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::GridBlazor.ICGrid>(
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                              GridComponent.Grid

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(45, "Values", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.IList<System.Tuple<System.String, System.Object>>>(
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                            new List<Tuple<string, object>>()

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(46, "HasSubGrid", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Boolean>(
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                             GridComponent.HasSubGrid

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(47, "RequiredTotalsColumn", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Boolean>(
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                                                                              GridComponent.RequiredTotalsColumn

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(48, "ItemsToDisplay", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.IEnumerable<System.Object>>(
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                                                                                                                                   GridComponent.Grid.ItemsToDisplay

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(49, "IsVisible", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Boolean>(
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                                                                                                                                                                                 true

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(50, "RowId", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Int32>(
#nullable restore
#line 36 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                                                                                                                                                                                               i

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(51, "\r\n");
#nullable restore
#line 37 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
    }
    else
    {
        foreach (object item in GridComponent.Grid.ItemsToDisplay)
        {
            int capturedI = i;

#line default
#line hidden
#nullable disable
            __builder.AddContent(52, "            ");
            __builder.OpenComponent<global::GridBlazor.Pages.GridRowComponent<T>>(53);
            __builder.AddAttribute(54, "Grid", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::GridBlazor.ICGrid>(
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                            GridComponent.Grid

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(55, "HasSubGrid", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Boolean>(
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                             GridComponent.HasSubGrid

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(56, "RequiredTotalsColumn", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Boolean>(
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                              GridComponent.RequiredTotalsColumn

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(57, "Item", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Object>(
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                                                                         item

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(58, "GridPosition", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Int32>(
#nullable restore
#line 43 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                                                                                                                                                                              capturedI

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(59, "\r\n");
#nullable restore
#line 44 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
            i++;
        }
    }
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
 if (GridComponent.HasTotals)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(60, "    ");
            __builder.OpenComponent<global::GridBlazor.Pages.GridTotalsComponent<T>>(61);
            __builder.AddAttribute(62, "Grid", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::GridBlazor.ICGrid>(
#nullable restore
#line 50 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
                                       GridComponent.Grid

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(63, "\r\n");
#nullable restore
#line 51 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridBodyComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591