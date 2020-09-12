using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Interfaces
{
    /// <summary> Кошелек </summary>
    public interface IWallet
    {
        /// <summary> Можно ли вычесть столько - есть ли столько денег </summary>
        bool MaySubsctact(int money);
        /// <summary> Вычесть деньги </summary>
        void Substract(int money);
        /// <summary> Прибавить деньги </summary>
        void Add(int money);
    }
}
