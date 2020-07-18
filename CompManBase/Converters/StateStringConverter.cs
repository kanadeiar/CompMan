using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CompManBase.Converters
{
    [ValueConversion(typeof(PlayerState),typeof(string))]
    class StateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((PlayerState)value)
            {
                case PlayerState.Teapot:
                    return "Чайник";
                case PlayerState.Lamer:
                    return "Ламер";
                case PlayerState.User:
                    return "Юзер";
                case PlayerState.Programmer:
                    return "Программист";
                case PlayerState.Sysadmin:
                    return "Систадмин";
                case PlayerState.Hacker:
                    return "Хакер";
                default:
                    return "Другой";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
