using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Repository;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service
{
    public class UserAccountService : IUserAccountService
    {

        IActiveDirectoryRepository _repository;

        public UserAccountService(IActiveDirectoryRepository repository)
        {
            _repository = repository;
        }

        public User SearchUserByBannerID(BannerID bannerID)
        {
            return _repository.FindUserByBannerID(bannerID);
        }

        public User SearchUserBySamAccountName(string samAccountName)
        {
            return _repository.FindUserBySamAccountName(samAccountName);
        }

        public ResetResult ChangeUserPassword(User user, string newPassword)
        {

            if (!_repository.ChangeUserPassword(user, newPassword))
                return new ResetResult(user, false, "Password could not be changed");
            if (!_repository.ChangeUserResetAttribute(user))
                return new ResetResult(user, true, "Reset attribute could not be set");
            return new ResetResult(user,true, null);

        }

        private bool IsValidUser(User userToVerify)
        {
            User user = _repository.FindUserByBannerID(userToVerify.BannerID);
            if (user != null && (user.Equals(userToVerify)))
                return true;
            return false;
        }

    }
}
