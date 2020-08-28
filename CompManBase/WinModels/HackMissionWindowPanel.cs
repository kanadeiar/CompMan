using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CompManBase.Annotations;
using CompManBase.Models;

namespace CompManBase.WinModels
{
    public class HackMissionWindowPanel : INotifyPropertyChanged
    {
        private string _missionText;
        /// <summary> Хакерство </summary>
        public Hack Hack { get; set; }
        public HackMissionWindowPanel() { }
        public HackMissionWindowPanel(Hack hack)
        {
            Hack = hack;
            MissionText = string.Empty;
            switch (Hack.CurrentMission.Id)
            {
                case 1: Task.Run(() => { Hack.Mission1(AddMissionText, ClearMissionText); });
                    break;
                case 2: Task.Run(() => { Hack.Mission2(AddMissionText, ClearMissionText); });
                    break;
                case 3: Task.Run(() => { Hack.Mission3(AddMissionText, ClearMissionText); });
                    break;
                default:
                    break;
            }
        }



        #region Свойства - зависимости

        public string MissionNameText => Hack.GetNewMission().Name;
        public IEnumerable<HackProgram> HackPrograms => Hack.HackPrograms.Select(p => new HackProgram {Id = p.Id, Name = p.Name });
        
        /// <summary> Текст выполнения миссии взлома </summary>
        public string MissionText
        {
            get => _missionText;
            set
            {
                if (value == _missionText) return;
                _missionText = value;
                Changed(nameof(MissionText));
            }
        }

        private void AddMissionText(string text)
        {
            MissionText += text;
        }

        private void ClearMissionText()
        {
            MissionText = string.Empty;
        }

        #endregion


        #region Задачи
        /// <summary> Применение программы </summary>
        public void UseProgram(object selectedItem)
        {
            int id = ((HackProgram)selectedItem).Id;
            Hack.UseProgramId(id);
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public struct HackProgram
        {
            /// <summary> Идентификатор </summary>
            public int Id { get; set; }
            /// <summary> Название </summary>
            public string Name { get; set; }
        }
    }
}
