using CompManBase.Interfaces;
using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static CompManBase.Models.PlayerBase;

namespace CompManBase.Converters
{
    [ValueConversion(typeof(int),typeof(string))]
    class StateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = PlayerBase.StateNames[(int)value].Name;
            return name;
            //switch ((PlayerState)value)
            //{
            //    case PlayerState.Teapot:
            //        return "Чайник";
            //    case PlayerState.Lamer:
            //        return "Ламер";
            //    case PlayerState.User:
            //        return "Юзер";
            //    case PlayerState.Sysadmin:
            //        return "Сисадмин";
            //    case PlayerState.Programmer:
            //        return "Программист";
            //    case PlayerState.Hacker:
            //        return "Хакер";
            //    default:
            //        return "Другой";
            //}
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
