#pragma checksum "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c718722ad5b17d9ae037c75d4dac19dead8e13ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Basket_List), @"mvc.1.0.view", @"/Views/Basket/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\_ViewImports.cshtml"
using AdvancedRepository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\_ViewImports.cshtml"
using AdvancedRepository.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c718722ad5b17d9ae037c75d4dac19dead8e13ee", @"/Views/Basket/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5375d1ec7ee915ddf63588b5726041bff0309f1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Basket_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AdvancedRepository.DTOs.Basket>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-5"">
        <h4>Basket</h4>
        <a href=""/Basket/Add"" class=""btn btn-primary"">Add Product</a>
        <table class=""table"">

            <thead>

                <tr>

                    <th>Id</th>
                    <th>Product Name</th>
                    <th>Amount</th>
                    <th>Unit Price</th>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 25 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 28 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml"
                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 29 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml"
                       Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml"
                       Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml"
                       Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 33 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Basket\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AdvancedRepository.DTOs.Basket>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591