using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages;
using Cmjimenez.PasswordResetTool.Application.Navigation.Messages;
using GalaSoft.MvvmLight.CommandWpf;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel
{
    public class BannerIDSearchViewModel : ModifiedBaseViewModel
    {
        private IUserAccountService _userSearchService;
        private BannerID _bannerID;
        public  RelayCommand SearchUserByBannerIDCommand { get; private set; }
        public  RelayCommand CloseCommand { get; private set; }
        public BannerID BannerID
        {
            get { return this._bannerID; }
            set
            {
                _bannerID = value;
                RaisePropertyChanged("BannerID");
            }
        }
        public BannerIDSearchViewModel(IUserAccountService userSearchService)
        {
            _userSearchService = userSearchService;
            SearchUserByBannerIDCommand = new RelayCommand(OnSearchUserByBannerIDCommand);
            CloseCommand = new RelayCommand(OnCloseCommand);
        }


        private void OnSearchUserByBannerIDCommand()
        {
            if(_bannerID != null)
            {
                User user = _userSearchService.SearchUserByBannerID(_bannerID);
                if (user != null)
                {
                    BannerID = null;
                    SendUserFoundMessage(user);
                    SendNavigationMessage("userdetail");
                }
                else
                {
                    SendUserNotFoundMessage(_bannerID);
                    SendNavigationMessage("usernotfound");
                    BannerID = null;
                }
            }
        }

        private void OnCloseCommand()
        {
            Messenger.Default.Send<CloseMessage>(new CloseMessage());
        }
      
        private void SendUserFoundMessage(User user)
        {
            Messenger.Default.Send<UserDetailsMessage>(new UserDetailsMessage(user));
        }

        private void SendUserNotFoundMessage(BannerID bannerId)
        {
            Messenger.Default.Send<UserNotFoundMessage>(new UserNotFoundMessage(bannerId));
        }

        private void SendNavigationMessage(string destinationViewModel)
        {
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage(destinationViewModel));
        }
    }
}