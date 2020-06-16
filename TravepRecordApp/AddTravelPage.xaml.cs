using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravepRecordApp.Models;
using SQLite;
using System.Data;
using Plugin.Geolocator;
using TravepRecordApp.Logic;

namespace TravepRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTravelPage : ContentPage
    {
        public AddTravelPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await VenueLogic.GetVenues(position.Latitude,position.Longitude);

        }

        private void btnSaveTravel_Clicked(object sender, EventArgs e)
        {
            Post post = new Post(editExperience.Text);

            /*
            SQLiteConnection conn = new SQLiteConnection(App.DBLocation);
            conn.CreateTable<Post>();
            int rows=conn.Insert(post); //this returns the number of rows inserted
            conn.Close();
            */
            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)) // this way you don't have to remember to close de connection
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post); //this returns the number of rows inserted

                if (rows > 0){
                    DisplayAlert("Sucess", "Experience succesfully inserted", "Ok");
                    Navigation.PushAsync(new HomePage());
                }
                else DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
            }
        }
    }

}