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

namespace TravepRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTravelPage : ContentPage
    {
        public AddTravelPage()
        {
            InitializeComponent();
        }

        private void btnSaveTravel_Clicked(object sender, EventArgs e)
        {
            Post post = new Post(editExperience.Text);
            SQLiteConnection conn = new SQLiteConnection(App.DBLocation);
            conn.CreateTable<Post>();
            int rows=conn.Insert(post);
            conn.Close();

            if (rows > 0) DisplayAlert("Sucess","Experience succesfully inserted","Ok");
            else DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
        }
    }
}