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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation)) // this way you don't have to remember to close de connection
                {
                    conn.CreateTable<Post>();
                    List<Post> postTable = conn.Table<Post>().Where(p => p.Email == App.userLogged.Email).ToList();
                    lblPostCount.Text = postTable.Count.ToString();

                    List<string> categories  = (from p in postTable orderby p.VenueCategoryId select p.VenueCategoryName).Distinct().ToList();
                    // List<string> categroies2 = postTable.OrderBy(p => p.VenueCategoryId).Select(p => p.VenueCategoryName).Distinct().ToList(); // the same as before just simplier, i prefer the full linq method

                    Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                    
                    foreach (string category in categories) {
                        
                        int count = (from p in postTable where p.VenueCategoryName == category select p).Count();
                        
                        //int count = postTable.Where(p => p.VenueCategoryName == category).Count(); // the same as before just simplier, i prefer the full linq method
                        
                        categoriesCount.Add(category, count);

                    }
                    listviewCategories.ItemsSource = categoriesCount;
                }
            }
            catch (Exception ex) { }
        }
    }
}