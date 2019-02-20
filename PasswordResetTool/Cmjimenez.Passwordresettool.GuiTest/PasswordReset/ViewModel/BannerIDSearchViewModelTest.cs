using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaSoft.MvvmLight.Messaging;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages;

namespace Cmjimenez.PasswordResetTool.ApplicationTest.PasswordReset.ViewModel
{
    [TestClass]
    public class BannerIDSearchViewModelTest
    {
        [TestMethod]
        public void SearchUserByBannerIDCommand_Sends_UserDetailsMessage_If_User_Is_Found()
        {
            string expectedSamAccountName = "samAccountName";
            string expectedFullName = "test, user name";
            BannerID bannerID = BannerID.CreateBannerID("A00000001");
            User expectedUser = new User(bannerID,expectedSamAccountName,expectedFullName);
            UserDetailsMessage userDetailsMessage = null;
            Messenger.Default.Register<UserDetailsMessage>(this, msg => userDetailsMessage = msg);

            var mockAccountService = new Mock<IUserAccountService>();
            mockAccountService.Setup(service => service.SearchUserByBannerID(It.IsAny<BannerID>())).Returns(expectedUser);
            BannerIDSearchViewModel viewModel = new BannerIDSearchViewModel(mockAccountService.Object){BannerID = bannerID};

            viewModel.SearchUserByBannerIDCommand.Execute(null);
            Assert.IsNotNull(userDetailsMessage);
            Assert.AreEqual(expectedUser, userDetailsMessage.User);
        }

        [TestMethod]
        public void SearchUserByBannerIDCommand_Sends_UserNotFoundMessage_If_User_Is_Not_Found()
        {
            BannerID bannerID = BannerID.CreateBannerID("A00000001");
            
            UserNotFoundMessage userNotFoundMessage = null;
            Messenger.Default.Register<UserNotFoundMessage>(this, msg => userNotFoundMessage = msg);

            var mockAccountService = new Mock<IUserAccountService>();
            mockAccountService.Setup(service => service.SearchUserByBannerID(It.IsAny<BannerID>())).Returns((User)null);
            BannerIDSearchViewModel viewModel = new BannerIDSearchViewModel(mockAccountService.Object) {BannerID = bannerID};

            viewModel.SearchUserByBannerIDCommand.Execute(null);
            Assert.IsNotNull(userNotFoundMessage);
            Assert.AreEqual(bannerID, userNotFoundMessage.BannerID);
        }
    }
}
