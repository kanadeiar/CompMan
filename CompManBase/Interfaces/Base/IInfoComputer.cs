using CompManBase.Models;

namespace CompManBase.Interfaces
{
    public interface IInfoComputer
    {
        /// <summary> Получение уровня компонента компьютера </summary>
        int GetLevel(ComputerBase.Components components);
    }
}