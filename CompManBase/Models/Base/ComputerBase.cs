using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public abstract class ComputerBase : INotifyPropertyChanged, IInfoComputer
    {
        private int _platform;
        private int _ram;
        private int _hdd;
        private int _video;
        private int _internet;

        public ComputerBase()
        {
        }
        int IInfoComputer.GetLevel(Components components)
        {
            switch (components)
            {
                case Components.Platform: return PlatformNames[_platform].Level;
                case Components.Ram: return RamNames[_ram].Level;
                case Components.Hdd: return HddNames[_hdd].Level;
                case Components.Video: return VideoNames[_video].Level;
                case Components.Internet: return InternetNames[_internet].Level;
                default: throw new InvalidEnumArgumentException("Неверный компонент компьютера!");
            }
        }
        #region Свойства-зависимости
        public int Platform
        {
            get => _platform;
            set
            {
                if (value == _platform) return;
                _platform = value;
                Changed(nameof(Platform));
                Changed(nameof(PlatformName));
            }
        }
        public string PlatformName => PlatformNames[_platform].Name;
        public int Ram
        {
            get => _ram;
            set
            {
                if (value == _ram) return;
                _ram = value;
                Changed(nameof(Ram));
                Changed(nameof(RamName));
            }
        }
        public string RamName => RamNames[_ram].Name;
        public int Hdd
        {
            get => _hdd;
            set
            {
                if (value == _hdd) return;
                _hdd = value;
                Changed(nameof(Hdd));
                Changed(nameof(HddName));
            }
        }
        public string HddName => HddNames[_hdd].Name;
        public int Video
        {
            get => _video;
            set
            {
                if (value == _video) return;
                _video = value;
                Changed(nameof(Video));
                Changed(nameof(VideoName));
            }
        }
        public string VideoName => VideoNames[_video].Name;
        public int Internet
        {
            get => _internet;
            set
            {
                if (value == _internet) return;
                _internet = value;
                Changed(nameof(Internet));
                Changed(nameof(InternetName));
            }
        }
        public string InternetName => InternetNames[_internet].Name;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /////////////////////////////////////////////////////////////////////
        #region Данные
        public struct HardCpt
        {
            /// <summary> Уровень железа </summary>
            public int Level;
            /// <summary> Название железа </summary>
            public string Name;
            /// <summary> Стоимость железа </summary>
            public int Cost;
        }
        public enum Components
        {
            Platform,
            Ram,
            Hdd,
            Video,
            Internet,
        }
        public static HardCpt[] PlatformNames = new[]
        {
            new HardCpt { Level = 0, Name ="нет компьютера", Cost = 0 },
            new HardCpt { Level = 1, Name ="Intel Celeron D", Cost = 2000 },
            new HardCpt { Level = 2, Name ="AMD Ryzen 3 1200", Cost = 7500 },
            new HardCpt { Level = 3, Name ="Intel Core i3-10320", Cost = 14200 },
            new HardCpt { Level = 4, Name ="AMD Ryzen 5 3600", Cost = 21000 },
            new HardCpt { Level = 5, Name ="Intel Core i5-4920K", Cost = 32000 },
            new HardCpt { Level = 6, Name ="Intel Core i9-9980XE", Cost = 189000 },
        };
        public static HardCpt[] RamNames = new[]
        {
            new HardCpt { Level = 0, Name ="отсутствует", Cost = 0 },
            new HardCpt { Level = 1, Name ="2 Гб DDR3 Samsung", Cost = 600 },
            new HardCpt { Level = 2, Name ="4 Гб DDR4 Corsair", Cost = 1900 },
            new HardCpt { Level = 3, Name ="8 Гб DDR4 Kingston", Cost = 2700 },
            new HardCpt { Level = 4, Name ="16 Гб DDR4 Patriot", Cost = 5000 },
            new HardCpt { Level = 5, Name ="2*16 Гб DDR4 Kingston", Cost = 32000 },
            new HardCpt { Level = 6, Name ="2*32 Гб DDR4 Corsair", Cost = 53000 },
        };
        public static HardCpt[] HddNames = new[]
        {
            new HardCpt { Level = 0, Name ="отсутствует", Cost = 0 },
            new HardCpt { Level = 1, Name ="100 Гб HDD Samsung", Cost = 1000 },
            new HardCpt { Level = 2, Name ="500 Гб HDD WD", Cost = 3000 },
            new HardCpt { Level = 3, Name ="1 Тб HDD Seagate", Cost = 6000 },
            new HardCpt { Level = 4, Name ="1 Тб SSD Transcend", Cost = 10500 },
            new HardCpt { Level = 5, Name ="2 Тб SSD Micron", Cost = 25000 },
            new HardCpt { Level = 6, Name ="6 Тб SSD Intel", Cost = 206000 },
        };
        public static HardCpt[] VideoNames = new[]
        {
            new HardCpt { Level = 0, Name ="отсутствует", Cost = 0 },
            new HardCpt { Level = 1, Name ="1Гб AFOX Radeon", Cost = 2100 },
            new HardCpt { Level = 2, Name ="2 Гб Inno GT 1030", Cost = 5100 },
            new HardCpt { Level = 3, Name ="4 Гб DDR4 ASUS ROG-STRIX-GTX1650S", Cost = 15800 },
            new HardCpt { Level = 4, Name ="8 Гб GIGABYTE GV-R57XTGAMING", Cost = 35000 },
            new HardCpt { Level = 5, Name ="11 Гб ASUS TURBO-RTX2080", Cost = 102000 },
            new HardCpt { Level = 6, Name ="32 Гб Tesla V100", Cost = 733000 },
        };
        public static HardCpt[] InternetNames = new[]
        {
            new HardCpt { Level = 0, Name ="отсутствует", Cost = 0 },
            new HardCpt { Level = 1, Name ="Dial-up модем 10 Кб/с", Cost = 300 },
            new HardCpt { Level = 2, Name ="USB GPRS модем 100 Кб/с", Cost = 1000 },
            new HardCpt { Level = 3, Name ="ADSL 1 Мб/с", Cost = 2000 },
            new HardCpt { Level = 4, Name ="FTTB 10 Мб/с", Cost = 5000 },
            new HardCpt { Level = 5, Name ="xPON оптика 100 Мб/с", Cost = 50000 },
            new HardCpt { Level = 6, Name ="Спутниковый 1 Гб/с", Cost = 300000 },
        };
        #endregion
    }
}
