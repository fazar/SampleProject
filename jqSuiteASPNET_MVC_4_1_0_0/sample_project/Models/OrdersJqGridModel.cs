using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;


namespace sample_project.Models
{
    public class OrdersJqGridModel
    {
        public OrdersJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "OrderID", 
                                                        // always set PrimaryKey for Add,Edit,Delete operations
                                                        // if not set, the first column will be assumed as primary key
                                                        PrimaryKey = true,
                                                        Editable = false,
                                                        Width = 50 },
                                     new JQGridColumn { DataField = "OrderDate", 
                                                        Editable = true,
                                                        Width = 100, 
                                                        DataFormatString = "{0:d}" },
                                     new JQGridColumn { DataField = "CustomerID", 
                                                        Editable = true,
                                                        Width = 100 },
                                     new JQGridColumn { DataField = "Freight", 
                                                        Editable = true,
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "ShipName",
                                                        Editable =  true
                                                      }                                     
                                 },
                Width = Unit.Pixel(640)
            };

            OrdersGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        public JQGrid OrdersGrid { get; set; }
    }
}
