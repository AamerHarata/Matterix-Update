#pragma checksum "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0401f6090c4bf5975889151eabce0ee5716557ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Sections_CourseClassSection), @"mvc.1.0.view", @"/Views/Course/Sections/CourseClassSection.cshtml")]
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
#line 1 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0401f6090c4bf5975889151eabce0ee5716557ae", @"/Views/Course/Sections/CourseClassSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Sections_CourseClassSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Course>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
  
    
    var view = Access.CourseViewAccess(User, Model.Id);
    var edit = Access.CourseEditAccess(User, Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"text-center un-select direction\">\r\n    <br/>\r\n");
#nullable restore
#line 16 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
     if (Model.Ended)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"display-4 title-1-5\">{{$t(\'message.courseIsEnded\')}}</div>\r\n");
#nullable restore
#line 19 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
    }
    else
    {
        if (view || edit)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""display-4 title-1-5"">{{$t('message.oneClickToGoToCourseClass')}}. <span class=""title-1-0 text-success"">{{$t('message.checkFirstLecturesTime')}}</span></div>
            <br/>
            <div class=""display-4 title-1-0 text-danger direction text-center"">{{$t('message.oneMomentPleaseJoiningReadInstructions')}}</div>
");
            WriteLiteral(@"            <div class=""col-md-6"" style=""margin: 2rem auto 3rem auto;"">
                <div class=""mb-3 text-0-9 matterix-color smoke-background card task-card task-card-clickable direction open-instruction-modal"" device =""Computer"" topic=""instructionJoinLectureComputer""");
            BeginWriteAttribute("target", " target=\"", 1135, "\"", 1188, 1);
#nullable restore
#line 29 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
WriteAttributeValue("", 1144, StaticInstructionVideos.JoinLectureComputer, 1144, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  style=""padding: 0.4rem 0.7rem; border: 0;"" type=""button"">
            
                    <div class=""d-flex""><i class=""fa fa-play-circle ml-2 mr-2 icon-direction-reserve set-my-direction"" style=""font-size: 2rem;""></i><div class=""align-self-center"">{{$t('message.instructionJoinLectureComputer')}}</div></div>

                </div>
    
                <div class=""text-0-9 matterix-color smoke-background card task-card task-card-clickable direction open-instruction-modal"" device =""Mobile"" topic=""instructionJoinLectureMobile""");
            BeginWriteAttribute("target", " target=\"", 1728, "\"", 1779, 1);
#nullable restore
#line 35 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
WriteAttributeValue("", 1737, StaticInstructionVideos.JoinLectureMobile, 1737, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  style=""padding: 0.4rem 0.7rem; border: 0;"" type=""button"">
            
                    <div class=""d-flex""><i class=""fa fa-play-circle ml-2 mr-2 icon-direction-reserve set-my-direction"" style=""font-size: 2rem;""></i><div class=""align-self-center"">{{$t('message.instructionJoinLectureMobile')}}</div></div>

                </div>
            </div>
");
            WriteLiteral("            <br/>\r\n");
#nullable restore
#line 43 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
            if (!string.IsNullOrEmpty(Model.ClassUrl))
             {

#line default
#line hidden
#nullable disable
            WriteLiteral("                 <div><a class=\"m-button m-button-primary\" style=\"font-size: 1rem\" target=\"_blank\"");
            BeginWriteAttribute("href", " href=\"", 2343, "\"", 2365, 1);
#nullable restore
#line 45 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
WriteAttributeValue("", 2350, Model.ClassUrl, 2350, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.clickHereToJoin\')}}</a></div>\r\n");
#nullable restore
#line 46 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
             }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"display-4 title-1-5 matterix-color\">{{$t(\'message.linkNotWorkContactNow\')}}</div>\r\n");
#nullable restore
#line 50 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
            }
            
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"display-4 title-1-5 direction text-center\">{{$t(\'message.youHaveToEnrollCourse\')}}</div>\r\n");
#nullable restore
#line 56 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Course\Sections\CourseClassSection.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n    \r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CourseService CourseService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public InformationService Info { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Course> Html { get; private set; }
    }
}
#pragma warning restore 1591
