using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages
{
    public class UserDetailsMessage
    {
        private readonly User _user;

        public User User { get { return _user; }}

        public UserDetailsMessage(User user) => _user = user;





    }
}
