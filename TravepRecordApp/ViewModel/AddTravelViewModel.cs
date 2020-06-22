using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravepRecordApp.Models;
using TravepRecordApp.ViewModel.Commands;

namespace TravepRecordApp.ViewModel
{
    public class AddTravelViewModel:INotifyPropertyChanged
    {
        public AddTravelCommand addTravelCommand { get; set; }
        private Venue venue;
        private Post post;
        private string experience;

        public AddTravelViewModel() {
            addTravelCommand = new AddTravelCommand(this);
            Venue = new Venue();
            Post = new Post();
        }

        public Post Post {
            get { return this.post; }
            set {
                this.post = value;
                OnPropertyChanged("Post");
            }
        }
        public string Experience {
            get { return this.experience; }
            set {
                this.experience = value;
                // Post = new Post(this.experience, this.venue);
                OnPropertyChanged("Experience");
            }
        }
        public Venue Venue{
            get { return this.venue; }
            set{
                this.venue = value;
                // Post = new Post(this.experience, this.venue);
                OnPropertyChanged("Venue");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PublishPost(Post post) {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation))
                { // this way you don't have to remember to close de connection
                    int rows = Post.Insert(conn, post);
                    if (rows > 0)
                    {
                        App.Current.MainPage.DisplayAlert("Sucess", "Experience succesfully inserted", "Ok");
                        App.Current.MainPage.Navigation.PushAsync(new HomePage());
                    }
                    else App.Current.MainPage.DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
                }
            }
            catch (NullReferenceException nrex)
            {
                App.Current.MainPage.DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Meeeec!!", "Experience failed to be inserted", "Ok");
            }
        }
    }
}
