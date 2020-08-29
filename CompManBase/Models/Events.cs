using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompManBase.Interfaces;


namespace CompManBase.Models
{
    public class Events : EventsBase
    {

        public Events(IDateTimerEvent timer) : base()
        {
            timer.NextDayEvent += DayUpdate;
        }
        /// <summary> Ежедневное - выброс случайных событий </summary>
        private void DayUpdate(object sender, EventArgs e)
        {
            
        }
    }
}
