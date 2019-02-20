using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.View.Validator
{
    public class BannerIDValidator : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                BannerID bannerID = BannerID.CreateBannerID((string)value);
                return ValidationResult.ValidResult;
            }
            catch (BannerIDInvalidFormatException exception)
            {
                return new ValidationResult(false, exception.Message);
            }
        }
    }
}
