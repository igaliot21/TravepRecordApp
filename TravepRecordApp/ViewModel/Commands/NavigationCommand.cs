using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravepRecordApp.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {
        private HomeViewModel homeviewmodel;
        public NavigationCommand(HomeViewModel homeViewModel) {
            this.homeviewmodel = homeViewModel;
        }
        public HomeViewModel homeViewModel
        {
            get { return this.homeviewmodel; }
            set { this.homeviewmodel = value; }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            homeViewModel.Navigate(); 
        }
    }
}
