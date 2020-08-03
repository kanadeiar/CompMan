using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public class Torrent : TorrentBase
    {
        private IChangeScore _score; //счет игрока
        private bool _mayUpload;
        private bool _mayDownload;
        Random rand = new Random();
        /// <summary> Обновление доступности закачки и скачки </summary>
        public event EventHandler MaysUpdated;
        /// <summary> Конструктор с счетом игрока </summary>
        public Torrent(IDateTimerEvent timer, IChangeScore score) : base()
        {
            _score = score;
            timer.NextDayEvent += DayUpdate;
            _mayUpload = _mayDownload = true;
        }

        #region Доступность скачиания
        public bool MayUpload => _mayUpload;
        public bool MayDownload => _mayDownload;
        #endregion

        #region Взаимодействие с торрентом
        public void DoUpload()
        {
            Upload += rand.Next(1, 3);
            _score.Add(1);
            _mayUpload = false;
        }
        public void DoDownload()
        {
            Download += rand.Next(1, 10);
            _score.Add(1);
            _mayDownload = false;
        }
        #endregion

        /// <summary> Ежедневное изменение состояния - получение возможности скачивания </summary>
        private void DayUpdate(object sender, EventArgs e)
        {
            _mayUpload = _mayDownload = true;
            MaysUpdated?.Invoke(this, new EventArgs());
        }
    }
}
