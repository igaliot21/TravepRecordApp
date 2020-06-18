using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravepRecordApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravepRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            locationsMap.IsShowingUser = true;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.Zero, 100);

            var position = await locator.GetPositionAsync();

            locationsMap.MoveToRegion(new MapSpan(new Position(position.Latitude, position.Longitude), 2, 2));
            /*
            Position center = new Position(position.Latitude, position.Longitude);
            MapSpan span = new MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);
            */
            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)) // this way you don't have to remember to close de connection
            {
                conn.CreateTable<Post>();
                List<Post> posts = conn.Table<Post>().Where(p => p.Email == App.userLogged.Email).ToList();

                DisplayInMap(posts);
            }
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;
            await locator.StopListeningAsync();
             
        }

        private void DisplayInMap(List<Post> posts)
        {

            foreach (Post post in posts)
            {
                try
                {
                    Position position = new Position(post.VenueLatitude, post.VenueLongitude);
                    Pin pin = new Pin()
                    {
                        Type = PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.VenueAddress
                    };
                    locationsMap.Pins.Add(pin);
                }
                catch (NullReferenceException nrex) { }
                catch (Exception ex) { }
            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            locationsMap.MoveToRegion(new MapSpan(new Position(e.Position.Latitude,e.Position.Longitude), 2, 2));
        }
    }
}