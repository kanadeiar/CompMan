using CompManBase.Models;
using CompManBase.Interfaces;
using System.ComponentModel;

namespace CompManBase.WinModels
{
    public class MainWindowPanel : INotifyPropertyChanged
    {
        private string _title;
        /// <summary> Игрок </summary>
        public PlayerBase Player { get; set; }
        /// <summary> Компьютер </summary>
        public ComputerBase Computer { get; set; }
        /// <summary> Софт на компьютере </summary>
        public SoftBase Soft { get; set; }

        public MainWindowPanel()
        {
            Player = new Player
            {
                State = PlayerState.Teapot,
                Money = 9000000,
                Happy = 99.899F,
            };
            Computer = new Computer();
            Soft = new Soft();
        }

        #region Свойства-зависимости
        public string Title
        {
            get => _title;
            set
            {
                if (value == _title) return;
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }




        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
