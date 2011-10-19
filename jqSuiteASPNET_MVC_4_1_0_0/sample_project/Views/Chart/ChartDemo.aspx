<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Trirand.Web.Mvc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Basic Line ToolTip</title>
    <!-- Use Microsoft's CDN for the jQuery library -->
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.5.1.js"></script>    
    <!-- Include the javascript client-side file for jqChart -->
    <script type="text/javascript" src="<%= Url.Content("~/Scripts/trirand/jquery.jqChart.min.js") %>"></script>
</head>
<body>
    <div>
        <!-- 
            The Html.Trirand().JQChart() helper has two parameters
            - the model of the chart -- all chart properties, data and settings
            - the ID of the chart -- can be used for client-side manipulation
            In this example we are using hardcoded model in the View, but you can contruct the model in 
            the controller based on runtime criteria and database data and pass the model 
            to the View using ViewData
        -->
        <%= Html.Trirand().JQChart(
                new JQChart
                {
                    Type = ChartType.Line,
                    Width = 700,
                    Height = 350,
                    MarginRight = 130,
                    MarginBottom = 50,
                    Title = new ChartTitleSettings
                    {
                        Text = "Monthly Average Temperature",
                        X = -15
                    },
                    SubTitle = new ChartTitleSettings
                    {
                        Text = "Source: WorldClimate.com",
                        X = -20
                    },
                    // we can have multiple x and y-axis.
                    XAxis = new List<ChartXAxisSettings>
                    {
                        new ChartXAxisSettings
                        {
                            Categories = new List<string> {"Jan", "Feb", "Mar", "Apr", "May", "Jun", 
						                        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                            Title = new ChartTitleSettings
                            {
                                Text = "Month, Year 2010"
                            }
                        }
                    },
                    // we can have multiple x and y-axis.
                    YAxis = new List<ChartYAxisSettings>
                    {
                        new ChartYAxisSettings
                        {
                            Title = new ChartTitleSettings
                            {
                                Text = "Temperature in Celcius"
                            }
                        }                  
                    },
                    Legend = new ChartLegendSettings
                    {
                        Layout = ChartLegendLayout.Vertical,
                        Align = ChartHorizontalAlign.Right,
                        VerticalAlign = ChartVerticalAlign.Top,
                        X = -10,
                        Y = 100,
                        BorderWidth = 0,
                    },
                    ToolTip = new ChartToolTipSettings
                    {
                        Formatter = "formatToolTip"                           
                    },                    
                    Series = new List<ChartSeriesSettings>
                    {
                        new ChartSeriesSettings 
                        {
                            Name = "Tokyo",                            
                            Data = new List<ChartPoint>().FromCollection(
                                new double[] { 7, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6 }
                            )                                    
                            
                        },
                        new ChartSeriesSettings 
                        {
                            Name = "New York",                            
                            Data = new List<ChartPoint>().FromCollection(
                                new double[] { -0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5 }
                            )
                        },
                        new ChartSeriesSettings 
                        {
                            Name = "Berlin",                            
                            Data = new List<ChartPoint>().FromCollection(
                                new double[] {-0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0}
                            )
                        },
                         new ChartSeriesSettings 
                        {
                            Name = "London",                            
                            Data = new List<ChartPoint>().FromCollection(
                                new double[] {3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8}
                            )
                        }                        
                    }
                }, "TemperatureChart")
        %>   
        
        <script type="text/javascript">
        
        function formatToolTip()
        {
            // "point" is the current point data, you can access various properties there            
            return '<b>'+ this.series.name +'</b><br/>'+
               this.x +': '+ this.y +'°C';			
        }
        
        </script>
        
        <br /><br />
        
    </div>
</body>
</html>
