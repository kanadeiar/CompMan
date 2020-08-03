using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// <summary> Прогресс закачивания / скачивания </summary>
        public int LoadProgress { get; set; }

        public async Task DoUploadAsync()
        {
            await Task.Run(LoadProcess());
            LoadProgress = 0;
            Changed(nameof(LoadProgress));
            Upload += rand.Next(1, 3);
            _score.Add(1);
            Rating++;
            _mayUpload = false;
        }
        public async Task DoDownloadAsync()
        {
            await Task.Run(LoadProcess());
            LoadProgress = 0;
            Changed(nameof(LoadProgress));
            Download += rand.Next(1, 10);
            _score.Add(1);
            Rating++;
            _mayDownload = false;
        }

        /// <summary> Скачивание / закачивание программы </summary>
        private Action LoadProcess()
        {
            return () =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    LoadProgress = i;
                    Changed(nameof(LoadProgress));
                    Thread.Sleep(10);
                }
            };
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
