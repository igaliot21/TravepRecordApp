using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravepRecordApp.Models;

namespace TravepRecordApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        private MainViewModel mainviewmodel;
        public event EventHandler CanExecuteChanged;
        public LoginCommand(MainViewModel viewModel) {
            this.mainviewmodel = viewModel;
        }
        public MainViewModel mainViewModel {
            get { return this.mainviewmodel; }
            set { this.mainviewmodel = value; }
        }
        public bool CanExecute(object parameter)
        {
            User user = (User)parameter;
            if (user == null) return false;
            else{
                if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password)) return false;
                else return true;
            }
        }
        public void Execute(object parameter)
        {
            mainViewModel.Login();
        }
    }
}
