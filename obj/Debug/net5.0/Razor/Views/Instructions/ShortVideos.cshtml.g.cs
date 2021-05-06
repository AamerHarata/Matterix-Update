#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd7c0a441b75f6223246f0266d93c01a1dd8c965"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instructions_ShortVideos), @"mvc.1.0.view", @"/Views/Instructions/ShortVideos.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7c0a441b75f6223246f0266d93c01a1dd8c965", @"/Views/Instructions/ShortVideos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Instructions_ShortVideos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/instructions.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/InstructionVideoModal.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
  
    ViewBag.Title = "Help Videos";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cd7c0a441b75f6223246f0266d93c01a1dd8c9654740", async() => {
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
            WriteLiteral(@"

<div class=""text-center direction un-select"">
    <div class=""title-1-5 matterix-color font-cairo"">{{$t('message.helpByShortVideos')}}</div>
    <div style=""font-size: 3rem;""><i class=""fas fa-play-circle matterix-color""></i></div>
    <hr class=""w-75""/>
    
    <div class=""w-75 text-center m-auto"">
        
        <div class=""card task-card task-card-clickable direction open-instruction-modal w-75 m-auto mb-3"" device =""Computer"" topic=""instructionEnrollCourseStudent""");
            BeginWriteAttribute("target", " target=\"", 638, "\"", 691, 1);
#nullable restore
#line 18 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 647, StaticInstructionVideos.EnrollCourseStudent, 647, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""padding: 0.4rem 0.7rem; border: 0;"" type=""button"">
            
            <div class=""d-flex""><i class=""fa fa-play-circle ml-2 mr-2 icon-direction-reserve set-my-direction"" style=""font-size: 2rem;""></i><div class=""align-self-center"">{{$t('message.instructionEnrollCourseStudent')}}</div></div>

        </div>
        <br/>
        
        <div class=""card task-card task-card-clickable direction open-instruction-modal w-75 m-auto mb-3"" device =""Computer"" topic=""instructionJoinLectureComputer""");
            BeginWriteAttribute("target", " target=\"", 1205, "\"", 1258, 1);
#nullable restore
#line 25 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 1214, StaticInstructionVideos.JoinLectureComputer, 1214, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  style=""padding: 0.4rem 0.7rem; border: 0;"" type=""button"">
            
            <div class=""d-flex""><i class=""fa fa-play-circle ml-2 mr-2 icon-direction-reserve set-my-direction"" style=""font-size: 2rem;""></i><div class=""align-self-center"">{{$t('message.instructionJoinLectureComputer')}}</div></div>

        </div>
        <br/>
    
        <div class=""card task-card task-card-clickable direction open-instruction-modal w-75 m-auto mb-3"" device =""Mobile"" topic=""instructionJoinLectureMobile""");
            BeginWriteAttribute("target", " target=\"", 1765, "\"", 1816, 1);
#nullable restore
#line 32 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 1774, StaticInstructionVideos.JoinLectureMobile, 1774, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  style=""padding: 0.4rem 0.7rem; border: 0;"" type=""button"">
            
            <div class=""d-flex""><i class=""fa fa-play-circle ml-2 mr-2 icon-direction-reserve set-my-direction"" style=""font-size: 2rem;""></i><div class=""align-self-center"">{{$t('message.instructionJoinLectureMobile')}}</div></div>

        </div>
        <br/>
        
        <div class=""card task-card task-card-clickable direction open-instruction-modal w-75 m-auto mb-3"" device =""Computer"" topic=""instructionJoinCourseChat""");
            BeginWriteAttribute("target", " target=\"", 2324, "\"", 2372, 1);
#nullable restore
#line 39 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 2333, StaticInstructionVideos.JoinCourseChat, 2333, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  style=""padding: 0.4rem 0.7rem; border: 0;"" type=""button"">
            
            <div class=""d-flex""><i class=""fa fa-play-circle ml-2 mr-2 icon-direction-reserve set-my-direction"" style=""font-size: 2rem;""></i><div class=""align-self-center"">{{$t('message.instructionJoinCourseChat')}}</div></div>

        </div>
        <br/>
        
    </div>
    
    
</div>



















");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://kit.fontawesome.com/331f4f953b.js\" crossorigin=\"anonymous\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd7c0a441b75f6223246f0266d93c01a1dd8c96510161", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 72 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("MetaTags", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 79 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
      
        var imageUrl = $"{StaticInformation.FullWebsite}{Url.Content("~/Images/Covers/ContactUs.jpg")}";
    

#line default
#line hidden
#nullable disable
                WriteLiteral("    \r\n    \r\n    <meta property=\"og:url\"");
                BeginWriteAttribute("content", "    content=\"", 3181, "\"", 3249, 2);
#nullable restore
#line 84 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 3194, StaticInformation.FullWebsite, 3194, 30, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3224, "/Instructions/ShortVideos", 3224, 25, true);
                EndWriteAttribute();
                WriteLiteral("/>\r\n    <meta property=\"og:type\"    content=\"website\"/>\r\n    \r\n    <meta property=\"og:image\"");
                BeginWriteAttribute("content", " content=\"", 3342, "\"", 3361, 1);
#nullable restore
#line 87 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 3352, imageUrl, 3352, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <meta property=\"og:image:url\"");
                BeginWriteAttribute("content", "    content=\"", 3400, "\"", 3422, 1);
#nullable restore
#line 88 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 3413, imageUrl, 3413, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <meta property=\"og:image:secure_url\"");
                BeginWriteAttribute("content", "    content=\"", 3468, "\"", 3490, 1);
#nullable restore
#line 89 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Instructions\ShortVideos.cshtml"
WriteAttributeValue("", 3481, imageUrl, 3481, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
    <meta property=""og:image:type""    content=""image/jpeg"" />
    <meta property=""og:image:width""    content=""4000"" />
    <meta property=""og:image:height""    content=""4000"" />
    <meta property=""fb:app_id""    content=""3431737436868705"" />
    
    
    
    
    <meta property=""og:title""    content=""Help - Norske Fag på Arabisk"" />
    <meta property=""og:description""    content=""المساعدة بواسطة فيديوهات قصيرة"" />
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
