using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages
{
    public class UserNotFoundMessage
    {
        private readonly BannerID _bannerID;

        public BannerID BannerID { get { return _bannerID; }}

        public UserNotFoundMessage(BannerID bannerId) => _bannerID = bannerId;
    }
}
