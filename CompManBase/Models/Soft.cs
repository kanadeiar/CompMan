using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public class Soft : SoftBase
    {
        private IWallet _wallet; //кошелек игрока
        private IInfoComputer _infoComputer; //инфа по компьютеру
        /// <summary> Конструктор с кошелем игрока </summary>
        /// <param name="wallet">Кошель игрока</param>
        public Soft(IWallet wallet, IInfoComputer computer)
        {
            _wallet = wallet;
        }
    }
}
