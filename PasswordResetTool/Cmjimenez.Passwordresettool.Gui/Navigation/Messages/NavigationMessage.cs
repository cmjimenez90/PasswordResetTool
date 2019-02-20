using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;

namespace Cmjimenez.PasswordResetTool.Application.Navigation.Messages
{
   public class NavigationMessage
    {
        private string _viewModel;

        public string ViewModel { get { return _viewModel; } }

        public NavigationMessage(string viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
