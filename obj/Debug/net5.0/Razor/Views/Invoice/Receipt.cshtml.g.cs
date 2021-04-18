#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30858947985b4d66a1cf51fff0c763068ba71b2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Receipt), @"mvc.1.0.view", @"/Views/Invoice/Receipt.cshtml")]
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
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30858947985b4d66a1cf51fff0c763068ba71b2b", @"/Views/Invoice/Receipt.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_Receipt : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.InvoiceViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Invoice.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/LogoHomePage.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("m-button m-button-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DownloadInvoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 5 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
  
    ViewBag.Title = $"Receipt {Model.Invoice.Number}";
    Layout = "_Layout";
    var payment = PaymentService.GetActivePayment(Model.Invoice.Number);
    var paymentMethod = payment.Method == EnumList.PaymentMethod.BankCID ? "Bankoverføring med kidnummer" :
        payment.Method == EnumList.PaymentMethod.Stripe ? "Bankkort" :
            payment.Method == EnumList.PaymentMethod.Admin || payment.Method == EnumList.PaymentMethod.Other ? "Direkte betaling til vår administrasjon" :
                payment.Method == EnumList.PaymentMethod.Vipps ? "Vipps" : "Annet";
            
    var paymentRef = payment.Id.Split("-").Any()? payment.Id.Split("-")[0] : "00000000";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "30858947985b4d66a1cf51fff0c763068ba71b2b6348", async() => {
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
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-3 text-center\">\r\n        <table class=\"text-center\" style=\"width: 60%; margin: auto\">\r\n            <tr>\r\n                <td colspan=\"2\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "30858947985b4d66a1cf51fff0c763068ba71b2b7660", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr><td colspan=\"2\"><h5>");
#nullable restore
#line 26 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                               Write(StaticInformation.SecondName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></td></tr>\r\n            <tr class=\"small\"><td colspan=\"2\">Nettskole</td></tr>\r\n            <tr><td colspan=\"2\">");
#nullable restore
#line 28 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                           Write(StaticInformation.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td><td></td></tr>\r\n            <tr><td colspan=\"2\">Org. nr: ");
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                    Write(StaticInformation.OrgNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n            <tr><td colspan=\"2\">");
#nullable restore
#line 30 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                           Write(StaticInformation.Website);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n        </table>\r\n    </div>\r\n    <div class=\"col-4\">\r\n        \r\n    </div>\r\n    \r\n    <div class=\"col-5\">\r\n        <table");
            BeginWriteAttribute("class", " class=\"", 1651, "\"", 1659, 0);
            EndWriteAttribute();
            WriteLiteral("style=\"width: 50%\">\r\n            <tr");
            BeginWriteAttribute("class", " class=\"", 1696, "\"", 1704, 0);
            EndWriteAttribute();
            WriteLiteral("><th colspan=\"2\" class=\"display-4\">Kvittering</th></tr>\r\n            <tr><td>&nbsp;</td></tr>\r\n            <tr><th>KundeId:</th><td>");
#nullable restore
#line 41 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                Write(Model.User.Id.Split("-")[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n            <tr><th>Fakturanr:</th><td>");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                  Write(Model.Invoice.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n        </table>\r\n    </div>\r\n</div>\r\n<br/>\r\n<br/>\r\n<br/>\r\n<div class=\"row\">\r\n    <div class=\"col-1\"></div>\r\n    <div class=\"col-8\">\r\n        <div class=\"display-4 title-2-5\">");
#nullable restore
#line 52 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                    Write(Info.AdminFullName(Model.User).ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div class=\"display-4 title-1-5\">");
#nullable restore
#line 53 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                    Write(Model.Address.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div class=\"display-4 title-1-5\">");
#nullable restore
#line 54 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                    Write(Model.Address.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 54 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                                           Write(Model.Address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <hr style=\"width: 50%;margin-left: 0\" class=\"text-left\"/>\r\n        \r\n        <div style=\"display: flex\">\r\n            <div class=\"display-4 title-1-5\"><strong>Bekreftelse på at du har betalt denne fakturaen på: ");
#nullable restore
#line 58 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                                                                                    Write(Format.NumberFormat(Model.FullAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral(",- kr</strong></div>  \r\n            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30858947985b4d66a1cf51fff0c763068ba71b2b13315", async() => {
                WriteLiteral("{{$t(\'message.download\')}}");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-invoiceNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                                                                           WriteLiteral(Model.Invoice.Number);

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
            WriteLiteral(@"
        </div>
        <hr style=""width: 50%;margin-left: 0"" class=""text-left""/>
    </div>

</div>
<br/>
<br/>
<div class=""row"">
    <div class=""col-1""></div>
    <div class=""col-10 text-center"">
        <div class=""font-cairo title-1-5""><strong>Kvittering Beskrivelse</strong></div>
        <hr class=""matterix-background""/>
        <br/>
        
        
");
#nullable restore
#line 76 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
              if(!string.IsNullOrEmpty(Model.Course.Id)){

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                 <div class=""title-1-0 mb-2""><strong>Kurs opplysninger</strong></div>
                 <table class=""table table-striped small"" style=""width: 100%; margin: auto"">
                     <thead>
                     <tr>
                         <th>Kursnavn</th>
                         <th>Kurskode</th>
                         <th>Påmeldingsdato</th>
                         <th>Gyldig til</th>
                         <th>Kurspris</th>
                         <th>Betalt så langt</th>
                         
                     </tr>
                     </thead>
             
                     <tr>
                     
                         <td>");
#nullable restore
#line 93 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                        Write(Model.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                         <td>");
#nullable restore
#line 94 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                        Write(Model.Course.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 95 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                          if (Model.Registration != null)
                         {

#line default
#line hidden
#nullable disable
            WriteLiteral("                             <td>");
#nullable restore
#line 97 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                            Write(Format.DateFormat(Model.Registration.RegisterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                             <td>");
#nullable restore
#line 98 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                            Write(Format.DateFormat(Model.Registration.ExpireDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                             <td>");
#nullable restore
#line 99 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                            Write(Format.NumberFormat(Model.Registration.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(",- kr.</td>\r\n");
#nullable restore
#line 100 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                         }
                         else
                         {

#line default
#line hidden
#nullable disable
            WriteLiteral("                             <td>-</td>\r\n                             <td>-</td>\r\n                             <td>-</td>\r\n");
#nullable restore
#line 106 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("                         <td>");
#nullable restore
#line 107 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                        Write(Format.NumberFormat(Model.Payments));

#line default
#line hidden
#nullable disable
            WriteLiteral(",- kr</td>\r\n                         \r\n                     </tr>\r\n            \r\n                 </table>\r\n                 <hr/>\r\n                 <br/>\r\n");
#nullable restore
#line 114 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
             }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""title-1-0 mb-2""><strong>Faktura opplysninger</strong></div>
        <table class=""table table-striped small"" style=""width: 100%; margin: auto"">
            <thead>
            <tr>
                <th>#</th>
                <th>Krav</th>
                <th>Bekrivelse</th>
                <th>Dato opprettet</th>
                <th>(Ny) Betalingsfrist</th>
                <th>Beløp</th>
            </tr>
            </thead>
             
            <tr>
                     
                <td>1</td>
                <td>Faktura - ");
#nullable restore
#line 131 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                         Write(Model.Invoice.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                \r\n                \r\n");
#nullable restore
#line 134 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                 if (string.IsNullOrEmpty(Model.Invoice.ExtraDescription))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>-</td>\r\n");
#nullable restore
#line 137 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 140 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                   Write(Model.Invoice.ExtraDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 141 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 142 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
               Write(Format.DateFormat(Model.Invoice.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 143 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
               Write(Format.DateFormat(Model.Invoice.OriginalDeadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 144 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
               Write(Format.NumberFormat(Model.Invoice.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral(",- kr</td>\r\n            </tr>\r\n            \r\n");
#nullable restore
#line 147 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
               var i = 2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 148 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
             foreach (var increment in Model.Increments)
            {
                var claim = "";
                var explanation = "";
                
                
                 switch (increment.Reason)
                {
                    case EnumList.IncrementReason.Latency:
                        if (increment.Type == EnumList.IncrementType.Fixed)
                        {
                            if (increment.InvoicePhase == EnumList.InvoiceType.Purring)
                            {
                                claim = "Purregebyr";
                                explanation = "Purring sent etter forsinkelsen";
                            }else if (increment.InvoicePhase == EnumList.InvoiceType.Inkassovarsel)
                            {
                                claim = "Inkassovarsel / Siste frist";
                                explanation = "Utsettelse på 15 nye dager som siste frist";
                            }
                            else if (increment.InvoicePhase == EnumList.InvoiceType.Inkasso)
                            {
                                claim = "Inkasso";
                                explanation = "Fakturaen har blitt sent til inkasso";
                            }
                            else
                            {
                                claim = "Gebyr";
                                explanation = "Forsinkelse gebyr";
                            }
                        }else
                        {
                            claim = "Inkassovarsel / Rente";
                            explanation = "Inkassovarsel / Forsinkelse rente på 8.5%";
                        }
                            
                        
                        break;
                    case EnumList.IncrementReason.Discount:
                        break;
                    case EnumList.IncrementReason.PaperInvoice:
                        claim = "Varsel på papir";
                        explanation = "Faktura sent via posten etter forsinkelsen";
                        break;
                    case EnumList.IncrementReason.Delay:
                        claim = "Utsettelse";
                        explanation = $"Betaling utsettet for {increment.Delay} dager";
                        break;
                    default:
                        break;
                }
                
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 202 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 203 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                   Write(claim);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 204 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                   Write(explanation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 205 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                   Write(Format.DateFormat(increment.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 206 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                   Write(Format.DateFormat(increment.NewDeadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 207 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                   Write(Format.NumberFormat(increment.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral(",- kr</td>\r\n                </tr>\r\n");
#nullable restore
#line 209 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                
                
                

                i++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("             \r\n            \r\n            <tfoot>\r\n            <tr>\r\n                <th colspan=\"1\">Total</th>\r\n                <th colspan=\"4\"></th>\r\n                <th>");
#nullable restore
#line 221 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
               Write(Format.NumberFormat(Model.FullAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral(@",- kr</th>    
            </tr>
            </tfoot>
            
        </table>
        
        
        
        
        <hr/>
    </div>
    <div class=""col-1""></div>
</div>

<br/><br/>
<div class=""row"">
    <div class=""col-1""></div>
    <div class=""col-4"">
        <table style=""width: 100%; font-size: 1rem;"">
            <tr><th>Betalingsdato:</th><td>");
#nullable restore
#line 240 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                      Write(Format.DateFormat(payment.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n            <tr><th>Betalingsmetode:</th><td>");
#nullable restore
#line 241 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                        Write(paymentMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n            <tr><th>Betalingsreferanse:</th><td>");
#nullable restore
#line 242 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                           Write(paymentRef);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n            <tr><th>Beløp:</th><td>");
#nullable restore
#line 243 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                              Write(payment.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", kr</td></tr>
        </table>
    </div>
</div>
<br/>

<div class=""row"">
    <div class=""col-1""></div>
    <div class=""col-11"">
        <p><div style=""color:red;"">Studentrabatt er inkludert. Derfor kan beløpet ikke betales eller refunderes av private eller offentlige organisasjoner (som NAV, kommuner, introduksjonssentere ... osv). Les mer om dette på www.matterix.no/plus</div></p>
    </div>
</div>

<br/>
<br/>


<div class=""row"">
    <div class=""col-12"">
        <hr/>
        <table style=""width: 100%; margin: auto;"" class=""small text-center"">
            <tr>
                <td>");
#nullable restore
#line 265 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
               Write(StaticInformation.SecondName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 265 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                                               Write(StaticInformation.FirstName.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral(" / Online Live Education</td>\r\n                <td >Org. Nr. ");
#nullable restore
#line 266 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                         Write(StaticInformation.OrgNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>Telefon: ");
#nullable restore
#line 267 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                        Write(StaticInformation.ContactNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>E-post: ");
#nullable restore
#line 268 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Invoice\Receipt.cshtml"
                       Write(StaticInformation.ContactEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("            </tr>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PaymentService PaymentService { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matterix.Models.ViewModel.InvoiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
