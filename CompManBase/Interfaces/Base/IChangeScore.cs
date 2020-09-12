using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Interfaces
{
    /// <summary> Изменение настроения </summary>
    public interface IChangeScore
    {
        /// <summary> Прибавить настроения </summary>
        void Add(int score);
        /// <summary> Убавить Настроение </summary>
        void Substract(int score);
    }
}
