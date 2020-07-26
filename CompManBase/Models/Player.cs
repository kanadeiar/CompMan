using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CompManBase.Models
{
    public class Player : PlayerBase
    {

        public Player(IDateTimerEvent timer)
        {
            timer.NextDayEvent += DayUpdate;
            timer.NextMounthEvent += MounthUpdate;
        }
        /// <summary> Ежедневное изменение состояния </summary>
        private void DayUpdate(object sender, EventArgs e)
        {
            Happy -= 3.0F;
        }
        /// <summary> Ежемесячное изменение состояния - квартплата </summary>
        private void MounthUpdate(object sender, EventArgs e)
        {
            int homePay = 1000 * Level;
            Money -= homePay;
        }
    }
}
