#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38fd7086890373f29cf0579c4d7b957b7baa3b21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment111_PaymentPartial__Header), @"mvc.1.0.view", @"/Views/Payment111/PaymentPartial/_Header.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38fd7086890373f29cf0579c4d7b957b7baa3b21", @"/Views/Payment111/PaymentPartial/_Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment111_PaymentPartial__Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.PaymentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Invoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"text-center un-select\">\r\n");
#nullable restore
#line 5 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
 switch (Model.Reason)
{
    
    case EnumList.PaymentReason.Register:
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"font-cairo matterix-color title-1-5 mb-2\">{{$t(\'message.youAreRegisteringInThisCourse\')}}</div>\r\n        <div><span class=\"display-4 title-1-0\"><a class=\"matterix-link\" target=\"_blank\"");
            BeginWriteAttribute("href", " href=\"", 406, "\"", 458, 1);
#nullable restore
#line 11 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
WriteAttributeValue("", 413, Url.Content("/Course/Area/"+Model.Course.Id), 413, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 11 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
                                                                                                                                        Write(Model.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 11 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
                                                                                                                                                                Write(Model.Course.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></span></div>\r\n");
#nullable restore
#line 12 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
        
        break;
    case EnumList.PaymentReason.Invoice:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"display-4 title-2-0\">{{$t(\'message.youAreNowPayingThisInvoice\')}}</div>\r\n        <br/>\r\n");
#nullable restore
#line 17 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
        //ToDo :: Redirect on click to view the invoice page

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div><span class=\"display-4 title-1-5\">{{$t(\'message.invoiceNumber\')}}: ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38fd7086890373f29cf0579c4d7b957b7baa3b216785", async() => {
#nullable restore
#line 18 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
                                                                                                                                                                                               Write(Model.InvoiceToPay.Number);

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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-invoiceNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
                                                                                                                                                            WriteLiteral(Model.InvoiceToPay.Number);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["invoiceNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-invoiceNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["invoiceNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span></div>\r\n");
#nullable restore
#line 19 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Payment111\PaymentPartial\_Header.cshtml"
    
        break;
    case EnumList.PaymentReason.Empty:
    case EnumList.PaymentReason.Donate:
    case EnumList.PaymentReason.Other:
    default:
        throw new ArgumentOutOfRangeException();
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
