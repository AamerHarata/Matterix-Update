#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b877013ed49052b3e3fd7952314b63f38e70a5b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserPageSections_Activities), @"mvc.1.0.view", @"/Views/Admin/UserPageSections/Activities.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b877013ed49052b3e3fd7952314b63f38e70a5b2", @"/Views/Admin/UserPageSections/Activities.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserPageSections_Activities : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserDevice>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr/>\r\n    <div class=\"text-center\">Ops! No Activities</div>\r\n");
#nullable restore
#line 8 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
    
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
                <th style=""width: 7rem"">Device</th>
                <th>Operating System</th>
                <th>IP Number</th>
                <th>Date and Time</th>
                <th>Activity</th>
                <th>Device Id</th>
                <th>Description</th>
                <th>Status</th>
                <th>Is New</th>
                <th>Group</th>
                <th >Apply</th>
                <th>Delete</th>
            </tr>
            </thead>
");
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
               var i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
             foreach (var activity in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"activity-number\">");
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                   Write(activity.DeviceType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                   Write(activity.OperatingSystem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 38 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                     if (!string.IsNullOrEmpty(activity.Ip))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                       Write(activity.Ip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 41 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>-</td>\r\n");
#nullable restore
#line 45 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td dir=\"ltr\">");
#nullable restore
#line 46 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                             Write(Format.DateFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 46 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                                                                     Write(Format.TimeFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 47 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                   Write(activity.Activity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 48 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                     if (!string.IsNullOrEmpty(activity.AuthCookies) && activity.AuthCookies.Length>23)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td");
            BeginWriteAttribute("group-number", " group-number=\"", 1698, "\"", 1734, 1);
#nullable restore
#line 50 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
WriteAttributeValue("", 1713, activity.GroupNumber, 1713, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("full-auth", " full-auth=\"", 1735, "\"", 1768, 1);
#nullable restore
#line 50 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
WriteAttributeValue("", 1747, activity.AuthCookies, 1747, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"activity-device auth-cookies\" style=\"background-color: \">");
#nullable restore
#line 50 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                                                                                                                                                              Write(activity.AuthCookies.Substring(6, 16));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>-</td>\r\n");
#nullable restore
#line 55 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 56 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                   Write(activity.Activity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    \r\n                    \r\n                    \r\n");
#nullable restore
#line 61 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                     if (activity.New)
                    {
                        if (activity.GroupNumber == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-success\">{{$t(\'message.yourDevice\')}}</td>\r\n");
#nullable restore
#line 66 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-danger\">{{$t(\'message.newDevice\')}}: ");
#nullable restore
#line 69 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                                                                            Write(activity.GroupNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 70 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                        }
                    }
                    else
                    {
                        
                        if (activity.GroupNumber == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-success\">{{$t(\'message.yourIdAuth\')}}</td>\r\n");
#nullable restore
#line 78 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-danger\">{{$t(\'message.registeredInNumber\')}}: ");
#nullable restore
#line 81 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                                                                                     Write(activity.GroupNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 82 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                        }
                        
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                    \r\n                    <td><input class=\"is-new-device\" type=\"checkbox\"");
            BeginWriteAttribute("checked", " checked=\"", 3295, "\"", 3318, 1);
#nullable restore
#line 87 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
WriteAttributeValue("", 3305, activity.New, 3305, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/></td>\r\n                    <td><input class=\"form-control w-25 m-auto device-group-number\" type=\"number\"");
            BeginWriteAttribute("value", " value=\"", 3425, "\"", 3454, 1);
#nullable restore
#line 88 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
WriteAttributeValue("", 3433, activity.GroupNumber, 3433, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/></td>\r\n                    <td><button class=\"btn btn-dark modify-device\"");
            BeginWriteAttribute("device-id", " device-id=\"", 3530, "\"", 3554, 1);
#nullable restore
#line 89 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
WriteAttributeValue("", 3542, activity.Id, 3542, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Ok</button></td>\r\n                    <td><button class=\"btn btn-danger delete-device\"");
            BeginWriteAttribute("device-id", " device-id=\"", 3642, "\"", 3666, 1);
#nullable restore
#line 90 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
WriteAttributeValue("", 3654, activity.Id, 3654, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">delete</button></td>\r\n                </tr>\r\n");
#nullable restore
#line 92 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
                i++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 95 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Admin\UserPageSections\Activities.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserDevice>> Html { get; private set; }
    }
}
#pragma warning restore 1591
