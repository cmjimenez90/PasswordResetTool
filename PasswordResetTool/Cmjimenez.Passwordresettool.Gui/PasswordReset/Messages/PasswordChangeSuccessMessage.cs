using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Messages
{
    public class PasswordChangeSuccessMessage
    {
        public ResetResult ResetResult { get; private set; }

        public PasswordChangeSuccessMessage(ResetResult result)
        {
            ResetResult = result;
        }
    }
}
