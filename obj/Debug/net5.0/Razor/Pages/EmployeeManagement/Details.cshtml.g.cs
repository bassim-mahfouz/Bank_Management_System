#pragma checksum "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d97b9f4d16d00bd07b72cd16c5a07338206446da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Bank_Management_System.Pages.EmployeeManagement.Pages_EmployeeManagement_Details), @"mvc.1.0.razor-page", @"/Pages/EmployeeManagement/Details.cshtml")]
namespace Bank_Management_System.Pages.EmployeeManagement
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
#line 1 "C:\Users\hp\Desktop\Bank_Management_System\Pages\_ViewImports.cshtml"
using Bank_Management_System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d97b9f4d16d00bd07b72cd16c5a07338206446da", @"/Pages/EmployeeManagement/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e651d55bfe1d9a2421cf3ce3bcf4f9e65d2085b6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_EmployeeManagement_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Download", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("c btn download"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: 1000px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
  
  ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
  body{
      background-color: #201E20;
      color: white;
    }      

    .c{
      color:#DDC3A5;
      background-color: #201E20;
      border-radius: 5px;
      height: 40px;
      border: 2px solid #DDC3A5;
    }
    .c:hover{
      color:black;
      background-color: #DDC3A5;
      border-radius: 5px;
      height: 40px;
      border: 2px solid black;
    }
   
    th{
        background-color:  #DDC3A5;
        color: black;

    }
    td{
        background-color: #201E20;
        color: #DDC3A5;
        border-bottom: 2px solid #DDC3A5;

    }
    table{
        border-left:2px  #DDC3A5 solid ;
        border-right:2px  #DDC3A5 solid ;
        border-radius: 12px 12px 0 0 ;
    }
        .download{
        transform: translateY(50px);
    }
    .tableTr{
        transform: translateY(-30px);
    }
</style>
<a href=""../AdminIndex"" class=""c btn"" style=""margin-left: 1035px;"" >Home</a>
<br>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d97b9f4d16d00bd07b72cd16c5a07338206446da5514", async() => {
                WriteLiteral("Download");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-name", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
                                                         WriteLiteral(Model.name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["name"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-name", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["name"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<br>\r\n<h2 style=\"color: #DDC3A5;\">\r\n  ");
#nullable restore
#line 55 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
Write(Model.employee.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</h2>
<br>
<br>
<div style=""width: 1000px;"">
<table class=""table tableTr""  >
    <thead>
        <tr>
            <th>
                    Action Type
            </th>
            <th>
                    Id
            </th>
            <th>
                    Date
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 75 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
         foreach (var item in Model.actions)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n");
#nullable restore
#line 79 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
                 if( @item.type==0){

#line default
#line hidden
#nullable disable
            WriteLiteral("                  <span>Loan Installment</span>\r\n");
#nullable restore
#line 81 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
                 if(@item.type==1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                  <span>Deposite</span>\r\n");
#nullable restore
#line 85 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
                 if(@item.type==2)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                  <span>Withdraw</span>\r\n");
#nullable restore
#line 89 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 92 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
               Write(item.ActionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 95 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
               Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 98 "C:\Users\hp\Desktop\Bank_Management_System\Pages\EmployeeManagement\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel>)PageContext?.ViewData;
        public DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
