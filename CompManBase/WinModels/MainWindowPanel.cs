using CompManBase.Models;
using CompManBase.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System;

namespace CompManBase.WinModels
{
    public class MainWindowPanel : INotifyPropertyChanged
    {
        private string _title = "Компьютерщик";
        /// <summary> Игрок </summary>
        public PlayerBase Player { get; set; }
        /// <summary> Компьютер </summary>
        public ComputerBase Computer { get; set; }
        /// <summary> Софт на компьютере </summary>
        public SoftBase Soft { get; set; }

        /// <summary> Часы игровые - таймер </summary>
        public DateTimerBase Timer { get; set; }
        /// <summary> Работа игрока </summary>
        public WorkBase Work { get; set; }

        public MainWindowPanel()
        {
            Timer = new DateTimer();
            Player = new Player(Timer)
            {
                State = PlayerState.Teapot,
                Money = 9000000,
                Happy = 100,
            };
            Computer = new Computer(Player);
            Soft = new Soft(Player, Computer);


            Work = new Work(Timer, Player);
            Work.Work = 1;
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
