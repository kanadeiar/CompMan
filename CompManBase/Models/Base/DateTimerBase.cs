using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace CompManBase.Models
{
    public abstract class DateTimerBase : INotifyPropertyChanged, IDateTimerEvent
    {
        protected DateTime startDateTime;
        protected DateTime _dateTime;
        protected DispatcherTimer _timer;
        /// <summary> Тик следующего дня </summary>
        public event EventHandler NextDayEvent;
        /// <summary> Тик следующего месяца </summary>
        public event EventHandler NextMounthEvent;

        public DateTimerBase()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        /// <summary> Тик таймера </summary>
        private void TimerTick(object sender, EventArgs e)
        {
            if (_dateTime.Hour == 0 && _dateTime != startDateTime)
                NextDayEvent?.Invoke(this, new EventArgs());
            if (_dateTime.Day == 1 && _dateTime.Hour == 0 && _dateTime != startDateTime)
                NextMounthEvent?.Invoke(this, new EventArgs());
            _dateTime = _dateTime.AddHours(1);
            Changed(nameof(MyDateString));
            Changed(nameof(MyTimeString));
        }


        #region Свойства-зависимости
        public string MyDateString
        {
            get => _dateTime.ToString("dd.MM.yyyy");
        }
        public string MyTimeString
        {
            get => _dateTime.ToString("HH:mm");
        }
        public string TextOnButton
        {
            get => (_timer.IsEnabled) ? "Пауза" : "Продолжить";
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
