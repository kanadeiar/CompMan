using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.WinModels
{
    public class SoftWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Софт </summary>
        public Soft Soft { get; set; }
        public SoftWindowPanel() { }
        public SoftWindowPanel(Soft soft)
        {
            Soft = soft;
        }

        #region свойства - зависимости
        /// <summary> флаг блокировки нажатий кнопок </summary>
        private bool blockButtons;

        public string NextActionOs => Soft.NextActionOs;
        public string NextOsName => Soft.NextOs.Name;
        public string NextOsCost => Soft.NextOs.Cost.ToString() + " рублей";
        public bool MayBuyNextOs => Soft.NextOsMayBuy && !blockButtons;
        public string TextButtonBuyOs => Soft.NextOsMayBuy ? "Установить!" : "Облом.";
        public async void BuyOsAsync()
        {
            BlockButtons(true);
            await Soft.BuyOsAsync();
            Changed(nameof(NextActionOs));
            Changed(nameof(NextOsName));
            Changed(nameof(NextOsCost));
            Changed(nameof(TextButtonBuyOs));
            BlockButtons(false);
        }
        public string NextActionDevelop => Soft.NextActionDevelop;
        public string NextDevelopName => Soft.NextDevelop.Name;
        public string NextDevelopCost => Soft.NextDevelop.Cost.ToString() + " рублей";
        public bool MayBuyNextDevelop => Soft.NextDevelopMayBuy && !blockButtons;
        public string TextButtonBuyDevelop => Soft.NextDevelopMayBuy ? "Установить!" : "Облом.";
        public async void BuyDevelopAsync()
        {
            BlockButtons(true);
            await Soft.BuyDevelopAsync();
            Changed(nameof(NextActionDevelop));
            Changed(nameof(NextDevelopName));
            Changed(nameof(NextDevelopCost));
            Changed(nameof(TextButtonBuyDevelop));
            BlockButtons(false);
        }
        public string NextActionAntivirus => Soft.NextActionAntivirus;
        public string NextAntivirusName => Soft.NextAntivirus.Name;
        public string NextAntivirusCost => Soft.NextAntivirus.Cost.ToString() + " рублей";
        public bool MayBuyNextAntivirus => Soft.NextAntivirusMayBuy && !blockButtons;
        public string TextButtonBuyAntivirus => Soft.NextAntivirusMayBuy ? "Установить!" : "Облом.";
        public async void BuyAntivirusAsync()
        {
            BlockButtons(true);
            await Soft.BuyAntivirusAsync();
            Changed(nameof(NextActionAntivirus));
            Changed(nameof(NextAntivirusName));
            Changed(nameof(NextAntivirusCost));
            Changed(nameof(TextButtonBuyAntivirus));
            BlockButtons(false);
        }
        public string NextActionGame => Soft.NextActionGame;
        public string NextGameName => Soft.NextGame.Name;
        public string NextGameCost => Soft.NextGame.Cost.ToString() + " рублей";
        public bool MayBuyNextGame => Soft.NextGameMayBuy && !blockButtons;
        public string TextButtonBuyGame => Soft.NextGameMayBuy ? "Установить!" : "Облом.";
        public async void BuyGameAsync()
        {
            BlockButtons(true);
            await Soft.BuyGameAsync();
            Changed(nameof(NextActionGame));
            Changed(nameof(NextGameName));
            Changed(nameof(NextGameCost));
            Changed(nameof(TextButtonBuyGame));
            BlockButtons(false);
        }
        public string NextActionBrowser => Soft.NextActionBrowser;
        public string NextBrowserName => Soft.NextBrowser.Name;
        public string NextBrowserCost => Soft.NextBrowser.Cost.ToString() + " рублей";
        public bool MayBuyNextBrowser => Soft.NextBrowserMayBuy && !blockButtons;
        public string TextButtonBuyBrowser => Soft.NextBrowserMayBuy ? "Установить!" : "Облом.";
        public async void BuyBrowserAsync()
        {
            BlockButtons(true);
            await Soft.BuyBrowserAsync();
            Changed(nameof(NextActionBrowser));
            Changed(nameof(NextBrowserName));
            Changed(nameof(NextBrowserCost));
            Changed(nameof(TextButtonBuyBrowser));
            BlockButtons(false);
        }

        /// <summary> Блокировка нажатий кнопок управления </summary>
        private void BlockButtons(bool block)
        {
            blockButtons = block;
            Changed(nameof(MayBuyNextOs));
            Changed(nameof(MayBuyNextDevelop));
            Changed(nameof(MayBuyNextAntivirus));
            Changed(nameof(MayBuyNextGame));
            Changed(nameof(MayBuyNextBrowser));
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
