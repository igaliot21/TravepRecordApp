using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravepRecordApp
{
    public partial class App : Application
    {
        public static string DBLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // if you more than one page on you app you need a navigation page to take care of the back and forth between pages
        }
        public App(string dbLocation) {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DBLocation = dbLocation;
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
