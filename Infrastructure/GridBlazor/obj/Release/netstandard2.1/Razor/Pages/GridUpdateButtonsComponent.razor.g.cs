#pragma checksum "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7d41c37e747ad1e8c5ea2d820cefa53d7eca482358fe245a54e2e4c5db22c1ae"
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

#nullable disable
    ;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor"
 using GridBlazor.Resources

#line default
#line hidden
#nullable disable
    ;
    #nullable restore
    public partial class GridUpdateButtonsComponent<
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor"
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
#line 3 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor"
 if (GridUpdateComponent._buttonsVisibility == 0)
{

#line default
#line hidden
#nullable disable

            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "button");
            __builder.AddAttribute(2, "type", "submit");
            __builder.AddAttribute(3, "class", "btn btn-primary btn-md");
            __builder.AddContent(4, 
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor"
                                                          Strings.Save

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n    ");
            __builder.OpenElement(6, "button");
            __builder.AddAttribute(7, "type", "button");
            __builder.AddAttribute(8, "class", "btn btn-primary btn-md");
            __builder.AddAttribute(9, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor"
                                                                   () => GridUpdateComponent.BackButtonClicked()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(10, 
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor"
                                                                                                                   Strings.Back

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n");
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridUpdateButtonsComponent.razor"
}

#line default
#line hidden
#nullable disable

        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
