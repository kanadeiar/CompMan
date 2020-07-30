using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public class HappyBase : INotifyPropertyChanged
    {
        public HappyBase()
        {

        }

        #region Свойства-зависимости
        public string Happy1Name => "Выпить кефирчика";
        public int Happy1Cost => 30;
        public string Happy2Name => "Посмотреть новый фильм";
        public int Happy2Cost => 300;
        public string Happy3Name => "Сходить в гости";
        public int Happy3Cost => 2_000;
        public string Happy4Name => "Поиграть в игру на ПК";
        public int Happy4Cost => 0;
        public string Happy5Name => "Сходить по бабам";
        public int Happy5Cost => 10_000;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
