using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service
{
    public interface IUserAccountService
    {
         User SearchUserByBannerID(BannerID bannerID);
         User SearchUserBySamAccountName(string samAccountName);
         ResetResult ChangeUserPassword(User user, string newPassword);
    }
}
