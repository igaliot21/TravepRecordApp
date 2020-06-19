using System;
using System.Collections.Generic;
using System.Text;
using TravepRecordApp.ViewModel.Commands;

namespace TravepRecordApp.ViewModel
{
    public class HomeViewModel
    {
        private NavigationCommand navcommand;
        public HomeViewModel() {
            this.navcommand = new NavigationCommand(this);
        }
        public NavigationCommand navCommand {
            get { return this.navcommand; }
            set { this.navcommand = value; }
        }
        public async void Navigate() {
            await App.Current.MainPage.Navigation.PushAsync(new AddTravelPage());
        }
    }
}
