using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Text.RegularExpressions;

namespace Audits.Converters
{
    [ValueConversion(typeof(double), typeof(string))]
    public class DecimalConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return value.ToString();
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string data = value as string;
            double result = 0;

            if (data == null)
            {
                return value;
            }
            if (data.Equals(string.Empty))
            {
                return 0;
            }
            if (!string.IsNullOrEmpty(data))
            {
                Regex regex = new Regex(@"^\d*[.][0]+$");

                if (data.EndsWith(".") || data.Equals("-0") || regex.IsMatch(data))
                {
                    return Binding.DoNothing;
                }
                if (double.TryParse(data, out result))
                {
                  return result;
                }
            }

            string adjustedData = data.Substring(0, data.Length - 1);
            if (double.TryParse(adjustedData, out result))
            {
                return result;
            }
            else
            return 0;
        }
    }
}
