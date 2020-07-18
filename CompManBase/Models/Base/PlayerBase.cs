using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public abstract class PlayerBase : IPlayer, INotifyPropertyChanged
    {
        private PlayerState _state;
        private int _score;
        private int _money;
        private int _happy;
        #region Свойства-зависимости
        public PlayerState State
        {
            get => _state;
            set
            {
                if (value == _state) return;
                _state = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
            }
        }
        public int Score
        {
            get => _score;
            set
            {
                if (value == _score) return;
                _score = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score)));
            }
        }
        public int Money
        {
            get => _money;
            set
            {
                if (value == _money) return;
                _money = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money)));
            }
        }
        public int Happy
        {
            get => _happy;
            set
            {
                if (value == _happy) return;
                _happy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Happy)));
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
