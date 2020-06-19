using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravepRecordApp.Models;
using TravepRecordApp.ViewModel.Commands;

namespace TravepRecordApp.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private User user;
        private LoginCommand logincommand;
        private string email;
        private string password;
        public MainViewModel() {
            this.user = new User();
            this.logincommand = new LoginCommand(this);
        }
        public User User {
            get { return this.user; }
            set { 
                this.user = value;
                OnPropertyChanged("User");
            }
        }
        public LoginCommand loginCommand {
            get { return this.logincommand; }
            set { this.logincommand = value; }
        }
        public string Email {
            get { return this.email; }
            set { 
                this.email = value;
                User = new User(this.Email, this.Password);
                OnPropertyChanged("Email");
            }
        }
        public string Password{
            get { return this.password; }
            set { 
                this.password = value;
                User = new User(this.Email, this.Password);
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName){
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Login() {
            bool switchEnter = false;
            if (string.IsNullOrEmpty(user.Email)){
                switchEnter = false;
            }
            else{
                if (string.IsNullOrEmpty(user.Password)){
                    switchEnter = false;
                }
                else switchEnter = true;
            }
            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){
                User userLogging = User.RetrieveUser(conn, user.Email, user.Password);
                if (userLogging == null){
                    App.Current.MainPage.DisplayAlert("Meeeec!!", "Email or password are incorrect", "Ok");
                    switchEnter = false;
                }
                else App.userLogged = userLogging;
            }
            if (switchEnter) App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}
