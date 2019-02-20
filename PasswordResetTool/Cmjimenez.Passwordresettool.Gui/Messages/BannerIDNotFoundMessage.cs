using Cmjimenez.PasswordResetTool.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Application.Messages
{
    public class BannerIDNotFoundMessage
    {
        private readonly BannerID _bannerID;

        public BannerID BannerID { get { return _bannerID; }}

        public BannerIDNotFoundMessage(BannerID bannerId) => _bannerID = bannerId;
    }
}
