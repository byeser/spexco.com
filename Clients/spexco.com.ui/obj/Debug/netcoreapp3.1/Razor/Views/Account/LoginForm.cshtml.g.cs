#pragma checksum "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\LoginForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00bf92e25c922ef3a98d447faf1f835ce89a4d07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_LoginForm), @"mvc.1.0.view", @"/Views/Account/LoginForm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/LoginForm.cshtml", typeof(AspNetCore.Views_Account_LoginForm))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00bf92e25c922ef3a98d447faf1f835ce89a4d07", @"/Views/Account/LoginForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4a2473ce75184fd377e90af3996bf9643e2dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_LoginForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<spexco.com.ui.Models.Login.LoginRequest>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\LoginForm.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            BeginContext(75, 154, true);
            WriteLiteral("    <div>\r\n        <br /><br /><br /> \r\n        <img src=\"http://www.spexco.com/web/content/images/logo-footer.png\" />\r\n        <br /><br />\r\n    </div>\r\n");
            EndContext();
            BeginContext(230, 23, false);
#nullable restore
#line 10 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\LoginForm.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            EndContext();
            BeginContext(253, 32, true);
            WriteLiteral("\r\n<div class=\"form-group\">\r\n    ");
            EndContext();
            BeginContext(286, 122, false);
#nullable restore
#line 12 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\LoginForm.cshtml"
Write(Html.TextBoxFor(m => m.username, new { @class = "form-control", @data_i18n = "[placeholder]login.email", @required = "" }));

#line default
#line hidden
#nullable disable
            EndContext();
            BeginContext(408, 40, true);
            WriteLiteral("\r\n</div>\r\n<div class=\"form-group\">\r\n    ");
            EndContext();
            BeginContext(449, 145, false);
#nullable restore
#line 15 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\LoginForm.cshtml"
Write(Html.TextBoxFor(m => m.password, new { @class = "form-control", @type = "password", @data_i18n = "[placeholder]login.password", @required = "" }));

#line default
#line hidden
#nullable disable
            EndContext();
            BeginContext(594, 442, true);
            WriteLiteral(@"
</div>
 
<button id=""login_button"" type=""submit"" class=""ladda-button ladda-button-demo btn btn-primary full-width m-b"" data-style=""zoom-in"" data-i18n=""button.login"">Giriş Yap</button>
<div class=""row"">  
    <p class=""m-t""> <small>Copyright &copy; 2021 - Spexco - 1.0.1 </small> </p>
</div>
<script>
    btn = $('#login_button').ladda();
    $(document).ready(function () {
        $(document).i18n();
    });
    
</script>

");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<spexco.com.ui.Models.Login.LoginRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591