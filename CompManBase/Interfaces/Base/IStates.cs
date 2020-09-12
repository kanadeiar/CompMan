using static CompManBase.Models.PlayerBase;

namespace CompManBase.Interfaces
{
    public interface IStates
    {
        int State { get; set; }
        int Score { get; set; }
        int Money { get; set; }
        float Happy { get; set; }
        int Level { get; }
    }

}
