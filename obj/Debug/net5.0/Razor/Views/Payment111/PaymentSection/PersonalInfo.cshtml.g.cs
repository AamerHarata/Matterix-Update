#pragma checksum "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2da9a90b6122bb0c9b38c0f831762903d19cb7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment111_PaymentSection_PersonalInfo), @"mvc.1.0.view", @"/Views/Payment111/PaymentSection/PersonalInfo.cshtml")]
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
#line 1 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2da9a90b6122bb0c9b38c0f831762903d19cb7e", @"/Views/Payment111/PaymentSection/PersonalInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment111_PaymentSection_PersonalInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matterix.Models.ViewModel.PaymentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
 switch (Model.Reason)
{
    case EnumList.PaymentReason.Empty:
        break;
    case EnumList.PaymentReason.Register:
    case EnumList.PaymentReason.Invoice:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-center display-4 title-1-5\">{{$t(\'message.personalInfo\')}}</div>\r\n        <br/>\r\n");
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-sm-3""></div>
            <div class=""col-sm-6"">
                <table class=""table table-hover text-center direction w-100 m-auto"">
                    <tr>
                        <th>{{$t('message.yourName')}}</th>
                        <td>");
#nullable restore
#line 19 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
                       Write(Model.Student.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 19 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
                                                Write(Model.Student.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.phoneNumber\')}}</th>\r\n                        <td>");
#nullable restore
#line 23 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
                       Write(Model.Student.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.email\')}}</th>\r\n                        <td>");
#nullable restore
#line 27 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
                       Write(Model.Student.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>{{$t(\'message.address\')}}</th>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
                       Write(Model.Address.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 31 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
                                              Write(Model.Address.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 31 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"
                                                                     Write(Model.Address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                    </tr>
    
                    <tfoot>
    
                    <tr>
                        <th colspan=""2"">
                            <a class=""m-button m-button-danger payment-next-section"" current-section=""personal-info"" next-section=""terms"">{{$t('message.back')}}</a>
                            <a class=""m-button m-button-success payment-next-section"" current-section=""personal-info"" next-section=""product-info"">{{$t('message.next')}}</a>
                        </th>    
                    </tr>
            

                    </tfoot>
    
                </table>
            </div>
            <div class=""col-sm-3""></div>
        </div>
");
#nullable restore
#line 50 "C:\Users\ARAGON\Desktop\Matterix-Update\Views\Payment111\PaymentSection\PersonalInfo.cshtml"


        break;
    case EnumList.PaymentReason.Donate:
        break;
    case EnumList.PaymentReason.Other:
        break;
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
