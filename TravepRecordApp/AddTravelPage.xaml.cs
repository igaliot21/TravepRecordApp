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
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace TravepRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTravelPage : ContentPage
    {
        Post newPost;
        public AddTravelPage()
        {
            InitializeComponent();
            newPost = new Post();
            stackNewExperience.BindingContext = newPost;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try{
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);
                if (status != PermissionStatus.Granted) {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location)) {
                        await DisplayAlert("Need permission", "I wasn't really asking... GIVE IT!!", "Sure");
                    }
                    var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    if (result.ContainsKey(Permission.Location)) status = result[Permission.Location];
                }

                if (status == PermissionStatus.Granted) {
                    var locator = CrossGeolocator.Current;
                    var position = await locator.GetPositionAsync();
                    var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
                    listViewVenues.ItemsSource = venues;
                }
                else{
                    await DisplayAlert("No permission", "Well well well... look what we have here.... i won't forgetting this anytime soon... traitor", "Whatever");
                }
            }
            catch (Exception ex) { }
        }

        private void btnSaveTravel_Clicked(object sender, EventArgs e){
            try{
                if (string.IsNullOrEmpty(editExperience.Text)) DisplayAlert("Meeeec!!", "You HAVE to write something, anything, i won't judge... much...", "Ok");
                else
                {
                    Venue selectedVenue       = listViewVenues.SelectedItem as Venue;

                    newPost.ExperienceDate    = DateTimeOffset.Now;  //DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK");
                    newPost.Email             = App.userLogged.Email;
                    newPost.VenueName         = selectedVenue.name;
                    newPost.VenueAddress      = selectedVenue.location.address;
                    newPost.VenueLatitude     = selectedVenue.location.lat;
                    newPost.VenueLongitude    = selectedVenue.location.lng;
                    newPost.VenueCategoryId   = selectedVenue.categories.FirstOrDefault().id;
                    newPost.VenueCategoryName = selectedVenue.categories.FirstOrDefault().name;

                    using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                        int rows = Post.Insert(conn, newPost);
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