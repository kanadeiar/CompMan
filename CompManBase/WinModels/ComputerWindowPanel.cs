using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompManBase.WinModels
{
    public class ComputerWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Компьютер </summary>
        public Computer Computer { get; set; }
        public ComputerWindowPanel() { }
        public ComputerWindowPanel(Computer computer)
        {
            Computer = computer;
        }

        #region Свойства-зависимости
        public string NextPlatformName => Computer.NextPlatform.Name;
        public string NextPlatformCost => Computer.NextPlatform.Cost.ToString() + " рублей";
        public bool MayBuyNextPlatform => Computer.NextPlatformMayBuy;
        public string TextButtonBuyPlatform => Computer.NextPlatformMayBuy ? "Купить!" : "Облом.";
        public void BuyPlatform()
        {
            Computer.BuyPlatform();
            Changed(nameof(NextPlatformName));
            Changed(nameof(NextPlatformCost));
            Changed(nameof(MayBuyNextPlatform));
            Changed(nameof(TextButtonBuyPlatform));
        }
        public string NextRamName => Computer.NextRam.Name;
        public string NextRamCost => Computer.NextRam.Cost.ToString() + " рублей";
        public bool MayBuyNextRam => Computer.NextRamMayBuy;
        public string TextButtonBuyRam => Computer.NextRamMayBuy ? "Купить!" : "Облом.";
        public void BuyRam()
        {
            Computer.BuyRam();
            Changed(nameof(NextRamName));
            Changed(nameof(NextRamCost));
            Changed(nameof(MayBuyNextRam));
            Changed(nameof(TextButtonBuyRam));
        }
        public string NextHddName => Computer.NextHdd.Name;
        public string NextHddCost => Computer.NextHdd.Cost.ToString() + " рублей";
        public bool MayBuyNextHdd => Computer.NextHddMayBuy;
        public string TextButtonBuyHdd => Computer.NextHddMayBuy ? "Купить!" : "Облом.";
        public void BuyHdd()
        {
            Computer.BuyHdd();
            Changed(nameof(NextHddName));
            Changed(nameof(NextHddCost));
            Changed(nameof(MayBuyNextHdd));
            Changed(nameof(TextButtonBuyHdd));
        }
        public string NextVideoName => Computer.NextVideo.Name;
        public string NextVideoCost => Computer.NextVideo.Cost.ToString() + " рублей";
        public bool MayBuyNextVideo => Computer.NextVideoMayBuy;
        public string TextButtonBuyVideo => Computer.NextVideoMayBuy ? "Купить!" : "Облом.";
        public void BuyVideo()
        {
            Computer.BuyVideo();
            Changed(nameof(NextVideoName));
            Changed(nameof(NextVideoCost));
            Changed(nameof(MayBuyNextVideo));
            Changed(nameof(TextButtonBuyVideo));
        }
        public string NextInternetName => Computer.NextInternet.Name;
        public string NextInternetCost => Computer.NextInternet.Cost.ToString() + " рублей";
        public bool MayBuyNextInternet => Computer.NextInternetMayBuy;
        public string TextButtonBuyInternet => Computer.NextInternetMayBuy ? "Купить!" : "Облом.";
        public void BuyInternet()
        {
            Computer.BuyInternet();
            Changed(nameof(NextInternetName));
            Changed(nameof(NextInternetCost));
            Changed(nameof(MayBuyNextInternet));
            Changed(nameof(TextButtonBuyInternet));
        }

        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
