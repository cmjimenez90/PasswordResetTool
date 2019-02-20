using Cmjimenez.PasswordResetTool.Application.Navigation.Messages;
using Cmjimenez.PasswordResetTool.Application.Navigation;
using GalaSoft.MvvmLight.Messaging;


namespace Cmjimenez.PasswordResetTool.Application.Main.ViewModel
{
    public class MainAppViewModel : ModifiedBaseViewModel
    {

        private NavigationService _navigationService;

        private ModifiedBaseViewModel _currentViewModel;

        public ModifiedBaseViewModel CurrentViewModel { get { return _currentViewModel; }
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    RaisePropertyChanged("CurrentViewModel");
                }
            }
        }                                       
    
        public MainAppViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Default.Register<NavigationMessage>(this, msg => ProcessNavigationMessage(msg));
            _navigationService.NavigateTo("bannerIDsearch");
            CurrentViewModel = _navigationService.CurrentViewModel;
        }

        
        private void ProcessNavigationMessage(NavigationMessage msg)
        {        
            if(msg.ViewModel == "cancel")
            {
                _navigationService.GoBack();
                CurrentViewModel = _navigationService.CurrentViewModel;
            }
            else if(msg.ViewModel == "exit"){
                Messenger.Default.Send<CloseMessage>(new CloseMessage());
            }
            else
            {
                _navigationService.NavigateTo(msg.ViewModel);
                CurrentViewModel = _navigationService.CurrentViewModel;
            }
            
        }
    }
}
