#pragma checksum "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Shared\_Redirect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd5c17bdb715558caa54f459f1e11be9d31c5806"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Redirect), @"mvc.1.0.view", @"/Views/Shared/_Redirect.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Redirect.cshtml", typeof(AspNetCore.Views_Shared__Redirect))]
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
#line 1 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\_ViewImports.cshtml"
using spexco.com.ui;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\_ViewImports.cshtml"
using spexco.com.ui.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd5c17bdb715558caa54f459f1e11be9d31c5806", @"/Views/Shared/_Redirect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4a2473ce75184fd377e90af3996bf9643e2dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Redirect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(17, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#nullable restore
#line 4 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Shared\_Redirect.cshtml"
 if (!string.IsNullOrEmpty(Model))
{
    

#line default
#line hidden
#nullable disable
            BeginContext(68, 51, true);
            WriteLiteral("\r\n        <script>\r\n            window.location = \'");
            EndContext();
            BeginContext(120, 5, false);
#nullable restore
#line 8 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Shared\_Redirect.cshtml"
                          Write(Model);

#line default
#line hidden
#nullable disable
            EndContext();
            BeginContext(125, 27, true);
            WriteLiteral("\';\r\n        </script>\r\n    ");
            EndContext();
#nullable restore
#line 10 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Shared\_Redirect.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
