#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58cacb0cbbdece2948e213e3cfde7fb52f07fd8eb364bd890d036b15f5e3aaf9"
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
    public partial class GridCellComponent<
#nullable restore
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
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
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
 if (_cellRender != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "td");
            __builder.AddAttribute(2, "class", 
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
                _cssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(3, "style", 
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
                                   _cssStyles

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "data-name", 
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
                                                           Column.Name

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
__builder.AddContent(5, _cellRender);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n");
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "    ");
            __builder.OpenElement(8, "td");
            __builder.AddAttribute(9, "class", 
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
                _cssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(10, "style", 
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
                                   _cssStyles

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(11, "data-name", 
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
                                                           Column.Name

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 9 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
__builder.AddContent(12, _cell);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
#nullable restore
#line 10 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\GridCellComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
