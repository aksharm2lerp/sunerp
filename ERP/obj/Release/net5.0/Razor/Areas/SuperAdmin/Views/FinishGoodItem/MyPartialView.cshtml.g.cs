#pragma checksum "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58fc3a1e74d80a30db87dc27f5c79343b07e77012ba2544a3caff7bf25d72a70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SuperAdmin_Views_FinishGoodItem_MyPartialView), @"mvc.1.0.view", @"/Areas/SuperAdmin/Views/FinishGoodItem/MyPartialView.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 5 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.SQL

#nullable disable
    ;
#nullable restore
#line 6 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Enums

#nullable disable
    ;
#nullable restore
#line 8 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Extensions

#nullable disable
    ;
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using ERP.Helpers

#nullable disable
    ;
#nullable restore
#line 10 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\_ViewImports.cshtml"
using Business.Entities.Dynamic

#nullable disable
    ;
#nullable restore
#line 1 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
 using Business.Entities.Master;

#nullable disable
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
 using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"58fc3a1e74d80a30db87dc27f5c79343b07e77012ba2544a3caff7bf25d72a70", @"/Areas/SuperAdmin/Views/FinishGoodItem/MyPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"66ca4ed4d968d0cb63ad96b0820d0f1f680273fdde74e92383c120d6a96a5604", @"/Areas/SuperAdmin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_SuperAdmin_Views_FinishGoodItem_MyPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataTable>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
	.TFtable {
		width: 100%;
		border-collapse: collapse;
	}

		.TFtable td {
			padding: 7px;
			border: #4e95f4 1px solid;
		}
		/* provide some minimal visual accomodation for IE8 and below */
		.TFtable tr {
			background: #b8d1f3;
		}
			/*  Define the background color for all the ODD background rows  */
			.TFtable tr:nth-child(odd) {
				background: #b8d1f3;
			}
			/*  Define the background color for all the EVEN background rows  */
			.TFtable tr:nth-child(even) {
				background: #dae5f4;
			}
</style>
<table class=""TFtable"">
");
#nullable restore
#line 29 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
  if (Model != null)
	{

#line default
#line hidden
#nullable disable

            WriteLiteral("\t\t<tr>\r\n");
#nullable restore
#line 32 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
    for (int i = 0; i < Model.Columns.Count; i++)
			{

#line default
#line hidden
#nullable disable

            WriteLiteral("\t\t\t\t<th>");
            Write(
#nullable restore
#line 34 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
         Model.Columns[i].ColumnName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</th>\r\n");
#nullable restore
#line 35 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
			}

#line default
#line hidden
#nullable disable

            WriteLiteral("\t\t</tr>\r\n");
#nullable restore
#line 37 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
		for (int i = 0; i < Model.Rows.Count; i++)
		{

#line default
#line hidden
#nullable disable

            WriteLiteral("\t\t\t<tr>\r\n");
#nullable restore
#line 40 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
     for (int j = 0; j < Model.Columns.Count; j++)
				{

#line default
#line hidden
#nullable disable

            WriteLiteral("\t\t\t\t\t<td>");
            Write(
#nullable restore
#line 42 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
          Model.Rows[i][j].ToString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n");
#nullable restore
#line 43 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
				}

#line default
#line hidden
#nullable disable

            WriteLiteral("\t\t\t</tr>\r\n");
#nullable restore
#line 45 "D:\GitHub\SUN\sunerpm2l\ERP\Areas\SuperAdmin\Views\FinishGoodItem\MyPartialView.cshtml"
		}
	}

#line default
#line hidden
#nullable disable

            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataTable> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
