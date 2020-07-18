using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Interfaces
{
    interface IStates
    {
        string State { get; set; }
        int Score { get; set; }
        int Money { get; set; }
        int Happy { get; set; }
    }
}
