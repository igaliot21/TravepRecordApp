using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravepRecordApp.Models;
using TravepRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravepRecordApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage(){
            InitializeComponent();
            var assembly = typeof(MainPage);
            viewModel = new MainViewModel();
            this.BindingContext = viewModel;
            imgMainPage.Source = ImageSource.FromResource("TravepRecordApp.Resources.Images.plane.png",assembly);
        }

        private void RegisterUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
