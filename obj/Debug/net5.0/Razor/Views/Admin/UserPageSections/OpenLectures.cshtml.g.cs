#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68b785a5c727cf16c82425dc6964b56b8399face"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserPageSections_OpenLectures), @"mvc.1.0.view", @"/Views/Admin/UserPageSections/OpenLectures.cshtml")]
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
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68b785a5c727cf16c82425dc6964b56b8399face", @"/Views/Admin/UserPageSections/OpenLectures.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserPageSections_OpenLectures : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OpenLecture>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "courseId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<button class=\"btn btn-danger\" id=\"new-open-lecture\" style=\"margin-bottom: 1rem;\">New</button>\r\n\r\n<table class=\"table table-hover\" id=\"admin-open-lecture\" hidden=\"hidden\">\r\n    <tr>\r\n        \r\n        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68b785a5c727cf16c82425dc6964b56b8399face4240", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 9 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Courses;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</td>
        <td><input type=""number"" name=""lectureNumber"" class=""form-control"" placeholder=""lectureNumber""/></td>
        <td><input type=""date"" class=""form-control"" name=""expDate"" value=""Expire""/></td>
        <td><button class=""btn btn-success"" id=""admin-open-lecture-btn"">Open</button></td>
    </tr>
    <tr>
        <td colspan=""5"" id=""open-lecture-response""><br/></td>
        
    </tr>
</table>

");
#nullable restore
#line 20 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr/>\r\n    <div class=\"text-center\">No OpenLectures!</div>\r\n");
#nullable restore
#line 24 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-hover"">
        
        <thead>
        <tr>
            <th>Course</th>
            <th>Code</th>
            <th>LectureNumber</th>
            <th>Exp Date</th>
            <th>Delete</th>
        </tr>
        </thead>
    
");
#nullable restore
#line 39 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
         foreach (var openLec in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 42 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
               Write(openLec.Lecture.Course.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 43 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
               Write(openLec.Lecture.Course.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 44 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
               Write(openLec.Lecture.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 45 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
               Write(Format.DateFormat(openLec.ExpireDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><button id=\"remove-open-lecture\"");
            BeginWriteAttribute("lecture-id", " lecture-id=\"", 1485, "\"", 1516, 1);
#nullable restore
#line 46 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
WriteAttributeValue("", 1498, openLec.LectureId, 1498, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</button></td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 49 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
        
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 52 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\UserPageSections\OpenLectures.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OpenLecture>> Html { get; private set; }
    }
}
#pragma warning restore 1591