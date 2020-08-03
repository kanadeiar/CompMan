using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.WinModels
{
    public class TorrentWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Торрент-трекер </summary>
        public Torrent Torrent { get; set; }

        public TorrentWindowPanel(Torrent torrent)
        {
            Torrent = torrent;
            torrent.MaysUpdated += MaysUpdate;
        }

        #region Свойства-зависимости
        /// <summary> флаг блокировки нажатий кнопок </summary>
        private bool blockButtons;

        public bool MayUpload => Torrent.MayUpload && !blockButtons;
        public async void DoUploadAsync()
        {
            BlockButtons(true);
            await Torrent.DoUploadAsync();
            BlockButtons(false);
        }
        public bool MayDownload => Torrent.MayDownload && !blockButtons;
        public async void DoDownloadAsync()
        {
            BlockButtons(true);
            await Torrent.DoDownloadAsync();
            BlockButtons(false);
        }
        /// <summary> Обновление статуса доступности кнопок </summary>
        private void MaysUpdate(object sender, EventArgs e)
        {
            Changed(nameof(MayUpload));
            Changed(nameof(MayDownload));
        }

        /// <summary> Блокировка нажатий кнопок управления </summary>
        private void BlockButtons(bool block)
        {
            blockButtons = block;
            MaysUpdate(this, null);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
