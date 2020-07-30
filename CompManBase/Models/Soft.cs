using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static CompManBase.Models.ComputerBase;

namespace CompManBase.Models
{
    public class Soft : SoftBase
    {
        private IWallet _wallet; //кошелек игрока
        private IChangeScore _score; //счет игрока
        private IInfoComputer _infoComputer; //инфа по компьютеру
        /// <summary> Конструктор с кошелем игрока </summary>
        /// <param name="wallet">Кошель игрока</param>
        public Soft(IPlayer player, IInfoComputer computer)
        {
            _wallet = player;
            _score = player;
            _infoComputer = computer;
        }

        #region Следующие по уровню программные компоненты

        public string NextActionOs
        {
            get
            {
                if (Os == 0)
                    return "Установка новой операционной системы";
                if (Os >= OsNames.Length - 1)
                    return "У вас и так максимально мощная операционка";
                return "Установка более мощной операционной системы";
            }
        }
        public SoftPrt NextOs => GetNextPart(Os, OsNames);
        public bool NextOsMayBuy => NextOs.Level != -1;
        public string NextActionDevelop
        {
            get
            {
                if (Develop == 0)
                    return "Установка новой среды разработки ПО";
                if (Develop >= DevelopNames.Length - 1)
                    return "У вас и так максимально мощная среда разработки ПО";
                return "Установка более мощной среды разработки ПО";
            }
        }
        public SoftPrt NextDevelop => GetNextPart(Develop, DevelopNames);
        public bool NextDevelopMayBuy => NextDevelop.Level != -1;
        public string NextActionAntivirus
        {
            get
            {
                if (Antivirus == 0)
                    return "Установка нового антивируса";
                if (Antivirus >= AntivirusNames.Length - 1)
                    return "У вас и так максимально мощный антивирус";
                return "Установка более мощного антивируса";
            }
        }
        public SoftPrt NextAntivirus => GetNextPart(Antivirus, AntivirusNames);
        public bool NextAntivirusMayBuy => NextAntivirus.Level != -1;
        public string NextActionGame
        {
            get
            {
                if (Game == 0)
                    return "Установка новой компьютерной игры";
                if (Game >= GameNames.Length - 1)
                    return "У вас и так максимально мощая компьютерная игра";
                return "Установка более мощной компьютерной игры";
            }
        }
        public SoftPrt NextGame => GetNextPart(Game, GameNames);
        public bool NextGameMayBuy => NextGame.Level != -1;
        public string NextActionBrowser
        {
            get
            {
                if (Browser == 0)
                    return "Установка нового Интернет-браузера";
                if (Browser >= BrowserNames.Length - 1)
                    return "У вас и так максимально мощный Интернет-браузер";
                return "Установка более мощного Интернет-браузера";
            }
        }
        public SoftPrt NextBrowser => GetNextPart(Browser, BrowserNames);
        public bool NextBrowserMayBuy => NextBrowser.Level != -1;


        /// <summary> Получение следующей по уровню программной части </summary>
        private SoftPrt GetNextPart(int part, SoftPrt[] names)
        {
            if (part <= names.Length - 2)
                return names[part + 1];
            else
                return new SoftPrt { Level = -1, Name = "Улучшать софт дальше некуда" };
        }
        #endregion

        #region Процесс установки частей программ
        /// <summary> Прогресс установки программы текущей </summary>
        public int InstallProgress { get; set; }

        public async Task BuyOsAsync()
        {
            if (Os >= OsNames.Length - 1)
                return;
            if (!_wallet.MaySubsctact(NextOs.Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            bool needs = false;
            StringBuilder sb = new StringBuilder();
            if (Os >= _infoComputer.GetLevel(Components.Platform))
                needs = AppendTextToNeeds(sb, "более мощная платформа");
            if (Os >= _infoComputer.GetLevel(Components.Ram) + 1 || _infoComputer.GetLevel(Components.Ram) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная оперативная память");
            if (Os >= _infoComputer.GetLevel(Components.Hdd) + 1 || _infoComputer.GetLevel(Components.Hdd) <= 0)
                needs = AppendTextToNeeds(sb, "более мощный жесткий диск");
            if (Os >= _infoComputer.GetLevel(Components.Video) + 2 || _infoComputer.GetLevel(Components.Video) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная видеокарта");
            if (needs)
            {
                MessageBox.Show($"Для установки ОС {NextOs.Name} взамен {OsName} требуется:\n" + sb.ToString(), "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextOs.Cost);
            await Task.Run(InstallProgramm());
            InstallProgress = 0;
            Changed(nameof(InstallProgress));
            Os++;
            _score.Add(1);
        }
        public async Task BuyDevelopAsync()
        {
            if (Develop >= DevelopNames.Length - 1)
                return;
            if (!_wallet.MaySubsctact(NextDevelop.Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            bool needs = false;
            StringBuilder sb = new StringBuilder();
            if (Develop >= Os)
                needs = AppendTextToNeeds(sb, "более мощная операционная система");
            if (Develop >= _infoComputer.GetLevel(Components.Platform))
                needs = AppendTextToNeeds(sb, "более мощная платформа");
            if (Develop >= _infoComputer.GetLevel(Components.Ram) || _infoComputer.GetLevel(Components.Ram) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная оперативная память");
            if (Develop >= _infoComputer.GetLevel(Components.Hdd) || _infoComputer.GetLevel(Components.Hdd) <= 0)
                needs = AppendTextToNeeds(sb, "более мощный жесткий диск");
            if (Develop >= _infoComputer.GetLevel(Components.Video) + 1 || _infoComputer.GetLevel(Components.Video) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная видеокарта");
            if (Develop >= _infoComputer.GetLevel(Components.Internet) + 2)
                needs = AppendTextToNeeds(sb, "более мощное подключеие к сети Интернет");
            if (needs)
            {
                MessageBox.Show($"Для установки ОС {NextDevelop.Name} взамен {DevelopName} требуется:\n" + sb.ToString(), "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextDevelop.Cost);
            await Task.Run(InstallProgramm());
            InstallProgress = 0;
            Changed(nameof(InstallProgress));
            Develop++;
            _score.Add(1);
        }
        public async Task BuyAntivirusAsync()
        {
            if (Antivirus >= AntivirusNames.Length - 1)
                return;
            if (!_wallet.MaySubsctact(NextAntivirus.Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            bool needs = false;
            StringBuilder sb = new StringBuilder();
            if (Antivirus >= Os)
                needs = AppendTextToNeeds(sb, "более мощная операционная система");
            if (Antivirus >= _infoComputer.GetLevel(Components.Platform))
                needs = AppendTextToNeeds(sb, "более мощная платформа");
            if (Antivirus >= _infoComputer.GetLevel(Components.Ram) + 2 || _infoComputer.GetLevel(Components.Ram) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная оперативная память");
            if (Antivirus >= _infoComputer.GetLevel(Components.Hdd) + 3 || _infoComputer.GetLevel(Components.Hdd) <= 0)
                needs = AppendTextToNeeds(sb, "более мощный жесткий диск");
            if (Antivirus >= _infoComputer.GetLevel(Components.Video) + 3 || _infoComputer.GetLevel(Components.Video) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная видеокарта");
            if (Antivirus >= _infoComputer.GetLevel(Components.Internet) + 1)
                needs = AppendTextToNeeds(sb, "более мощное подключеие к сети Интернет");
            if (needs)
            {
                MessageBox.Show($"Для установки антвируса {NextAntivirus.Name} взамен {AntivirusName} требуется:\n" + sb.ToString(), "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextAntivirus.Cost);
            await Task.Run(InstallProgramm());
            InstallProgress = 0;
            Changed(nameof(InstallProgress));
            Antivirus++;
            _score.Add(1);
        }
        public async Task BuyGameAsync()
        {
            if (Game >= GameNames.Length - 1)
                return;
            if (!_wallet.MaySubsctact(NextGame.Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            bool needs = false;
            StringBuilder sb = new StringBuilder();
            if (Game >= Os)
                needs = AppendTextToNeeds(sb, "более мощная операционная система");
            if (Game >= _infoComputer.GetLevel(Components.Platform))
                needs = AppendTextToNeeds(sb, "более мощная платформа");
            if (Game >= _infoComputer.GetLevel(Components.Ram) || _infoComputer.GetLevel(Components.Ram) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная оперативная память");
            if (Game >= _infoComputer.GetLevel(Components.Hdd) || _infoComputer.GetLevel(Components.Hdd) <= 0)
                needs = AppendTextToNeeds(sb, "более мощный жесткий диск");
            if (Game >= _infoComputer.GetLevel(Components.Video) || _infoComputer.GetLevel(Components.Video) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная видеокарта");
            if (needs)
            {
                MessageBox.Show($"Для установки игры {NextGame.Name} взамен {GameName} требуется:\n" + sb.ToString(), "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextGame.Cost);
            await Task.Run(InstallProgramm());
            InstallProgress = 0;
            Changed(nameof(InstallProgress));
            Game++;
            _score.Add(1);
        }
        public async Task BuyBrowserAsync()
        {
            if (Browser >= BrowserNames.Length - 1)
                return;
            if (!_wallet.MaySubsctact(NextBrowser.Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            bool needs = false;
            StringBuilder sb = new StringBuilder();
            if (Browser >= Os)
                needs = AppendTextToNeeds(sb, "более мощная операционная система");
            if (Browser >= _infoComputer.GetLevel(Components.Platform))
                needs = AppendTextToNeeds(sb, "более мощная платформа");
            if (Browser >= _infoComputer.GetLevel(Components.Ram) + 1 || _infoComputer.GetLevel(Components.Ram) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная оперативная память");
            if (Browser >= _infoComputer.GetLevel(Components.Hdd) + 2 || _infoComputer.GetLevel(Components.Hdd) <= 0)
                needs = AppendTextToNeeds(sb, "более мощный жесткий диск");
            if (Browser >= _infoComputer.GetLevel(Components.Video) + 3 || _infoComputer.GetLevel(Components.Video) <= 0)
                needs = AppendTextToNeeds(sb, "более мощная видеокарта");
            if (Antivirus >= _infoComputer.GetLevel(Components.Internet) + 1)
                needs = AppendTextToNeeds(sb, "более мощное подключеие к сети Интернет");
            if (needs)
            {
                MessageBox.Show($"Для установки браузера {NextBrowser.Name} взамен {BrowserName} требуется:\n" + sb.ToString(), "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextBrowser.Cost);
            await Task.Run(InstallProgramm());
            InstallProgress = 0;
            Changed(nameof(InstallProgress));
            Browser++;
            _score.Add(1);
        }

        /// <summary> Добавление причины к отказу </summary>
        private static bool AppendTextToNeeds(StringBuilder sb, string text)
        {
            bool needs = true;
            sb.AppendLine(text);
            return needs;
        }
        /// <summary> Установка программы </summary>
        private Action InstallProgramm()
        {
            return () =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    InstallProgress = i;
                    Changed(nameof(InstallProgress));
                    Thread.Sleep(30);
                }
            };
        }
        #endregion
    }
}
