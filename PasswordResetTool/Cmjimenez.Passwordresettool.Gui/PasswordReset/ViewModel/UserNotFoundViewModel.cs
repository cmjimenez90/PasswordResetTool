using GalaSoft.MvvmLight.Messaging;
using Cmjimenez.PasswordResetTool.Application.Navigation.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel
{
    public class UserNotFoundViewModel : ModifiedBaseViewModel
    {
        private string _bannerID;

        public RelayCommand ConfirmCommand { get; private set; }

        public string BannerID
        {
            get { return _bannerID; }
        }

        public UserNotFoundViewModel()
        {
           
            Messenger.Default.Register<UserNotFoundMessage>(this, msg => {
                _bannerID = msg.BannerID.Value;
            });

            ConfirmCommand = new RelayCommand(OnConfirmCommand);
        }

        private void OnConfirmCommand()
        {
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage("cancel"));
        }
    }
}
