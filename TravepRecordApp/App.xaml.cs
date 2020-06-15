using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravepRecordApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // if you more than one page on you app you need a navigation page to take care of the back and forth between pages
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
