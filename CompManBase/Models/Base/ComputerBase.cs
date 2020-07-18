using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public abstract class ComputerBase : INotifyPropertyChanged
    {
        private int _platform;
        private int _ram;
        private int _hdd;
        private int _internet;
        private int _video;

        #region Свойства-зависимости
        public int Platform
        {
            get => _platform;
            set
            {
                if (value == _platform) return;
                _platform = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Platform)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlatformName)));
            }
        }
        public string PlatformName => PlatformNames[_platform];
        public int Ram
        {
            get => _ram;
            set
            {
                if (value == _ram) return;
                _ram = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ram)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RamName)));
            }
        }
        public string RamName => RamNames[_ram];
        public int Hdd
        {
            get => _hdd;
            set
            {
                if (value == _hdd) return;
                _hdd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hdd)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HddName)));
            }
        }
        public string HddName => HddNames[_hdd];
        public int Internet
        {
            get => _internet;
            set
            {
                if (value == _internet) return;
                _internet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Internet)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InternetName)));
            }
        }
        public string InternetName => InternetNames[_internet];
        public int Video
        {
            get => _video;
            set
            {
                if (value == _video) return;
                _video = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Video)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VideoName)));
            }
        }
        public string VideoName => VideoNames[_video];
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string[] PlatformNames = new[] { "нет компьютера", "Intel Pentium 4", "Intel Celeron J4005", "AMD Ryzen 3 2200X", "Intel Core i5-9400KF", "Intel Core i9-9900KF" };
        public string[] RamNames = new[] { "отсутствует", "1 Гб DDR3", "2 Гб DDR4", "4 Гб DDR4", "8 Гб DDR4", "32 Гб DDR4" };
        public string[] HddNames = new[] { "отсутствует", "256 Гб HDD", "1 Тб HDD", "128Гб SSD + 1Тб HDD", "256Тб SSD + 2Тб HDD", "2Тб SSD + 4Тб HDD" };
        public string[] InternetNames = new[] { "отсутствует", "Dial-up модем", "USB модем", "ADSL", "оптиковолокно", "Спутник-я тарелка" };
        public string[] VideoNames = new[] { "отсутствует", "1 Гб Radeon R5 230", "4Гб GeForce GTX 1660Ti", "6Гб GeForce GTX 1330", "8Гб Radeon RX5700XT", "11Гб GeForce RTX2080Ti" };
    }


}
