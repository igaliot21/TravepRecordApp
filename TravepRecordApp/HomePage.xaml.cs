using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravepRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravepRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        HomeViewModel viewModel;
        public HomePage(){
            InitializeComponent();
            viewModel = new HomeViewModel();
            this.BindingContext = viewModel;
        }
    }
}