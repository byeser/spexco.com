#pragma checksum "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "684c76c7571584d0e3ea7477bfd5203d0d9098b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Login.cshtml", typeof(AspNetCore.Views_Account_Login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"684c76c7571584d0e3ea7477bfd5203d0d9098b8", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4a2473ce75184fd377e90af3996bf9643e2dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Account/Login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("m-t"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("OnBegin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-complete", new global::Microsoft.AspNetCore.Html.HtmlString("OnSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("OnSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("POST"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-mode", new global::Microsoft.AspNetCore.Html.HtmlString("replace"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("OnSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#frm_login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("gray-bg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\Login.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            BeginContext(27, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(54, 5391, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "684c76c7571584d0e3ea7477bfd5203d0d9098b88494", async() => {
                BeginContext(60, 5378, true);
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title data-i18n=""app.project_name""></title>
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <link rel=""shortcut icon"" href=""http://www.spexco.com/web/content/images/favicon.png"" type=""image/x-icon"">
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700' rel='stylesheet' type='text/css'>
    <!-- Add local styles, mostly for plugins css file -->
    <!-- Add jQuery Style direct - used for jQGrid plugin -->
    <link href=""/Scripts/plugins/jquery-ui/jquery-ui.min.css"" rel=""stylesheet"" type=""text/css"" />

    <!-- Primary Inspinia style -->
    <link href=""/fonts/font-awesome/css/font-awesome.min.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/dataTables/datatables.min.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/chosen/bootstrap-chosen.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/touchspin/jquery.bootstr");
                WriteLiteral(@"ap-touchspin.min.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/select2/select2.min.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/iCheck/custom.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/jasny/jasny-bootstrap.min.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/daterangepicker/daterangepicker-bs3.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/datapicker/datepicker3.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/ladda/ladda-themeless.min.css"" rel=""stylesheet"" />

    <link href=""/Content/plugins/sweetalert/sweetalert.css"" rel=""stylesheet"" />


    <link href=""/Content/plugins/toastr/toastr.min.css"" rel=""stylesheet"" />



    <link href=""/Content/bootstrap.min.css"" rel=""stylesheet"" />
    <link href=""/Content/animate.css"" rel=""stylesheet"" />
    <link href=""/Content/style.css"" rel=""stylesheet"" />
    <link href=""/Content/main.css"" rel=""stylesheet"" />




    <!-- Section for main scripts render -->
    <scri");
                WriteLiteral(@"pt src=""/Scripts/jquery-3.1.1.min.js""></script>

    <script src=""/Scripts/jquery.unobtrusive-ajax.min.js""></script>

    <script src=""/Scripts/popper.min.js""></script>

    <script src=""/Scripts/bootstrap.min.js""></script>

    <script src=""/Scripts/plugins/slimscroll/jquery.slimscroll.min.js""></script>


    <script src=""/Scripts/plugins/toastr/toastr.min.js""></script>

    <script src=""/Scripts/plugins/flot/jquery.flot.js""></script>
    <script src=""/Scripts/plugins/flot/jquery.flot.tooltip.min.js""></script>
    <script src=""/Scripts/plugins/flot/jquery.flot.resize.js""></script>
    <script src=""/Scripts/plugins/flot/jquery.flot.pie.js""></script>
    <script src=""/Scripts/plugins/flot/jquery.flot.time.js""></script>
    <script src=""/Scripts/plugins/flot/jquery.flot.spline.js""></script>

    <script src=""/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js""></script>
    <script src=""/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js""></script>

    <script src=""/Scr");
                WriteLiteral(@"ipts/plugins/i18next/i18next.min.js""></script>

    <script src=""/Scripts/plugins/dataTables/datatables.min.js""></script>

    <script src=""/Scripts/plugins/chosen/chosen.jquery.js""></script>

    <script src=""/Scripts/plugins/touchspin/jquery.bootstrap-touchspin.min.js""></script>

    <script src=""/Scripts/plugins/select2/select2.full.min.js""></script>

    <script src=""/Scripts/plugins/iCheck/icheck.min.js""></script>

    <script src=""/Scripts/plugins/jasny/jasny-bootstrap.min.js""></script>

    <script src=""/Scripts/plugins/datapicker/bootstrap-datepicker.js""></script>

    <script src=""/Scripts/plugins/toastr/toastr.min.js""></script>

    <script src=""/Scripts/plugins/ladda/spin.min.js""></script>
    <script src=""/Scripts/plugins/ladda/ladda.min.js""></script>
    <script src=""/Scripts/plugins/ladda/ladda.jquery.min.js""></script>




    <link href=""/Content/plugins/datetimepicker/bootstrap-datetimepicker.min.css"" rel=""stylesheet"" />

    <script src=""/Scripts/plugins/datetimepic");
                WriteLiteral(@"ker/bootstrap-datetimepicker.min.js""></script>
    <script src=""/Scripts/plugins/datetimepicker/bootstrap-datetimepicker.tr.js""></script>

    <script src=""/Scripts/plugins/fullcalendar/moment.min.js""></script>
    <script src=""/Scripts/plugins/daterangepicker/daterangepicker.js""></script>

    <script src=""/Scripts/plugins/metisMenu/metisMenu.min.js""></script>
    <script src=""/Scripts/plugins/pace/pace.min.js""></script>
    <script src=""/Scripts/app/inspinia.js""></script>

    <script src=""/Scripts/plugins/chartjs/Chart.min.js""></script>

    <script src=""/Scripts/plugins/iCheck/icheck.min.js""></script>



    <script type=""text/javascript"">
        $(document).ready(function () {
            toastr.options = {
                closeButton: true,
                debug: true,
                progressBar: true,
                positionClass: 'toast-top-right',
                timeOut: 5000,
                onclick: null
            };
        });
        var btn = null;
        func");
                WriteLiteral(@"tion OnBegin() {
            if (btn != null) {
                btn.ladda('start');
            }
        }
        function OnSuccess(data) {
            if (btn != null) {
                btn.ladda('stop');
            }
        }
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5445, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5447, 593, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "684c76c7571584d0e3ea7477bfd5203d0d9098b815398", async() => {
                BeginContext(5469, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5475, 550, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "684c76c7571584d0e3ea7477bfd5203d0d9098b815787", async() => {
                    BeginContext(5755, 161, true);
                    WriteLiteral("\r\n        <div id=\"loginbox\" class=\"middle-box text-center loginscreen  animated fadeInDown\">\r\n\r\n            <div id=\"frm_login\" class=\"login\">\r\n                ");
                    EndContext();
                    BeginContext(5917, 59, false);
#nullable restore
#line 150 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Account\Login.cshtml"
           Write(await Html.PartialAsync("~/Views/Account/LoginForm.cshtml"));

#line default
#line hidden
#nullable disable
                    EndContext();
                    BeginContext(5976, 42, true);
                    WriteLiteral("\r\n            </div>\r\n        </div>\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6025, 8, true);
                WriteLiteral("\r\n\r\n\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6040, 9, true);
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
