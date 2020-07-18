using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Interfaces
{
    interface IStates
    {
        PlayerState State { get; set; }
        int Score { get; set; }
        int Money { get; set; }
        int Happy { get; set; }
    }
    public enum PlayerState
    {
        Teapot,
        Lamer,
        User,
        Programmer,
        Sysadmin,
        Hacker
    }
}
