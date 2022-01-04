using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Trip_Details = default form for creating a new travel plan's basic information

namespace Trip_Planner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Trip_Details : ContentPage
    {

        public Trip_Details()
        {
            InitializeComponent();

            Title = "Trip Information";

            //sets dimensions for the banner image
            Image banner = new Image
            {
                //https://www.clipartmax.com/png/middle/30-301819_tourist-travel-icon-png.png
                Source = "TravelingIcon.PNG",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                WidthRequest = 500,
                HeightRequest = 100
            };
            Label pageHeading = new Label()
            {
                Text = "General Trip Information",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(0, 10, 0, 0),
                TextColor = Color.FromHex("#000066")
            };

            Label pickDestinationLabel = new Label()
            {
                Text = "Destinations",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(0, 10, 0, 0),
                TextColor = Color.FromHex("#000066")
            };

            //declares a new instance of Picker and defines its title and position
            Picker destinationPicker = new Picker
            {
                Title = "Pick a Destination",
                VerticalOptions = LayoutOptions.Center
            };
            var destinations = new List<string>
            {
                "Colorado", "Nebraska", "Oregon", "Pennsylvania",
                "China", "Japan", "England", "Russia"
            };

            //for loop that adds each item in the list above to an array
            foreach (string optionName in destinations)
            {
                destinationPicker.Items.Add(optionName);
            }
            destinationPicker.SelectedIndex = 0;

            Label tripDescriptionLabel = new Label()
            {
                Text = "Trip Description",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(0, 10, 0, 0),
                TextColor = Color.FromHex("#000066")
            };
            Entry tripDescription = new Entry
            {
                Placeholder = "Briefly describe your travel plans"
            };

            Label tripPurposeLabel = new Label()
            {
                Text = "Pick a reason for your visit",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(0, 10, 0, 0),
                TextColor = Color.FromHex("#000066")
            };
            Picker pickTripPurpose = new Picker
            {
                Title = "Why are you traveling?",
                VerticalOptions = LayoutOptions.Center
            };
            var tripPurpose = new List<string>
            {
                "Vacation", "Sabbatical", "Amusement", "Educational"
            };

            //for loop that adds each item in the list above to an array
            foreach (string optionName in tripPurpose)
            {
                pickTripPurpose.Items.Add(optionName);
            }
            pickTripPurpose.SelectedIndex = 0;

            Label tripStartLabel = new Label()
            {
                Text = "Start Date: ",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            DatePicker startDate = new DatePicker
            {
                MinimumDate = new DateTime(2020, 1, 1),
                Date = new DateTime(2020, 1, 1)
            };

            Label tripEndLabel = new Label()
            {
                Text = "End Date: ",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            DatePicker endDate = new DatePicker
            {
                MinimumDate = new DateTime(2020, 1, 2),
                MaximumDate = new DateTime(2021, 1, 1),
                Date = new DateTime(2020, 1, 2)
            };

            Label travelerNameLabel = new Label
            {
                Text = "Traveler Name(s)",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            Entry travelerName = new Entry()
            {
                Placeholder = "Who is going on this trip with you?"
            };

            Button button = new Button
            {
                Text = "Trip Planner Menu",
                TextColor = Color.White,
                BackgroundColor = Color.Teal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            //Event that takes the user back to the Trip Planner Menu page
            button.Clicked += async (sendernav, args) =>
                await Navigation.PushAsync(new Trip_PlannerMenu());

            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    banner,
                    pageHeading,
                    pickDestinationLabel,
                    destinationPicker,
                    tripDescriptionLabel,
                    tripDescription,
                    tripPurposeLabel,
                    pickTripPurpose,
                    tripStartLabel,
                    startDate,
                    tripEndLabel,
                    endDate,
                    travelerNameLabel,
                    travelerName,
                    button
                },

            };

            ScrollView scrollView = new ScrollView { Content = stackLayout };

            Content = scrollView;
        }
    }
}