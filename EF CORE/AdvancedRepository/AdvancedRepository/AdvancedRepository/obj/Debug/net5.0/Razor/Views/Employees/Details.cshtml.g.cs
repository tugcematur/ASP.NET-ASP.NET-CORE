#pragma checksum "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Employees\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "084a6d0d219d8d66a4424a14eaf2dcb21269292a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_Details), @"mvc.1.0.view", @"/Views/Employees/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084a6d0d219d8d66a4424a14eaf2dcb21269292a", @"/Views/Employees/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5375d1ec7ee915ddf63588b5726041bff0309f1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Employees_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdvancedRepository.Models.ViewModels.EmployeeDetails>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Employees\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Employee Details</h1>
<hr />

<table>
    <thead>
        <tr>
            <th>Employee Id</th>
            <th>Full Name</th>
            <th>Header</th>
            <th>Salary</th>
        </tr>
    </thead>
    <tbody>

            <tr>
                <td>");
#nullable restore
#line 22 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Employees\Details.cshtml"
               Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 23 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Employees\Details.cshtml"
              Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Employees\Details.cshtml"
               Write(Model.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\301Sabah\15-EF CORE\AdvancedRepository\AdvancedRepository\AdvancedRepository\Views\Employees\Details.cshtml"
               Write(Model.Salary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n  \r\n\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdvancedRepository.Models.ViewModels.EmployeeDetails> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
