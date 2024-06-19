using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace C_mainproject2
{
    public class BoolToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isPast = (bool)value;
            return isPast ? Brushes.LightGray : Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
