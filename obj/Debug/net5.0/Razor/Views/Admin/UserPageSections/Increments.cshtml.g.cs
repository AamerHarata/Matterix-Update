#pragma checksum "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a43ac2f2fa5a77e5c6c7b465b7f1a14a61cc2e3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserPageSections_Increments), @"mvc.1.0.view", @"/Views/Admin/UserPageSections/Increments.cshtml")]
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
#line 1 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a43ac2f2fa5a77e5c6c7b465b7f1a14a61cc2e3e", @"/Views/Admin/UserPageSections/Increments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserPageSections_Increments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InvoiceIncrement>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 6 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr/>\r\n    <div class=\"text-center\">No Increments!</div>\r\n");
#nullable restore
#line 10 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-hover"">
        
        <thead>
        <tr>
            <th>Invoice Number</th>
            <th>KID</th>
            <th>Reason</th>
            <th>Type</th>
            <th>Amount</th>
            <th>New DueDate</th>
            <th>New Deadline</th>
            <th>Delete</th>
        </tr>
        </thead>
    
");
#nullable restore
#line 28 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
         foreach (var inc in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
               Write(inc.InvoiceNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
               Write(inc.Invoice.CIDNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
               Write(inc.Reason);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
               Write(inc.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
               Write(inc.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
               Write(Format.DateFormat(inc.NewDueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
               Write(Format.DateFormat(inc.NewDeadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><button");
            BeginWriteAttribute("increment-id", " increment-id=\"", 954, "\"", 976, 1);
#nullable restore
#line 38 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
WriteAttributeValue("", 969, inc.Id, 969, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger remove-increment\">Delete</button></td>\r\n");
            WriteLiteral("\r\n            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
        
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 49 "C:\Users\Joudy\Matterix-Update\Views\Admin\UserPageSections\Increments.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InvoiceIncrement>> Html { get; private set; }
    }
}
#pragma warning restore 1591
