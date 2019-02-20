using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;

namespace Cmjimenez.PasswordResetTool.Application.Navigation
{
    public class NavigationService : INavigationService
    {
        private string _currentViewModelKey;
        private ModifiedBaseViewModel _currentViewModel;

        private Dictionary<string, ModifiedBaseViewModel> _viewModels;
        
        public string CurrentPageKey { get { return _currentViewModelKey; } }

        public ModifiedBaseViewModel CurrentViewModel {
            get { return _currentViewModel; }
            private set {    
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;                      
                }              
            }
        }
       
        public NavigationService()
        {
            _viewModels = new Dictionary<string, ModifiedBaseViewModel>();
            LoadViewModelsInDictionary();
        }

        public void GoBack()
        {
            NavigateTo("bannerIDsearch");
        }

        public void NavigateTo(string pageKey)
        {
            if (_viewModels.ContainsKey(pageKey))
            {
                _currentViewModelKey = pageKey;
                CurrentViewModel = _viewModels[pageKey];
            }
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            NavigateTo(pageKey);
        }

        private void LoadViewModelsInDictionary()
        {
            ModifiedBaseViewModel vm = SimpleIoc.Default.GetInstance<BannerIDSearchViewModel>();
            _viewModels.Add("bannerIDsearch", vm);

            vm = SimpleIoc.Default.GetInstance<UserDetailsViewModel>();
            _viewModels.Add("userdetail", vm);

            vm = SimpleIoc.Default.GetInstance<PasswordResetViewModel>();
            _viewModels.Add("passwordreset", vm);

            vm = SimpleIoc.Default.GetInstance<PasswordResetResultViewModel>();
            _viewModels.Add("resetresult", vm);

            vm = SimpleIoc.Default.GetInstance<UserNotFoundViewModel>();
            _viewModels.Add("usernotfound", vm);
        }
    }
}
