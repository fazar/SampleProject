jqGrid for ASP.NET MVC 4.0

===========================
Installlation
===========================

Download and unzip the contents of the archive to any convenient location. The package contains the following folders

- [bin] - Contains the assembly DLL of the product (Trirand.Web.Mvc.dll). This is the assembly that you can reference directly in your MVC project.
- [themes] - Contains the themes shipped with the product. Since jqGrid supports jQuery UI Themeroller, any theme compatible with jQuery UI ThemeRoller will work for jqGrid as well. Therefore, the package contains just one theme ("Redmond"). You can download any additional themes directly from jQuery UI's ThemeRoller site available here: 

http://jqueryui.com/themeroller/

In addition to the "Redmond" theme, there is one more file in the [themes] folder - ui.jqgrid.css. This is the one and only Css file jqGrid needs. Just add it after you add the reference to Redmond in your ASPX file.

<link rel="stylesheet" type="text/css" href="themes/redmond/jquery-ui-1.8.2.custom.css" />
<link rel="stylesheet" type="text/css" href="themes/ui.jqgrid.css" />

- [js] - The javascript files of jqGrid (and the needed libraries). You need to include them in your ASPX page, in order to gain the client side functionality of the grid. 
The first file is "jquery-1.5.2.min.js" - this is the official jQuery library on which jqGrid is built upon.
The second file you need is the i18n (localization) javascript file. Depending on the language you need, just pick one from the "js/i18n" folder.
The last one is the jqGrid javascript code itself, located in "jquery.jqGrid.min.js"

The final result you will have in an ASPX page containing jqGrid would be something similar to that (assuming you have copied the [js] and [themes] folder ot the Script and Content folders of your ASP.NET MVC site respectively.

...
<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<sample_project.Models.OrdersJqGridModel>" %>
<%@ Import Namespace="Trirand.Web.Mvc" %>
<%@ Import Namespace="sample_project.Controllers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Performance Linq</title>
    <!-- The jQuery UI theme that will be used by the grid -->    
    <link rel="stylesheet" type="text/css" href="../../Content/themes/redmond/jquery-ui-1.8.2.custom.css" />    
    <!-- The Css UI theme extension of jqGrid -->
    <link rel="stylesheet" type="text/css" href="../../Content/themes/ui.jqgrid.css" />    
    <!-- jQuery library is a prerequisite for jqGrid -->
    <script type="text/javascript" src="../../Scripts/jquery-1.4.4.min.js"></script>    
    <!-- language pack - MUST be included before the jqGrid javascript -->
    <script type="text/javascript" src="../../Scripts/jqgrid/i18n/grid.locale-en.js"></script>    
    <!-- the jqGrid javascript runtime -->
    <script type="text/javascript" src="../../Scripts/jqgrid/jquery.jqGrid.min.js"></script>
    
</head>
<body>
    <div>           
        <%= Html.Trirand().JQGrid(Model.OrdersGrid, "JQGrid1") %>
    </div>
</body>
</html>
...

============================
Licensing
============================
This is our evaluation free 30-day trial license. We are very helpful to ALL customers, including trial customers and will gladly assist you 
with any problems you might have (send questions to support@trirand.net or better yet - to our public forums). 
To remove that, just purchase the single developer versions and we will send you a download link to unrestricted versions. 
You can purchase developer versions here (http://www.trirand.net/licensing.aspx)

It's as simple as that, no cryptic settings in configs, no registry settings - complete license freedom (so you can use it on test/deployment servers, 
have QA look it at without licenses issues, etc)



=============================
Hope this helps. If you have any questions, just mail them to support@trirand.net

Regards,
Trirand Inc