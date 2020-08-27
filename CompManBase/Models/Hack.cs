﻿using System;
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
        private IWallet _wallet; //кошелек игрока

        private bool AnonimaizerDone; //применение анонимайзера
        private bool PasswordDone; //подбор пароля
        private bool MaskDone; //применение маскировки

        public Hack(IPlayer player) : base()
        {
            HackPrograms = new ObservableCollection<HackProgram>();
            _states = player;
            _wallet = player;
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

        #region Задачи
        
        /// <summary> Скачивание софта с запрещенного ресурса </summary>
        public void Mission1(Action<string> addMissionText, Action clearMissionText)
        {
            clearMissionText.Invoke();
            addMissionText.Invoke("Соединение с заблокированным запрещенным ресурсом www.torrents.com");
            addMissionText.Invoke("\nУстановка соединения, необходимо применить анонимайзер .");
            AnonimaizerDone = false;
            int i = 10;
            while (i >= 0 && !AnonimaizerDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nСоединение с запрещенным ресурсом недоступно");
                    addMissionText.Invoke("\n\nМиссия провалена!");
                    return;
                }
                addMissionText.Invoke(".");
                i--;
            }
            addMissionText.Invoke("\nАнонимайзер успешно применен!\n\nСкачивание софта с запрещенного ресурса .");
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(500);
                addMissionText.Invoke(".");
            }
            addMissionText.Invoke("\nСофт успешно скачан");
            addMissionText.Invoke("\n\nМиссия выполнена! +1000 рублей");
            _wallet.Add(1000);
        }

        /// <summary>
        /// Применение программы
        /// </summary>
        public void UseProgramId(int id)
        {
            switch (id)
            {
                case 1: AnonimaizerDone = true;
                    break;
                case 2: PasswordDone = true;
                    break;
                case 3: MaskDone = true;
                    break;
                default:
                    break;
            }
            
        }
        #endregion

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
            new HackMission{Id = 1, Name = "Скачивание софта с запрещенного ресурса", MissionText = "Очень простая учебная задача. Необходимо скачать софт с запрещенного заблорикованного в Интренете ресурса используя анонимайзер. Плата - 1000 рублей.", NeedLevel = 1},
            new HackMission{Id = 2, Name = "Взлом аккаунта пользователя", MissionText = "Простое задание. Взломать аккаунт у пользователя в социальной сети и скачать с него секретную информацию. Плата - 5000 рублей", NeedLevel = 2},
        };
        #endregion
    }
}
