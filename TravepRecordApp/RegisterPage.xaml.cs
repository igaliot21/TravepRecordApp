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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)  
        {
            if(string.IsNullOrEmpty(entUser.Text) || string.IsNullOrEmpty(entPassword.Text) || string.IsNullOrEmpty(entConfirmPassword.Text))
            {
                DisplayAlert("Meeeeeeeeec!", "User fields cannot be empty", "Ok");
                if (string.IsNullOrEmpty(entUser.Text)) entUser.PlaceholderColor = Color.Red;
                if (string.IsNullOrEmpty(entPassword.Text)) entPassword.PlaceholderColor = Color.Red;
                if (string.IsNullOrEmpty(entConfirmPassword.Text)) entConfirmPassword.PlaceholderColor = Color.Red;
            }
            else if (entPassword.Text != entConfirmPassword.Text) {
                DisplayAlert("Meeeeeeeeec!", "Password don't match", "Ok");
            }
            else{
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                    User userExist = User.RetrieveUser(conn, entUser.Text);
                    if (userExist != null){
                        DisplayAlert("Meeeec!!", "User already exists", "Ok");
                    }
                    else{
                        int rows = User.Insert(conn, entUser.Text, entPassword.Text);
                        if (rows > 0){
                            DisplayAlert("Success", "User registered", "Ok");
                            Navigation.PushAsync(new MainPage());
                        }
                        else DisplayAlert("Meeeec!!", "Something went wrong, user not registered", "Ok");
                    }
                }
            }
        }
    }
}