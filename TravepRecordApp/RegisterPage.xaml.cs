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
        User user;
        public RegisterPage()
        {
            InitializeComponent();
            user = new User();
            stackRegister.BindingContext = user;
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)  
        {
            if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(entConfirmPassword.Text))
            {
                DisplayAlert("Meeeeeeeeec!", "User fields cannot be empty", "Ok");
                if (string.IsNullOrEmpty(entUser.Text)) entUser.PlaceholderColor = Color.Red;
                if (string.IsNullOrEmpty(entPassword.Text)) entPassword.PlaceholderColor = Color.Red;
                if (string.IsNullOrEmpty(entConfirmPassword.Text)) entConfirmPassword.PlaceholderColor = Color.Red;
            }
            else if (user.Password != entConfirmPassword.Text) {
                DisplayAlert("Meeeeeeeeec!", "Password don't match", "Ok");
            }
            else{
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){ // this way you don't have to remember to close de connection
                    User userExist = User.RetrieveUser(conn, user.Email); // somehow the find methods con the retrieve user won't work if there is a interface
                    if (userExist != null){
                        DisplayAlert("Meeeec!!", "User already exists", "Ok");
                    }
                    else{
                        int rows = User.Insert(conn, user);
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