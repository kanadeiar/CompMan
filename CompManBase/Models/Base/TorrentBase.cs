using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public class TorrentBase : INotifyPropertyChanged
    {
        private int _rating; //рейтинг
        private int _upload; //закачано
        private int _download; //скачано

        public TorrentBase()
        {
        }

        #region Свойства-зависимости
        public int Rating
        {
            get => _rating;
            set
            {
                if (value == _rating) return;
                _rating = value;
                Changed(nameof(Rating));
            }
        }
        public int Upload
        {
            get => _upload;
            set
            {
                if (value == _upload) return;
                _upload = value;
                Changed(nameof(Upload));
            }
        }
        public int Download
        {
            get => _download;
            set
            {
                if (value == _download) return;
                _download = value;
                Changed(nameof(Download));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
