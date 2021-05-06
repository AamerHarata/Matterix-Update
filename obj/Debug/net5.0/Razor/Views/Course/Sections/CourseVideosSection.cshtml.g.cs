#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47b51264e792f7f6ca4276910f95506891c496ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Sections_CourseVideosSection), @"mvc.1.0.view", @"/Views/Course/Sections/CourseVideosSection.cshtml")]
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
#line 2 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b51264e792f7f6ca4276910f95506891c496ce", @"/Views/Course/Sections/CourseVideosSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Sections_CourseVideosSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Matterix.Models.LectureVideo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/CourseArea/Videos.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
  
    var anyVideo = Model.Take(1).SingleOrDefault();


    var courseId = "";

    if (anyVideo != null)
    {
        
        courseId = anyVideo.Lecture.CourseId;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "47b51264e792f7f6ca4276910f95506891c496ce4527", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 21 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
 if (!Model.Any() || string.IsNullOrEmpty(courseId))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center direction un-select font-cairo\">{{$t(\'message.noVideoInCourse\')}}</div>\r\n");
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\" id=\"course-videos-container\">\r\n        <div class=\"col-2 text-center un-select\" id=\"playlist-container\">\r\n            \r\n");
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
             if (Access.CourseViewAccess(User, courseId))
            {
                foreach (var video in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"video-in-list\"");
            BeginWriteAttribute("id", " id=\"", 865, "\"", 887, 1);
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
WriteAttributeValue("", 870, video.UniqueCode, 870, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 36 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                         if (video.Lecture.Introduction && video.Lecture.Title != "intro")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 1042, "\"", 1050, 0);
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.exampleOfCourse\')}}</div>\r\n");
#nullable restore
#line 39 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                        }
                        else if(video.Lecture.Introduction && video.Lecture.Title == "intro")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 1274, "\"", 1282, 0);
            EndWriteAttribute();
            WriteLiteral(">{{$tc(\'message.intro\')}}</div>\r\n");
#nullable restore
#line 43 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 1432, "\"", 1440, 0);
            EndWriteAttribute();
            WriteLiteral(">{{$tc(\'message.lecture\', \'");
#nullable restore
#line 46 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                                                               Write(video.Lecture.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}</div>\r\n");
#nullable restore
#line 47 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"fa fa-play-circle\" style=\"font-size: 2.5rem;\"></i>\r\n                        <div>");
#nullable restore
#line 49 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                        Write(video.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <input type=\"hidden\" value=\"300\"/>\r\n                        <hr/>\r\n                        <div class=\"small\">");
#nullable restore
#line 52 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                                      Write(Format.DateFormat(video.Lecture.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n");
#nullable restore
#line 54 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                }
                
            }
            else
            {
                foreach (var video in Model)
                {
                    var isVideoOpen = Access.IsLectureOpen(video.LectureId, User) || video.Lecture.Introduction || video.Lecture.Free;
                    if (isVideoOpen)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"video-in-list\"");
            BeginWriteAttribute("id", " id=\"", 2267, "\"", 2289, 1);
#nullable restore
#line 64 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
WriteAttributeValue("", 2272, video.UniqueCode, 2272, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 65 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                             if (video.Lecture.Introduction && video.Lecture.Title != "intro")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>{{$t(\'message.exampleOfCourse\')}}</div>\r\n");
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                            }
                            else if(video.Lecture.Introduction && video.Lecture.Title == "intro")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>{{$tc(\'message.intro\')}}</div>\r\n");
#nullable restore
#line 72 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>{{$tc(\'message.lecture\', \'");
#nullable restore
#line 75 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                                                          Write(video.Lecture.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}</div>\r\n");
#nullable restore
#line 76 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div><i class=\"fa fa-play-circle\" style=\"font-size: 2.5rem;\"></i></div>\r\n                            <div>");
#nullable restore
#line 78 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                            Write(video.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\" value=\"300\"/>\r\n                            <hr/>\r\n                            <div class=\"small\">");
#nullable restore
#line 81 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                                          Write(Format.DateFormat(video.Lecture.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 82 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                             if (video.Lecture.Number > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"small\"><span class=\"small\">{{$t(\'message.thisVideoIsOpenedAs\')}}</span></div>\r\n");
#nullable restore
#line 85 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n");
#nullable restore
#line 87 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
                    }
                }
                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <button id=""close-video-list"" class=""btn btn-danger open-close-video-list title-1-5 ""><i class=""fa fa-close""></i></button>
        <button id=""open-video-list"" class=""btn btn-success open-close-video-list title-1-5""><i class=""fa fa-play-circle""></i></button>
    
        <div class=""col-10"" id=""main-video-container"">
            <div class=""text-center direction"" id=""video-mask""></div>
            <iframe width=""100%"" height=""90%"" id=""main-video-frame""");
            BeginWriteAttribute("src", "\r\n                    src=\"", 4133, "\"", 4160, 0);
            EndWriteAttribute();
            WriteLiteral("\r\n                    frameborder=\"0\"\r\n                    allowfullscreen allow-same-origin>\r\n            </iframe>\r\n            \r\n        </div>\r\n        \r\n        \r\n    </div>\r\n");
#nullable restore
#line 107 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseVideosSection.cshtml"
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AccessService Access { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Matterix.Models.LectureVideo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
