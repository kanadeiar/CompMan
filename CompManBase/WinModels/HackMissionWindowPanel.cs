using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CompManBase.Annotations;
using CompManBase.Models;

namespace CompManBase.WinModels
{
    public class HackMissionWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Хакерство </summary>
        public Hack Hack { get; set; }
        public HackMissionWindowPanel() { }
        public HackMissionWindowPanel(Hack hack)
        {
            Hack = hack;
            //MissionText = Hack.GetNewMission().Name;
        }
        #region Свойства - зависимости

        public string MissionText => Hack.GetNewMission().Name;

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
