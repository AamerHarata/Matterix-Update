#pragma checksum "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_OneCourseOverView), @"mvc.1.0.view", @"/Views/Admin/OneCourseOverView.cshtml")]
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
#line 1 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
using Matterix.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
using Matterix.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c84", @"/Views/Admin/OneCourseOverView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552acd028a672a3563f853327800f928060bd5b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_OneCourseOverView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Course>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Course", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CourseArea", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CoursesOverview", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PartialViews/_SharedModal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Admin/AdminSendGroup.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
  
    ViewBag.Title = @Model.Subject;
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
  
    var students = Con.Registrations.Where(x=>x.CourseId == Model.Id).Where(x=>!x.Canceled).OrderBy(x=>x.RegisterDate).Select(x=>x.Student);
    var i = 1;
    
    var totalCoursesMoney = 0;
    var totalCoursesPaid = 0;
    var totalCoursesLate = 0;
    var totalCoursesRest = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <div><code>");
#nullable restore
#line 25 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
          Write(Model.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c848015", async() => {
#nullable restore
#line 25 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                                                                                                                           Write(Model.Id);

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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-courseId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                                                                                                         WriteLiteral(Model.Id);

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
            WriteLiteral("</code> &nbsp;&nbsp;");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c8410821", async() => {
                WriteLiteral("All Courses");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n    <br/>\r\n    <div>\r\n        <a id=\"admin-send-email-group-btn\"");
            BeginWriteAttribute("course-id", " course-id=\"", 891, "\"", 912, 1);
#nullable restore
#line 28 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
WriteAttributeValue("", 903, Model.Id, 903, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"m-button m-button-primary\">Send group email</a>&nbsp;\r\n        <a id=\"admin-send-sms-group-btn\"");
            BeginWriteAttribute("course-id", " course-id=\"", 1016, "\"", 1037, 1);
#nullable restore
#line 29 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
WriteAttributeValue("", 1028, Model.Id, 1028, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""m-button m-button-danger"">Send group sms</a>
    </div>
    <br/>
    
    <table class=""table table-hover"">

        <thead>
        <tr>
            <th>#</th>
            <th>ID</th>
            <th>Name</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Devices</th>
            <th>Date</th>
            <th>Expired</th>
            <th>Required</th>
            <th>Paid</th>
            <th>Late</th>
            <th>Rest</th>
        </tr>
        </thead>
        
");
#nullable restore
#line 52 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
         foreach (var student in students)
        {

            
            var totalLateInvoices = Con.Invoices.Where(x=>x.UserId == student.Id).Where(x=>x.CourseId == Model.Id).Where(x=>x.IsLate()).ToList();
            var totalRequiredInvoices = Con.Invoices.Where(x => x.UserId == student.Id).Where(x=>x.CourseId == Model.Id).Where(x=>!x.Canceled).ToList();


            var totalRequired = totalRequiredInvoices.Sum(x=>x.CurrentAmount);
            var totalPaid = Con.Payments.Where(x=>x.UserId == student.Id).Where(x=>x.CourseId == Model.Id).Where(x=>!x.Refunded).Sum(x=>x.Amount);
            
            
            var totalLate = totalLateInvoices.Sum(x => x.CurrentAmount);
            
            
            var totalRest = totalRequired - totalPaid;
            

            //ToDo :: Continue fixing here
            var reg = Con.Registrations.Where(x => x.CourseId == Model.Id).Where(x=>!x.Canceled).SingleOrDefault(x => x.StudentId == student.Id);
            var expired = "-";
            var registerDate = DateTime.MinValue;
            if (reg != null)
            {
                registerDate = reg.RegisterDate;
                if (reg.Expire){
                    expired = "yes";
                }
            }


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 83 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c8415403", async() => {
#nullable restore
#line 84 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                                                                                                                               Write(student.Id.Split("-")[0]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-username", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                                                                                              WriteLiteral(student.ProfileUserName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c8418243", async() => {
#nullable restore
#line 85 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                                                                                                              Write(Info.AdminFullName(student));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                                                                                          WriteLiteral(student.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 86 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(student.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 87 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(student.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 88 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(Admin.DifferentDevices(student.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 89 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(Format.DateFormat(registerDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 90 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(expired);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 91 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(Format.NumberFormat(totalRequired));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 92 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(Format.NumberFormat(totalPaid));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><code>");
#nullable restore
#line 93 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                     Write(Format.NumberFormat(totalLate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></td>\r\n                <td>");
#nullable restore
#line 94 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
               Write(Format.NumberFormat(totalRest));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 96 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"

            totalCoursesMoney += (int) totalRequired;
            totalCoursesPaid += (int) totalPaid;
            totalCoursesLate += (int) totalLate;
            totalCoursesRest += (int) totalRest;
            i++;

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        
        <tr>
            <th colspan=""12""></th>
        </tr>
        <tfoot>
        <tr>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>Required</th>
            <th>Paid</th>
            <th>Late</th>
            <th>Rest</th>
        </tr>
        <tr>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>");
#nullable restore
#line 132 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
           Write(totalCoursesMoney);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 133 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
           Write(totalCoursesPaid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th><code>");
#nullable restore
#line 134 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                 Write(totalCoursesLate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code></th>\r\n            <th class=\"text-success\">");
#nullable restore
#line 135 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
                                Write(totalCoursesRest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        </tr>\r\n        </tfoot>\r\n\r\n\r\n\r\n    </table>\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c8425737", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d0b827a5c8be08c2e23f4f46d32d4f16b0b9c8426960", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
#nullable restore
#line 150 "D:\GitFolders\Programming\C#\Live\Matterix\Views\Admin\OneCourseOverView.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AdminService Admin { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PaymentService Payment { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext Con { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Course> Html { get; private set; }
    }
}
#pragma warning restore 1591
