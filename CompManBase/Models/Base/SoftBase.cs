using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public abstract class SoftBase : INotifyPropertyChanged
    {
        private int _os;
        private int _develop;
        private int _antivirus;
        private int _browser;
        private int _other;


        public SoftBase()
        {
        }
        #region Свойства-зависимости
        public int Os
        {
            get => _os;
            set
            {
                if (value == _os) return;
                _os = value;
                Changed(nameof(Os));
                Changed(nameof(OsName));
            }
        }
        public string OsName => OsNames[_os].Name;
        public int Develop
        {
            get => _develop;
            set
            {
                if (value == _develop) return;
                _develop = value;
                Changed(nameof(Develop));
                Changed(nameof(DevelopName));
            }
        }
        public string DevelopName => DevelopNames[_develop].Name;
        public int Antivirus
        {
            get => _antivirus;
            set
            {
                if (value == _antivirus) return;
                _antivirus = value;
                Changed(nameof(Antivirus));
                Changed(nameof(AntivirusName));
            }
        }
        public string AntivirusName => AntivirusNames[_antivirus].Name;
        public int Browser
        {
            get => _browser;
            set
            {
                if (value == _browser) return;
                _browser = value;
                Changed(nameof(Browser));
                Changed(nameof(BrowserName));
            }
        }
        public string BrowserName => BrowserNames[_browser].Name;
        public int Other
        {
            get => _other;
            set
            {
                if (value == _other) return;
                _other = value;
                Changed(nameof(Other));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /////////////////////////////////////////////////////////////////////
        public struct SoftPrt
        {
            public int Level;
            public string Name;
            public int Cost;
        }
        #region Данные
        public static SoftPrt[] OsNames = new[]
        {
            new SoftPrt { Level = 0, Name ="отсутствует", Cost = 0 },
            new SoftPrt { Level = 1, Name ="Windows 95", Cost = 0 },
            new SoftPrt { Level = 2, Name ="Windows XP", Cost = 2000 },
            new SoftPrt { Level = 3, Name ="Windows 7", Cost = 5000 },
            new SoftPrt { Level = 4, Name ="Windows 8.1", Cost = 8000 },
            new SoftPrt { Level = 5, Name ="Windows 10", Cost = 12500 },
            new SoftPrt { Level = 6, Name ="Kali Linux", Cost = 0 },
        };
        public static SoftPrt[] DevelopNames = new[]
        {
            new SoftPrt { Level = 0, Name ="отсутствует", Cost = 0 },
            new SoftPrt { Level = 1, Name ="QBasic", Cost = 0 },
            new SoftPrt { Level = 2, Name ="Delphi 7", Cost = 0 },
            new SoftPrt { Level = 3, Name ="Eclipse", Cost = 0 },
            new SoftPrt { Level = 4, Name ="Intellij IDEA", Cost = 0 },
            new SoftPrt { Level = 5, Name ="VisualStudio", Cost = 30000 },
            new SoftPrt { Level = 6, Name ="ReSharper", Cost = 10000 },
        };
        public static SoftPrt[] AntivirusNames = new[]
{
            new SoftPrt { Level = 0, Name ="отсутствует", Cost = 0 },
            new SoftPrt { Level = 1, Name ="Doctor Solomon Antivirus", Cost = 0 },
            new SoftPrt { Level = 2, Name ="Dr.Web", Cost = 0 },
            new SoftPrt { Level = 3, Name ="Norton", Cost = 0 },
            new SoftPrt { Level = 4, Name ="Avast", Cost = 0 },
            new SoftPrt { Level = 5, Name ="Comodo", Cost = 6000 },
            new SoftPrt { Level = 6, Name ="Хакерский", Cost = 900000 },
        };
        public static SoftPrt[] BrowserNames = new[]
{
            new SoftPrt { Level = 0, Name ="отсутствует", Cost = 0 },
            new SoftPrt { Level = 1, Name ="Internet Explorer", Cost = 0 },
            new SoftPrt { Level = 2, Name ="Edge", Cost = 0 },
            new SoftPrt { Level = 3, Name ="Opera", Cost = 0 },
            new SoftPrt { Level = 4, Name ="Comodo", Cost = 0 },
            new SoftPrt { Level = 5, Name ="Firefox", Cost = 30000 },
            new SoftPrt { Level = 6, Name ="Chrome", Cost = 10000 },
        };
        #endregion
    }
}
