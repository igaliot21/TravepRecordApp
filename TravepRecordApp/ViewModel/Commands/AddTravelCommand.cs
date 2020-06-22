using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravepRecordApp.Models;

namespace TravepRecordApp.ViewModel.Commands
{
    public class AddTravelCommand : ICommand
    {
        private AddTravelViewModel viewModel;
        public event EventHandler CanExecuteChanged;
        public AddTravelCommand(AddTravelViewModel viewModel) {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;
            if (post != null)
            {
                if (string.IsNullOrEmpty(post.Experience)) return false;
                if (post != null) return true;
                else return false;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            viewModel.PublishPost(post);
        }
    }
}
