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
    public class HackWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Хакерство </summary>
        public Hack Hack { get; set; }

        public HackWindowPanel()
        {
        }

        public HackWindowPanel(Hack hack)
        {
            Hack = hack;
            MissionText = Hack.GetNewMission().Name;
        }

        #region Свойства - зависимости

        public IEnumerable<string> ProgramsStrs => Hack.HackPrograms.Select(p => p.Name);
        public string MissionText { get; set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
