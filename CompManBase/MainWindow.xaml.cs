using CompManBase.Models;
using CompManBase.Windows;
using CompManBase.WinModels;
using System.Windows;
using System.Windows.Data;
using CompManBase.Interfaces;
using static CompManBase.Models.ComputerBase.Components;

namespace CompManBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowPanel _panel = new MainWindowPanel();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowPanel.DataContext = _panel;
            WindowTitleBinding();
        }


        ///////////////////////////////////////////////////////////////////////////

        private void WindowTitleBinding()
        {
            Binding bindingTitle = new Binding
            {
                Source = _panel,
                Path = new PropertyPath("Title"),
            };
            this.SetBinding(TitleProperty, bindingTitle);
        }

        #region Обработчики событий
        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
           ((DateTimer)_panel.Timer).PauseStart();
        }
        private void ButtonComputer_Click(object sender, RoutedEventArgs e)
        {
            ComputerWindow window = new ComputerWindow(_panel.Computer);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }
        private void ButtonSoft_Click(object sender, RoutedEventArgs e)
        {
            SoftWindow window = new SoftWindow(_panel.Soft);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }
        private void ButtonWork_Click(object sender, RoutedEventArgs e)
        {
            WorkWindow window = new WorkWindow(_panel.Work);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }
        private void ButtonHappy_Click(object sender, RoutedEventArgs e)
        {
            HappyWindow window = new HappyWindow(_panel.Happy);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }
        private void ButtonTorrents_Click(object sender, RoutedEventArgs e)
        {
            //доступ к торрентам - только если подключен интернет и есть браузер
            bool mayTorrent = ((IInfoComputer)_panel.Computer).GetLevel(Internet) > 0 && ((IInfoSoft)_panel.Soft).GetInfo(SoftBase.Parts.Browser) > 0;
            if (!mayTorrent)
            {
                MessageBox.Show("Для доступа к торрент-трекеру должен быть подключен интернет и должен быть установлен любой браузер!", "Торрент-трекер недоступен", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            TorrentWindow window = new TorrentWindow(_panel.Torrent);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }
        private void ButtonForums_Click(object sender, RoutedEventArgs e)
        {
            //доступ к торрентам - только если подключен интернет и есть браузер
            bool mayTorrent = ((IInfoComputer)_panel.Computer).GetLevel(Internet) > 0 && ((IInfoSoft)_panel.Soft).GetInfo(SoftBase.Parts.Browser) > 0;
            if (!mayTorrent)
            {
                MessageBox.Show("Для доступа к интернет-форуму должен быть подключен интернет и должен быть установлен любой браузер!", "Интернет-форум недоступен", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ForumWindow window = new ForumWindow(_panel.Forum);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }

        private void ButtonHack_OnClick(object sender, RoutedEventArgs e)
        {
            HackWindow window = new HackWindow(_panel.Hack);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }


        #endregion



    }
}
