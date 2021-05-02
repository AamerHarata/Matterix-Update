#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7b02036dcc42dffb1420be984c86647e272ee18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HomePartial__SideUpcomingHomework), @"mvc.1.0.view", @"/Views/Home/HomePartial/_SideUpcomingHomework.cshtml")]
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
#line 2 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7b02036dcc42dffb1420be984c86647e272ee18", @"/Views/Home/HomePartial/_SideUpcomingHomework.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_HomePartial__SideUpcomingHomework : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LectureFile>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"collapse task-box\" id=\"upcoming-homework-task-box\">\r\n    <hr class=\"mt-0\"/>\r\n");
#nullable restore
#line 6 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
     if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-center direction mt-3 mb-3 text-secondary\">{{$t(\'message.noUnDeliveredHomework\')}}</div>\r\n");
#nullable restore
#line 9 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
    }
    else
    {
        foreach (var homework in Model)
        {
            var homeworkName = homework.Name.Split(".")[0];

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card task-card direction\" style=\"padding: 0.4rem 0.7rem; border: 0\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 538, "\"", 609, 4);
            WriteAttributeValue("", 548, "window.open(\'", 548, 13, true);
#nullable restore
#line 15 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
WriteAttributeValue("", 561, Url.Content(homework.Path), 561, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 588, "#homework\',", 588, 11, true);
            WriteAttributeValue(" ", 599, "\'_blank\')", 600, 10, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"text-left\" style=\"font-weight: 600\">");
#nullable restore
#line 16 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
                                                           Write(homework.Lecture.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div style=\"overflow-x: hidden; text-wrap: none;\" class=\"text-left matterix-color\">");
#nullable restore
#line 17 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
                                                                                              Write(homeworkName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <span class=\"text-right small\" style=\"color: gray\">{{$t(\'message.deadline\')}} ");
#nullable restore
#line 18 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
                                                                                         Write(Format.DateFormat(homework.DeadLine));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 20 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingHomework.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LectureFile>> Html { get; private set; }
    }
}
#pragma warning restore 1591
