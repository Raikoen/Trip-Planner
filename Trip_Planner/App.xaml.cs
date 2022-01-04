using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trip_Planner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            //Sets Trip_PlannerMenu as the first page to be loaded
            MainPage = new NavigationPage(new Trip_PlannerMenu());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
