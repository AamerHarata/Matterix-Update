#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9eba7b41226156eaae16d636311c1e4dec7b3aad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HomePartial__SideUpcomingInvoices), @"mvc.1.0.view", @"/Views/Home/HomePartial/_SideUpcomingInvoices.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eba7b41226156eaae16d636311c1e4dec7b3aad", @"/Views/Home/HomePartial/_SideUpcomingInvoices.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_HomePartial__SideUpcomingInvoices : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MatterixInvoice>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PartialViews/_InformationModals/_InvoiceInformation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-link text-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Invoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "History", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"collapse task-box\"  id=\"upcoming-invoices-task-box\">\r\n    <hr class=\"mt-0\"/>\r\n    <div class=\"text-0-6\">\r\n    \r\n");
#nullable restore
#line 8 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
         if (!Model.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"small text-center direction\">{{$t(\'message.noUnPaidInvoice\')}}</div>\r\n");
#nullable restore
#line 11 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
        }
        else
        {
        
            foreach (var invoice in Model)
            {
                var color = invoice.IsPostponed() ? "green" : "red";
                var overdueOrLate = !invoice.IsPostponed();
            

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card task-card invoice-btn\"");
            BeginWriteAttribute("invoiceNumber", " invoiceNumber=\"", 657, "\"", 688, 1);
#nullable restore
#line 20 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
WriteAttributeValue("", 673, invoice.Number, 673, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\"");
            BeginWriteAttribute("dueOrLate", " dueOrLate=\"", 703, "\"", 740, 1);
#nullable restore
#line 20 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
WriteAttributeValue("", 715, overdueOrLate.ToString(), 715, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"text-left\" style=\"font-weight: 600\">");
#nullable restore
#line 21 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
                                                               Write(invoice.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"direction matterix-color\">{{$tc(\'message.currency\', \'");
#nullable restore
#line 22 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
                                                                                Write(Format.NumberFormat(invoice.CurrentAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}</div>\r\n                    <div class=\"text-left\">Kidnummer: <span class=\"force-select\">");
#nullable restore
#line 23 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
                                                                            Write(invoice.CIDNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n                    <div class=\"direction\" style=\"color: gray\">{{$t(\'message.dueDate\')}}: ");
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
                                                                                     Write(Format.DateFormat(invoice.CurrentDueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span");
            BeginWriteAttribute("style", " style=\"", 1235, "\"", 1256, 2);
            WriteAttributeValue("", 1243, "color:", 1243, 6, true);
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
WriteAttributeValue(" ", 1249, color, 1250, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&nbsp;&nbsp;(");
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
                                                                                                                                                                         Write(Format.Translate(invoice.StatusString()));

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span></div>\r\n                </div>\r\n");
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9eba7b41226156eaae16d636311c1e4dec7b3aad9299", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 28 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = invoice;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
            
        
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"mb-2 text-0-6 text-secondary\">{{$t(\'message.invoicesCanBePaidToAccount\')}}: <span class=\"force-select\">");
#nullable restore
#line 35 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Home\HomePartial\_SideUpcomingInvoices.cshtml"
                                                                                                                  Write(StaticInformation.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n    <div class=\"mb-2 text-0-6\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9eba7b41226156eaae16d636311c1e4dec7b3aad11695", async() => {
                WriteLiteral("{{$t(\'message.invoicesAndReceipts\')}}");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MatterixInvoice>> Html { get; private set; }
    }
}
#pragma warning restore 1591
