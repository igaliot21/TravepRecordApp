using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravepRecordApp.Models;
using TravepRecordApp.ViewModel.Commands;

namespace TravepRecordApp.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private RegisterCommand registerommand;
        private User user;
        private string email;
        private string password;
        private string confirmpassword;

        public RegisterViewModel() {
            this.registerCommand = new RegisterCommand(this);
        }
        public User User{
            get { return this.user; }
            set{
                this.user = value;
                OnPropertyChanged("User");
            }
        }
        public string Email{
            get { return this.email; }
            set{
                this.email = value;
                User = new User(this.Email, this.Password, this.ConfirmPassword);
                OnPropertyChanged("Email");
            }
        }
        public string Password{
            get { return this.password; }
            set{
                this.password = value;
                User = new User(this.Email, this.Password, this.ConfirmPassword);
                OnPropertyChanged("Password");
            }
        }
        public string ConfirmPassword{
            get { return this.confirmpassword; }
            set
            {
                this.confirmpassword = value;
                User = new User(this.Email, this.Password,this.ConfirmPassword);
                OnPropertyChanged("ConfirmPassword");
            }
        }
        public RegisterCommand registerCommand {
            get { return this.registerommand; }
            set { this.registerommand = value; }
        }
        private void OnPropertyChanged(string propertyName){
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public async void Register(User user) {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword)){
                await App.Current.MainPage.DisplayAlert("Meeeeeeeeec!", "User fields cannot be empty", "Ok");
            }
            else if (user.Password != user.ConfirmPassword){
                await App.Current.MainPage.DisplayAlert("Meeeeeeeeec!", "Password don't match", "Ok");
            }
            else{
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                    User userExist = User.RetrieveUser(conn, user.Email); 
                    if (userExist != null){
                        await App.Current.MainPage.DisplayAlert("Meeeec!!", "User already exists", "Ok");
                    }
                    else{
                        int rows = User.Insert(conn, user);
                        if (rows > 0){
                            await App.Current.MainPage.DisplayAlert("Success", "User registered", "Ok");
                            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
                        }
                        else await App.Current.MainPage.DisplayAlert("Meeeec!!", "Something went wrong, user not registered", "Ok");
                    }
                } 
            }
        }

    }
}
