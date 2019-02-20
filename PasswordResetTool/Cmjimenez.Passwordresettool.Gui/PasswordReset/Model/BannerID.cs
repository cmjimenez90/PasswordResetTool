using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Model
{
    public class BannerID
    {
        public String Value { get; }

        private BannerID(String value) => Value = value;

        public static BannerID CreateBannerID(String value)
        {
            ValidateValue(value);
            return new BannerID(value);
        }

        private static void ValidateValue(String value)
        {
            Regex validRegexPattern = new Regex("^A[0-9]{8}$");
            if(!validRegexPattern.IsMatch(value))
            {
                throw (new BannerIDInvalidFormatException(value));
            }
        }

        public override bool Equals(object obj)
        {
            return obj is BannerID iD &&
                   Value == iD.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}
