#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "60d752230f14d688c172406bd1124cba52a3c344b1fd76d90a20f9b03878fb10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridCol), @"mvc.1.0.view", @"/Views/Shared/_GridCol.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml"
using GridShared.Columns;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"60d752230f14d688c172406bd1124cba52a3c344b1fd76d90a20f9b03878fb10", @"/Views/Shared/_GridCol.cshtml")]
    #nullable restore
    public class Views_Shared__GridCol : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGridColumn>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml"
  
    const string HiddenStyle = "display:none;";
    string _cssStyles;

    if (Model.Hidden)
    {
        _cssStyles = HiddenStyle;
    }
    else
    {
        _cssStyles = "";
    }

    if (!string.IsNullOrWhiteSpace(Model.Width))
    {
        _cssStyles = string.Concat(_cssStyles, " width:", Model.Width, ";").Trim();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<col");
            BeginWriteAttribute("style", " style=\"", 412, "\"", 431, 1);
#nullable restore
#line 24 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridCol.cshtml"
WriteAttributeValue("", 420, _cssStyles, 420, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IGridColumn> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
