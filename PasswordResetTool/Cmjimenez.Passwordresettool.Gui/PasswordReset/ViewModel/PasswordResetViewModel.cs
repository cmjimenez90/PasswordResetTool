using Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages;
using Cmjimenez.PasswordResetTool.Application.Navigation.Messages;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel
{
    public class PasswordResetViewModel : ModifiedBaseViewModel
    {
        private IUserAccountService _userAccountService;
        private User _user;
        private string _newPassword;
        private string _confirmPassword;

        public RelayCommand ResetPasswordCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public string NewPassword
        {
            get { return _newPassword; }

            set
            {
                _newPassword = value;
                RaisePropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                RaisePropertyChanged();
            }
        }

        public string SamAccountName
        {
            get { return _user.SamAccountName; }
        }

        public string BannerID
        {
            get { return _user.BannerID.Value; }
        }
           
        public PasswordResetViewModel(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;

            Messenger.Default.Register<UserDetailsMessage>(this, msg => 
            {
                _user = msg.User;
            });

            ResetPasswordCommand = new RelayCommand(OnResetPasswordCommand);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }

        private void OnResetPasswordCommand()
        {
            if((_newPassword == null || _confirmPassword == null) || _newPassword.Equals(_confirmPassword) == false)
            {
                this.AddError("NewPassword", "New Password Does Not Match Confirmation Password");
            }
            else
            {
                this.RemoveError("NewPassword");
                ResetResult result = _userAccountService.ChangeUserPassword(_user, _newPassword);
                Messenger.Default.Send<PasswordChangeSuccessMessage>(new PasswordChangeSuccessMessage(result));
                Messenger.Default.Send<NavigationMessage>(new NavigationMessage("resetresult"));
                NewPassword = null;
                ConfirmPassword = null;
            }
        }

        private void OnCancelCommand()
        {
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage("cancel"));
            NewPassword = null;
            ConfirmPassword = null;
        }


    }
}
