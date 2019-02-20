using Cmjimenez.PasswordResetTool.Application.Model;


namespace Cmjimenez.PasswordResetTool.Applicaiton.Messages
{
    class UserFoundBySamAccountNameMessage
    {
        private readonly User _user;

        public User User { get { return _user; } }

        public UserFoundBySamAccountNameMessage(User user) => _user = user;
    }
}
