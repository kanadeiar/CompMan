using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.WinModels
{
    public class WorkWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Работа </summary>
        public Work Work { get; set; }
        public WorkWindowPanel() {}
        public WorkWindowPanel(Work work)
        {
            Work = work;
        }

        #region Свойства-зависимости

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
