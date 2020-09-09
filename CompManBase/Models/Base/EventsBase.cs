using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CompManBase.Annotations;

namespace CompManBase.Models
{
    public abstract class EventsBase : INotifyPropertyChanged
    {
        public EventsBase()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /////////////////////////////////////////////////////////////////////
        #region Данные
        public struct MyEvent
        {
            /// <summary> Идентификатор </summary>
            public int Id;
            /// <summary> Вероятность 0 - 100 % каждый день </summary>
            public float May;
            /// <summary> Название события </summary>
            public string Name;
        }

        public static MyEvent[] MyEvents = new[]
        {
            new MyEvent{Id = 1, May = 10F, Name = "Компьютерный вирус атаковал ваш компьютер!"},
            new MyEvent{Id = 2, May = 5F, Name = "Сломался компьютер! Требуется срочный ремонт!"},
        };

        #endregion
    }
}
