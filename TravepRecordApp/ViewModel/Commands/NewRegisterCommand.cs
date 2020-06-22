using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravepRecordApp.ViewModel.Commands
{
    public class NewRegisterCommand : ICommand

    {
        private MainViewModel mainviewmodel;
        public event EventHandler CanExecuteChanged;
        public NewRegisterCommand(MainViewModel viewModel) {
            this.mainviewmodel = viewModel;
        }
        public MainViewModel mainViewModel{
            get { return this.mainviewmodel; }
            set { this.mainviewmodel = value; }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mainViewModel.NewRegister();
        }
    }
}
