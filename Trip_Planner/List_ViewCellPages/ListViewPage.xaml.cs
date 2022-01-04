using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trip_Planner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ViewCell
    {
        /*
            Used to customize how listView on Trip_PlannerMenu looks
            Can be found in the textbook as ListItemPage.cs
        */
        public ListViewPage()
        {
            InitializeComponent();

            Label titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Aqua
            };
            titleLabel.SetBinding(Label.TextProperty, "Title");
            Label descLabel = new Label
            {

                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 12,
                TextColor = Color.White
            };
            descLabel.SetBinding(Label.TextProperty, "Description");

            Label priceLabel = new Label
            {
                HorizontalOptions = LayoutOptions.End,
                FontSize = 25,
                TextColor = Color.Aqua
            };
            priceLabel.SetBinding(Label.TextProperty, "Price");

            StackLayout viewLayoutItem = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { titleLabel, descLabel }

            };

            StackLayout viewLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(25, 10, 55, 15),
                Children = { viewLayoutItem, priceLabel }
            };

            View = viewLayout;
        }
    }
}