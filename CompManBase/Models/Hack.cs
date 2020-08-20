using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CompManBase.Interfaces;

namespace CompManBase.Models
{
    public class Hack : HackBase, IHackPrograms
    {
        Random rand = new Random();
        private IStates _states; //состояние игрока
        public Hack(IPlayer player) : base()
        {
            HackPrograms = new ObservableCollection<HackProgram>();
            _states = player;
        }
        /// <summary> Программы в наличии </summary>
        public IEnumerable<HackProgram> HackPrograms { get; set; }
        /// <summary> Текущая миссия </summary>
        public HackMission CurrentMission { get; set; }
        public HackMission GetNewMission()
        {
            var mayMissions = _hackMissions.Where(m => m.NeedLevel <= _states.Level).ToArray();
            if (mayMissions.Length == 0)
                return CurrentMission = new HackMission{Id = 0, Name = "Слишком низкий уровень!"};
            return CurrentMission = mayMissions[rand.Next(mayMissions.Count())];
        }
        /// <summary> Добавление в хранилище новой программы </summary>
        public void AddHackProgram(int id)
        {
            ((ObservableCollection<HackProgram>)HackPrograms).Add(new HackProgram {Id = id, Name = HackProgramsNames.First(p => p.Id == id).Name});
        }



        //////////////////////////////////////////////////////////////////////////////////////////

        #region Данные
        public struct HackMission
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string MissionText { get; set; }
            public int NeedLevel { get; set; }
        }
        private static HackMission[] _hackMissions = new[]
        {
            new HackMission{Id = 1, Name = "Скачивание софта с запрещенного ресурса", MissionText = "Очень простая учебная задача. Необходимо скачать софт с запрещенного заблорикованного в Интренете ресурса используя анонимайзер.", NeedLevel = 1},
            new HackMission{Id = 2, Name = "Взлом аккаунта пользователя", MissionText = "Простое задание. Взломать аккаунт у пользователя в социальной сети и скачать с него секретную информацию.", NeedLevel = 2},
        };
        #endregion
    }
}
