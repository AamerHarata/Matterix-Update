<<<<<<< HEAD
#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "917905b96298cd855ec086d44672f71576d0fcf8"
=======
#pragma checksum "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "917905b96298cd855ec086d44672f71576d0fcf8"
>>>>>>> origin/Myada_First
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_CoursePartial__LectureVideoAdd), @"mvc.1.0.view", @"/Views/Course/CoursePartial/_LectureVideoAdd.cshtml")]
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
<<<<<<< HEAD
#line 1 "D:\GitFolders\Programming\C#\Update\Matterix\Views\_ViewImports.cshtml"
=======
#line 1 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
>>>>>>> origin/Myada_First
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 2 "D:\GitFolders\Programming\C#\Update\Matterix\Views\_ViewImports.cshtml"
=======
#line 2 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
>>>>>>> origin/Myada_First
using Matterix.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"917905b96298cd855ec086d44672f71576d0fcf8", @"/Views/Course/CoursePartial/_LectureVideoAdd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_CoursePartial__LectureVideoAdd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.VideoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"add-video-container\">\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 4 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
=======
#line 4 "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
>>>>>>> origin/Myada_First
     if (Model.OneLectureVideos.Count != 0)
    {
        foreach (var video in Model.OneLectureVideos)
         {

#line default
#line hidden
#nullable disable
            WriteLiteral("             <div class=\"add-video-inputs\" ready=\"false\" style=\"display: block;\">\r\n                 <span>");
#nullable restore
<<<<<<< HEAD
#line 9 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
=======
#line 9 "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
>>>>>>> origin/Myada_First
                  Write(video.VideoNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("- </span>\r\n                 <input class=\"video-name form-control\" v-bind:placeholder=\"Name\"");
            BeginWriteAttribute("value", " value=\"", 421, "\"", 440, 1);
#nullable restore
<<<<<<< HEAD
#line 10 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
=======
#line 10 "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
>>>>>>> origin/Myada_First
WriteAttributeValue("", 429, video.Name, 429, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 441, "\"", 475, 2);
            WriteAttributeValue("", 446, "video-name-", 446, 11, true);
#nullable restore
<<<<<<< HEAD
#line 10 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
=======
#line 10 "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
>>>>>>> origin/Myada_First
WriteAttributeValue("", 457, video.VideoNumber, 457, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n                 <input class=\"video-path form-control\" v-bind:placeholder=\"Link\"");
            BeginWriteAttribute("value", " value=\"", 561, "\"", 579, 1);
#nullable restore
<<<<<<< HEAD
#line 11 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
=======
#line 11 "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
>>>>>>> origin/Myada_First
WriteAttributeValue("", 569, video.Url, 569, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 580, "\"", 614, 2);
            WriteAttributeValue("", 585, "video-path-", 585, 11, true);
#nullable restore
<<<<<<< HEAD
#line 11 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
=======
#line 11 "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
>>>>>>> origin/Myada_First
WriteAttributeValue("", 596, video.VideoNumber, 596, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n                 <div class=\"video-remove\">&#10060;</div>\r\n             </div>\r\n");
#nullable restore
<<<<<<< HEAD
#line 14 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
=======
#line 14 "C:\Users\Joudy\Matterix-Update\Views\Course\CoursePartial\_LectureVideoAdd.cshtml"
>>>>>>> origin/Myada_First
         }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n</div>\r\n\r\n<button class=\"btn btn-dark\" id=\"new-video-btn\" style=\"border-radius: 90%; display: block; margin: 1rem\"><i class=\"fa fa-plus\" aria-hidden=\"true\"></i></button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matterix.Models.ViewModel.VideoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
