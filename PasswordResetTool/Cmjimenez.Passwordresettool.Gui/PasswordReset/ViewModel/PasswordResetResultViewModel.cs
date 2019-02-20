using Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages;
using Cmjimenez.PasswordResetTool.Application.Navigation.Messages;
using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel
{
    public class PasswordResetResultViewModel : ModifiedBaseViewModel
    {
        private User _user;
        private bool _resetSucces;
        private bool _hasErrors;
        private string _errorMessage;

        public RelayCommand ConfirmCommand { get; private set; }

        public string SamAccountName
        {
            get { return _user.SamAccountName; }
        }

        public string BannerID
        {
            get { return _user.BannerID.Value; }
        }

        public bool IsSuccessful
        {
            get { return _resetSucces; }
        }

        public string ErrorMessage { get { return _errorMessage; } }

        public PasswordResetResultViewModel()
        {
            Messenger.Default.Register<PasswordChangeSuccessMessage>(this, msg => 
            {
                _user = msg.ResetResult.User;
                _resetSucces = msg.ResetResult.PasswordChanged;
                _hasErrors = msg.ResetResult.HasErrorMessage;
                if (_hasErrors)
                {
                    _errorMessage = msg.ResetResult.FailureMessage;
                }
            });

            ConfirmCommand = new RelayCommand(OnConfirmCommand);
        }

        private void OnConfirmCommand()
        {
            _errorMessage = null;
            _hasErrors = false;
            _resetSucces = false;
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage("cancel"));
        }
    }
}
