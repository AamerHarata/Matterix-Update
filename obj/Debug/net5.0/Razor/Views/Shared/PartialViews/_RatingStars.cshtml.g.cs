#pragma checksum "C:\Users\Joudy\Matterix-Update\Views\Shared\PartialViews\_RatingStars.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab4a54a4069dfdada860b8b3891ebd12645259cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PartialViews__RatingStars), @"mvc.1.0.view", @"/Views/Shared/PartialViews/_RatingStars.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab4a54a4069dfdada860b8b3891ebd12645259cc", @"/Views/Shared/PartialViews/_RatingStars.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PartialViews__RatingStars : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""stars-container rating-stars star-pointer un-select"">
    <ul class=""stars"">
        <li class=""star"" data-toggle=""tooltip"" data-placement=""top"" v-bind:title=""$t('message.poor')"" data-value=""1"">
            <i class=""fa fa-star fa-fw""></i>
        </li>
        <li class=""star"" data-toggle=""tooltip"" data-placement=""top"" v-bind:title=""$t('message.fair')"" data-value=""2"">
            <i class=""fa fa-star fa-fw""></i>
        </li>
        <li class=""star"" data-toggle=""tooltip"" data-placement=""top"" v-bind:title=""$t('message.good')"" data-value=""3"">
            <i class=""fa fa-star fa-fw""></i>
        </li>
        <li class=""star"" data-toggle=""tooltip"" data-placement=""top"" v-bind:title=""$t('message.excellent')"" data-value=""4"">
            <i class=""fa fa-star fa-fw""></i>
        </li>
        <li class=""star"" data-toggle=""tooltip"" data-placement=""top"" v-bind:title=""$t('message.wow')"" data-value=""5"">
            <i class=""fa fa-star fa-fw""></i>
        </li>
    </ul>
</div>");
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
