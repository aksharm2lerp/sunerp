#pragma checksum "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ff62a876866d7003e2399ee420dde08b2189b555bf4a17d4aef8680bdfd645a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridTotals), @"mvc.1.0.view", @"/Views/Shared/_GridTotals.cshtml")]
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
#line 1 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 using GridCore

#nullable disable
    ;
#nullable restore
#line 2 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 using GridCore.Resources

#nullable disable
    ;
#nullable restore
#line 3 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 using GridShared

#nullable disable
    ;
#nullable restore
#line 4 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 using GridShared.Columns

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ff62a876866d7003e2399ee420dde08b2189b555bf4a17d4aef8680bdfd645a3", @"/Views/Shared/_GridTotals.cshtml")]
    #nullable restore
    public class Views_Shared__GridTotals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISGrid>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 if (Model == null) { return; }

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
  
    var firstColumn = (ITotalsColumn)Model.Columns.FirstOrDefault();
    bool hasSubGrid = Model.SubGridKeys != null && Model.SubGridKeys.Length > 0;
    bool requiredTotalsColumn = firstColumn != null
              && (firstColumn.IsSumEnabled || firstColumn.IsAverageEnabled
                  || firstColumn.IsMaxEnabled || firstColumn.IsMinEnabled);
    string cssStyles = "";
    if (Model.Direction == GridDirection.RTL)
        cssStyles = string.Concat(cssStyles, " text-align:right;direction:rtl;").Trim();

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
#nullable restore
#line 20 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
 if (Model.RenderOptions.RenderRowsOnly)
{
    return;
}
else
{

#line default
#line hidden
#nullable disable

            WriteLiteral("    <tr class=\"grid-row\"><td class=\"grid-cell\" style=\"height:25px;border:none;background-color:white\"></td></tr>\r\n");
#nullable restore
#line 27 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    if (Model.IsSumEnabled)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <tr class=\"grid-totals-row\">\r\n");
#nullable restore
#line 30 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\r\n");
#nullable restore
#line 33 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 34 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 1142, "\"", 1160, 1);
            WriteAttributeValue("", 1150, 
#nullable restore
#line 36 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                              cssStyles

#line default
#line hidden
#nullable disable
            , 1150, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 36 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                             Strings.Sum

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 37 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 38 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 1562, "\"", 1580, 1);
            WriteAttributeValue("", 1570, 
#nullable restore
#line 44 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                  cssStyles

#line default
#line hidden
#nullable disable
            , 1570, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 44 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                 Strings.Sum

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 45 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsSumEnabled)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <td class=\"grid-cell purchaseorderamount\" previouscost=\"0\" previousqty=\"0\" title=\"0\" totalamount=\"0\"");
            BeginWriteAttribute("style", " style=\"", 1861, "\"", 1879, 1);
            WriteAttributeValue("", 1869, 
#nullable restore
#line 50 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                                                                                     cssStyles

#line default
#line hidden
#nullable disable
            , 1869, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 50 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                                                                                                    column.SumString

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 51 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\r\n");
#nullable restore
#line 57 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 2282, "\"", 2300, 1);
            WriteAttributeValue("", 2290, 
#nullable restore
#line 60 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                          cssStyles

#line default
#line hidden
#nullable disable
            , 2290, 10, false);
            EndWriteAttribute();
            WriteLiteral("></td>\r\n");
#nullable restore
#line 61 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }

            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 67 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
    if (Model.IsAverageEnabled)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <tr class=\"grid-totals-row\">\r\n");
#nullable restore
#line 71 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\r\n");
#nullable restore
#line 74 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 75 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 2705, "\"", 2723, 1);
            WriteAttributeValue("", 2713, 
#nullable restore
#line 77 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                              cssStyles

#line default
#line hidden
#nullable disable
            , 2713, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 77 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                             Strings.Average

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 78 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 79 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 3129, "\"", 3147, 1);
            WriteAttributeValue("", 3137, 
#nullable restore
#line 85 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                  cssStyles

#line default
#line hidden
#nullable disable
            , 3137, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 85 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                 Strings.Average

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 86 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsAverageEnabled)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 3357, "\"", 3375, 1);
            WriteAttributeValue("", 3365, 
#nullable restore
#line 91 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                      cssStyles

#line default
#line hidden
#nullable disable
            , 3365, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 91 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                     column.AverageString

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 92 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\r\n");
#nullable restore
#line 98 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 3782, "\"", 3800, 1);
            WriteAttributeValue("", 3790, 
#nullable restore
#line 101 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                          cssStyles

#line default
#line hidden
#nullable disable
            , 3790, 10, false);
            EndWriteAttribute();
            WriteLiteral("></td>\r\n");
#nullable restore
#line 102 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }
            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 107 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
    if (Model.IsMaxEnabled)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <tr class=\"grid-totals-row\">\r\n");
#nullable restore
#line 111 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\r\n");
#nullable restore
#line 114 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 115 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 4199, "\"", 4217, 1);
            WriteAttributeValue("", 4207, 
#nullable restore
#line 117 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                              cssStyles

#line default
#line hidden
#nullable disable
            , 4207, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 117 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                             Strings.Max

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 118 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 119 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 4619, "\"", 4637, 1);
            WriteAttributeValue("", 4627, 
#nullable restore
#line 125 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                  cssStyles

#line default
#line hidden
#nullable disable
            , 4627, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 125 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                 Strings.Max

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 126 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsMaxEnabled)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 4839, "\"", 4857, 1);
            WriteAttributeValue("", 4847, 
#nullable restore
#line 131 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                      cssStyles

#line default
#line hidden
#nullable disable
            , 4847, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 131 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                     column.MaxString

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 132 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\r\n");
#nullable restore
#line 138 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 5260, "\"", 5278, 1);
            WriteAttributeValue("", 5268, 
#nullable restore
#line 141 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                          cssStyles

#line default
#line hidden
#nullable disable
            , 5268, 10, false);
            EndWriteAttribute();
            WriteLiteral("></td>\r\n");
#nullable restore
#line 142 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }
            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 147 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
    if (Model.IsMinEnabled)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <tr class=\"grid-totals-row\">\r\n");
#nullable restore
#line 151 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (hasSubGrid)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\" data-name=\"\"></td>\r\n");
#nullable restore
#line 154 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 155 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             if (requiredTotalsColumn)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 5677, "\"", 5695, 1);
            WriteAttributeValue("", 5685, 
#nullable restore
#line 157 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                              cssStyles

#line default
#line hidden
#nullable disable
            , 5685, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 157 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                             Strings.Min

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 158 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
            }

#line default
#line hidden
#nullable disable

#nullable restore
#line 159 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
             for (int i = 0; i < Model.Columns.Count(); i++)
            {
                var column = (ITotalsColumn)Model.Columns.ElementAt(i);
                if (i == 0 && !column.IsSumEnabled && !column.IsAverageEnabled
                   && !column.IsMaxEnabled && !column.IsMinEnabled)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 6097, "\"", 6115, 1);
            WriteAttributeValue("", 6105, 
#nullable restore
#line 165 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                  cssStyles

#line default
#line hidden
#nullable disable
            , 6105, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 165 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                 Strings.Min

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 166 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                }
                else
                {
                    if (column.IsMinEnabled)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 6317, "\"", 6335, 1);
            WriteAttributeValue("", 6325, 
#nullable restore
#line 171 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                      cssStyles

#line default
#line hidden
#nullable disable
            , 6325, 10, false);
            EndWriteAttribute();
            WriteLiteral("><b>");
            Write(
#nullable restore
#line 171 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                                     column.MinString

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 172 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                    }
                    else
                    {
                        if (((IGridColumn)column).Hidden)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\" style=\"display:none;\"></td>\r\n");
#nullable restore
#line 178 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <td class=\"grid-cell\"");
            BeginWriteAttribute("style", " style=\"", 6738, "\"", 6756, 1);
            WriteAttributeValue("", 6746, 
#nullable restore
#line 181 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                                                          cssStyles

#line default
#line hidden
#nullable disable
            , 6746, 10, false);
            EndWriteAttribute();
            WriteLiteral("></td>\r\n");
#nullable restore
#line 182 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
                        }
                    }
                }
            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 187 "D:\GitHub\SUN\sunerpm2l\Infrastructure\GridMvc\Views\Shared\_GridTotals.cshtml"
    }
}

#line default
#line hidden
#nullable disable

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
