#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87c72fb1b159cff3b6bb22f638db85289f7c3e73"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Sections_CourseDiscordSection), @"mvc.1.0.view", @"/Views/Course/Sections/CourseDiscordSection.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\_ViewImports.cshtml"
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Views\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87c72fb1b159cff3b6bb22f638db85289f7c3e73", @"/Views/Course/Sections/CourseDiscordSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Sections_CourseDiscordSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Course>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Instructions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CourseChatHelp", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
  
    
    var view = Access.CourseViewAccess(User, Model.Id);
    var edit = Access.CourseEditAccess(User, Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"text-center un-select\">\r\n    <br/>\r\n\r\n");
#nullable restore
#line 17 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
     if (view || edit)
    {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"display-4 title-1-0 text-danger direction text-center\">{{$t(\'message.ifYouHaveNotBeenToCourseChat\')}} ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87c72fb1b159cff3b6bb22f638db85289f7c3e735054", async() => {
                WriteLiteral("{{$t(\'message.instructionsAndHelp\')}}");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n        <br/>\r\n        <div class=\"text-0-9 matterix-color smoke-background card task-card task-card-clickable direction open-instruction-modal m-auto\" device =\"Computer\" topic=\"instructionJoinCourseChat\"");
            BeginWriteAttribute("target", " target=\"", 817, "\"", 865, 1);
#nullable restore
#line 22 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
WriteAttributeValue("", 826, StaticInstructionVideos.JoinCourseChat, 826, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  style=""padding: 0.4rem 0.7rem; border: 0; width: max-content"" type=""button"">
            
            <div class=""d-flex""><i class=""fa fa-play-circle ml-2 mr-2 icon-direction-reserve set-my-direction"" style=""font-size: 2rem;""></i><div class=""align-self-center"">{{$t('message.instructionJoinCourseChat')}}</div></div>

        </div>
        <br/>
");
#nullable restore
#line 28 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
        if (!string.IsNullOrEmpty(Info.GetDiscordLink()))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"display-4 title-1-5\"><a class=\"matterix-color\"");
            BeginWriteAttribute("href", " href=\"", 1361, "\"", 1390, 1);
#nullable restore
#line 30 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
WriteAttributeValue("", 1368, Info.GetDiscordLink(), 1368, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><strong>{{$t(\'message.clickHereToJoinChat\')}}</strong></a></div>\r\n");
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"display-4 title-1-5 matterix-color\">{{$t(\'message.linkNotWorkContactNow\')}}</div>\r\n");
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
        }
            
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"display-4 title-1-5 direction text-center\">{{$t(\'message.youHaveToEnrollCourse\')}}</div>\r\n");
#nullable restore
#line 41 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Course\Sections\CourseDiscordSection.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n    \r\n</div>\r\n");
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