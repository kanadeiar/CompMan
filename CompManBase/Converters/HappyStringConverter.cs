using System;
using System.Globalization;
using System.Windows.Data;

namespace CompManBase.Converters
{
    [ValueConversion(typeof(float), typeof(string))]
    class HappyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((float)value)
            {
                case float f when f < 20.0F:
                    return $"{f:f1}% Скверное";
                case float f when f < 40:
                    return $"{f:f1}% Плохое";
                case float f when f < 60:
                    return $"{f:f1}% Нормальное";
                case float f when f < 80:
                    return $"{f:f1}% Хорошее";
                case float f when f <= 100:
                    return $"{f:f1}% Отличное";
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
