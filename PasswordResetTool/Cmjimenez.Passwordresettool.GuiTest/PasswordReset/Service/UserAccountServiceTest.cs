using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Repository;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;

namespace Cmjimenez.PasswordResetTool.ApplicationTest.PasswordReset.Service
{
    [TestClass]
    public class UserAccountServiceTest
    {

        [TestMethod]
        public void SearchUserByBannerID_Returns_Null_If_Not_Found()
        {
            BannerID testBannerID = BannerID.CreateBannerID("A00000000");
            var mockRepo = new Mock<IActiveDirectoryRepository>();
            mockRepo.Setup(repo => repo.FindUserByBannerID(testBannerID)).Returns((User)null);
            UserAccountService userAccountService = new UserAccountService(mockRepo.Object);
            Assert.IsNull(userAccountService.SearchUserByBannerID(testBannerID));
        }

        [TestMethod]
        public void SearchUserByBannerID_Returns_User_If_Found()
        {
            BannerID testBannerID = BannerID.CreateBannerID("A00000000");
            User testUser = new User(testBannerID, "testSamAccount", "test, user one");

            var mockRepo = new Mock<IActiveDirectoryRepository>();
            mockRepo.Setup(repo => repo.FindUserByBannerID(testBannerID)).Returns(testUser);

            UserAccountService userAccountService = new UserAccountService(mockRepo.Object);
            User recievedUser = userAccountService.SearchUserByBannerID(testBannerID);
            Assert.IsNotNull(recievedUser);
            Assert.AreEqual<BannerID>(testUser.BannerID, recievedUser.BannerID);
            Assert.AreEqual(testUser.SamAccountName, recievedUser.SamAccountName);
            Assert.AreEqual(testUser.FullName, recievedUser.FullName);
        }
        [TestMethod]
        public void SearchUserBySamAccountName_Returns_Null_If_Not_Found()
        {
            BannerID testBannerID = BannerID.CreateBannerID("A00000000");
            string testSamAccountName = "testSamAccount";
            User testUser = new User(testBannerID, testSamAccountName, "test, user one");

            var mockRepo = new Mock<IActiveDirectoryRepository>();
            mockRepo.Setup(repo => repo.FindUserByBannerID(testBannerID)).Returns((User)null);

            UserAccountService userAccountService = new UserAccountService(mockRepo.Object);
            User recievedUser = userAccountService.SearchUserBySamAccountName(testSamAccountName);
            Assert.IsNull(recievedUser);
         
        }

        [TestMethod]
        public void SearchUserBySamAccountName_Returns_User_If_Found()
        {
            BannerID testBannerID = BannerID.CreateBannerID("A00000000");
            string testSamAccountName = "testSamAccount";
            User testUser = new User(testBannerID, testSamAccountName, "test, user one");

            var mockRepo = new Mock<IActiveDirectoryRepository>();
            mockRepo.Setup(repo => repo.FindUserBySamAccountName(testSamAccountName)).Returns(testUser);

            UserAccountService userAccountService = new UserAccountService(mockRepo.Object);
            User recievedUser = userAccountService.SearchUserBySamAccountName(testSamAccountName);
            Assert.IsNotNull(recievedUser);
            Assert.AreEqual<BannerID>(testUser.BannerID, recievedUser.BannerID);
            Assert.AreEqual(testUser.SamAccountName, recievedUser.SamAccountName);
            Assert.AreEqual(testUser.FullName, recievedUser.FullName);
        }

        [TestMethod]
        public void ChangeUserPassword_Returns_ResetResult_With_No_Failures()
        {
            BannerID testBannerID = BannerID.CreateBannerID("A00000000");
            string testSamAccountName = "testSamAccount";
            string newPassword = "new_test_password";
            User testUser = new User(testBannerID, testSamAccountName, "test, user one");

            var mockRepo = new Mock<IActiveDirectoryRepository>();
            mockRepo.Setup(repo => repo.FindUserByBannerID(testUser.BannerID)).Returns(testUser);
            mockRepo.Setup(repo => repo.ChangeUserPassword(testUser, newPassword)).Returns(true);
            mockRepo.Setup(repo => repo.ChangeUserResetAttribute(testUser)).Returns(true);
            UserAccountService userAccountService = new UserAccountService(mockRepo.Object);
            ResetResult result = userAccountService.ChangeUserPassword(testUser, newPassword);

            Assert.IsFalse(result.HasErrorMessage);
            Assert.AreEqual(testUser, result.User);          
        }

        [TestMethod]
        public void ChangeUserPassword_Returns_ResetResult_With_Failure_When_Returned_User_DoesNotMatch()
        {
            BannerID testBannerID = BannerID.CreateBannerID("A00000001");
            string testSamAccountName = "testSamAccount";
            string newPassword = "new_test_password";
            User testEnteredUser = new User(testBannerID, testSamAccountName, "test, user one");

            testBannerID = BannerID.CreateBannerID("A00000001");
            testSamAccountName = "testSamAccount2";
            User testReturnedUser = new User(testBannerID, testSamAccountName, "test, user one3");

            var mockRepo = new Mock<IActiveDirectoryRepository>();
            mockRepo.Setup(repo => repo.FindUserByBannerID(testEnteredUser.BannerID)).Returns(testReturnedUser);
            
            UserAccountService userAccountService = new UserAccountService(mockRepo.Object);
            ResetResult result = userAccountService.ChangeUserPassword(testEnteredUser, newPassword);

            Assert.IsTrue(result.HasErrorMessage);
            Assert.AreEqual(testEnteredUser, result.User);
        }

        [TestMethod]
        public void ChangeUserPassword_Returns_ResetResult_With_Failure_When_Entered_User_Does_Not_Exist()
        {
            BannerID testBannerID = BannerID.CreateBannerID("A00000001");
            string testSamAccountName = "testSamAccount";
            string newPassword = "new_test_password";
            User testEnteredUser = new User(testBannerID, testSamAccountName, "test, user one");

            var mockRepo = new Mock<IActiveDirectoryRepository>();
            mockRepo.Setup(repo => repo.FindUserByBannerID(testEnteredUser.BannerID)).Returns((User)null);
           
            UserAccountService userAccountService = new UserAccountService(mockRepo.Object);
            ResetResult result = userAccountService.ChangeUserPassword(testEnteredUser, newPassword);

            Assert.IsTrue(result.HasErrorMessage);
            Assert.AreEqual(testEnteredUser, result.User);
        }

    }
}
