#pragma checksum "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8babb5d6bf3fb54f19d39fd6f2b8f35af6fb6a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseOrders_Details), @"mvc.1.0.view", @"/Views/PurchaseOrders/Details.cshtml")]
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
#line 1 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\_ViewImports.cshtml"
using ShopCaddy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\_ViewImports.cshtml"
using ShopCaddy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8babb5d6bf3fb54f19d39fd6f2b8f35af6fb6a7", @"/Views/PurchaseOrders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76a0521c7c2058081ba725b41ca32f847938b2a", @"/Views/_ViewImports.cshtml")]
    public class Views_PurchaseOrders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopCaddy.Controllers.PurchaseOrdersController.POPViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1></h1>\r\n\r\n<div class=\"table table-dark text-center\">\r\n    <h4>");
#nullable restore
#line 10 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
   Write(Html.DisplayFor(model => model.PurchaseOrder.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n</div>\r\n<dl class=\"table-dark\">\r\n         <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Vendor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
       Write(Html.DisplayFor(model => model.PurchaseOrder.Vendor.Contact));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 20 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
       Write(Html.DisplayFor(model => model.PurchaseOrder.Vendor.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
       Write(Html.DisplayFor(model => model.PurchaseOrder.Vendor.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>

<table class="" table table-dark"">
    <thead>
        <tr>
            <th class=""col-sm-2"">
                Image
            </th>
            <th class=""col-sm-2"">
                Product Name
            </th>
            <th class=""col-sm-2"">
                Quantity
            </th>
            <th class=""col-sm-2"">
                ");
#nullable restore
#line 40 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Product.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"col-sm-2\">\r\n                Delete\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 48 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
         foreach (ShopCaddy.Controllers.PurchaseOrdersController.POPViewModel purchaseOrderProduct in Model.groupedProducts)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n");
            WriteLiteral("                <td class=\"col-sm-8\"> <img");
            BeginWriteAttribute("src", " src=\"", 1543, "\"", 1610, 1);
#nullable restore
#line 53 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
WriteAttributeValue("", 1549, Html.DisplayFor(model => purchaseOrderProduct.Product.Image), 1549, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img h-25 w-auto\" /></td>\r\n                <td class=\"col-sm-8\">");
#nullable restore
#line 54 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
                                Write(Html.DisplayFor(model => purchaseOrderProduct.Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                <td class=\"col-sm-8\">");
#nullable restore
#line 56 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
                                Write(Html.DisplayFor(model => purchaseOrderProduct.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-sm-8\">");
#nullable restore
#line 57 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
                                Write(Html.DisplayFor(model => purchaseOrderProduct.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-sm-8\"><button class=\"delete-POP btn btn-danger\"");
            BeginWriteAttribute("id", " id=\"", 2031, "\"", 2080, 1);
#nullable restore
#line 58 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
WriteAttributeValue("", 2036, purchaseOrderProduct.PurchaseOrderProductId, 2036, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">X</button></td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 61 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td class=\"col-sm-8\"</td>\r\n            <td class=\"col-sm-8\"></td>\r\n            <td class=\"col-sm-8\"><h5>Total Price</h5></td>\r\n            <td class=\"col-sm-8\">");
#nullable restore
#line 67 "C:\Users\newforce\workspace\cohort2\c#\ShopCaddy\ShopCaddy\Views\PurchaseOrders\Details.cshtml"
                            Write(Model.groupedProducts.Sum(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n\r\n<div>\r\n");
            WriteLiteral("</div>\r\n");
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopCaddy.Controllers.PurchaseOrdersController.POPViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
