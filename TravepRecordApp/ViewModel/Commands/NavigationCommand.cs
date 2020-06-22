﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravepRecordApp.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {
        private HomeViewModel homeviewmodel;
        public event EventHandler CanExecuteChanged;
        public NavigationCommand(HomeViewModel viewModel) {
            this.homeviewmodel = viewModel;
        }
        public HomeViewModel homeViewModel
        {
            get { return this.homeviewmodel; }
            set { this.homeviewmodel = value; }
        }

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
