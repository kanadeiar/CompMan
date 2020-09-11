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
        private IWallet _wallet; //кошелек игрока
        private IChangeScore _score; //счет игрока

        private bool AnonimaizerDone; //применение анонимайзера
        private bool PasswordDone; //подбор пароля
        private bool MaskDone; //применение маскировки
        private bool DDOSDone; //применение ДДОС атаки
        private bool Finance; //применение финансовых транзакций

        public Hack(IPlayer player) : base()
        {
            HackPrograms = new ObservableCollection<HackProgram>();
            _states = player;
            _wallet = player;
            _score = player;
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

        #region Задания
        
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
            addMissionText.Invoke("\nАнонимайзер успешно применен!\n\nСкачивание софта с запрещенного ресурса -");
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(500);
                addMissionText.Invoke("-");
            }
            addMissionText.Invoke("\nСофт успешно скачан");
            addMissionText.Invoke("\n\nМиссия выполнена! +1000 рублей");
            _wallet.Add(1000);
            _score.Add(1);
        }

        /// <summary> Взлом аккаунта пользователя </summary>
        public void Mission2(Action<string> addMissionText, Action clearMissionText)
        {
            clearMissionText.Invoke();
            addMissionText.Invoke("Соединение с API социальной сети \"Вконтакте\" api.vk.com");
            addMissionText.Invoke("\nУстановка соединения, необходимо применить анонимайзер .");
            AnonimaizerDone = false;
            int i = 10;
            while (i >= 0 && !AnonimaizerDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nСоединение с ресурсом не удалось");
                    addMissionText.Invoke("\n\nМиссия провалена!");
                    return;
                }
                addMissionText.Invoke(".");
                i--;
            }
            addMissionText.Invoke("\nСоединение установлено.\n\nВвод логина пользователя:> #");
            for (int j = 0; j < 6; j++)
            {
                Thread.Sleep(1000);
                addMissionText.Invoke("#");
            }
            addMissionText.Invoke("\nВвод пароля, необходимо применить программу подбора паролей .");
            PasswordDone = false;
            i = 10;
            while (i >= 0 && !PasswordDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nИстекло время ввода пароля");
                    addMissionText.Invoke("\n\nМиссия провалена!");
                    return;
                }
                addMissionText.Invoke(".");
                i--;
            }
            addMissionText.Invoke("\nУспешный вход в аккаунт пользователя\n\nСкачивание секретной информации с аккаунта пользователя .");
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(500);
                addMissionText.Invoke(".");
            }
            addMissionText.Invoke("\nСекретная информация успешно скачана");
            addMissionText.Invoke("\n\nМиссия выполнена! +5000 рублей");
            _wallet.Add(5000);
            _score.Add(1);
        }

        /// <summary> Взлом сайта банка </summary>
        public void Mission3(Action<string> addMissionText, Action clearMissionText)
        {
            clearMissionText.Invoke();
            addMissionText.Invoke("Соединение с консолью администрирования SSH сайта банка ssh.homebank.ru");
            addMissionText.Invoke("\nУстановка соединения, необходимо применить анонимайзер .");
            AnonimaizerDone = false;
            int i = 10;
            while (i >= 0 && !AnonimaizerDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nНе удалось соединиться с банком.");
                    addMissionText.Invoke("\n\nМиссия провалена!");
                    return;
                }
                addMissionText.Invoke(".");
                i--;
            }
            addMissionText.Invoke("\nСоединение с банком установлено.\n\nПроцедура валидации устройства пользователя, необходимо применить маскировку .");
            MaskDone = false;
            i = 10;
            while (i >= 0 && !MaskDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nУстройство пользователя не подтверждено, доступ откленен.");
                    addMissionText.Invoke("\n\nМиссия провалена!");
                    return;
                }
                addMissionText.Invoke(".");
                i--;
            }
            addMissionText.Invoke("\nПроверка пройдена.\n\nПолучение доступа. Ввод пароля пользователя:> *");
            PasswordDone = false;
            i = 10;
            while (i >= 0 && !PasswordDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nИстекло время ввода пароля");
                    addMissionText.Invoke("\n\nМиссия провалена! За нарушение закона штраф 50000 рублей!");
                    _wallet.Substract(50000);
                    _score.Substract(1);
                    return;
                }
                addMissionText.Invoke("*");
                i--;
            }
            addMissionText.Invoke("\nУспешный получение доступа.\n\nСкачивание секретной информации с сервера банка -");
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(500);
                addMissionText.Invoke("-");
            }
            addMissionText.Invoke("\nСекретная информация успешно скачана\n\nРазмещение фальшивой информации на сервере банка |");
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(500);
                addMissionText.Invoke("|");
            }
            addMissionText.Invoke("\nФальшивая информация успешно размещена на сервере банка.");
            addMissionText.Invoke("\n\nМиссия выполнена! +10000 рублей");
            _wallet.Add(10000);
            _score.Add(1);
        }

        /// <summary> Заддосивание сайта банка </summary>
        public void Mission4(Action<string> addMissionText, Action clearMissionText)
        {
            clearMissionText.Invoke();
            addMissionText.Invoke("Соединение с консолью безопасности сайта банка secure.vkbank.ru");
            addMissionText.Invoke("\nУстановка соединения, необходимо применить анонимайзер .");
            AnonimaizerDone = false;
            int i = 10;
            while (i >= 0 && !AnonimaizerDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nНе удалось соединиться с банком.");
                    addMissionText.Invoke("\n\nМиссия провалена!");
                    return;
                }
                addMissionText.Invoke(".");
                i--;
            }
            addMissionText.Invoke("\nСоединение с системой безопасности установлено.\n\nВНИМАНИЕ! Процедура проверки пользователя, необходимо применить маскировку .");
            MaskDone = false;
            i = 10;
            while (i >= 0 && !MaskDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nВы попались! Доступ откленен.");
                    addMissionText.Invoke("\n\nМиссия провалена! За нарушение закона штраф 1000000 рублей!");
                    _wallet.Substract(1000000);
                    _score.Substract(1);
                    return;
                }
                addMissionText.Invoke(".");
                i--;
            }
            addMissionText.Invoke("\nВы успешно замаскировались.\n\nПолучение доступа. Ввод пароля пользователя:> *");
            PasswordDone = false;
            i = 10;
            while (i >= 0 && !PasswordDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nИстекло время ввода пароля! Вы попались!");
                    addMissionText.Invoke("\n\nМиссия провалена! За нарушение закона штраф 1000000 рублей!");
                    _wallet.Substract(1000000);
                    _score.Substract(1);
                    return;
                }
                addMissionText.Invoke("*");
                i--;
            }
            addMissionText.Invoke("\nУспешное получение доступа.\n\nОтключение защиты от ДДОС атак #");
            for (int j = 0; j < 5; j++)
            {
                Thread.Sleep(1000);
                addMissionText.Invoke("#");
            }
            addMissionText.Invoke("\nУспешное отключение защиты от ДДОС атак на 1 минуту.\nУспешный выход из системы безопасности банка.\n\nПора применять ДДОС-атаку ->");
            DDOSDone = false;
            i = 60;
            while (i >= 0 && !DDOSDone)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    addMissionText.Invoke("\nИстекло время ввода отключения защиты.\n\nМиссия провалена!");
                    _score.Substract(1);
                    return;
                }
                i--;
            }
            addMissionText.Invoke("\nВНИМАНИЕ! Производится ДДОС Атака сайта банка! \\");
            for (int j = 0; j < 30; j++)
            {
                Thread.Sleep(300);
                addMissionText.Invoke("\\");
            }

            addMissionText.Invoke("\nДДОС атака сайта банка успешно проведена. Сайт больше не доступен клиентам.");
            addMissionText.Invoke("\n\nМиссия выполнена! +100000 рублей");
            _wallet.Add(100000);
            _score.Add(1);
        }

        /// <summary> Кража денег со счетов в банке </summary>
        public void Mission5(Action<string> addMissionText, Action clearMissionText)
        {
            clearMissionText.Invoke();

            addMissionText.Invoke("\n\nМиссия выполнена! +300000 рублей");
            _wallet.Add(300000);
            _score.Add(1);
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
                case 4: DDOSDone = true;
                    break;
                case 5: Finance = true;
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
            new HackMission{Id = 1, Name = "Скачивание софта с запрещенного ресурса", MissionText = "Очень простая учебная задача. Необходимо скачать софт с запрещенного заблорикованного в Интренете ресурса используя анонимайзер. Плата - 1000 рублей.", NeedLevel = 3},
            new HackMission{Id = 2, Name = "Взлом аккаунта пользователя", MissionText = "Простое задание. Взломать аккаунт у пользователя в социальной сети и скачать с него секретную информацию. Плата - 5000 рублей.", NeedLevel = 4},
            new HackMission{Id = 3, Name = "Взлом сайта банка", MissionText = "Взломать защищенный сайт филиала банка, скачать секретную информацию, разместить на нем фальшивую информацию. Плата - 10000 рублей. Штраф - 50000 рублей.", NeedLevel = 4},
            new HackMission{Id = 4, Name = "Блокирование сайта банка", MissionText = "Заддосить защищеный сайт банка, сделать его временно недоступным для пользователей. Плата - 100000 рулей. Штраф - 1000000 рублей.", NeedLevel = 5},
            new HackMission{Id = 5, Name = "Кража денег со счетов из банка", MissionText = "Украсть деньги с нескольких счетов из банка, положить на подставной счет для последующего отмывания денег. Плата - 300000 рублей. Штраф - 3000000 рублей.", NeedLevel = 5},
        };
        #endregion
    }
}
