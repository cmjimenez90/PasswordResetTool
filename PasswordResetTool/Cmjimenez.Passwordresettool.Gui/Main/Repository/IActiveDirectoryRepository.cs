using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Repository
{
    public interface IActiveDirectoryRepository
    {
        User FindUserByBannerID(BannerID bannerID);
        User FindUserBySamAccountName(string testSamAccountName);
        bool ChangeUserPassword(User user, string newPassword);
        bool ChangeUserResetAttribute(User user);
    }
}
