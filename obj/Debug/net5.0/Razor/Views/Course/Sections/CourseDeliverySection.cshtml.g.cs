#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24293bd84a3e0417be01c2193cb7e581fe0a3dfa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Sections_CourseDeliverySection), @"mvc.1.0.view", @"/Views/Course/Sections/CourseDeliverySection.cshtml")]
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
#line 2 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24293bd84a3e0417be01c2193cb7e581fe0a3dfa", @"/Views/Course/Sections/CourseDeliverySection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Sections_CourseDeliverySection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.HomeworkViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/CourseArea/Homework.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("matterix-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Lecture", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DownloadFile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
  
//    var userId = "";
//    if (User.Identity.IsAuthenticated)
//    {
//        userId = Access.GetUserId(User);
//    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "24293bd84a3e0417be01c2193cb7e581fe0a3dfa5586", async() => {
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
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 18 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
 if (!Model.StudentsDeliveredHomework.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center direction font-cairo\">{{$t(\'message.noDeliveryYet\')}}</div>\r\n");
#nullable restore
#line 21 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
}
else
{
    
    
    //Here is the Teacher View

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"direction un-select\">\r\n");
#nullable restore
#line 61 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
         foreach (var delivery in Model.StudentsDeliveredHomework)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card file-card\"");
            BeginWriteAttribute("lecture-id", " lecture-id=\"", 2981, "\"", 3025, 1);
#nullable restore
#line 64 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
WriteAttributeValue("", 2994, delivery.LectureFile.LectureId, 2994, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("student-id", " student-id=\"", 3026, "\"", 3058, 1);
#nullable restore
#line 64 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
WriteAttributeValue("", 3039, delivery.StudentId, 3039, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("related-homework-name", " related-homework-name=\"", 3059, "\"", 3108, 1);
#nullable restore
#line 64 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
WriteAttributeValue("", 3083, delivery.LectureFileName, 3083, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"text-center matterix-color font-cairo\">{{$tc(\'message.lecture\', \'");
#nullable restore
#line 65 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                        Write(delivery.LectureFile.Lecture.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}} - ");
#nullable restore
#line 65 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                                                                   Write(delivery.LectureFile.Lecture.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"text-muted text-0-6 text-center\">{{$t(\'message.deadline\')}}: ");
#nullable restore
#line 66 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                    Write(Format.DateFormat(delivery.LectureFile.DeadLine));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 3457, "\"", 3465, 0);
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.studentName\')}}: ");
#nullable restore
#line 67 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                        Write(Info.FullName(delivery.StudentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 3560, "\"", 3568, 0);
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.homeworkFile\')}}: <a class=\"matterix-link\"");
            BeginWriteAttribute("href", " href=\"", 3626, "\"", 3672, 1);
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
WriteAttributeValue("", 3633, Url.Content(delivery.LectureFile.Path), 3633, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                                                                                 Write(delivery.LectureFile.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></div>\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 3748, "\"", 3756, 0);
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.deliveryFile\')}}: <a class=\"matterix-link\"");
            BeginWriteAttribute("href", " href=\"", 3814, "\"", 3848, 1);
#nullable restore
#line 69 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
WriteAttributeValue("", 3821, Url.Content(delivery.Path), 3821, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 69 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                                                                     Write(delivery.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>&nbsp;&nbsp;");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24293bd84a3e0417be01c2193cb7e581fe0a3dfa12758", async() => {
                WriteLiteral("({{$t(\'message.download\')}})");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-path", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                                                                                                                                                                                        WriteLiteral(delivery.RootPath);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["path"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-path", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["path"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                                                                                                                                                                                                                            WriteLiteral(delivery.Name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["name"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-name", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["name"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 4100, "\"", 4108, 0);
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.deliveryDate\')}}: {{$t(\'message.underDevelopment\')}}</div>\r\n                <div class=\"pointer homework-add-comment\">{{$t(\'message.notes\')}}: &#128172;<textarea hidden class=\"homework-comment-text\">");
#nullable restore
#line 71 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                                                                                                                                      Write(delivery.TeacherComment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea></div>\r\n                <div>");
#nullable restore
#line 72 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
                Write(Html.DropDownList("Mark", Enumerable.Range(0,7).Select(x=> new SelectListItem {Text = x.ToString(), Selected = x.ToString() == delivery.Mark.ToString()}), new{@class="form-control text-center homework-mark", @style="max-width: max-content; margin: auto;"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            </div>\r\n");
#nullable restore
#line 74 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
            
            
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n        \r\n    </div>\r\n");
#nullable restore
#line 81 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Course\Sections\CourseDeliverySection.cshtml"
    
    
    
    
    
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AccessService Access { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CourseService CourseService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public InformationService Info { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matterix.Models.ViewModel.HomeworkViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
