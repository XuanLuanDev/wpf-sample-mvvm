using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SampleMVVM.Helpers
{
    public class BoolToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            if (value == null)
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(value.ToString()))
            {
                return string.Empty;
            }
            bool retVal = false;
            bool isBool = bool.TryParse(value.ToString(), out retVal);
            if (isBool)
            {
                if (retVal)
                {
                    return "Male";
                }
                else
                {
                    return "Female";
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
