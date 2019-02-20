using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.View.Converter
{
    class BannerIDToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
               return (value as BannerID).Value;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
               return  BannerID.CreateBannerID((string)value);
            }
            catch(BannerIDInvalidFormatException)
            {
                return value;
            }
        }
    }
}
