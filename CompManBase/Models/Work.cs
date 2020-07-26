using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public class Work : WorkBase
    {
        private IWallet _wallet; //кошелек игрока
        /// <summary> Конструктор с кошелем игрока </summary>
        public Work(IDateTimerEvent timer, IWallet wallet)
        {
            _wallet = wallet;
            timer.NextDayEvent += DayUpdate;
        }
        /// <summary> Ежедневное изменение состояния - получение зарплаты </summary>
        private void DayUpdate(object sender, EventArgs e)
        {
            _wallet.Add(Salary);
        }
    }
}
