#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fc0ba436462d027b241837ca48815b30ff3a839"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fc0ba436462d027b241837ca48815b30ff3a839", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Admin.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("admin-user-search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditStudent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PartialViews/_SharedModal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Admin/AdminMain.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Admin";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7fc0ba436462d027b241837ca48815b30ff3a8398450", async() => {
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
            WriteLiteral("\r\n\r\n<div class=\"text-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fc0ba436462d027b241837ca48815b30ff3a8399603", async() => {
                WriteLiteral("<input class=\"form-control\" name=\"searchPattern\" placeholder=\"Write Name, email, phone, or any info to find ...\" style=\"width: 60%; margin: 1rem auto\"/>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <button type=\"submit\" id=\"admin-user-search-btn\" class=\"btn btn-success\">Search</button>\r\n    <button class=\"btn btn-secondary\" id=\"admin-user-all-btn\">Show All</button>\r\n    \r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 21 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
 foreach (var user in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"full-user-div\"");
            BeginWriteAttribute("blocked", " blocked=\"", 823, "\"", 857, 1);
#nullable restore
#line 23 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
WriteAttributeValue("", 833, user.Blocked.ToString(), 833, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div style=\" margin: auto\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fc0ba436462d027b241837ca48815b30ff3a83912340", async() => {
                WriteLiteral("<img");
                BeginWriteAttribute("src", " src=\"", 1009, "\"", 1054, 1);
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1015, Url.Content(Info.ProfilePicture(user)), 1015, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"120\" height=\"120\" style=\"border-radius: 50%; object-fit: cover;\"/>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-username", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                             WriteLiteral(user.ProfileUserName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n        <div class=\"full-user-body\">\r\n            \r\n            <table class=\"table table-hover full-user-body-table\">\r\n                <tr>\r\n                    <th><span>");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                         Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                         Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                              if (!string.IsNullOrEmpty(user.MiddleName)) {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>, ");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                              Write(user.MiddleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                                                          }

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                                                             if(!user.ShowFullName){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"small text-success\">, Hidden</span>");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                                                                                                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></th>\r\n                    <td>");
#nullable restore
#line 30 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                   Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                   Write(user.Email);

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                    if(!@user.EmailConfirmed){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span> - Not Verified</span>");
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                          }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                   Write(user.PhoneNumber);

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                          if(!@user.PhoneNumberConfirmed){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span> - Not Verified</span>");
#nullable restore
#line 32 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Sign up: ");
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                            Write(Format.DateFormat(user.SignUpDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                  Write(Format.DateFormat(user.SignUpDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>Birth: ");
#nullable restore
#line 36 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                          Write(Format.DateFormat(user.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                   Write(user.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                  Write(user.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                       if(user.Role != EnumList.Role.Student){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span> - ");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                  Write(user.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                   Write(user.CurrentPassword);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n");
#nullable restore
#line 41 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                       var address = AdminService.GetUserAddress(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td colspan=\"2\">");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                               Write(address.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                Write(address.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                 Write(address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>Payments: ");
#nullable restore
#line 43 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                             Write(AdminService.TotalPaidAmount(user.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>Not Paid: ");
#nullable restore
#line 44 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                             Write(AdminService.NotPaidAmount(user.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Total Courses: ");
#nullable restore
#line 47 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                  Write(AdminService.CourseTakenCount(user.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>Total Feedback: ");
#nullable restore
#line 48 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                   Write(AdminService.UserFeedbackCount(user.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>Average Rating: ");
#nullable restore
#line 49 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                   Write(AdminService.UserRatingAverage(user.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>Devices: <span class=\"user-devices-count\">");
#nullable restore
#line 50 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                             Write(AdminService.DifferentDevices(user.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                </tr>\r\n");
#nullable restore
#line 52 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                 if (user.Blocked)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 55 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                       Write(user.BlockType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 55 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                         Write(Format.DateFormat(user.BlockDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td colspan=\"2\">");
#nullable restore
#line 56 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                   Write(user.BlockDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><button class=\"btn btn-light admin-unblock-btn\"");
            BeginWriteAttribute("userId", " userId=\"", 3293, "\"", 3310, 1);
#nullable restore
#line 57 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
WriteAttributeValue("", 3302, user.Id, 3302, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Unblock</button></td>\r\n                    </tr>\r\n");
#nullable restore
#line 59 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n");
#nullable restore
#line 61 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                 if (!string.IsNullOrEmpty(user.StatusMessage))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr><td colspan=\"4\"><code>");
#nullable restore
#line 63 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                         Write(user.StatusMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td></tr>\r\n");
#nullable restore
#line 64 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n                <tr>\r\n                    <tfoot class=\"text-center\">\r\n                    <td><button class=\"btn btn-success admin-send-email-btn\"");
            BeginWriteAttribute("user-id", " user-id=\"", 3751, "\"", 3769, 1);
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
WriteAttributeValue("", 3761, user.Id, 3761, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("email", " email=\"", 3770, "\"", 3789, 1);
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
WriteAttributeValue("", 3778, user.Email, 3778, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Email</button></td>\r\n                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fc0ba436462d027b241837ca48815b30ff3a83928695", async() => {
                WriteLiteral("<button class=\"btn btn-info\">Page</button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                              WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fc0ba436462d027b241837ca48815b30ff3a83931260", async() => {
                WriteLiteral("<button class=\"btn btn-secondary\">Edit</button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
                                                                                                 WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                    <td><button class=\"btn btn-danger admin-block-btn\"");
            BeginWriteAttribute("userId", " userId=\"", 4228, "\"", 4245, 1);
#nullable restore
#line 71 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
WriteAttributeValue("", 4237, user.Id, 4237, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Block</button></td>\r\n                    </tfoot>\r\n                </tr>\r\n            </table>\r\n            \r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 78 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7fc0ba436462d027b241837ca48815b30ff3a83934573", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fc0ba436462d027b241837ca48815b30ff3a83935794", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_12.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
#nullable restore
#line 84 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\Index.cshtml"
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
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public InformationService Info { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AdminService AdminService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
