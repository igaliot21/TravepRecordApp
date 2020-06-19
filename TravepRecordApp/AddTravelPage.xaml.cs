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
            var venues = await Venue.GetVenues(position.Latitude,position.Longitude);
            
            listViewVenues.ItemsSource = venues;
        }

        private void btnSaveTravel_Clicked(object sender, EventArgs e){
            try{
                if (string.IsNullOrEmpty(editExperience.Text)) DisplayAlert("Meeeec!!", "You HAVE to write something, anything, i won't judge... much...", "Ok");
                else
                {
                    Venue selectedVenue = listViewVenues.SelectedItem as Venue;
                    Post post = new Post(editExperience.Text,App.userLogged.Email, selectedVenue.name, selectedVenue.location.address,
                                         selectedVenue.location.lat, selectedVenue.location.lng,
                                         selectedVenue.categories.FirstOrDefault().id, selectedVenue.categories.FirstOrDefault().name);
                    using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                        int rows = Post.Insert(conn, post);
                        if (rows > 0){
                            DisplayAlert("Sucess", "Experience succesfully inserted", "Ok");
                            Navigation.PushAsync(new HomePage());
                        }
                        else DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
                    }
                }
            }
            catch (NullReferenceException nrex){
                DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
            }
            catch (Exception ex) {
                DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
            }
        }
    }

}