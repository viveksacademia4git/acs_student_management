using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wpf_StudentManagement
{
    public class BoolToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool) value;
            return val ? "Submitted" : "Not Submitted";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string) value;
            return val == "Submitted";
        }
    }
}
