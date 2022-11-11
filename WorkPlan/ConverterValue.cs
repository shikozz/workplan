using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace WorkPlan
{
    class ConverterValue : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return ((DateTime)value).ToString("dd.MM.yyyy");
            }
            else 
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
