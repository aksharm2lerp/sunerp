#pragma checksum "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "08ac85d978ae4dd3ccee2bcb7720ccc6af821fc5244f29188d11ec784024ee6a"
// <auto-generated/>
#pragma warning disable 1591
namespace GridBlazor.Pages
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\_Imports.razor"
using System.Text.Json

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\_Imports.razor"
using System.Net.Http.Json

#line default
#line hidden
#nullable disable
    ;
    #nullable restore
    public partial class CheckboxComponent<
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
           T

#line default
#line hidden
#nullable disable
    > : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
 if (_readonly)
{

#line default
#line hidden
#nullable disable

            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "input");
            __builder.AddAttribute(2, "type", "checkbox");
            __builder.AddAttribute(3, "checked", 
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
                                     _value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "disabled", "disabled");
            __builder.AddAttribute(5, "readonly", "readonly");
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n");
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
}
else
{

#line default
#line hidden
#nullable disable

            __builder.AddContent(7, "    ");
            __builder.OpenElement(8, "input");
            __builder.AddAttribute(9, "type", "checkbox");
            __builder.AddAttribute(10, "checked", 
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
                                     _value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(11, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
                                                        ChangeHandler

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventStopPropagationAttribute(12, "onclick", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\CheckboxComponent.razor"
}

#line default
#line hidden
#nullable disable

        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
