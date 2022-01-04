using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Trip_Planner
{
    class Travel_Plan_TabPage : TabbedPage
    {
        //Creates a tabbed page that connects to Trip_Details + Travel_Expenses
        public Travel_Plan_TabPage()
        {
            this.Children.Add(new Trip_Details());
            this.Children.Add(new Travel_Expenses());
        }
    }
}
