#pragma checksum "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3462e6e7e9904985017bde0008a9d4b453b0f977ef6230082eec0af7a63857d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridSearch), @"mvc.1.0.view", @"/Views/Shared/_GridSearch.cshtml")]
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
#line 1 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml"
using GridCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml"
using GridCore.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml"
using GridShared.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"3462e6e7e9904985017bde0008a9d4b453b0f977ef6230082eec0af7a63857d7", @"/Views/Shared/_GridSearch.cshtml")]
    #nullable restore
    public class Views_Shared__GridSearch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISGrid>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml"
  
    string _seachUrl;
    string _searchValue = Model.Settings.SearchSettings.SearchValue;

    //determine current url:
    var queryBuilder = new CustomQueryStringBuilder(Model.Settings.SearchSettings.Query);
    var exceptQueryParameters = new List<string> { "grid-search" };
    _seachUrl = queryBuilder.GetQueryStringExcept(exceptQueryParameters);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"grid-search col-md-6\" data-search-url=\"");
#nullable restore
#line 16 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml"
                                              Write(_seachUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
    <div class=""input-group"">
        <span class=""input-group-btn"">
            <button class=""grid-button btnss btn-default btn-primary grid-search-apply"" type=""button""></button>
        </span>
        <input type=""text"" class=""form-control grid-search-input""");
            BeginWriteAttribute("value", " value=\"", 788, "\"", 809, 1);
#nullable restore
#line 21 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml"
WriteAttributeValue("", 796, _searchValue, 796, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 810, "\"", 842, 1);
#nullable restore
#line 21 "D:\AksharItSolution\M2LERP Detail\ERP Backup\aksharm2l\Infrastructure\GridMvc\Views\Shared\_GridSearch.cshtml"
WriteAttributeValue("", 824, Strings.SearchFor, 824, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <span class=\"input-group-btn\">\r\n\r\n            <button id=\"btnss\" class=\"grid-button btn btn-default btn-primary grid-search-clear\" type=\"button\"></button>\r\n\r\n        </span>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISGrid> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591