#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\SubGridComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "43861aa4bf4931fe60575116ce22c32692c87879d5671ac03b3c0f9b29cf41fe"
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
    public partial class SubGridComponent<T> : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\SubGridComponent.razor"
 if (_visible)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "    <td></td>\r\n    ");
            __builder.OpenElement(1, "td");
            __builder.AddAttribute(2, "colspan", 
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\SubGridComponent.razor"
                  Cols

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\SubGridComponent.razor"
__builder.AddContent(3, _subGridRender);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n");
#nullable restore
#line 7 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridBlazor\Pages\SubGridComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591