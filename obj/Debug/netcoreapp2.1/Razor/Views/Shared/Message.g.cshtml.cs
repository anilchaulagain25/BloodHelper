#pragma checksum "D:\Projects\BLOOD_HELP\Views\Shared\Message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab0235295e04457ece5ec31a12de09538bd6d1fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Message), @"mvc.1.0.view", @"/Views/Shared/Message.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Message.cshtml", typeof(AspNetCore.Views_Shared_Message))]
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
#line 1 "D:\Projects\BLOOD_HELP\Views\_ViewImports.cshtml"
using BLOOD_HELP;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab0235295e04457ece5ec31a12de09538bd6d1fa", @"/Views/Shared/Message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfe36adf47313849e02ecc646ad331ea8ba48809", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Message : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AvailableBloodSample", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 1 "D:\Projects\BLOOD_HELP\Views\Shared\Message.cshtml"
  
Layout = "_Layout";

#line default
#line hidden
            BeginContext(28, 148, true);
            WriteLiteral("<div class=\"row\" class=\"text-center\" style=\"margin:15px;\">\r\n\t<div class=\"container py-5\">\r\n\t\t<div class=\"row\">\r\n\t\t\t<div class=\"col-md-10 mx-auto\">\r\n");
            EndContext();
#line 8 "D:\Projects\BLOOD_HELP\Views\Shared\Message.cshtml"
                  
					if(ViewBag.result!=null){
						var result=ViewBag.result;
						if(result.Success){

#line default
#line hidden
            BeginContext(277, 133, true);
            WriteLiteral("\t\t\t\t\t\t\t<h2 style=\"color:#28a745;\">\r\n\t\t\t\t\t\t\t\t<i class=\"fa fa-check-circle\" aria-hidden=\"true\"></i>\r\n\t\t\t\t\t\t\t\tSuccessful\r\n\t\t\t\t\t\t\t</h2>\r\n");
            EndContext();
#line 16 "D:\Projects\BLOOD_HELP\Views\Shared\Message.cshtml"
						}else{

#line default
#line hidden
            BeginContext(424, 132, true);
            WriteLiteral("\t\t\t\t\t\t\t<h2 style=\"color:#dc3545;\">\r\n\t\t\t\t\t\t\t\t<i class=\"fa fa-chain-broken\" aria-hidden=\"true\"></i>\r\n\r\n\t\t\t\t\t\t\t\tWarning\r\n\t\t\t\t\t\t\t</h2>\r\n");
            EndContext();
#line 22 "D:\Projects\BLOOD_HELP\Views\Shared\Message.cshtml"
						}

#line default
#line hidden
            BeginContext(565, 34, true);
            WriteLiteral("\t\t\t\t\t\t<p>\r\n                   \t\t\t ");
            EndContext();
            BeginContext(600, 22, false);
#line 24 "D:\Projects\BLOOD_HELP\Views\Shared\Message.cshtml"
                           Write(ViewBag.result.Message);

#line default
#line hidden
            EndContext();
            BeginContext(622, 26, true);
            WriteLiteral("\r\n                \t\t</p>\r\n");
            EndContext();
#line 26 "D:\Projects\BLOOD_HELP\Views\Shared\Message.cshtml"
					}
				

#line default
#line hidden
            BeginContext(663, 14, true);
            WriteLiteral("\t\t\t\t<br>\r\n\t\t\t\t");
            EndContext();
            BeginContext(677, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5a2c2ac2cd04d6db1b3965eb40eaf4b", async() => {
                BeginContext(737, 12, true);
                WriteLiteral("Back to page");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(753, 59, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div> \r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
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