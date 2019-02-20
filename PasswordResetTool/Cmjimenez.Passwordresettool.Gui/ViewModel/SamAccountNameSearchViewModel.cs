using Cmjimenez.PasswordResetTool.Applicaiton.Messages;
using Cmjimenez.PasswordResetTool.Application.Model;
using Cmjimenez.PasswordResetTool.Application.Service;
using Cmjimenez.PasswordResetTool.Application.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Cmjimenez.PasswordResetTool.Applicaiton.ViewModel
{
    class SamAccountNameSearchViewModel : ViewModelBase
    {
        private IUserAccountService _userSearchService;
        private string _samAccountName;
        public RelayCommand SearchUserBySamAccountNameCommand { get; private set; }

        public string SamAccountName
        {
            get { return this._samAccountName; }
            set
            {
                _samAccountName = value;
                RaisePropertyChanged("SamAccountName");
            }
        }
        public SamAccountNameSearchViewModel(IUserAccountService userSearchService)
        {
            _userSearchService = userSearchService;
            SearchUserBySamAccountNameCommand = new RelayCommand(OnSearchUserBySamAccountNameCommand);
        }


        private void OnSearchUserBySamAccountNameCommand()
        {
            User user = _userSearchService.SearchUserBySamAccountName(_samAccountName);
            if (user != null)
            {
                SendUserFoundMessage(user);
            }
            else
            {
                SendUserNotFoundMessage(_samAccountName);
            }
        }

        private void SendUserFoundMessage(User user)
        {
            Messenger.Default.Send<UserFoundBySamAccountNameMessage>(new UserFoundBySamAccountNameMessage(user));
        }

        private void SendUserNotFoundMessage(string samAccountName)
        {
            Messenger.Default.Send<SamAccountNotFoundMessage>(new SamAccountNotFoundMessage(samAccountName));
        }
    }
}
