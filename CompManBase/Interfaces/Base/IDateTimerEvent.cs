using System;

namespace CompManBase.Interfaces
{
    public interface IDateTimerEvent
    {
        event EventHandler NextDayEvent;
        event EventHandler NextMounthEvent;
    }
}