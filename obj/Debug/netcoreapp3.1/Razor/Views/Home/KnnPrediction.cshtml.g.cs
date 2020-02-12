#pragma checksum "C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\Views\Home\KnnPrediction.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3edade90853d0c03a2c0be9547a67c5ad09a800"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_KnnPrediction), @"mvc.1.0.view", @"/Views/Home/KnnPrediction.cshtml")]
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
#line 1 "C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\Views\_ViewImports.cshtml"
using DataAcquisitionTermProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\Views\_ViewImports.cshtml"
using DataAcquisitionTermProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3edade90853d0c03a2c0be9547a67c5ad09a800", @"/Views/Home/KnnPrediction.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d9c8b7aed45bfd20d19da0724cec052a155481", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_KnnPrediction : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-sm-6\">\r\n            <div class=\"card\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">User Based Prediction for ");
#nullable restore
#line 11 "C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\Views\Home\KnnPrediction.cshtml"
                                                                Write(Model.MovieTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 12 "C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\Views\Home\KnnPrediction.cshtml"
                                    Write(ViewData["userBasedPrediction"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                    
                </div>
            </div>
        </div>
        <div class=""col-sm-6"">
            <div class=""card"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Item Based Prediction for ");
#nullable restore
#line 20 "C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\Views\Home\KnnPrediction.cshtml"
                                                                Write(Model.MovieTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 21 "C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\Views\Home\KnnPrediction.cshtml"
                                    Write(ViewData["itemBasedPrediction"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591
