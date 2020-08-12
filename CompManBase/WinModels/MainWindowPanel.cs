﻿using CompManBase.Models;
using CompManBase.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System;
using static CompManBase.Models.PlayerBase;

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
        /// <summary> Развлечения игрока </summary>
        public HappyBase Happy { get; set; }
        /// <summary> Торренты </summary>
        public TorrentBase Torrent { get; set; }
        /// <summary> Форум </summary>
        public ForumBase Forum { get; set; }
        /// <summary> Хакерство </summary>
        public HackBase Hack { get; set; }

        public MainWindowPanel()
        {
            Timer = new DateTimer();
            Player = new Player(Timer)
            {
                State = 2,
                Money = 900000,
                Happy = 100,
            };
            Computer = new Computer(Player);
            Soft = new Soft(Player, Computer);
            Work = new Work(Timer, Player, Player);
            Work.Work = 0;
            Happy = new Happy(Player, Soft);
            Torrent = new Torrent(Timer, Player, Soft);
            Hack = new Hack();
            Forum = new Forum(Player, (Hack)Hack);

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
