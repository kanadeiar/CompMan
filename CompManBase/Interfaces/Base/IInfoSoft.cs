using CompManBase.Models;

namespace CompManBase.Interfaces
{
    public interface IInfoSoft
    {
        /// <summary> Получение уровня программы компьютера </summary>
        int GetInfo(SoftBase.Parts parts);
    }
}