#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0255cc2040f72a0c85c1dfdeab5aa701b94b680"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UserProfile), @"mvc.1.0.view", @"/Views/Home/UserProfile.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0255cc2040f72a0c85c1dfdeab5aa701b94b680", @"/Views/Home/UserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.UserProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/UserProfileIndex.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("25"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flag lang"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/flag-nob.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/flag-en.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("عربي"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("20"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/flag-ar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Course", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CourseArea", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
  
    ViewBag.Title = Info.FullName(Model.User.Id);
    Layout = "_Layout";
    var old = DateTime.Now.Year - Model.User.BirthDate.Year;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f0255cc2040f72a0c85c1dfdeab5aa701b94b6808592", async() => {
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
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n<div class=\"full-user-div direction un-select\" id=\"course-info-main-box\">\r\n    <div class=\"row\">\r\n        <div class=\"col-3 align-self-center\"><img id=\"in-profile-pic\"");
            BeginWriteAttribute("src", " src=\"", 500, "\"", 551, 1);
#nullable restore
#line 19 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
WriteAttributeValue("", 506, Url.Content(Info.ProfilePicture(Model.User)), 506, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""full-width"" style=""border-radius: 50%; object-fit: cover""/></div>
        <div class=""col-7 full-course-body w-75"">
            <div class=""matterix-color title-2-0 w-50 display-4 "" style=""padding: 5% 0 1% 0; margin-bottom: 5%; border-bottom: 1px solid lightgray"">
");
#nullable restore
#line 22 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                 if (Model.User.ShowFullName)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>");
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                     Write(Info.FullName(Model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 25 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span data-toggle=\"tooltip\" data-placement=\"auto\" v-bind:title=\"$t(\'message.thisUserChoseToDontShow\')\" style=\"border-top: none;\">");
#nullable restore
#line 28 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                Write(Info.FullName(Model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            \r\n            \r\n            <div class=\"display-4 title-1-0 mb-3\">\r\n                ");
#nullable restore
#line 34 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
           Write(Format.Translate(Model.User.Gender.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("{{$t(\'message.,\')}}&nbsp;{{$tc(\'message.yearOld\', \'");
#nullable restore
#line 34 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                             Write(old);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}{{$t(\'message.,\')}}&nbsp;\r\n                    \r\n");
#nullable restore
#line 36 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                 switch (Model.User.Language)
                {
                    case EnumList.Language.Norwegian:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f0255cc2040f72a0c85c1dfdeab5aa701b94b68013226", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n");
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"

                        break;
                    case EnumList.Language.English:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f0255cc2040f72a0c85c1dfdeab5aa701b94b68014898", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n");
#nullable restore
#line 44 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"

                        break;
                    case EnumList.Language.Arabic:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f0255cc2040f72a0c85c1dfdeab5aa701b94b68016486", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n");
#nullable restore
#line 48 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            \r\n            \r\n            <div class=\"mb-3 display-4 title-1-0\">\r\n");
#nullable restore
#line 57 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                 switch (Model.User.Role)
                {
                    case EnumList.Role.Student:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"display-4 title-1-0\" >{{$tc(\'message.student\',\'");
#nullable restore
#line 60 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                Write((int)Model.User.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}} {{$t(\'message.,\')}} {{$t(\'message.since\')}} ");
#nullable restore
#line 60 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                         Write(Format.DateFormat(Model.User.SignUpDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 60 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                                                              ;
                        break;
                    case EnumList.Role.Teacher:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"display-4 title-1-0\" >{{$tc(\'message.aTeacher\',\'");
#nullable restore
#line 63 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                 Write((int)Model.User.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}} {{$t(\'message.,\')}} {{$t(\'message.since\')}} ");
#nullable restore
#line 63 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                          Write(Format.DateFormat(Model.User.SignUpDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 63 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                                                               ;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>{{$tc(\'message.aTeacher\',\'1\')}}</span>\r\n");
#nullable restore
#line 65 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                        break;
                    case EnumList.Role.Admin:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"display-4 title-1-0\">{{$tc(\'message.aTeacher\',\'");
#nullable restore
#line 67 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                Write((int)Model.User.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}} {{$t(\'message.,\')}} {{$tc(\'message.anAdmin\',\'");
#nullable restore
#line 67 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                           Write((int)Model.User.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}} {{$t(\'message.,\')}} {{$t(\'message.since\')}} ");
#nullable restore
#line 67 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                                                                                    Write(Format.DateFormat(Model.User.SignUpDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 67 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                                                                                                                                         ;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                
                <span class=""title-1-0"">&nbsp;&nbsp;<i class=""fa fa-comments-o"" data-toggle=""tooltip"" data-placement=""auto"" v-bind:title=""$t('message.thisSectionIsUnderDeveloping')""></i></span>


            </div>
            
            <div>
");
#nullable restore
#line 79 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                 if (string.IsNullOrEmpty(Model.User.StatusMessage))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div id=\"status-message\" class=\"small\" style=\"color: gray\">{{$t(\'message.noStatusMessage\')}}</div>\r\n");
#nullable restore
#line 82 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div id=\"status-message\"><code>");
#nullable restore
#line 85 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                              Write(Model.User.StatusMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></div>\r\n");
#nullable restore
#line 86 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            \r\n            \r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n    \r\n");
#nullable restore
#line 184 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
 if (ViewBag.ProfileOwner || User.HasClaim("Role", "Admin"))
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center direction d-flex un-select"" style=""width: 80%; margin: auto;"">
        <input maxlength=""200"" autocomplete=""off"" class=""form-control direction m-auto"" style=""width: 85%"" id=""status"" v-bind:placeholder=""$t('message.writeAStatus')""/>
        <button style=""width: fit-content;"" class=""btn btn-primary"" id=""change-status""");
            BeginWriteAttribute("user-id", " user-id=\"", 9433, "\"", 9457, 1);
#nullable restore
#line 189 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
WriteAttributeValue("", 9443, Model.User.Id, 9443, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">{{$t(\'message.ChangeStatus\')}}</button>\r\n    </div>\r\n");
#nullable restore
#line 191 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"un-select\">\r\n    <br/>\r\n    <br/>\r\n</div>\r\n\r\n");
#nullable restore
#line 198 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
 switch (Model.User.Role)
{
    case EnumList.Role.Student:
    
    

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"direction un-select\">\r\n                <div class=\"matterix-color display-4 title-2-0\" style=\"margin: auto 1rem;width: fit-content;border-bottom: 1px dashed var(--Matterix)\">\r\n                    {{$tc(\'message.theyStudied\', \'");
#nullable restore
#line 205 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                              Write((int)Model.User.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}\r\n                </div>\r\n                <br/>\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"direction un-select\" style=\"margin: 0 0.5rem;\">\r\n            <div>\r\n                <ul>\r\n");
#nullable restore
#line 214 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                     foreach (var course in Model.RegisteredCourses)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"display-4 title-1-5\" style=\"padding: 0.4rem\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0255cc2040f72a0c85c1dfdeab5aa701b94b68027749", async() => {
#nullable restore
#line 216 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                               Write(course.Subject);

#line default
#line hidden
#nullable disable
                WriteLiteral(" / <span class=\"small\">");
#nullable restore
#line 216 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                                                                     Write(course.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-courseId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 216 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                           WriteLiteral(course.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-courseId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 217 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 222 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
    
    
        break;
    case EnumList.Role.Teacher:
    case EnumList.Role.Admin:
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row direction un-select"">
            <div class=""col-1""></div>
            <div class=""col-3"">
                <div class=""matterix-color display-4 title-2-0"" style=""border-bottom: 1px dashed var(--Matterix)"">
                    {{$tc('message.theyTeach', '");
#nullable restore
#line 232 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                            Write((int)Model.User.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}\r\n                </div>\r\n                <br/>\r\n            </div>\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"row direction un-select\">\r\n            <div class=\"col-1\"></div>\r\n            <div class=\"col-5\">\r\n                <ul>\r\n");
#nullable restore
#line 243 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                     foreach (var course in Model.TeacherCourses)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"display-4 title-1-5\" style=\"padding: 0.4rem\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0255cc2040f72a0c85c1dfdeab5aa701b94b68032902", async() => {
#nullable restore
#line 245 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                               Write(course.Subject);

#line default
#line hidden
#nullable disable
                WriteLiteral(" / <span class=\"small\">");
#nullable restore
#line 245 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                                                                                     Write(course.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-courseId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 245 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                                                                                                                                                           WriteLiteral(course.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-courseId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 246 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 251 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\UserProfile.cshtml"
    
    
    
        break;
    default:
        throw new ArgumentOutOfRangeException();
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    
    <script>
        $(document).ready(function() {
            $(""#in-profile-pic"").css('height', $(""#in-profile-pic"").css('width'));
            $(window).on('resize',
                function() {
                    $(""#in-profile-pic"").css('height', $(""#in-profile-pic"").css('width'));
                });
            

            const changeBtn = $(""#change-status"");


            $(""#status"").keyup(function(e) {
                if (e.keyCode === 13)
                    $(changeBtn).click();
            });
            
            

            $(changeBtn).unbind().bind('click',
                function() {
                    const userId = $(this).attr(""user-id"");
                    const status = $(""#status"").val();
                    console.log(userId);
                    
                    $.ajax({
                        type: ""POST"",
                        url:""/home/ChangeUserName/"",
                        data: {userId: userId, status: status},
    ");
                WriteLiteral(@"                    success: function() {
                            $(""#status"").val('');
                            $(""#status-message"").removeAttr(""style"").html(`<code>${status}</code>`);
                        }
                    });
                    

                });

        });
    </script>
    
    
");
            }
            );
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matterix.Models.ViewModel.UserProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591