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
    public partial class ListHeaderCell : ViewCell
    {
        /*
            This code comes from page 175 of the textbook.
            This code customizes the header cell of the List View
        */
        public ListHeaderCell()
        {
            InitializeComponent();

            //sets the row height for the list headers
            this.Height = 40;

            //defines the characteristics of the list headers
            var title = new Label
            {
                FontSize = 16,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center
            };
            title.SetBinding(Label.TextProperty, "Key");
            View = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 40,
                BackgroundColor = Color.Blue,
                Padding = 5,
                Orientation = StackOrientation.Horizontal,
                Children = { title }
            };
        }
    }
}