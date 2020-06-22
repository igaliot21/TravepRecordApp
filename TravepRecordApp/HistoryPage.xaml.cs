using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravepRecordApp.Models;
using TravepRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravepRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;
        public HistoryPage(){
            InitializeComponent();
            viewModel = new HistoryViewModel();
            this.BindingContext = viewModel;
        }
        protected override void OnAppearing(){
            base.OnAppearing();
            viewModel.UpdatePost();
        }

        private void btnDeleteHistory_Clicked(object sender, EventArgs e){
            Post selectedHistory = listViewPost.SelectedItem as Post;
            viewModel.DeletePost(selectedHistory);
            viewModel.UpdatePost();
        }
    }
}