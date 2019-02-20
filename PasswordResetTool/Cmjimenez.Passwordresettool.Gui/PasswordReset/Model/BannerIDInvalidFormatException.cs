using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Model
{
    public class BannerIDInvalidFormatException : Exception
    {
        public BannerIDInvalidFormatException()
        {
        }

        public BannerIDInvalidFormatException(string message) : base(CreateExceptionMessage(message))
        {
        }

        public BannerIDInvalidFormatException(string message, Exception innerException) : base(CreateExceptionMessage(message), innerException)
        {
        }

        private static String CreateExceptionMessage(String value)
        {
            return String.Format("Invalid format for BannerID number: {0}",value);
        }
    }
}
