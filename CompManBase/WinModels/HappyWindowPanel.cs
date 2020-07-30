using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.WinModels
{
    public class HappyWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Развлечения </summary>
        public Happy Happy { get; set; }

        public HappyWindowPanel() { }
        public HappyWindowPanel(Happy happy)
        {
            Happy = happy;
        }

        #region Свойства - зависимости

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
