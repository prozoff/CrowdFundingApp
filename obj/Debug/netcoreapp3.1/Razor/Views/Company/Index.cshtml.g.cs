#pragma checksum "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9aae32678dc94c57dde5d2d581118ea4cc47b6f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_Index), @"mvc.1.0.view", @"/Views/Company/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9aae32678dc94c57dde5d2d581118ea4cc47b6f9", @"/Views/Company/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89cc0212d5d52435405321a5cb191d9359c2f386", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CrowdFundingApp.ViewModels.CompanyViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CompanyProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CompanyProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
  
    ViewBag.Title = "Company List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
 foreach (Company company in Model.companies)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"media mb-3\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 270, "\"", 295, 1);
#nullable restore
#line 11 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
WriteAttributeValue("", 276, company.companyImg, 276, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"128\" width=\"128\" class=\"align-self-start mr-3\" alt=\"...\">\r\n        <div class=\"media-body\">\r\n            <h5 class=\"mt-0\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9aae32678dc94c57dde5d2d581118ea4cc47b6f94841", async() => {
#nullable restore
#line 13 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
                                                                                                                                Write(company.companyName);

#line default
#line hidden
#nullable disable
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
#line 13 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
                                                                                                     WriteLiteral(company.companyId);

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
            WriteLiteral("</h5>\r\n            <p>");
#nullable restore
#line 14 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
          Write(company.about);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <hr />\r\n            <div class=\"row ml-2\">\r\n                <small class=\"mr-2\">");
#nullable restore
#line 17 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
                               Write(Localizer["Rating"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 17 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
                                                      Write(company.rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 21 "D:\Dev\Proj\Itra\Curs\CrowdFundingApp\Views\Company\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrowdFundingApp.ViewModels.CompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
