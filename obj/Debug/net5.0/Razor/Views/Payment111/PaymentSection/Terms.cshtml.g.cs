#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd67fbd1a74c5054003858cd78de24893fee70bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment111_PaymentSection_Terms), @"mvc.1.0.view", @"/Views/Payment111/PaymentSection/Terms.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd67fbd1a74c5054003858cd78de24893fee70bf", @"/Views/Payment111/PaymentSection/Terms.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment111_PaymentSection_Terms : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.PaymentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Payment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-reason", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
 switch (Model.Reason)
{
    
    case EnumList.PaymentReason.Register:
        if (Model.Course.Ended)
        {
            if (!string.IsNullOrEmpty(ViewBag.AltCourse))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"text-danger text-center direction un-select\">{{$t(\'message.altCourseExists\')}} ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd67fbd1a74c5054003858cd78de24893fee70bf4777", async() => {
#nullable restore
#line 12 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                                                                                                                                                                                                                         Write(Model.Course.Subject);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-courseId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                                                                                                                                                                  WriteLiteral(ViewBag.AltCourse);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-courseId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-reason", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["reason"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                <br/>\r\n");
#nullable restore
#line 14 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
            }
            
        }
    
    

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-center display-4 title-1-5\">{{$t(\'message.termsConditions\')}}</div>\r\n        <br/>\r\n");
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-sm-3""></div>
            <div class=""col-sm-6"">
                <table class=""table table-active text-center direction w-100 m-auto"">
            

                    <tr><td>{{$t('message.courseValidOneYear')}}</td></tr>
                    <tr>
                
                        <td>
                            {{$t('message.thisRegistrationExpiresAt')}}
");
#nullable restore
#line 33 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                             if (DateTime.Now > Model.Course.StartDate)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>");
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                                 Write(Format.DateFormat(DateTime.Now.AddYears(1)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 36 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>");
#nullable restore
#line 39 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                                 Write(Format.DateFormat(Model.Course.StartDate.AddYears(1)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n            \r\n");
#nullable restore
#line 44 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                     if (!Model.Course.Ended)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr><td>{{$t(\'message.onceYouAreDoneYouGetInstruction\')}}</td></tr>\r\n");
#nullable restore
#line 47 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            
            
                    <tr><td>{{$t('message.rightsOfFilesAndVideos')}}</td></tr>
                    <tr><td>{{$t('message.ifYouNoticeMistake')}}</td></tr>
                    <tr><td>{{$t('message.thisProcessIsDoneBy')}}. {{$t('message.thisProcedureCauseExpenses')}}</td></tr>
                    <tr>
                        <td id=""user-device"">
                            {{$t('message.youAreNowRegisteringFrom')}}: <span id=""device-type""></span>, {{$t('message.withAnOperatingSystem')}}: <span id=""operating-system""></span>, {{$t('message.hasTheIpNumber')}}: <span id=""ip-number""></span>
                        </td>
                    </tr>
                    <tr id=""terms-row""><td><input id=""terms-btn"" type=""radio""/>&nbsp; {{$t('message.iAcceptThe')}} <a target=""_blank""");
            BeginWriteAttribute("href", " href=\"", 2651, "\"", 2688, 1);
#nullable restore
#line 58 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
WriteAttributeValue("", 2658, Url.Action("Privacy", "Home"), 2658, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">{{$t('message.termsConditions')}}</a></td></tr>
                    <tfoot>
                    <tr><td><a class=""m-button m-button-success payment-next-section"" current-section=""terms"" next-section=""personal-info"">{{$t('message.next')}}</a></td></tr>
                    </tfoot>
                </table>
            </div>
            
            <div class=""col-sm-3""></div>

        </div>
");
#nullable restore
#line 68 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
        
        break;
        
        
        
        
        
        
        
        
    case EnumList.PaymentReason.Invoice:

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""text-center display-4 title-1-5"">{{$t('message.termsConditions')}}</div>
        <br/>
        <div class=""row"">
            <div class=""col-sm-3""></div>
            <div class=""col-sm-6"">
                <table class=""table table-active text-center direction w-100 m-auto"">

                    <tr><td>{{$t('message.delayInPaying')}}</td></tr>
                    <tr><td>{{$t('message.ifYouNoticeMistakeInInvoice')}}</td></tr>
                    <tr><td>{{$t('message.ifYouNoticeMistake')}}</td></tr>
                    <tr>
                        <td id=""user-device"">
                            {{$t('message.youAreNowPayingFrom')}}: <span id=""device-type""></span>, {{$t('message.withAnOperatingSystem')}}: <span id=""operating-system""></span>, {{$t('message.hasTheIpNumber')}}: <span id=""ip-number""></span>
                        </td>
                    </tr>
                    <tr id=""terms-row""><td><input id=""terms-btn"" type=""radio""/>&nbsp; {{$t('message.iAcceptThe')}} <a");
            WriteLiteral(" target=\"_blank\"");
            BeginWriteAttribute("href", " href=\"", 4283, "\"", 4320, 1);
#nullable restore
#line 94 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
WriteAttributeValue("", 4290, Url.Action("Privacy", "Home"), 4290, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">{{$t('message.termsConditions')}}</a></td></tr>
                    <tfoot>
                    <tr><td><button class=""btn btn-success payment-next-section"" current-section=""terms"" next-section=""personal-info"">{{$t('message.next')}}</button></td></tr>
                    </tfoot>
                </table>
            </div>
            <div class=""col-sm-3""></div>
        </div>
");
#nullable restore
#line 102 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentSection\Terms.cshtml"
        break;
    case EnumList.PaymentReason.Donate:
    case EnumList.PaymentReason.Empty:
    case EnumList.PaymentReason.Other:
    default:
        throw new ArgumentOutOfRangeException();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matterix.Models.ViewModel.PaymentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
