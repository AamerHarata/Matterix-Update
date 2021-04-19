#pragma checksum "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7272bfa8c8f57ac87a78261b2cd424ee0c3f074"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserPageSections_Payments), @"mvc.1.0.view", @"/Views/Admin/UserPageSections/Payments.cshtml")]
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
#line 1 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7272bfa8c8f57ac87a78261b2cd424ee0c3f074", @"/Views/Admin/UserPageSections/Payments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserPageSections_Payments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MatterixPayment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<button class=""btn btn-danger"" id=""new-payment"" style=""margin-bottom: 1rem;"">New</button>

<table class=""table table-hover"" id=""admin-create-payment"" hidden=""hidden"">
    <tr>
        
        <td><input type=""number"" name=""invoiceNumber"" class=""form-control"" placeholder=""Invoice Number""/></td>
        <td><input type=""number"" name=""amount"" class=""form-control"" placeholder=""Amount""/></td>
        <td><span> ");
#nullable restore
#line 12 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
              Write(Html.DropDownList(" " ,
                       new SelectList(Enum.GetValues(typeof(EnumList.PaymentMethod))), "Pay method",
                       new {@class = "form-control", @id="create-payment-method"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        <td><span> ");
#nullable restore
#line 15 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
              Write(Html.DropDownList(" " ,
                       new SelectList(Enum.GetValues(typeof(EnumList.PaymentReason))), "Payment reason",
                       new {@class = "form-control", @id="create-payment-reason"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
        <td><input name=""description"" class=""form-control"" placeholder=""Description""/></td>
        <td><input type=""date"" class=""form-control"" name=""paymentDate""/> </td>
        <td><button class=""btn btn-success"" id=""admin-create-payment-btn"">Create</button></td>
        
    </tr>
    <tr>
        <td colspan=""5"" id=""add-payment-response""><br/></td>
        <td colspan=""3""></td>
        
    </tr>
</table>






");
#nullable restore
#line 35 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
 if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr/>\r\n        <div class=\"text-center\">No payments yet!</div>\r\n");
#nullable restore
#line 39 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-hover text-center"">
            <thead>
            <tr>
                <th>#</th>
                <th>Course</th>
                <th>Invoice</th>
                <th>Amount</th>
                <th>Date</th>
                <th>Reason</th>
                <th>Method</th>
                <th>Service ID</th>
                <th>Description</th>
                <th>Refund</th>
            </tr>
            </thead>
");
#nullable restore
#line 57 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
           var i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
         foreach (var payment in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("id", " id=\"", 2075, "\"", 2091, 1);
#nullable restore
#line 60 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
WriteAttributeValue("", 2080, payment.Id, 2080, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"payment-row\">\r\n                <td>");
#nullable restore
#line 61 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 62 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                 if (payment.Course != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 64 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                   Write(payment.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 64 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                                             Write(payment.Course.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 65 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>No course / No code</td>\r\n");
#nullable restore
#line 69 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 70 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
               Write(payment.InvoiceNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 71 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
               Write(Format.NumberFormat(payment.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 72 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
               Write(Format.DateFormat(payment.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 72 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                                                      Write(Format.TimeFormat(payment.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 73 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
               Write(payment.Reason);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 74 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
               Write(payment.Method);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"payment-service-id\">");
#nullable restore
#line 75 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                                          Write(payment.PaymentServiceRef);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                <td>");
#nullable restore
#line 77 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
               Write(payment.ExtraDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 78 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                 if (payment.Refunded)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 80 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                   Write(Format.DateFormat(payment.RefundedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 81 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"not-this\"><button class=\"btn btn-secondary admin-refund-payment\"");
            BeginWriteAttribute("payment-method", " payment-method=\"", 3181, "\"", 3224, 1);
#nullable restore
#line 84 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
WriteAttributeValue("", 3198, payment.Method.ToString(), 3198, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("amount", " amount=\"", 3225, "\"", 3249, 1);
#nullable restore
#line 84 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
WriteAttributeValue("", 3234, payment.Amount, 3234, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Refund</button></td>\r\n");
#nullable restore
#line 85 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 87 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
            i++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 90 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Admin\UserPageSections\Payments.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MatterixPayment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
