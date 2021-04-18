#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4f60542d4954ffab7c400affda899781cc3959e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ActivitiesOverview), @"mvc.1.0.view", @"/Views/Admin/ActivitiesOverview.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
using Matterix.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4f60542d4954ffab7c400affda899781cc3959e", @"/Views/Admin/ActivitiesOverview.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ActivitiesOverview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserDevice>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 10 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
  
    ViewBag.Title = "Activites";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 15 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
  
    var activities = Model.ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
 if (!activities.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr/>\r\n    <div class=\"text-center\">Ops! No Activities</div>\r\n");
#nullable restore
#line 23 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
    
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""direction text-center table table-striped"" style=""width: 100%;"">
            
            <thead>
            <tr>
                <th style=""width: 2rem"">#</th>
                <th>User</th>
                <th>Activity</th>
                <th style=""width: 7rem"">Device</th>
                <th>Operating System</th>
                <th>IP Number</th>
                <th>Date and Time</th>
                <th>Device Id</th>

            </tr>
            </thead>
");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
               var i = @activities.Count;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
             foreach (var activity in activities)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"activity-number\">");
#nullable restore
#line 46 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4f60542d4954ffab7c400affda899781cc3959e6965", async() => {
#nullable restore
#line 47 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                                                                                                                       Write(activity.User.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 47 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                                                                                                                                                Write(activity.User.LastName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                                                                                              WriteLiteral(activity.UserId);

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
#nullable restore
#line 48 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                   Write(activity.Activity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 49 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                   Write(activity.DeviceType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 50 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                   Write(activity.OperatingSystem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                     if (!string.IsNullOrEmpty(activity.Ip))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 53 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                       Write(activity.Ip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 54 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>-</td>\r\n");
#nullable restore
#line 58 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td dir=\"ltr\">");
#nullable restore
#line 59 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                             Write(Format.DateFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 59 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                                                                     Write(Format.TimeFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    \r\n");
#nullable restore
#line 61 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                     if (!string.IsNullOrEmpty(activity.AuthCookies))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td");
            BeginWriteAttribute("group-number", " group-number=\"", 2028, "\"", 2064, 1);
#nullable restore
#line 63 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
WriteAttributeValue("", 2043, activity.GroupNumber, 2043, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("full-auth", " full-auth=\"", 2065, "\"", 2098, 1);
#nullable restore
#line 63 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
WriteAttributeValue("", 2077, activity.AuthCookies, 2077, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"activity-device auth-cookies\" style=\"background-color: \">");
#nullable restore
#line 63 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                                                                                                                                                              Write(activity.AuthCookies);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 64 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>-</td>\r\n");
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                    \r\n                    \r\n\r\n                </tr>\r\n");
#nullable restore
#line 74 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
                i--;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 77 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\ActivitiesOverview.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AdminService Admin { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PaymentService Payment { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext Con { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserDevice>> Html { get; private set; }
    }
}
#pragma warning restore 1591
