<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<sample_project.Models.OrdersJqGridModel>" %>
<%@ Import Namespace="Trirand.Web.Mvc" %>
<%@ Import Namespace="sample_project.Controllers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Performance Linq</title>
    <!-- The jQuery UI theme that will be used by the grid -->    
        <link rel="stylesheet" type="text/css" media="screen" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.11/themes/redmond/jquery-ui.css" />
    <!-- The Css UI theme extension of jqGrid -->
    <link rel="stylesheet" type="text/css" href="../../Content/themes/ui.jqgrid.css" />    
    <!-- jQuery library is a prerequisite for jqGrid -->
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <!-- language pack - MUST be included before the jqGrid javascript -->
    <script type="text/javascript" src="../../Scripts/trirand/i18n/grid.locale-en.js"></script>
    <!-- the jqGrid javascript runtime -->
    <script type="text/javascript" src="../../Scripts/trirand/jquery.jqGrid.min.js"></script>    
    <style>
        body { font-size: 60%; }
    </style>
</head>
<body>
    <div>           
        <%= Html.Trirand().JQGrid(Model.OrdersGrid, "JQGrid1") %>
    </div>
</body>
</html>
