<<<<<<< HEAD
#pragma checksum "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9460f6a129ca1bcfafcb365de8aa03223775001a"
=======
#pragma checksum "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9460f6a129ca1bcfafcb365de8aa03223775001a"
>>>>>>> origin/Myada_First
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_History), @"mvc.1.0.view", @"/Views/Invoice/History.cshtml")]
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
<<<<<<< HEAD
#line 1 "D:\GitFolders\Programming\C#\Update\Matterix\Views\_ViewImports.cshtml"
=======
#line 1 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
>>>>>>> origin/Myada_First
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 2 "D:\GitFolders\Programming\C#\Update\Matterix\Views\_ViewImports.cshtml"
=======
#line 2 "C:\Users\Joudy\Matterix-Update\Views\_ViewImports.cshtml"
>>>>>>> origin/Myada_First
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 2 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 2 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9460f6a129ca1bcfafcb365de8aa03223775001a", @"/Views/Invoice/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MatterixInvoice>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/Home/Invoice.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-link matterix-color"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Course", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CourseArea", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Invoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "InvoicePartial/_InvoiceInHistory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
<<<<<<< HEAD
#line 5 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 5 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
  
    ViewBag.Title = "History";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a6798", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a6728", async() => {
>>>>>>> origin/Myada_First
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
<<<<<<< HEAD
#line 9 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 9 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
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
            WriteLiteral(@"




<div class=""text-center un-select"">
    <p class=""display-4 title-1-5 matterix-color font-cairo""><strong>{{$t('message.invoicesAndReceipts')}}</strong></p>
    <hr class=""matterix-background"" style=""width: 95%""/>
</div>




    


<div class=""direction text-center un-select"">
");
            WriteLiteral("    <div class=\"invoice-type-bar title-1-5 font-cairo\">{{$t(\'message.paidInvoices\')}}</div>\r\n\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 30 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 30 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
       var paidInvoices = Model.Where(x => x.Paid).OrderBy(x => x.OriginalDueDate).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
<<<<<<< HEAD
#line 32 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 32 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
     if (!paidInvoices.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("       <p class=\"text-center direction un-select small text-secondary\">{{$t(\'message.noPaidInvoices\')}}</p>\r\n");
#nullable restore
<<<<<<< HEAD
#line 35 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 35 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
    }
    else
    {
        
        foreach (var paid in paidInvoices){
            var payment = Payment.GetActivePayment(paid.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""card invoice-body direction"">
                <table class=""table w-100"">
                    <tr>
                        <th style=""border-top: 0!important"">{{$t('message.courseName')}}:</th><td style=""border-top: 0!important"">");
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9460f6a129ca1bcfafcb365de8aa03223775001a10400", async() => {
#nullable restore
#line 44 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9460f6a129ca1bcfafcb365de8aa03223775001a10274", async() => {
#nullable restore
#line 44 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                                                                                                                                                                                                                                     Write(paid.Course.Subject);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-courseId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
<<<<<<< HEAD
#line 44 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 44 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                                                                                                                                                                                                              WriteLiteral(paid.CourseId);

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
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.invoiceNumber\')}}:</th><td>");
#nullable restore
<<<<<<< HEAD
#line 47 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 47 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                                Write(paid.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.reason\')}}:</th><td>");
#nullable restore
<<<<<<< HEAD
#line 50 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 50 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                         Write(Format.Translate(paid.Reason.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.payDate\')}}:</th><td>");
#nullable restore
<<<<<<< HEAD
#line 53 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 53 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                          Write(Format.DateFormat(payment.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.paymentMethod\')}}:</th><td>");
#nullable restore
<<<<<<< HEAD
#line 56 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 56 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                                Write(Format.Translate(payment.Method.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.amount\')}}:</th><td>{{$tc(\'message.currency0\',\'");
#nullable restore
<<<<<<< HEAD
#line 59 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 59 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                                                    Write(Format.NumberFormat(paid.CurrentAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\')}}</td>\r\n                    </tr>\r\n                </table>\r\n                \r\n\r\n                <div class=\"text-center buttons-in-modal-container set-my-direction mt-2\">\r\n                    ");
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9460f6a129ca1bcfafcb365de8aa03223775001a15926", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9460f6a129ca1bcfafcb365de8aa03223775001a15702", async() => {
>>>>>>> origin/Myada_First
                WriteLiteral("<span>{{$t(\'message.receipt\')}}</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-invoiceNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
<<<<<<< HEAD
#line 65 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 65 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
                                                                                                WriteLiteral(paid.Number);

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
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>    \r\n");
#nullable restore
<<<<<<< HEAD
#line 69 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 69 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
        }
            
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("    <div class=\"invoice-type-bar title-1-5 font-cairo\">{{$t(\'message.lateInvoices\')}}</div>\r\n");
#nullable restore
<<<<<<< HEAD
#line 79 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 79 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
       var lateInvoices = Model.Where(x => x.IsOriginallyLate()).OrderBy(x => x.OriginalDueDate).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
<<<<<<< HEAD
#line 81 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 81 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
     if (!lateInvoices.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"text-center direction small text-secondary\">{{$t(\'message.noLateInvoices\')}}</p>\r\n");
#nullable restore
<<<<<<< HEAD
#line 84 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 84 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
    }
    else
    {
        foreach (var late in lateInvoices)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a19827", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a19533", async() => {
>>>>>>> origin/Myada_First
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
#nullable restore
<<<<<<< HEAD
#line 89 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 89 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = late;

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
<<<<<<< HEAD
#line 90 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 90 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
        }

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n    \r\n");
            WriteLiteral("\r\n    <div class=\"invoice-type-bar title-1-5 font-cairo\">{{$t(\'message.overdueInvoices\')}}</div>\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 100 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 100 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
       var overdueInvoices = Model.Where(x => x.IsOriginallyOverdue()).OrderBy(x => x.OriginalDeadline).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
<<<<<<< HEAD
#line 102 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 102 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
     if (!overdueInvoices.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"text-center direction small text-secondary\">{{$t(\'message.noOverdueInvoices\')}}</p>\r\n");
#nullable restore
<<<<<<< HEAD
#line 105 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 105 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
    }
    else
    {
        
        foreach (var overdue in overdueInvoices)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a22692", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a22328", async() => {
>>>>>>> origin/Myada_First
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
#nullable restore
<<<<<<< HEAD
#line 111 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 111 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = overdue;

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
<<<<<<< HEAD
#line 112 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 112 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
        }
        
    
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n    \r\n    \r\n    \r\n");
#nullable restore
<<<<<<< HEAD
#line 121 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 121 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
       var postponed = Model.Where(x => x.IsPostponed()).OrderBy(x => x.OriginalDueDate).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"invoice-type-bar title-1-5 font-cairo\">{{$t(\'message.postponedInvoices\')}}</div>\r\n\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 125 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 125 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
     if (!postponed.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"text-center direction small text-secondary\">{{$t(\'message.noPostponedInvoices\')}}</p>\r\n");
#nullable restore
<<<<<<< HEAD
#line 128 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 128 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
    }
    else
    {
        
        foreach (var post in postponed)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a25527", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9460f6a129ca1bcfafcb365de8aa03223775001a25093", async() => {
>>>>>>> origin/Myada_First
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
#nullable restore
<<<<<<< HEAD
#line 134 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 134 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = post;

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
<<<<<<< HEAD
#line 135 "D:\GitFolders\Programming\C#\Update\Matterix\Views\Invoice\History.cshtml"
=======
#line 135 "C:\Users\Joudy\Matterix-Update\Views\Invoice\History.cshtml"
>>>>>>> origin/Myada_First
        }


    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n    \r\n\r\n\r\n</div>");
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
