using Cmjimenez.PasswordResetTool.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Application.Messages
{
    public class UserFoundByBannerIDMessage
    {
        private readonly User _user;

        public User User { get { return _user; }}

        public UserFoundByBannerIDMessage(User user) => _user = user;





    }
}
