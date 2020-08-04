using CompManBase.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Windows;

namespace CompManBase.Models
{
    public abstract class PlayerBase : IPlayer, INotifyPropertyChanged
    {
        private int _state; //текущий статус
        private int _score;
        private int _money;
        private float _happy;


        public PlayerBase()
        {
        }
        /// <summary> Добавление денег </summary>
        void IWallet.Add(int money) => Money += money;
        /// <summary> Есть ли столько денег - можно ли их вычесть </summary>
        bool IWallet.MaySubsctact(int money) => Money >= money;
        /// <summary> Вычитание денег </summary>
        void IWallet.Substract(int money) => Money -= money;
        /// <summary> Прибавить настроения </summary>
        void IHappy.Add(int happy) => Happy += happy;
        /// <summary> Убавить Настроение </summary>
        void IHappy.Substract(int happy) => Happy -= happy;
        /// <summary> Прибавить счет </summary>
        void IChangeScore.Add(int score)
        {
            Score += score;
            if (Score > StateNames.First(n => n.Level == _state).ScoreUp && State < StateNames.Length - 1)
            {
                State++;
                MessageBox.Show("Поздравления с повышением в уровне!", "Повышение!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary> Убавить счет </summary>
        void IChangeScore.Substract(int score)
        {
            Score -= score;
            if (Score < StateNames.First(n => n.Level == _state).Score && State > 0)
            {
                State--;
                MessageBox.Show("Сочуствуем вашему понижению уровня.", "Понижение.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #region Свойства-зависимости
        public int State
        {
            get => _state;
            set
            {
                if (value == _state) return;
                _state = value;
                Changed(nameof(State));
                Changed(nameof(Level));
            }
        }
        public int Level { get => StateNames[State + 1].Level; }
        public int Score
        {
            get => _score;
            set
            {
                if (value == _score) return;
                _score = value;
                Changed(nameof(Score));
            }
        }
        public int Money
        {
            get => _money;
            set
            {
                if (value == _money) return;
                _money = value;
                Changed(nameof(Money));
            }
        }
        public float Happy
        {
            get => _happy;
            set
            {
                if (value == _happy) return;
                _happy = value;
                if (_happy > 100) _happy = 100;
                Changed(nameof(Happy));
            }
        }
        #endregion

        
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /////////////////////////////////////////////////////////////////////
        public struct StateData
        {
            /// <summary> Уровень игрока </summary>
            public int Level;
            /// <summary> Название статуса </summary>
            public string Name;
            /// <summary> Очки статуса минимум </summary>
            public int Score;
            /// <summary> Очки статуса повышения </summary>
            public int ScoreUp;
        }
        #region Данные
        public static StateData[] StateNames = new[]
        {
            new StateData { Level = 0, Name ="Чайник", Score = int.MinValue, ScoreUp = 11 },
            new StateData { Level = 1, Name ="Ламер", Score = 9, ScoreUp = 32 },
            new StateData { Level = 2, Name ="Юзер", Score = 28, ScoreUp = 103 },
            new StateData { Level = 3, Name ="Сисадмин", Score = 97, ScoreUp = 304 },
            new StateData { Level = 4, Name ="Программист", Score = 296, ScoreUp = 1005 },
            new StateData { Level = 5, Name ="Хакер", Score = 995, ScoreUp = int.MaxValue },
        };
        #endregion
    }
}
