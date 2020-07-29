namespace CompManBase.Interfaces
{
    public interface IStates
    {
        PlayerState State { get; set; }
        int Score { get; set; }
        int Money { get; set; }
        float Happy { get; set; }
        int Level { get; }
    }
    public enum PlayerState
    {
        Teapot,
        Lamer,
        User,
        Sysadmin,
        Programmer,
        Hacker
    }
}
