using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;


namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Model
{
    public class ResetResult
    {
        public  string FailureMessage { get; private set; }
        public  User User { get; private set; }
        public bool PasswordChanged { get; private set; }
        public  bool HasErrorMessage { get; private set; }

        public ResetResult(User user, bool passwordChanged, string failureMessage)
        {
            if (failureMessage == null)
            {
                HasErrorMessage = false;
            }
            else
            {
                FailureMessage = failureMessage;
                HasErrorMessage = true;
            }
            User = user;
            PasswordChanged = passwordChanged;
        }

    }
}
