#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Shared\_CookieConsentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcfef9e68d89897f47d9806b0cb3977c2322f68d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CookieConsentPartial), @"mvc.1.0.view", @"/Views/Shared/_CookieConsentPartial.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Shared\_CookieConsentPartial.cshtml"
using Microsoft.AspNetCore.Http.Features;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcfef9e68d89897f47d9806b0cb3977c2322f68d", @"/Views/Shared/_CookieConsentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CookieConsentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Privacy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Shared\_CookieConsentPartial.cshtml"
  
    var consentFeature = Context.Features.Get<ITrackingConsentFeature>();
    var showBanner = !consentFeature?.CanTrack ?? false;
    var cookieString = consentFeature?.CreateConsentCookie();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Shared\_CookieConsentPartial.cshtml"
 if (showBanner)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"cookieConsent\" class=\"alert alert-info alert-dismissible fade show un-select text-center\" role=\"alert\">\r\n        {{$t(\'message.thisWebsiteUses\')}}&nbsp;");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcfef9e68d89897f47d9806b0cb3977c2322f68d4719", async() => {
                WriteLiteral("{{$t(\'message.termsConditions\')}}");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <button type=\"button\" class=\"accept-policy close\" data-dismiss=\"alert\" aria-label=\"Close\" data-cookie-string=\"");
#nullable restore
#line 13 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Shared\_CookieConsentPartial.cshtml"
                                                                                                                 Write(cookieString);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <span aria-hidden=\"true\">{{$t(\'message.iAccept\')}}</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 17 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Shared\_CookieConsentPartial.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
