using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravepRecordApp.Models;

namespace TravepRecordApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterViewModel viewmodel;
        public event EventHandler CanExecuteChanged;
        public RegisterCommand(RegisterViewModel viewModel) {
            this.viewmodel = viewModel;
        }
        public RegisterViewModel registerViewModel {
            get { return this.viewmodel; }
            set { this.viewmodel = value; }
        }

        public bool CanExecute(object parameter)
        {
            User user = (User)parameter;
            if (user == null) return false;
            else
            {
                if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) 
                    || string.IsNullOrEmpty(user.ConfirmPassword)) return false;
                else return true;
            }
        }

        public void Execute(object parameter)
        {
            User user = (User)parameter;
            registerViewModel.Register(user);
        }
    }
}
