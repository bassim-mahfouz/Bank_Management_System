#pragma checksum "C:\Users\hp\Desktop\Bank_Management_System\Pages\Accounts\Message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a68bd144b44279c1c4d67307964caa9ffc65dc5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Bank_Management_System.Pages.Accounts.Pages_Accounts_Message), @"mvc.1.0.razor-page", @"/Pages/Accounts/Message.cshtml")]
namespace Bank_Management_System.Pages.Accounts
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a68bd144b44279c1c4d67307964caa9ffc65dc5b", @"/Pages/Accounts/Message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e651d55bfe1d9a2421cf3ce3bcf4f9e65d2085b6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Accounts_Message : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\hp\Desktop\Bank_Management_System\Pages\Accounts\Message.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    body {
        background-color: #201E20;
    }

    .c {
        color: #DDC3A5;
        background-color: #201E20;
        border-radius: 5px;
        height: 40px;
        border: 2px solid #DDC3A5;
    }

    .c:hover {
        color: black;
        background-color: #DDC3A5;
        border-radius: 5px;
        height: 40px;
        border: 2px solid black;
    }

    .c_input {
        background-color: #201E20;
        border-top: 2px #201E20 solid;
        border-left: 2px #201E20 solid;
        border-right: 2px #201E20 solid;
        border-bottom: 2px #DDC3A5 solid;
        color: #DDC3A5;
        height: 40px;
        width: 500px;

    }

    .c_input:focus {
        background-color: #201E20;
        border-top: 2px #201E20 solid;
        border-left: 2px #201E20 solid;
        border-right: 2px #201E20 solid;
        border-bottom: 2px #DDC3A5 solid;
        color: #DDC3A5;
        height: 40px;
        width: 500px;

    }
    h2{
       ");
            WriteLiteral(@" border-bottom: 2px #DDC3A5 solid;
        height:70px;
    }
</style>

<br>
<h1 style='color: red;'>
Error : 

</h1>
<br>
<br>

    <h2 class=""form-group"" style=""color: #DDC3A5;"">
        the Customer with the  
        <span style=""color: red;"">id ' ");
#nullable restore
#line 66 "C:\Users\hp\Desktop\Bank_Management_System\Pages\Accounts\Message.cshtml"
                                  Write(Model.id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \'</span>  already has an Account\r\n    </h2>\r\n\r\n<br>\r\n\r\n<a href=\"index\" class=\"btn c\" >Previous</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MessageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MessageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MessageModel>)PageContext?.ViewData;
        public MessageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591