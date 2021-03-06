#pragma checksum "C:\Users\ADMIN\Desktop\Student\Views\Class\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e74508558f3f028b7fbaf6a88ce79d78c70aa7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Class_Index), @"mvc.1.0.view", @"/Views/Class/Index.cshtml")]
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
#line 1 "C:\Users\ADMIN\Desktop\Student\Views\_ViewImports.cshtml"
using StudentManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ADMIN\Desktop\Student\Views\_ViewImports.cshtml"
using StudentManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e74508558f3f028b7fbaf6a88ce79d78c70aa7a", @"/Views/Class/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7bb6102ef74a0920854243dc02f5efb2e491047", @"/Views/_ViewImports.cshtml")]
    public class Views_Class_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SelectList>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\ADMIN\Desktop\Student\Views\Class\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Index</h1>
 <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"" />
 
<p>
    <a href=""/Class/Create"" class=""btn btn-primary"" id=""Create"">Create</a>
</p>
<table class=""table"" id= ""tbClass"">
    <thead>
        <tr>
            <th>
                ClassName
            </th>
            <th>
                Description
            </th>
            <th>
               Amount
            </th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>


");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script src=""https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js""></script>

<script>
    $(document).ready(function () {
        $(""#tbClass"").dataTable(
        {   processing:true,
            serverSide:true,
            ajax:{
                type:'POST',
                url:""/Class/GetData"",
                dataType: ""json"",

            },  

            columns: [
            {'data':'className'},
            {'data':'description'},
            {'data':'amount'},
            {'data':'id',
            'render':function(data,type,row,meta){
                return '<a class=""btn btn-primary""href=""/Class/Edit/'+data+'"" >Edit</a>'+
                      '<a class=""btn btn-danger"" href=""/Class/Delete/'+data+'"" style=""margin-left:4px"" >Delete</a>'
                     
            }
            },
            ]
        }); 
       
        
    });
</script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SelectList> Html { get; private set; }
    }
}
#pragma warning restore 1591
