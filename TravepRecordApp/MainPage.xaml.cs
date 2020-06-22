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
            viewModel = new MainViewModel();
            this.BindingContext = viewModel;
            //
            var assembly = typeof(MainPage);
            imgMainPage.Source = ImageSource.FromResource("TravepRecordApp.Resources.Images.plane.png",assembly);
        }
    }
}
