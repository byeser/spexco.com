#pragma checksum "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Products\_Filters.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3f98e0b864eeff04ef916957afab3649e80cedd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products__Filters), @"mvc.1.0.view", @"/Views/Products/_Filters.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/_Filters.cshtml", typeof(AspNetCore.Views_Products__Filters))]
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
#nullable restore
#line 6 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Products\_Filters.cshtml"
using spexco.com.ui.utils;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3f98e0b864eeff04ef916957afab3649e80cedd", @"/Views/Products/_Filters.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4a2473ce75184fd377e90af3996bf9643e2dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Products__Filters : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<spexco.com.ui.Models.generate_response<spexco.com.ui.Models.Category.CategoryRequest>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Products/_List.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Products\_Filters.cshtml"
  
    var categorylist = spexco.com.ui.utils.service.helper<spexco.com.ui.Models.generate_response<List<string>>>.get_api_client(spexco.com.ui.utils.enums.http_protocol.get, "/api/v1/Category/GetAll", null, true, null, null).Result.data;
     

#line default
#line hidden
#nullable disable
            BeginContext(373, 164, true);
            WriteLiteral("<div class=\"col-lg-12\">\r\n    <div class=\"col-sm-6\" style=\"padding-left: 0px;\">\r\n        <div class=\"form-group\">\r\n            <label >Kategori</label>\r\n            ");
            EndContext();
            BeginContext(538, 340, false);
#nullable restore
#line 11 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Products\_Filters.cshtml"
       Write(Html.ExtendedDropDownListFor(m => m.data.name, categorylist.Select(x => new ExtendedSelectListItem()
       {
           Selected = false,
           Text = x.ToString(),
           Value = x.ToString()
       }).OrderBy(x => x.Text).ToList(),
           new { @class = "dropdown-select-categoryid", @tabindex = "5", @required = "" }));

#line default
#line hidden
#nullable disable
            EndContext();
            BeginContext(878, 253, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-sm-1\" style=\"padding-top: 22px;\">\r\n        <button id=\"btnFilter\" class=\"btn btn-primary\" type=\"button\"  tabindex=\"500\">Filter</button>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"col-lg-12\" id=\"container\">\r\n    ");
            EndContext();
            BeginContext(1131, 106, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e3f98e0b864eeff04ef916957afab3649e80cedd5475", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 26 "D:\Github\spexco.com\Clients\spexco.com.ui\Views\Products\_Filters.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new spexco.com.ui.Models.generate_response<int>();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1237, 393, true);
            WriteLiteral(@"
</div>

<script>

    $(document).ready(function () {
        $(document).i18n();
        $('.dropdown-select').select2({
            placeholder: i18n.t('button.pls_select'),
            width: '100%'
        });
        $("".touchspin"").TouchSpin({
            buttondown_class: 'btn btn-white',
            buttonup_class: 'btn btn-white'
        });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<spexco.com.ui.Models.generate_response<spexco.com.ui.Models.Category.CategoryRequest>> Html { get; private set; }
    }
}
#pragma warning restore 1591
