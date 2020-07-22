using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CompManBase.Models
{
    public class Computer : ComputerBase
    {
        private IWallet _wallet; //кошелек игрока

        public Computer(PlayerBase player)
        {
            _wallet = player;
        }
        #region Следующие по уровню компоненты
        public string NextActionPlatform
        {
            get
            {
                if (Platform == 0)
                    return "Покупка новой платформы";
                if (Platform >= PlatformNames.Length - 1)
                    return "У вас и так максимально мощная платформа";
                return "Апгрейд платформы";
            }
        }
        public HardCpt NextPlatform => GetNextComponent(Platform, PlatformNames);
        public bool NextPlatformMayBuy => NextPlatform.Level != -1 && _wallet.MaySubsctact(NextPlatform.Cost);
        public void BuyPlatform()
        {
            if (Platform >= PlatformNames.Length - 1)
                return;
            _wallet.Substract(NextPlatform.Cost);
            Platform++;
        }
        public string NextActionRam
        {
            get
            {
                if (Ram == 0)
                    return "Покупка новой оперативной памяти";
                if (Ram >= RamNames.Length - 1)
                    return "У вас и так максимальне количество ОЗУ";
                return "Апгрейд оперативной памяти";
            }
        }
        public HardCpt NextRam => GetNextComponent(Ram, RamNames);
        public bool NextRamMayBuy => NextRam.Level != -1 && _wallet.MaySubsctact(NextRam.Cost);
        public void BuyRam()
        {
            if (Ram >= RamNames.Length - 1)
                return;
            if (Ram >= Platform)
            {
                MessageBox.Show("Для апгрейда ОЗУ требуется более мощная платформа!", "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextRam.Cost);
            Ram++;
        }
        public string NextActionHdd
        {
            get
            {
                if (Hdd == 0)
                    return "Покупка нового жесткого диска";
                if (Hdd >= HddNames.Length - 1)
                    return "У вас и так максимально мощный жесткий диск";
                return "Апгрейд жесткого диска";
            }
        }
        public HardCpt NextHdd => GetNextComponent(Hdd, HddNames);
        public bool NextHddMayBuy => NextHdd.Level != -1 && _wallet.MaySubsctact(NextHdd.Cost);
        public void BuyHdd()
        {
            if (Hdd >= HddNames.Length - 1)
                return;
            if (Hdd >= Platform)
            {
                MessageBox.Show("Для апгрейда жесткого диска требуется более мощная платформа!", "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextHdd.Cost);
            Hdd++;
        }
        public string NextActionVideo
        {
            get
            {
                if (Video == 0)
                    return "Покупка новой видеокарты";
                if (Video >= VideoNames.Length - 1)
                    return "У вас и так максимально мощная видеокарта";
                return "Апгрейд видеокарты";
            }
        }
        public HardCpt NextVideo => GetNextComponent(Video, VideoNames);
        public bool NextVideoMayBuy => NextVideo.Level != -1 && _wallet.MaySubsctact(NextVideo.Cost);
        public void BuyVideo()
        {
            if (Video >= HddNames.Length - 1)
                return;
            if (Video >= Platform)
            {
                MessageBox.Show("Для апгрейда видеокарты требуется более мощная платформа!", "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextVideo.Cost);
            Video++;
        }
        public string NextActionInternet
        {
            get
            {
                if (Internet == 0)
                    return "Подключение к Интернету";
                if (Internet >= InternetNames.Length - 1)
                    return "У вас и так максимально скоростной Интернет";
                return "Апгрейд подключения к Интернету";
            }
        }
        public HardCpt NextInternet => GetNextComponent(Internet, InternetNames);
        public bool NextInternetMayBuy => NextInternet.Level != -1 && _wallet.MaySubsctact(NextInternet.Cost);
        public void BuyInternet()
        {
            if (Internet >= InternetNames.Length - 1)
                return;
            if (Platform < 1)
            {
                MessageBox.Show("Для апгрейда Интернет-провайдера требуется купить любую платформу!", "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextInternet.Cost);
            Internet++;
        }


        /// <summary> Получение следующей по уровню платформы </summary>
        private HardCpt GetNextComponent(int platform, HardCpt[] names)
        {
            if (platform <= names.Length - 2)
                return names[platform + 1];
            else
                return new HardCpt { Level = -1, Name = "Улучшать больше некуда" };
        }
        #endregion
    }
}
