using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public MainPage()
        {
            InitializeComponent();
            var assembly = typeof(MainPage);
            imgMainPage.Source = ImageSource.FromResource("TravepRecordApp.Resources.Images.plane.png",assembly);
        }

        private void LogInButton_Clicked(object sender, EventArgs e)
        {
            bool switchEnter = false;
            if (string.IsNullOrEmpty(entUser.Text))
            {
                entUser.Placeholder = "Enter User Email";
                entUser.PlaceholderColor = Color.Red;
                switchEnter = false;
            }
            else
            {
                if (string.IsNullOrEmpty(entPassword.Text))
                {
                    entPassword.Placeholder = "Enter User Password";
                    entPassword.PlaceholderColor = Color.Red;
                    switchEnter = false;
                }
                else switchEnter = true;
            }
            /*
                        string MySQLConnectionString = "Server=192.168.1.20;Database=Curso_SQL;Uid=XamarinTest;Pwd=xamarintest;Port=3306;";
                        string MySQLQuery = "SELECT * FROM `CLIENTES` LIMIT 0 , 30";

                        try
                        {
                            using (MySqlConnection MySQLconn = new MySqlConnection(MySQLConnectionString))
                            {
                                MySQLconn.Open();
                                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(MySQLQuery, MySQLconn);
                                DataTable MySQLTable = new DataTable();
                                MySQLTable.TableName = "";
                                mySqlDataAdapter.Fill(MySQLTable);
                            }
                        }
                        catch(Exception ex) {
                            string ex_message = ex.Message;
                            string ex_stacktrace = ex.StackTrace;
                        }
            */

            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation))
            {
                conn.CreateTable<User>();
                User userLogging = conn.Table<User>().ToList().Find(u => u.Email == entUser.Text && u.Password == entPassword.Text);
                //List<User> userTable = conn.Table<User>().ToList();
                //User userLogged = userTable.Find(u => u.Email == entUser.Text && u.Password == entPassword.Text);
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
