using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Interfaces
{
    /// <summary> Развлечения </summary>
    public interface IHappy
    {
        /// <summary> Прибавить настроения </summary>
        void Add(int happy);
        /// <summary> Убавить Настроение </summary>
        void Substract(int happy);
    }
}
