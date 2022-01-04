using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Travel_Expenses = the default form dedicated to a new trip's travel expenses

namespace Trip_Planner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Travel_Expenses : ContentPage
    {
        public Travel_Expenses()
        {
            InitializeComponent();

            Title = "Travel Expenses";

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
                Text = "Travel Expenses",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };

            //Transportation Expenses

            Label airline_OptionsLabel = new Label
            {
                Text = "Airline Options",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            Picker airlinePicker = new Picker
            {
                Title = "Pick an airline",
                VerticalOptions = LayoutOptions.Center
            };
            var airlines = new List<string>
            {
                "I'm driving", "American Airlines, AA34F\n$300.00", "Spirit, SA24F\n$150.00", "United Airlines, UA14F\n$250.00"
            };
            foreach (string optionName in airlines)
            {
                airlinePicker.Items.Add(optionName);
            }

            //Sets the default value to "I'm driving" at index = [0]
            airlinePicker.SelectedIndex = 0;


            Label carRental_Label = new Label()
            {
                Text = "Car Rental Company",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            Picker car_RentalPicker = new Picker
            {
                Title = "Pick a car rental company",
                VerticalOptions = LayoutOptions.Center
            };
            var carRental_Deals = new List<string>
            {
                "I'm flyng", "Enterprise, $100.00\nChevy Suburban",
                "Hertz, $150.00\nHonda Accord", "Thrifty, $200.00\nDodge Ram"
            };
            foreach (string optionName in carRental_Deals)
            {
                car_RentalPicker.Items.Add(optionName);
            }
            car_RentalPicker.SelectedIndex = 0;

            //Hotel Expenses 

            Label pickHotel_Label = new Label()
            {
                Text = "Hotel Options",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            Picker hotelPicker = new Picker
            {
                Title = "Pick a hotel",
                VerticalOptions = LayoutOptions.Center
            };
            var hotels = new List<string>
            {
                "Cottage Inn", "Hampton Inn", "Marriott Inn"
            };
            foreach (string optionName in hotels)
            {
                hotelPicker.Items.Add(optionName);
            }
            hotelPicker.SelectedIndex = 0;


            Label pickHotel_RoomLabel = new Label()
            {
                Text = "Reservations",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            Picker hotelRoomPicker = new Picker
            {
                Title = "Pick a room",
                VerticalOptions = LayoutOptions.Center
            };
            var rooms = new List<string>
            {
                "Single\n$100.00", "Double\n$150.00", "Suite\n$200.00"
            };
            foreach (string optionName in rooms)
            {
                hotelRoomPicker.Items.Add(optionName);
            }
            hotelRoomPicker.SelectedIndex = 0;

            //Meal Plans

            Label pickMealPlan_Label = new Label()
            {
                Text = "Meal Plans",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000066")
            };
            Picker meal_Picker = new Picker
            {
                Title = "Pick a meal plan",
                VerticalOptions = LayoutOptions.Center
            };
            var meals = new List<string>
            {
                "1-Day\n$50.00", "7-Day\n$350.00", "14-Day\n$700.00"
            };
            foreach (string optionName in meals)
            {
                meal_Picker.Items.Add(optionName);
            }
            meal_Picker.SelectedIndex = 0;


            Button button = new Button
            {
                Text = "Trip Planner Menu",
                TextColor = Color.White,
                BackgroundColor = Color.Teal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            button.Clicked += async (sendernav, args) =>
                await Navigation.PushAsync(new Trip_PlannerMenu());

            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    banner,
                    pageHeading,
                    airline_OptionsLabel,
                    airlinePicker,
                    carRental_Label,
                    car_RentalPicker,
                    pickHotel_Label,
                    hotelPicker,
                    pickHotel_RoomLabel,
                    hotelRoomPicker,
                    pickMealPlan_Label,
                    meal_Picker,
                    button
                }
            };
            ScrollView scrollView = new ScrollView { Content = stackLayout };
            Content = scrollView;
        }
    }
}