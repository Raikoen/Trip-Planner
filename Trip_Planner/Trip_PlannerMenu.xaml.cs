using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Trip_PlannerMenu = the main trip selection menu

namespace Trip_Planner 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Trip_PlannerMenu : ContentPage
    {
        //Constructor for ListItem listView from the textbook
        public class ListItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public Type PageName { get; set; }

        }

        //Constructor for ListItem grouped list from the textbook
        public class Group : List<ListItem>
        {
            public String Key { get; private set; }
            public Group(String key, List<ListItem> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Add(item);
            }
        }
        public Trip_PlannerMenu()
        {
            InitializeComponent();

            Title = "Trip Planner Menu";

            //Defines the structure and location of the application's name
            Label appName = new Label
            {
                Text = "Kai's Travel Planner",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Aqua
            };

            //Creates a list of items grouped by categories such as Other Countries
            List<Group> tripList = new List<Group>
            {
                new Group ("United States", new List<ListItem>
                {
                    new ListItem { Title = "Colorado", Description="Visit Maroon Lake Trail", PageName=typeof(Colorado_Details)},
                    new ListItem { Title = "Nebraska", Description = "Visit the Sunken Gardens", PageName=typeof(Nebraska_Details)},
                    new ListItem { Title = "Oregon", Description="Visit Florence and Heceda Head", PageName=typeof(Oregon_Details)},
                    new ListItem { Title = "Pennsylvania", Description="Visit the Raymondskill Falls", PageName=typeof(Pennsylvania_Details)}
                }),
                new Group ("Other Countries", new List<ListItem>{

                    new ListItem { Title = "China", Description="Visit the Great Wall", PageName=typeof(China_Details)},
                    new ListItem { Title = "Japan", Description="Visit the Sankeien Gardens", PageName=typeof(Japan_Details)},
                    new ListItem { Title = "England", Description="Visit the Malham Cove", PageName=typeof(England_Details)},
                    new ListItem { Title = "Russia", Description="Visit the Tobizin Cape", PageName=typeof(Russia_Details)}
                })
            };

            //Defines the display characteristics of the grouped list
            ListView listView = new ListView()
            {
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Key"),

                //Binds listView's category headings to customizations found in ListHeaderCell
                GroupHeaderTemplate = new DataTemplate(typeof(ListHeaderCell)),
                HasUnevenRows = true,

                ItemTemplate = new DataTemplate(typeof(TextCell))
                {
                    Bindings =
                    {
                        { TextCell.TextProperty, new Binding("Title") },
                        { TextCell.DetailProperty, new Binding("Description") }
                    }
                }
            };

            //sets the list's data source as the tripList grouped list
            listView.ItemsSource = tripList;
            listView.RowHeight = 100;
            listView.BackgroundColor = Color.Black;

            //Binds the listView to the customizations found in ListViewPage
            listView.ItemTemplate = new DataTemplate(typeof(ListViewPage));
            Content = listView;

            //Allows listView to open a different page when an item is clicked
            listView.ItemTapped += async (sender, args) =>
            {
                var item = args.Item as ListItem;
                if (item == null) return;
                Page page = (Page)Activator.CreateInstance(item.PageName);
                await Navigation.PushAsync(page);
                listView.SelectedItem = null;
            };

            Button newTripBtn = new Button
            {
                Text = "Plan a new trip",
                TextColor = Color.White,
                BackgroundColor = Color.Teal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            /*
                Intiates a new instance of the Travel_Plan_TabPage.
                When clicked, the user can create a new trip plan
            */
            newTripBtn.Clicked += async (sendernav, args) =>
                await Navigation.PushAsync(new Travel_Plan_TabPage());

            StackLayout stackLayout = new StackLayout
            {
                Children = { appName, listView, newTripBtn },
                HorizontalOptions = LayoutOptions.Center

            };

            //Sets the contents of stackLayout as something scrollable
            ScrollView scrollView = new ScrollView { Content = stackLayout };

            Content = scrollView;
         
        }
    }
}