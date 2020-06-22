using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TravepRecordApp.Models;

namespace TravepRecordApp.ViewModel
{
    public class HistoryViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }
        public HistoryViewModel() {
            Posts = new ObservableCollection<Post>();
        }
        public void UpdatePost(){
            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                List<Post> posts = Post.RetrievePost(conn, App.userLogged.Email);
                Posts.Clear();
                foreach (var post in posts) Posts.Add(post);
            }
        }
        public void DeletePost(Post PostToDelete) {
            try{
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                    Post.Delete(conn, PostToDelete);
                }
            }
            catch (Exception ex) { }
        }
    }
}
