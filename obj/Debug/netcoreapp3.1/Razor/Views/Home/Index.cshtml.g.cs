#pragma checksum "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03479951e30da641b7a16eeba2cdadb76ce8ff79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "/home/mich/Pulpit/NTR20Z/Views/_ViewImports.cshtml"
using NTR20Z;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
using NTR20Z.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03479951e30da641b7a16eeba2cdadb76ce8ff79", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbdffa1f3afd5501ce8bb20a05324ccebb91d510", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Reader>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Planner";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to the Planner</h1>\r\n    \r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 15 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("RemoveTeacher", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 384, "\"", 465, 4);
            WriteAttributeValue("", 399, "location.href=\'", 399, 15, true);
#nullable restore
#line 21 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 414, Url.Action("RemoveTeacher", "Home"), 414, 36, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 450, "\';return", 450, 8, true);
            WriteAttributeValue(" ", 458, "false;", 459, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Usun nauczyciela</button>\r\n");
#nullable restore
#line 22 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 24 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("AddTeacher", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 693, "\"", 771, 4);
            WriteAttributeValue("", 708, "location.href=\'", 708, 15, true);
#nullable restore
#line 30 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 723, Url.Action("AddTeacher", "Home"), 723, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 756, "\';return", 756, 8, true);
            WriteAttributeValue(" ", 764, "false;", 765, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Dodaj nauczyciela</button>\r\n");
#nullable restore
#line 31 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 33 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("RemoveGroup", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 1001, "\"", 1080, 4);
            WriteAttributeValue("", 1016, "location.href=\'", 1016, 15, true);
#nullable restore
#line 39 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 1031, Url.Action("RemoveGroup", "Home"), 1031, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1065, "\';return", 1065, 8, true);
            WriteAttributeValue(" ", 1073, "false;", 1074, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Usuń grupę</button>\r\n");
#nullable restore
#line 40 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 42 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("AddGroup", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 1300, "\"", 1376, 4);
            WriteAttributeValue("", 1315, "location.href=\'", 1315, 15, true);
#nullable restore
#line 48 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 1330, Url.Action("AddGroup", "Home"), 1330, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1361, "\';return", 1361, 8, true);
            WriteAttributeValue(" ", 1369, "false;", 1370, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Dodaj klasę</button>\r\n");
#nullable restore
#line 49 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 51 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("RemoveRoom", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 1599, "\"", 1677, 4);
            WriteAttributeValue("", 1614, "location.href=\'", 1614, 15, true);
#nullable restore
#line 57 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 1629, Url.Action("RemoveRoom", "Home"), 1629, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1662, "\';return", 1662, 8, true);
            WriteAttributeValue(" ", 1670, "false;", 1671, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Usuń salę</button>\r\n");
#nullable restore
#line 58 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 60 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("AddRoom", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 1895, "\"", 1970, 4);
            WriteAttributeValue("", 1910, "location.href=\'", 1910, 15, true);
#nullable restore
#line 66 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 1925, Url.Action("AddRoom", "Home"), 1925, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1955, "\';return", 1955, 8, true);
            WriteAttributeValue(" ", 1963, "false;", 1964, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Dodaj salę</button>\r\n");
#nullable restore
#line 67 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 69 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("RemoveSubject", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 2195, "\"", 2276, 4);
            WriteAttributeValue("", 2210, "location.href=\'", 2210, 15, true);
#nullable restore
#line 75 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 2225, Url.Action("RemoveSubject", "Home"), 2225, 36, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2261, "\';return", 2261, 8, true);
            WriteAttributeValue(" ", 2269, "false;", 2270, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Usuń przedmiot</button>\r\n");
#nullable restore
#line 76 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 78 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 using(Html.BeginForm("AddSubject", "Home"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
Write(Html.ValidationSummary(true, "nie dziala", new{@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n    onclick=\"", 2502, "\"", 2580, 4);
            WriteAttributeValue("", 2517, "location.href=\'", 2517, 15, true);
#nullable restore
#line 84 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
WriteAttributeValue("", 2532, Url.Action("AddSubject", "Home"), 2532, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2565, "\';return", 2565, 8, true);
            WriteAttributeValue(" ", 2573, "false;", 2574, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Dodaj przedmiot</button>\r\n");
#nullable restore
#line 85 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 87 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 if (ViewBag.Warning1 == 2)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class =\"alert alert-danger alert-dismissible fade show\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n        <strong>Błąd współbieżności</strong>\r\n    </div>\r\n");
#nullable restore
#line 93 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 95 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 if (ViewBag.Warning1 == -1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class =\"alert alert-danger alert-dismissible fade show\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n        <strong>Element jest powiązany z aktywnymi zajęciami</strong>\r\n    </div>\r\n");
#nullable restore
#line 101 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 103 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
 if (ViewBag.Warning1 == 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class =\"alert alert-danger alert-dismissible fade show\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n        <strong>Element o takiej nazwie jest już w bazie</strong>\r\n    </div>\r\n");
#nullable restore
#line 109 "/home/mich/Pulpit/NTR20Z/Views/Home/Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Reader> Html { get; private set; }
    }
}
#pragma warning restore 1591
