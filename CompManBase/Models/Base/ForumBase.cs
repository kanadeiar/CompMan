using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CompManBase.Annotations;

namespace CompManBase.Models
{
    public class ForumBase : INotifyPropertyChanged
    {
        public ForumBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /////////////////////////////////////////////////////////////////////
        public struct ForumMessage
        {
            /// <summary> Идентификатор </summary>
            public int Id;
            /// <summary> Нужный уровень игрока </summary>
            public int NeedLevel;
            /// <summary> Заголовок </summary>
            public string Title;
            /// <summary> Сообщение </summary>
            public string Message;
            /// <summary> Название действия </summary>
            public string DoName;
        }
        #region Данные
        public static ForumMessage[] ForumMessages = new[]
        {
            new ForumMessage { Id = 1, NeedLevel = 2, Title = "Продажа простого анонимайзера", Message = "Продается простая программа-анонимайзер доступа в Интернет за 10000 рублей", DoName = "Купить"},
            new ForumMessage { Id = 2, NeedLevel = 3, Title = "Продажа программы подбора паролей", Message = "Продается программа подбора паролей за 25000 рублей", DoName = "Купить"},
            new ForumMessage { Id = 3, NeedLevel = 4, Title = "Обмен программы маскировки", Message = "Меняю программу-маскировку на программу подбра паролей", DoName = "Обменять"},
        };
        #endregion
    }
}
