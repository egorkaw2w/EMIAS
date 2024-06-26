using System;
using System.Globalization;
using System.Windows.Data;

namespace C_mainproject2
{
    public class CompletedToContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCompleted = (bool)value;
            return isCompleted ? "Прием завершен" : "Начать прием";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
