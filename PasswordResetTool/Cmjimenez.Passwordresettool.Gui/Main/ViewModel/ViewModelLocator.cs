/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Cmjimenez.Passwordresettool.Gui"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Cmjimenez.PasswordResetTool.Application.Main.Repository;
using Cmjimenez.PasswordResetTool.Application.Navigation;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Repository;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Cmjimenez.PasswordResetTool.Application.Main.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #if DEBUG
                SimpleIoc.Default.Register<IActiveDirectoryRepository, FakeActiveDirectoryRepository>();
            #else
                SimpleIoc.Default.Register<PrincipalContextFactory>();
                SimpleIoc.Default.Register<IActiveDirectoryRepository, ADServicesActiveDirectoryRepository>();
            #endif

            SimpleIoc.Default.Register<IUserAccountService, UserAccountService>();
            SimpleIoc.Default.Register<NavigationService>(); 
            SimpleIoc.Default.Register<MainAppViewModel>();
            SimpleIoc.Default.Register<BannerIDSearchViewModel>();
            SimpleIoc.Default.Register<UserDetailsViewModel>();
            SimpleIoc.Default.Register<PasswordResetViewModel>();
            SimpleIoc.Default.Register<PasswordResetResultViewModel>();
            SimpleIoc.Default.Register<UserNotFoundViewModel>();
        }

        public MainAppViewModel MainAppViewModel
        {
            get { return SimpleIoc.Default.GetInstance<MainAppViewModel>(); }
        }
        public BannerIDSearchViewModel BannerIDSearchViewModel
        {
            get { return SimpleIoc.Default.GetInstance<BannerIDSearchViewModel>(); }
        }

        public UserDetailsViewModel UserDetailsViewModel
        {
            get { return SimpleIoc.Default.GetInstance<UserDetailsViewModel>(); }
        }

        public PasswordResetViewModel PasswordResetViewModel
        {
            get { return SimpleIoc.Default.GetInstance<PasswordResetViewModel>(); }
        }

        public PasswordResetResultViewModel PasswordResetResultViewModel
        {
            get { return SimpleIoc.Default.GetInstance<PasswordResetResultViewModel>(); }
        }

        public UserNotFoundViewModel UserNotFoundViewModel
        {
            get { return SimpleIoc.Default.GetInstance<UserNotFoundViewModel>(); }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}