#pragma checksum "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9ba10273a2ba8b6155300616ab997043e3123a904bb84eaed5a07a9ecfaff177"
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
#line 1 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
 using GridBlazor.Resources

#line default
#line hidden
#nullable disable
    ;
    #nullable restore
    public partial class GridDeleteButtonsComponent<
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
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
#line 3 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
 if (GridDeleteComponent._buttonsVisibility == 0)
{

#line default
#line hidden
#nullable disable

            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "button");
            __builder.AddAttribute(2, "type", "button");
            __builder.AddAttribute(3, "class", "btn btn-primary btn-md");
            __builder.AddAttribute(4, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
                                                                   () => GridDeleteComponent.DeleteItem()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(5, 
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
                                                                                                            Strings.Delete

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n    ");
            __builder.OpenElement(7, "button");
            __builder.AddAttribute(8, "type", "button");
            __builder.AddAttribute(9, "class", "btn btn-primary btn-md");
            __builder.AddAttribute(10, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
                                                                   () => GridDeleteComponent.BackButtonClicked()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(11, 
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
                                                                                                                   Strings.Back

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n");
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridBlazor\Pages\GridDeleteButtonsComponent.razor"
}

#line default
#line hidden
#nullable disable

        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
