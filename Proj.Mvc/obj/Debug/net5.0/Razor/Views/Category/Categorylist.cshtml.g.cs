#pragma checksum "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd11220e28c52f58733b234d426c7c18a3aa9ef7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Categorylist), @"mvc.1.0.view", @"/Views/Category/Categorylist.cshtml")]
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
#line 1 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\_ViewImports.cshtml"
using Proj.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
using Proj.Mvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd11220e28c52f58733b234d426c7c18a3aa9ef7", @"/Views/Category/Categorylist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87d5523fc23c6ce8ba8643294c456558d2304a55", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Categorylist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
  
    ViewData["Title"] = "Category List";
    int count = 0;
    int count1 = 0;
    string shortDesc = "";
    string catCatName = "";
    string css = "";
    var url = ViewBag.Url;
    var trueOrfalsed = url.Contains("True");
    var productwithoutcategory = ViewBag.productlist as List<Product>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Category List Welcome</h1>\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12 mt-3\">\r\n\r\n\r\n");
#nullable restore
#line 21 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
             if (Model != null && Model.Count() > 0)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                 if (trueOrfalsed)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4>All Categories</h4>\r\n");
#nullable restore
#line 26 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4> Categories With Non-Zero Stock</h4>\r\n");
#nullable restore
#line 30 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""table-responsive"">
                    <table id=""mytable"" class=""table table-bordred table-striped"">

                        <thead>
                            <tr>
                                <th scope=""col"">#</th>
                                <th scope=""col"">Category Name</th>
                                <th scope=""col"">Min. Stock Quantity</th>
                                <th scope=""col"">Total Product</th>
                                <th scope=""col"">#</th>
                                <th scope=""col"">#</th>
                                <th scope=""col"">#</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 46 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                             foreach (var item in Model)
                            {
                                if (item.Products.Count() <= 0)
                                {
                                    css = "display: none";
                                }
                                else
                                {
                                    css = "";
                                }
                                count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 58 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                   Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 59 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 60 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                   Write(item.MinStockQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 61 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                   Write(item.Products.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2357, "\"", 2389, 2);
            WriteAttributeValue("", 2364, "/Update-Category/", 2364, 17, true);
#nullable restore
#line 62 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 2381, item.Id, 2381, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\"");
            BeginWriteAttribute("style", " style=\"", 2421, "\"", 2433, 1);
#nullable restore
#line 62 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 2429, css, 2429, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-title=\"Edit\">Edit</a></td>\r\n                                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2510, "\"", 2542, 2);
            WriteAttributeValue("", 2517, "/Category-Detail/", 2517, 17, true);
#nullable restore
#line 63 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 2534, item.Id, 2534, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-sm\"");
            BeginWriteAttribute("style", " style=\"", 2574, "\"", 2586, 1);
#nullable restore
#line 63 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 2582, css, 2582, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-title=\"Info\">Info</a></td>\r\n                                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2663, "\"", 2695, 2);
            WriteAttributeValue("", 2670, "/Delete-Category/", 2670, 17, true);
#nullable restore
#line 64 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 2687, item.Id, 2687, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\"  data-title=\"Delete\">Delete</a></td>\r\n                                </tr>\r\n");
#nullable restore
#line 66 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
#nullable restore
#line 69 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                     if (trueOrfalsed)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"/Category-List\" class=\"btn btn-warning btn-sm\" data-title=\"ShowZeroQuantity\">Show All</a>\r\n");
#nullable restore
#line 72 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"/Category-List/True\" class=\"btn btn-warning btn-sm\" data-title=\"ShowZeroQuantity\">Show Zero</a>\r\n");
#nullable restore
#line 76 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 78 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"

                if (productwithoutcategory != null && productwithoutcategory.Count() > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <h4 style="" margin-top:50px""> Products Without Category </h4>
                    <div class=""table-responsive"">
                        <table id=""mytable"" class=""table table-bordred table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">#</th>
                                    <th scope=""col"">Title</th>
                                    <th scope=""col"">Description</th>
                                    <th scope=""col"">Quantity</th>
                                    <th scope=""col"">Category</th>
                                    <th scope=""col"">#</th>
                                    <th scope=""col"">#</th>
                                    <th scope=""col"">#</th>
                                </tr>
                            </thead>

                            <tbody>
");
#nullable restore
#line 98 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                 foreach (var item in productwithoutcategory)
                                {
                                    count1++;
                                    if (item.Description.Length > 99)
                                    {
                                        shortDesc = item.Description.Substring(0, 100);
                                    }
                                    else
                                    {
                                        shortDesc = item.Description;
                                    }
                                    if (item.Category == null)
                                    {
                                        catCatName = "-";
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 114 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                       Write(count1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 115 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 116 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                       Write(shortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 117 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 118 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                       Write(catCatName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 5556, "\"", 5587, 2);
            WriteAttributeValue("", 5563, "/Update-Product/", 5563, 16, true);
#nullable restore
#line 119 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 5579, item.Id, 5579, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\" data-title=\"Edit\">Edit</a></td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 5699, "\"", 5730, 2);
            WriteAttributeValue("", 5706, "/Product-Detail/", 5706, 16, true);
#nullable restore
#line 120 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 5722, item.Id, 5722, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-sm\" data-title=\"Info\">Info</a></td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 5842, "\"", 5873, 2);
            WriteAttributeValue("", 5849, "/Delete-Product/", 5849, 16, true);
#nullable restore
#line 121 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
WriteAttributeValue("", 5865, item.Id, 5865, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\" data-title=\"Delete\">Delete</a></td>\r\n                                    </tr>\r\n");
#nullable restore
#line 123 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n");
#nullable restore
#line 127 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"table-responsive\">\r\n\r\n                    <h4>Sorry nothing to show</h4>\r\n                </div>\r\n");
#nullable restore
#line 135 "C:\Users\MONSTER\source\repos\Proj\Proj.Mvc\Views\Category\Categorylist.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591