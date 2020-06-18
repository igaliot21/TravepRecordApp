using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravepRecordApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravepRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            /*
            SQLiteConnection conn = new SQLiteConnection(App.DBLocation);
            conn.CreateTable<Post>();
            var posts = conn.Table<Post>().ToList(); // create a list of Post objects aka a list or registers in the database
            conn.Close();
            */

            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)) // this way you don't have to remember to close de connection
            {
                conn.CreateTable<Post>();
                //List<Post> posts = conn.Table<Post>().ToList();
                List<Post> posts = conn.Table<Post>().Where(p => p.Email == App.userLogged.Email).ToList();
                //var posts = conn.Table<Post>().ToList();
                listViewPost.ItemsSource = posts;
            }
        }

        private void btnDeleteHistory_Clicked(object sender, EventArgs e)
        {
            try
            {
                Post selectedHistory = listViewPost.SelectedItem as Post;
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)) // this way you don't have to remember to close de connection
                {
                    conn.Delete(selectedHistory);
                    List<Post> posts = conn.Table<Post>().ToList();
                    listViewPost.ItemsSource = posts;
                }
            }
            catch (Exception ex) { }
        }
    }
}