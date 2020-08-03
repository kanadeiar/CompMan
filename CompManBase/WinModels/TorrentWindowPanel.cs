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
        public bool MayUpload => Torrent.MayUpload;
        public void DoUpload()
        {
            Torrent.DoUpload();
            Changed(nameof(MayUpload));
        }
        public bool MayDownload => Torrent.MayDownload;
        public void DoDownload()
        {
            Torrent.DoDownload();
            Changed(nameof(MayDownload));
        }
        private void MaysUpdate(object sender, EventArgs e)
        {
            Changed(nameof(MayUpload));
            Changed(nameof(MayDownload));
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
