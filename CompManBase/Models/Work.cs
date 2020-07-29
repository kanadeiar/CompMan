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
        private IStates _player; //Состояние игрока
        private IWallet _wallet; //кошелек игрока
        /// <summary> Конструктор с кошелем игрока </summary>
        public Work(IDateTimerEvent timer, IWallet wallet, IStates player)
        {
            _wallet = wallet;
            _player = player;
            timer.NextDayEvent += DayUpdate;
        }
        /// <summary> Определение что доступна эта работа (такого уровня) игроку </summary>
        public bool GetMayDoItWork(int work)
        {
            return work <= _player.Level && Work != work;
        }
        /// <summary> Переход на другую работу </summary>
        public void GoToWork(int work)
        {
            Work = work;
        }

        /// <summary> Ежедневное изменение состояния - получение зарплаты </summary>
        private void DayUpdate(object sender, EventArgs e)
        {
            _wallet.Add(Salary);
        }
    }
}
