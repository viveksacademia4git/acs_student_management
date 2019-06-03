﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wpf_ManageStudents
{
    class Bool2String : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool what =(bool)value;
            if (what)
            {
                return "Submitted";
            }
            else
            {
                return "Not Submitted";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Contains("not"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
