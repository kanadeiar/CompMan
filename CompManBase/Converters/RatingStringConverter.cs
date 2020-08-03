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
    class RatingStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case int i when i == 0: return "0 Никакой";
                case int i when i > 0 && i <= 10: return $"{i} Низкий";
                case int i when i > 10 && i <= 100: return $"{i} Средний";
                case int i when i > 100 && i <= 1000: return $"{i} Высокий";
                case int i when i > 1000: return $"{i} Наивысший";
                default: return "-1 Неизвестный";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
