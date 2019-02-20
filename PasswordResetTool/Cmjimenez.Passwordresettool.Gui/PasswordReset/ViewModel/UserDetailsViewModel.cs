using Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Cmjimenez.PasswordResetTool.Application.Navigation.Messages;
using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;


namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel
{
    public class UserDetailsViewModel : ModifiedBaseViewModel
    {
        private User _user;
        
        public RelayCommand ResetCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public string BannerID
        {
            get { return _user.BannerID.Value; }
        }

        public string SamAccountName
        {
            get { return _user.SamAccountName; }
        }

        public string FullName
        {
            get { return _user.FullName; }
        }

      

        public UserDetailsViewModel()
        {
            Messenger.Default.Register<UserDetailsMessage>(this, msg => {
                _user = msg.User;   
            });

            ResetCommand = new RelayCommand(OnResetCommand);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }

        private void OnResetCommand()
        {
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage("passwordreset"));
        }

        private void OnCancelCommand()
        {
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage("cancel"));
        }
    }
}
