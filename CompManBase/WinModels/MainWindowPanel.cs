﻿using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.WinModels
{
    public class MainWindowPanel : INotifyPropertyChanged
    {
        private string _title;
        /// <summary> Игрок </summary>
        public PlayerBase Player { get; set; }



        public MainWindowPanel()
        {
            Player = new Compman
            {
                State = Interfaces.PlayerState.Teapot,
                Money = 1000,
                Happy = 100,
            };
            
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
