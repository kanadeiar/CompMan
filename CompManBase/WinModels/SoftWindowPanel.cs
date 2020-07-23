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
        SoftWindowPanel() { }
        SoftWindowPanel(Soft soft)
        {
            Soft = soft;
        }

        #region свойства - зависимости





        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
