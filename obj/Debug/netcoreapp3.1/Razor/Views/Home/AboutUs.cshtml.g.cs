#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c781fea1b84b92fc5811c011526efac3cb9a130"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AboutUs), @"mvc.1.0.view", @"/Views/Home/AboutUs.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
using Matterix.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c781fea1b84b92fc5811c011526efac3cb9a130", @"/Views/Home/AboutUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AboutUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/Home/SlideShow.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "HomePartial/_IconsOnMainPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Home/SlideShow.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
  
    ViewBag.Title = "About us";
    Layout = "_Layout";


    var std2018 = 42;
    var reg2018 = 47;
    
    var std2019 = 291;
    var reg2019 = 423;

    var std = Con.Users.ToList();
    var reg = Con.Registrations.Where(x=>!x.Canceled).ToList();

    var std2020 = std.Count(x => x.SignUpDate.Year < 2021);
    var reg2020 = reg.Count(x => x.RegisterDate.Year < 2021);

    var std2021 = std.Count(x => x.SignUpDate.Year >= 2021 && x.SignUpDate.Year < 2022);
    var reg2021 = reg.Count(x => x.RegisterDate.Year >= 2021 && x.RegisterDate.Year < 2022);

    var stdTot = std2018 + std2019 + std2020 + std2021;
    var regTot = reg2018 + reg2019 + reg2020 + reg2021;
    
    
    
    
            
     

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7c781fea1b84b92fc5811c011526efac3cb9a1305811", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7c781fea1b84b92fc5811c011526efac3cb9a1307793", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<div class=\"text-center direction un-select\">\r\n");
            WriteLiteral(@"    <br/>
    <br/>
    <div class=""container-fluid"">
        <p>{{$t('message.theOrganizationStarted')}}</p>
        <p>{{$t('message.thanksToAGroupOfQualifiedTeachers')}}</p>
        <p>{{$t('message.todayBecameMatterix')}}</p>
        <p>{{$t('message.byBuildingThisWebsite')}}</p>
        <p>{{$t('message.matterixAspires')}}</p>
    </div>
    <br/>
    <table class=""table table-striped w-50 text-center m-auto font-cairo"">
        
        
        <tr>
            <th></th>
            <th>{{$t('message.registeredStudentsCount')}}</th>
            <th>{{$t('message.totalEnrollmentsCount')}}</th>
        </tr>
        
        <tr>
            <th>2018</th>
            <td><code>");
#nullable restore
#line 71 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(std2018);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n            <td><code>");
#nullable restore
#line 72 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(reg2018);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <th>2019</th>\r\n            <td><code>");
#nullable restore
#line 77 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(std2019);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n            <td><code>");
#nullable restore
#line 78 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(reg2019);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n        </tr>\r\n        <tr>\r\n            <th>2020</th>\r\n            <td><code>");
#nullable restore
#line 82 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(std2020);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n            <td><code>");
#nullable restore
#line 83 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(reg2020);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n        </tr>\r\n        <tr>\r\n            <th>2021</th>\r\n            <td><code>");
#nullable restore
#line 87 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(std2021);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n            <td><code>");
#nullable restore
#line 88 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(reg2021);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n        </tr>\r\n\r\n\r\n        <tfoot>\r\n        <tr>\r\n            <th>{{$t(\'message.total\')}}</th>\r\n            <td><code>");
#nullable restore
#line 95 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(stdTot);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n            <td><code>");
#nullable restore
#line 96 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
                 Write(regTot);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</code></td>
        </tr>
        </tfoot>

    </table>
    <hr class=""mb-4""/>
    
    <div class=""row mb-4 mt-5"">
        <div class=""col-md-4""></div>
        <div class=""col-md-4"">
            <iframe style=""min-height: 250px;"" width=""100%"" height=""auto"" src=""https://www.youtube.com/embed/ZVu-l5rQTrw?controls=1"" frameborder=""0"" allow=""accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>
            <div class=""font-cairo"">{{$tc('message.successForTheYear', '2019 - 2020')}}</div>
        </div>
        <div class=""col-md-4""></div>
    </div>
    
    <div class=""row mb-4"">
        <div class=""col-md-4""></div>
        <div class=""col-md-4"">
            <iframe style=""min-height: 250px;"" width=""100%"" height=""auto"" src=""https://www.youtube.com/embed/c9wk7MeBwoE?controls=1"" frameborder=""0"" allow=""accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>
            <div class=""font-cairo"">{{$t('message.s");
            WriteLiteral("uccessProjectAutumn2019\')}}</div>\r\n        </div>\r\n        <div class=\"col-md-4\"></div>\r\n    </div>\r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c781fea1b84b92fc5811c011526efac3cb9a13013890", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 131 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\AboutUs.cshtml"
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
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext Con { get; private set; }
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
