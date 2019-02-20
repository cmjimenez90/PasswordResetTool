using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Cmjimenez.PasswordResetTool.Application.Navigation.Messages;

namespace Cmjimenez.PasswordResetTool.Application.Main.View
{
    /// <summary>
    /// Interaction logic for MainAppView.xaml
    /// </summary>
    public partial class MainAppView : Window
    {
        public MainAppView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseMessage>(this, msg => { Close(); });
        }
    }
}
