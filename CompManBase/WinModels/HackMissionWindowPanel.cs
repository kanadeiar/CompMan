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
            Task.Run(() => {Mission1();});
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

        #endregion

        #region Задачи
        /// <summary> Скачивание софта с запрещенного ресурса </summary>
        public void Mission1()
        {
            MissionText = "Соединение с заблокированным запрещенным ресурсом www.torrents.com - .";
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);


                MissionText += ".";
            }
            MissionText += "\nСоединение с запрещенным ресурсом недоступно";
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
