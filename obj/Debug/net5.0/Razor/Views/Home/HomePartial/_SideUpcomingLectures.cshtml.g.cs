#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9cbc37a92ccdcfec3c5c755af1b446c383329e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HomePartial__SideUpcomingLectures), @"mvc.1.0.view", @"/Views/Home/HomePartial/_SideUpcomingLectures.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9cbc37a92ccdcfec3c5c755af1b446c383329e8", @"/Views/Home/HomePartial/_SideUpcomingLectures.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_HomePartial__SideUpcomingLectures : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Lecture>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<div class=\"text-0-6 collapse task-box\" id=\"upcoming-lectures-task-box\">\r\n    <hr class=\"mt-0\"/>\r\n");
#nullable restore
#line 8 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
     if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-center direction mt-3 mb-3 text-secondary\">{{$t(\'message.noComingUpLecture\')}}</div>\r\n");
#nullable restore
#line 11 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
    }
    else
    {
        var gotHelp = false;
        foreach (var lecture in Model)
        {
            var date = $"{Format.Translate(lecture.Date.DayOfWeek.ToString())} {Format.DateFormat(lecture.Date)}";
            if (lecture.Date == Format.NorwayDateNow())
            {
                date = "{{$t('message.today')}}";
            }
            else if (lecture.Date == Format.NorwayDateNow().AddDays(1))
            {
                date = "{{$t('message.tomorrow')}}";
            }

            var liveNow = Format.NorwayDateNow() == lecture.Date.Date && Format.NorwayTimeNow() >= lecture.From.Subtract(new TimeSpan(0, 30, 0))
                          && Format.NorwayTimeNow() < lecture.To;
            var diff = lecture.From.Subtract(Format.NorwayTimeNow()).TotalMilliseconds;


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card task-card join-lecture-btn\" type=\"button\"");
            BeginWriteAttribute("isLive", " isLive=\"", 1193, "\"", 1221, 1);
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
WriteAttributeValue("", 1202, liveNow.ToString(), 1202, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("courseTitle", " courseTitle=\"", 1222, "\"", 1259, 1);
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
WriteAttributeValue("", 1236, lecture.Course.Subject, 1236, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("classUrl", " classUrl=\"", 1260, "\"", 1295, 1);
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
WriteAttributeValue("", 1271, lecture.Course.ClassUrl, 1271, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 32 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                 if (liveNow)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"direction font-cairo\" style=\"color: red\"><i class=\"fa fa-dot-circle-o\"></i><span>&nbsp;&nbsp;{{$t(\'message.liveNow\')}}&nbsp;&nbsp;|&nbsp;&nbsp;</span><span class=\"start-within\"");
            BeginWriteAttribute("diff", " diff=\"", 1557, "\"", 1569, 1);
#nullable restore
#line 34 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
WriteAttributeValue("", 1564, diff, 1564, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span></div>\r\n");
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"text-left\" style=\"font-weight: 600\">");
#nullable restore
#line 36 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                           Write(lecture.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"direction\">{{$t(\'message.lectureNumber\')}}: ");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                         if(lecture.Title == "intro"){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>0</span>");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                                                                    }else{

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                                                                     Write(lecture.Number);

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                                                                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 38 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                 if (!string.IsNullOrEmpty(lecture.Title))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"direction\">{{$t(\'message.lectureSubject\')}}: ");
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                              if(lecture.Title == "intro"){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>{{$t(\'message.intro\')}}</span>");
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                                                                                               }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>");
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                                                                                                      Write(lecture.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                                                                                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 41 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"direction\" style=\"color: gray\">");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                      Write(date);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;&nbsp;|&nbsp;&nbsp;");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                                                                                    Write(Format.TimeFormat(lecture.From));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 43 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                 if (liveNow)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"text-center text-secondary font-cairo\" style=\"margin: 0.2rem 0; color: red\">{{$t(\'message.clickHereToJoin\')}}</div>\r\n");
#nullable restore
#line 46 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 49 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
            if (liveNow && !gotHelp)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"mb-2 matterix-link open-instruction-modal\" device=\"Computer\"");
            BeginWriteAttribute("target", " target=\"", 2639, "\"", 2692, 1);
#nullable restore
#line 51 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
WriteAttributeValue("", 2648, StaticInstructionVideos.JoinLectureComputer, 2648, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.hereYouLearnHowToAccessLive\')}}</div>\r\n");
#nullable restore
#line 52 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Home\HomePartial\_SideUpcomingLectures.cshtml"
                gotHelp = true;

            }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Lecture>> Html { get; private set; }
    }
}
#pragma warning restore 1591
