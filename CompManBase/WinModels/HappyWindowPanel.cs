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
        public void DoHappy1()
        {
            Happy.DoHappy1();
        }
        public void DoHappy2()
        {
            Happy.DoHappy2();
        }
        public void DoHappy3()
        {
            Happy.DoHappy3();
        }
        public void DoHappy4()
        {
            Happy.DoHappy4();
        }
        public void DoHappy5()
        {
            Happy.DoHappy5();
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
