using Moq;
using System.Collections;
using GalaSoft.MvvmLight.Messaging;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.ViewModel;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;

namespace Cmjimenez.PasswordResetTool.ApplicationTest.PasswordReset.ViewModel
{
    [TestClass]
    public class PasswordResetViewModelTest
    {
      

       [TestMethod]
       public void ResetPasswordCommand_Notifies_Of_Error_If_Both_Password_Fields_Do_Not_Match()
        {
            User _testUser = new User(BannerID.CreateBannerID("A00000001"), "samAccountName", "test, user 1");
            PasswordResetViewModel _viewModel = new PasswordResetViewModel(new Mock<IUserAccountService>().Object);
            string newPassword = "password";
            string nonMatchingPassword = "drowssap";

            _viewModel.NewPassword = newPassword;
            _viewModel.ConfirmPassword = nonMatchingPassword;

            _viewModel.ResetPasswordCommand.Execute(null);
            Assert.IsTrue(_viewModel.HasErrors);
            IEnumerator errorEnumerator = _viewModel.GetErrors("NewPassword").GetEnumerator();
            errorEnumerator.MoveNext();
            Assert.AreEqual("New Password Does Not Match Confirmation Password", errorEnumerator.Current);   
        }
        [TestMethod]
        public void Successfull_Reset_Sends_PasswordChangeSuccessMessage_With_True()
        {
            User _testUser = new User(BannerID.CreateBannerID("A00000001"), "samAccountName", "test, user 1");
            ResetResult testResult = new ResetResult(_testUser, true, null);
            var mockAccountService = new Mock<IUserAccountService>();
            mockAccountService.Setup(service => service.ChangeUserPassword(It.IsAny<User>(), It.IsAny<string>())).Returns(testResult);
            PasswordResetViewModel _viewModel = new PasswordResetViewModel(mockAccountService.Object);

            string newPassword = "password";
            string matchingPassword = "password";

            _viewModel.NewPassword = newPassword;
            _viewModel.ConfirmPassword = matchingPassword;

            PasswordChangeSuccessMessage passwordChangeSuccessMessage = null;

            Messenger.Default.Register<PasswordChangeSuccessMessage>(this, msg => passwordChangeSuccessMessage = msg);
            _viewModel.ResetPasswordCommand.Execute(null);

            Assert.IsNotNull(passwordChangeSuccessMessage);
            Assert.IsTrue(passwordChangeSuccessMessage.ResetResult.PasswordChanged);
        }

        [TestMethod]
        public void Failed_Reset_Sends_PasswordChangeSuccessMessage_With_False()
        {
            User _testUser = new User(BannerID.CreateBannerID("A00000001"), "samAccountName", "test, user 1");
            ResetResult testResult = new ResetResult(_testUser,false, "failure");
            var mockAccountService = new Mock<IUserAccountService>();
            mockAccountService.Setup(service => service.ChangeUserPassword(It.IsAny<User>(), It.IsAny<string>())).Returns(testResult);
            PasswordResetViewModel _viewModel = new PasswordResetViewModel(mockAccountService.Object);

            string newPassword = "password";
            string matchingPassword = "password";

            _viewModel.NewPassword = newPassword;
            _viewModel.ConfirmPassword = matchingPassword;

            PasswordChangeSuccessMessage passwordChangeSuccessMessage = null;

            Messenger.Default.Register<PasswordChangeSuccessMessage>(this, msg => passwordChangeSuccessMessage = msg);
            _viewModel.ResetPasswordCommand.Execute(null);

            Assert.IsNotNull(passwordChangeSuccessMessage);
            Assert.IsFalse(passwordChangeSuccessMessage.ResetResult.PasswordChanged);
        }
        [TestMethod]
        public void PasswordResetCommand_Calls_ChangeUserPassword_In_UserAccountService_If_Both_Password_Fields_Match()
        {
            User _testUser = new User(BannerID.CreateBannerID("A00000001"), "samAccountName", "test, user 1");
            ResetResult testResult = new ResetResult(_testUser,true, null);
            string newPassword = "password";
            string matchingPassword = "password";

            var mockAccountService = new Mock<IUserAccountService>();
            mockAccountService.Setup(service => service.ChangeUserPassword(It.IsAny<User>(), It.IsAny<string>())).Returns(testResult).Verifiable();
            PasswordResetViewModel _viewModel = new PasswordResetViewModel(mockAccountService.Object)
            {
                NewPassword = newPassword,
                ConfirmPassword = matchingPassword
            };

            _viewModel.ResetPasswordCommand.Execute(null);
            Mock.Verify(mockAccountService);
        }
    }
}
