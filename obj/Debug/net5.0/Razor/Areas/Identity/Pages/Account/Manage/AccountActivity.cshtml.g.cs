#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01cb7cb96837fae0548c279fc0fc84c99970853f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Matterix.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage_AccountActivity), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/AccountActivity.cshtml")]
namespace Matterix.Areas.Identity.Pages.Account.Manage
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\_ViewImports.cshtml"
using Matterix.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Matterix.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using Matterix.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01cb7cb96837fae0548c279fc0fc84c99970853f", @"/Areas/Identity/Pages/Account/Manage/AccountActivity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae2f75a91ae49f9a44ea220e664cc9dd8b237f5f", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59d39737caedec9adeab6305dc4decbc6f1d3b4e", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b121ba2129b18994dc77adce8f08805bd08a711", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_AccountActivity : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ColoringDevices.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
  
    ViewData["Title"] = "Login Activity";
    ViewData["ActivePage"] = ManageNavPages.AccountActivity;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12"">
        <div class=""Matterix-color display-4 title-2-0"">{{$t('message.activities')}}</div>
        <hr class=""Matterix-background""/>
        
        <table class=""direction text-center un-select table table-success"" style=""background-color: "">
            <tr>
                <td colspan=""4"">{{$t('message.AAp1')}} <a");
            BeginWriteAttribute("href", " href=\"", 570, "\"", 607, 1);
#nullable restore
#line 18 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
WriteAttributeValue("", 577, Url.Action("Privacy", "Home"), 577, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" target=""_blank"">{{$t('message.termsConditions')}}</a> {{$t('message.AAp2')}}</td>
            </tr>
            <tr>
                <td colspan=""4"">{{$t('message.AAp3')}}</td>
            </tr>
            <tr >
                
                
                <td style=""width: 30%""></td>
");
#nullable restore
#line 27 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                   var differentDevices = Admin.DifferentDevices(Model.Input.userId);

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                 if (differentDevices >=2)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"width: 20%; background-color: tomato\">{{$t(\'message.differentDevices\')}}</td>\r\n                    <td style=\"width: 20%; background-color: tomato\">");
#nullable restore
#line 31 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                Write(differentDevices);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 32 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"width: 20%;\">{{$t(\'message.differentDevices\')}}</td>\r\n                    <td style=\"width: 20%;\">");
#nullable restore
#line 36 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                       Write(differentDevices);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 37 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <td style=""width: 30%""></td>
                
                
                
            </tr>
        </table>
        
        
        <table class=""direction text-center un-select table table-striped direction"" style=""width: 100%;"">
            <thead>
            <tr>
                <th style=""width: 2rem"">#</th>
                <th>{{$t('message.activity')}}</th>
                <th>{{$t('message.dateAndTime')}}</th>
                <th style=""width: 7rem"">{{$t('message.device')}}</th>
                <th>{{$t('message.operatingSystem')}}</th>
                <th>{{$t('message.ipNumber')}}</th>
                <th>{{$t('message.deviceId')}}</th>
                <th>{{$t('message.status')}}</th>
");
            WriteLiteral("            </tr>\r\n            </thead>\r\n");
#nullable restore
#line 60 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
               var i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
             foreach (var activity in Model.Input.Devices)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"activity-number\">");
#nullable restore
#line 64 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 65 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                   Write(Format.Translate(activity.Activity.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 66 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                   Write(Format.DateFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 66 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                           Write(Format.DateFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 67 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                   Write(Format.Translate(activity.DeviceType.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                   Write(Format.Translate(activity.OperatingSystem.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 69 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                     if (string.IsNullOrEmpty(activity.Ip))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>-</td>\r\n");
#nullable restore
#line 72 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 75 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                       Write(activity.Ip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 76 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td");
            BeginWriteAttribute("group-number", " group-number=\"", 3166, "\"", 3202, 1);
#nullable restore
#line 77 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
WriteAttributeValue("", 3181, activity.GroupNumber, 3181, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"activity-device\" style=\"background-color: \">");
#nullable restore
#line 77 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                                                                 if(!string.IsNullOrEmpty(activity.AuthCookies)&& activity.AuthCookies.Length>23){

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                                                                                                                                             Write(activity.AuthCookies.Substring(6, 16));

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                                                                                                                                                                                        }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>-</span>");
#nullable restore
#line 77 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                                                                                                                                                                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 78 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                     if (activity.New)
                    {
                        if (activity.GroupNumber == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-success\">{{$t(\'message.yourDevice\')}}</td>\r\n");
#nullable restore
#line 83 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-danger\">{{$t(\'message.newDevice\')}}: ");
#nullable restore
#line 86 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                            Write(activity.GroupNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 87 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
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
#line 95 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-danger\">{{$t(\'message.registeredInNumber\')}}: ");
#nullable restore
#line 98 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                                     Write(activity.GroupNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 99 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                        }
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                                                                                        
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                </tr>
");
#nullable restore
#line 109 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\AccountActivity.cshtml"
                i++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n        \r\n        \r\n        \r\n    </div>\r\n    \r\n    <div class=\"col-md-1\"></div>\r\n    \r\n        \r\n        \r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01cb7cb96837fae0548c279fc0fc84c99970853f19171", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
        public AdminService Admin { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccountActivity> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccountActivity> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccountActivity>)PageContext?.ViewData;
        public AccountActivity Model => ViewData.Model;
    }
}
#pragma warning restore 1591
