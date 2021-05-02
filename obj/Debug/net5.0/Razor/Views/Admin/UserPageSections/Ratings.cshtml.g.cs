#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63f508547640450ab00a745fdb6edec77f03c8d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserPageSections_Ratings), @"mvc.1.0.view", @"/Views/Admin/UserPageSections/Ratings.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Update\Matterix\Views\_ViewImports.cshtml"
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitFolders\Programming\C#\Update\Matterix\Views\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
using Microsoft.EntityFrameworkCore.Internal;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63f508547640450ab00a745fdb6edec77f03c8d7", @"/Views/Admin/UserPageSections/Ratings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserPageSections_Ratings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CourseRating>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">This user has no ratings yet!</div>\r\n");
#nullable restore
#line 7 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-hover\">\r\n        <thead>\r\n        <tr>\r\n            <th>Course</th>\r\n            <th>Value</th>\r\n        </tr>\r\n        </thead>\r\n");
#nullable restore
#line 17 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
         foreach (var rating in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
               Write(rating.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"small\"> / ");
#nullable restore
#line 20 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
                                                            Write(rating.Course.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                <td>");
#nullable restore
#line 21 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
               Write(rating.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 23 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    </table>\r\n");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Ratings.cshtml"
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CourseRating>> Html { get; private set; }
    }
}
#pragma warning restore 1591
