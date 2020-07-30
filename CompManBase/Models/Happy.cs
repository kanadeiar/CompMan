using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public class Happy : HappyBase
    {
        private IWallet _wallet; //кошелек игрока
        private IInfoSoft _soft; //программы игрока
        /// <summary> Конструктор с кошелем игрока </summary>
        public Happy(IWallet wallet, IInfoSoft soft)
        {
            _wallet = wallet;
            _soft = soft;
        }

        #region Доступность
        public bool Happy1MayDo => true;
        public bool Happy2MayDo => true;
        public bool Happy3MayDo => true;
        public bool Happy4MayDo => _soft.GetInfo(SoftBase.Parts.Game) >= 1;
        public bool Happy5MayDo => true;
        #endregion

        #region Действие - развлечься

        #endregion
    }
}
