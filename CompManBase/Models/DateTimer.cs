using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CompManBase.Models
{
    public class DateTimer : DateTimerBase
    {
        public DateTimer() : base()
        {
            _dateTime = startDateTime = new DateTime(2020, 01, 01, 00, 00, 00);            
        }
        /// <summary> Пауза / пуск таймера </summary>
        public void PauseStart()
        {
            _timer.IsEnabled = !_timer.IsEnabled;
            Changed(nameof(TextOnButton));
        }
        /// <summary> Остановка таймера </summary>
        public void Pause()
        {
            _timer.IsEnabled = false;
            Changed(nameof(TextOnButton));
        }
    }
}
