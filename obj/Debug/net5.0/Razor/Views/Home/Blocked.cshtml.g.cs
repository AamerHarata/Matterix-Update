#pragma checksum "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c369a88af5bc780b1421bd0d8059a037ae9e7f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Blocked), @"mvc.1.0.view", @"/Views/Home/Blocked.cshtml")]
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
#line 1 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c369a88af5bc780b1421bd0d8059a037ae9e7f5", @"/Views/Home/Blocked.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Blocked : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.BlockedViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/ColoringDevices.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
  
    ViewBag.Title = "Blocked";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center un-select"">
    <div class=""display-4 title-2-0 direction text-center"">{{$t('message.thisAccountHasBeenBlocked')}}</div>
    <hr class=""matterix-background""/>
    
    <table class=""direction table table-success text-center"" style=""width: 60%; margin: auto; font-size: 0.9rem"">
        <tr>
            <th>{{$t('message.blockDate')}}</th>
            <th>{{$t('message.blockReason')}}</th>
            <th>{{$t('message.blockDescription')}}</th>
        </tr>
        <tr>
            <td dir=""ltr"">");
#nullable restore
#line 20 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                     Write(Format.DateFormat(Model.User.BlockDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 20 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                Write(Format.TimeFormat(Model.User.BlockDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
           Write(Format.Translate(Model.User.BlockType.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
           Write(Model.User.BlockDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
        </tr>
        <tr>
            <th colspan=""3"" style=""background-color: whitesmoke"">{{$t('message.youCanSolveThisContact')}}!</th>
        </tr>
    </table>
    <table class=""direction text-center table table-success"" style=""width: 40%; margin: auto"">
        <tr style=""background-color: whitesmoke"">
            <th>{{$t('message.email')}}</th>
            <th>{{$t('message.phoneNumber')}}</th>
        </tr>
        <tr style=""background-color: whitesmoke"">
            <td>");
#nullable restore
#line 34 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
           Write(Model.ContactEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td dir=\"ltr\">");
#nullable restore
#line 35 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                     Write(Model.ContactPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n    <br/>\r\n    \r\n    \r\n");
#nullable restore
#line 42 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
     if (Model.User.BlockType == EnumList.Block.SharedAccount)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""direction text-center un-select table table-striped direction"" style=""width: 100%;"">
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
#line 58 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
               var i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
             foreach (var activity in Model.Devices)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"activity-number\">");
#nullable restore
#line 62 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 63 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                   Write(Format.Translate(activity.Activity.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 64 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                   Write(Format.DateFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 64 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                           Write(Format.TimeFormat(activity.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 65 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                   Write(Format.Translate(activity.DeviceType.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 66 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                   Write(Format.Translate(activity.OperatingSystem.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 67 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                     if (string.IsNullOrEmpty(activity.Ip))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>-</td>\r\n");
#nullable restore
#line 70 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 73 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                       Write(activity.Ip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 74 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td");
            BeginWriteAttribute("group-number", " group-number=\"", 3170, "\"", 3206, 1);
#nullable restore
#line 75 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
WriteAttributeValue("", 3185, activity.GroupNumber, 3185, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"activity-device\" style=\"background-color: \">");
#nullable restore
#line 75 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                                                                 if(!string.IsNullOrEmpty(activity.AuthCookies)){

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                                                                                                            Write(activity.AuthCookies.Substring(6, 16));

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                                                                                                                                                       }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>-</span>");
#nullable restore
#line 75 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                                                                                                                                                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 76 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                     if (activity.New)
                    {
                        if (activity.GroupNumber == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-success\">{{$t(\'message.yourDevice\')}}</td>\r\n");
#nullable restore
#line 81 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-danger\">{{$t(\'message.newDevice\')}}: ");
#nullable restore
#line 84 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                            Write(activity.GroupNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 85 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
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
#line 93 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-danger\">{{$t(\'message.registeredInNumber\')}}: ");
#nullable restore
#line 96 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                                     Write(activity.GroupNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 97 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                        }
                        
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                </tr>
");
#nullable restore
#line 106 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                i++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 109 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
    }
    
    
    
    
    
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                            
    else if (Model.User.BlockType == EnumList.Block.FakeAccount || Model.User.BlockType == EnumList.Block.WrongInfo)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""direction text-center un-select table table-striped"" style=""width: 100%;"">
            <thead>
            <tr>
                <td colspan=""7"">{{$t('message.accordingToBlockReasonInformation')}}</td>
            </tr>
            <tr><td colspan=""7"">{{$t('message.noteNoBodyCanAccess')}}</td></tr>
            </thead>
            
            <thead>
            <tr>
                <th>{{$t('message.firstName')}}</th>
                <th>{{$t('message.lastName')}}</th>
                <th>{{$t('message.email')}}</th>
                <th>{{$t('message.phoneNumber')}}</th>
                <th colspan=""2"">{{$t('message.address')}}</th>
                <th>{{$t('message.registerDate')}}</th>
            </tr>
            </thead>
            <tr>
                <td>");
#nullable restore
#line 137 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
               Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 138 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
               Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 139 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
               Write(Model.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 140 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
               Write(Model.User.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td colspan=\"2\">");
#nullable restore
#line 141 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                           Write(Model.Address.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 141 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                  Write(Model.Address.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 141 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                         Write(Model.Address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td dir=\"ltr\">");
#nullable restore
#line 142 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                         Write(Format.DateFormat(Model.User.SignUpDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 142 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                     Write(Format.TimeFormat(Model.User.SignUpDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                \r\n            </tr>\r\n        </table>\r\n");
#nullable restore
#line 146 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
    }
    
    //INVOICE BLOCK
    else if(Model.User.BlockType == EnumList.Block.UnPaid)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""direction text-center un-select table table-striped"" style=""width: 100%;"">
            <thead>
            <tr>
                <td colspan=""7"">{{$t('message.accordingToBlockReasonInvoice')}}!</td>
            </tr>
            <tr><td colspan=""7"">{{$t('message.noteNoBodyCanAccess')}}</td></tr>
            
            
            </thead>
            
            <thead>
            <tr>
                <th style=""width: 2rem"">#</th>
                <th>{{$t('message.invoiceNumber')}}</th>
                <th>{{$t('message.cidNumber')}}</th>
                <th>{{$t('message.dueDate')}}</th>
                <th>{{$t('message.payDeadline')}}</th>
                <th>{{$t('message.courseName')}}</th>
                <th>{{$t('message.description')}}</th>
                <th>{{$t('message.amount')}}</th>
            </tr>
            </thead>
");
#nullable restore
#line 173 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
               var i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 174 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
             foreach (var invoice in Model.Invoices)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 177 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a target=\"_blank\">");
#nullable restore
#line 178 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                      Write(invoice.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td> ");
            WriteLiteral("\r\n                    <td><a target=\"_blank\">");
#nullable restore
#line 179 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                      Write(invoice.CIDNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td> ");
            WriteLiteral("\r\n                    <td dir=\"ltr\">");
#nullable restore
#line 180 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                             Write(Format.DateFormat(invoice.CurrentDueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 181 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                   Write(Format.DateFormat(invoice.CurrentDeadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 182 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                         if(invoice.Course.Subject!=null){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>");
#nullable restore
#line 182 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                           Write(invoice.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 182 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                                              }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>-</span>");
#nullable restore
#line 182 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                                                                                                  }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 183 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                   Write(invoice.ExtraDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>{{$tc(\'message.currency\', \'");
#nullable restore
#line 184 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                              Write(Format.NumberFormat(invoice.CurrentAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}</td>\r\n                </tr>\r\n");
#nullable restore
#line 186 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                i++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n            <tfoot>\r\n            <tr>\r\n                <th>{{$t(\'message.total\')}}</th>\r\n                <td colspan=\"6\"></td>\r\n                <th>{{$tc(\'message.currency\', \'");
#nullable restore
#line 193 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
                                          Write(Format.NumberFormat(@Model.TotalInvoices));

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}</th>\r\n            </tr>\r\n            <tr>\r\n                <td colspan=\"8\"></td>\r\n            </tr>\r\n            </tfoot>\r\n            \r\n        </table>\r\n");
#nullable restore
#line 201 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c369a88af5bc780b1421bd0d8059a037ae9e7f525410", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 222 "C:\Users\Joudy\Matterix-Update\Views\Home\Blocked.cshtml"
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
        public PaymentService Payment { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matterix.Models.ViewModel.BlockedViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
