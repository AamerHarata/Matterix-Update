#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "389fb53f0d1cec0c037daee56f45f8e75604860d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Matterix.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage_ProfilePicture), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/ProfilePicture.cshtml")]
namespace Matterix.Areas.Identity.Pages.Account.Manage
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\_ViewImports.cshtml"
using Matterix.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\_ViewImports.cshtml"
using Matterix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Matterix.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using Matterix.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{handler?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"389fb53f0d1cec0c037daee56f45f8e75604860d", @"/Areas/Identity/Pages/Account/Manage/ProfilePicture.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae2f75a91ae49f9a44ea220e664cc9dd8b237f5f", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59d39737caedec9adeab6305dc4decbc6f1d3b4e", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b121ba2129b18994dc77adce8f08805bd08a711", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_ProfilePicture : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/IdentityArea/UploadPicture.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml"
  
    ViewData["Title"] = "Profile Picture";
    ViewData["ActivePage"] = ManageNavPages.ProfilePicture;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml"
  
    var picturePath = Info.ProfilePicture(User);
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row un-select\">\r\n    <div class=\"col-md-4\">\r\n        <div class=\"display-4 title-2-0\">{{$t(\'message.profilePicture\')}}</div>\r\n        <hr/>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "389fb53f0d1cec0c037daee56f45f8e75604860d7062", async() => {
                WriteLiteral(@"
            <input hidden=""hidden"" class=""btn btn-dark"" id=""file-input"" type=""file"" name=""PictureFile""/>
            <button class=""btn btn-secondary"" id=""choose-picture-btn"" type=""button"">{{$t('message.chooseFile')}}</button>
            
            <button disabled=""disabled"" class=""btn btn-light"" id=""upload-picture-btn"" type=""submit"">{{$t('message.upload')}}</button>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <br/>\r\n        <span id=\"file-name\"></span>\r\n        <span class=\"text-danger\">");
#nullable restore
#line 27 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml"
                             Write(Html.ValidationMessage("picError"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        <hr/>\r\n        \r\n");
#nullable restore
#line 30 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml"
         if(!picturePath.Contains("DefaultMan") && !picturePath.Contains("DefaultWoman")){

#line default
#line hidden
#nullable disable
            WriteLiteral("             ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "389fb53f0d1cec0c037daee56f45f8e75604860d9724", async() => {
                WriteLiteral("\r\n                <button type=\"submit\" id=\"delete-picture-btn\" class=\"btn btn-danger\">{{$t(\'message.delete\')}}</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </div>\r\n    \r\n    <div class=\"col-md-1\"></div>\r\n    <div class=\"col-md-4\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 1492, "\"", 1537, 1);
#nullable restore
#line 40 "D:\GitFolders\Programming\C#\Live\Matterix\Areas\Identity\Pages\Account\Manage\ProfilePicture.cshtml"
WriteAttributeValue("", 1498, Url.Content(Info.ProfilePicture(User)), 1498, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"450\" width=\"450\" style=\"object-fit: cover;\"/>\r\n    </div>\r\n        \r\n        \r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "389fb53f0d1cec0c037daee56f45f8e75604860d12269", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    \r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public InformationService Info { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfilePictureModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProfilePictureModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProfilePictureModel>)PageContext?.ViewData;
        public ProfilePictureModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
