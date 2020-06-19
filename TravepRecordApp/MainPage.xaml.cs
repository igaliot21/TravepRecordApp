using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravepRecordApp.Models;
using Xamarin.Forms;

namespace TravepRecordApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage(){
            InitializeComponent();
            var assembly = typeof(MainPage);
            imgMainPage.Source = ImageSource.FromResource("TravepRecordApp.Resources.Images.plane.png",assembly);
        }

        private void LogInButton_Clicked(object sender, EventArgs e){
            bool switchEnter = false;
            if (string.IsNullOrEmpty(entUser.Text)){
                entUser.Placeholder = "Enter User Email";
                entUser.PlaceholderColor = Color.Red;
                switchEnter = false;
            }
            else{
                if (string.IsNullOrEmpty(entPassword.Text))
                {
                    entPassword.Placeholder = "Enter User Password";
                    entPassword.PlaceholderColor = Color.Red;
                    switchEnter = false;
                }
                else switchEnter = true;
            }
            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)){
                User userLogging = User.RetrieveUser(conn, entUser.Text, entPassword.Text);
                if (userLogging == null) {
                    DisplayAlert("Meeeec!!", "Email or password are incorrect", "Ok");
                    switchEnter = false;
                }
                else App.userLogged = userLogging;
            }
            if (switchEnter)Navigation.PushAsync(new HomePage());
        }
        private void RegisterUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
