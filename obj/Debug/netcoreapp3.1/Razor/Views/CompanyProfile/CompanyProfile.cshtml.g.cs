#pragma checksum "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06b8eb6b39ff72d472f875a118137b73fc5c03be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CompanyProfile_CompanyProfile), @"mvc.1.0.view", @"/Views/CompanyProfile/CompanyProfile.cshtml")]
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
#line 1 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\_ViewImports.cshtml"
using CrowdFundingApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\_ViewImports.cshtml"
using CrowdFundingApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06b8eb6b39ff72d472f875a118137b73fc5c03be", @"/Views/CompanyProfile/CompanyProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89cc0212d5d52435405321a5cb191d9359c2f386", @"/Views/_ViewImports.cshtml")]
    public class Views_CompanyProfile_CompanyProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CrowdFundingApp.ViewModels.CompanyProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CompanyProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCompany", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "News", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "createNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
  
    ViewData["Title"] = "Company Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06b8eb6b39ff72d472f875a118137b73fc5c03be4597", async() => {
                WriteLiteral("Edit Company");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-companyId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 6 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
                                                                     WriteLiteral(Model.companyProfile.companyId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["companyId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-companyId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["companyId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06b8eb6b39ff72d472f875a118137b73fc5c03be7039", async() => {
                WriteLiteral("Create News");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-companyId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
                                                          WriteLiteral(Model.companyProfile.companyId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["companyId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-companyId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["companyId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<p>Name: ");
#nullable restore
#line 8 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
    Write(Model.companyProfile.companyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Theme: ");
#nullable restore
#line 9 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
     Write(Model.themeName.theme.themeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>rating: ");
#nullable restore
#line 10 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
      Write(Model.companyProfile.CompanyRatings);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>money need: ");
#nullable restore
#line 11 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
          Write(Model.companyProfile.needDonate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>total donate: ");
#nullable restore
#line 12 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
            Write(Model.companyProfile.totaldonate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>total About: ");
#nullable restore
#line 13 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
           Write(Model.companyProfile.about);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<div>\r\n    <table class=\"table\">\r\n        <tr><th>Bonus</th><th>Cost</th><th></th></tr>\r\n");
#nullable restore
#line 17 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
         foreach (BonusList bonusList in Model.companyProfile.BonusList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
               Write(bonusList.bonusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
               Write(bonusList.bonusCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 23 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\CompanyProfile\CompanyProfile.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrowdFundingApp.ViewModels.CompanyProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
