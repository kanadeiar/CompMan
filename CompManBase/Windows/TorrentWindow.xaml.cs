using CompManBase.Models;
using CompManBase.WinModels;
using System.Windows;

namespace CompManBase.Windows
{
    /// <summary>
    /// Логика взаимодействия для TorrentWindow.xaml
    /// </summary>
    public partial class TorrentWindow : Window
    {
        private TorrentWindowPanel _panel;
        public TorrentWindow(TorrentBase torrent)
        {
            InitializeComponent();
            _panel = new TorrentWindowPanel((Torrent)torrent);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TorrentWindowPanel.DataContext = _panel;
        }

        private void ButtonUpload_Click(object sender, RoutedEventArgs e)
        {
            _panel.DoUploadAsync();
        }
        private void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {
            _panel.DoDownloadAsync();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
