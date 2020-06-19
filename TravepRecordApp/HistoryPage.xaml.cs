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
        public HistoryPage(){
            InitializeComponent();
        }
        protected override void OnAppearing(){
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                List<Post> posts = Post.RetrievePost(conn, App.userLogged.Email);
                listViewPost.ItemsSource = posts;
            }
        }

        private void btnDeleteHistory_Clicked(object sender, EventArgs e){
            try{
                Post selectedHistory = listViewPost.SelectedItem as Post;
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                    Post.Delete(conn, selectedHistory);
                    List<Post> posts = Post.RetrievePost(conn, App.userLogged.Email);
                    listViewPost.ItemsSource = posts;
                }
            }
            catch (Exception ex) { }
        }
    }
}