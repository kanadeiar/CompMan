using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CompManBase.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    class HappyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case int i when i < 20:
                    return $"{i}% Депрессия";
                case int i when i < 40:
                    return $"{i}% Плохое";
                case int i when i < 60:
                    return $"{i}% Нормальное";
                case int i when i < 80:
                    return $"{i}% Хорошее";
                case int i when i <= 100:
                    return $"{i}% Отличное";
                default:
                    return "-1% Странное";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
