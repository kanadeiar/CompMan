using CompManBase.Models;
using CompManBase.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System;
using static CompManBase.Models.PlayerBase;
using System.Threading.Tasks;
using System.Threading;

namespace CompManBase.WinModels
{
    public class MainWindowPanel : INotifyPropertyChanged
    {
        private string _title = "Компьютерщик";
        private string _helpString = "Подсказка";
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
        /// <summary> Случайные события </summary>
        public EventsBase Events { get; set; }
        public MainWindowPanel()
        {
            Timer = new DateTimer();
            Player = new Player(Timer)
            {
                State = 5,
                Money = 900000,
                Happy = 100,
            };
            Computer = new Computer(Player);
            Soft = new Soft(Player, Computer);
            Work = new Work(Timer, Player, Player);
            Work.Work = 0;
            Happy = new Happy(Player, Soft);
            Torrent = new Torrent(Timer, Player, Soft);
            Hack = new Hack(Player);
            Forum = new Forum(Player, (Hack)Hack);
            Events = new Events(Timer, Player, Soft, Soft, Computer);
            Task.Run(() => { GoHelpString(); });
        }


        #region Свойства-зависимости
        public string Title
        {
            get => _title;
            set
            {
                if (value == _title) return;
                _title = value;
                Changed(nameof(Title));
            }
        }
        public string HelpString
        {
            get => _helpString;
            set
            {
                if (value == _helpString) return;
                _helpString = value;
                Changed(nameof(HelpString));
            }
        }
        #endregion

        #region Подсказка
        private void GoHelpString()
        {
            HelpString = "Добро пожаловать в игру \"Компьютерщик\"!";
            Thread.Sleep(10000);
            HelpString = "Для начала купите самый простой, самый древний и дешевый компьютер!";
            Thread.Sleep(30000);
            HelpString = "Установите на ваш компьютер операционную систему, веб-браузер, антивирус, среду программирования!";
            Thread.Sleep(30000);
            HelpString = "Найдите подходящую работу по своему уровню!";
            Thread.Sleep(30000);
            HelpString = "Регулярно заходите на торрент-сайты для обмена софтом с другими людьми, это повышает Ваш авторитет!";
            Thread.Sleep(30000);
            HelpString = "После того как вырастите, можно будет заняться хакерством!";
            Thread.Sleep(30000);
            HelpString = "Играйте в игру \"Компьютерщик\"!";
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
