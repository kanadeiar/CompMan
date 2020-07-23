using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.WinModels
{
    public class SoftWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Софт </summary>
        public Soft Soft { get; set; }
        public SoftWindowPanel() { }
        public SoftWindowPanel(Soft soft)
        {
            Soft = soft;
        }

        #region свойства - зависимости

        public string NextActionOs => Soft.NextActionOs;
        public string NextOsName => Soft.NextOs.Name;
        public string NextOsCost => Soft.NextOs.Cost.ToString() + " рублей";
        public bool MayBuyNextOs => Soft.NextOsMayBuy;
        public string TextButtonBuyOs => Soft.NextOsMayBuy ? "Установить!" : "Облом.";
        public void BuyOs()
        {
            Soft.BuyOs();
            Changed(nameof(NextActionOs));
            Changed(nameof(NextOsName));
            Changed(nameof(NextOsCost));
            Changed(nameof(MayBuyNextOs));
            Changed(nameof(TextButtonBuyOs));
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
