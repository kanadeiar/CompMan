using CompManBase.Interfaces;
using System;
using System.ComponentModel;

namespace CompManBase.Models
{
    public abstract class PlayerBase : IPlayer, INotifyPropertyChanged
    {
        private PlayerState _state;
        private int _score;
        private int _money;
        private float _happy;


        public PlayerBase()
        {
        }
        /// <summary> Добавление денег </summary>
        void IWallet.Add(int money) => Money += money;
        /// <summary> Есть ли столько денег - можно ли их вычесть </summary>
        bool IWallet.MaySubsctact(int money) => Money > money;
        /// <summary> Вычитание денег </summary>
        void IWallet.Substract(int money) => Money -= money;

        #region Свойства-зависимости
        public PlayerState State
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
        public int Level { get => Convert.ToInt32(_state) + 1; }
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
                Changed(nameof(Happy));
            }
        }
        #endregion

        
        public event PropertyChangedEventHandler PropertyChanged;



        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
