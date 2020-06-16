using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await locator.StartListeningAsync(new TimeSpan(0,0,10), 50);

            var position = await locator.GetPositionAsync();

            locationsMap.MoveToRegion(new MapSpan(new Position(position.Latitude, position.Longitude), 2, 2));
            /*
            Position center = new Position(position.Latitude, position.Longitude);
            MapSpan span = new MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);
            */
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            locationsMap.MoveToRegion(new MapSpan(new Position(e.Position.Latitude,e.Position.Longitude), 2, 2));
        }
    }
}