using CompManBase.Models;
using CompManBase.WinModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompManBase.Windows
{
    /// <summary>
    /// Логика взаимодействия для SoftWindow.xaml
    /// </summary>
    public partial class SoftWindow : Window
    {
        private SoftWindowPanel _panel;
        public SoftWindow(SoftBase soft)
        {
            InitializeComponent();
            _panel = new SoftWindowPanel((Soft)soft);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoftWindowPanel.DataContext = _panel;
        }
        private void ButtonBuyOs_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyOsAsync();
        }
        private void ButtonBuyDevelop_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyDevelopAsync();
        }
        private void ButtonBuyAntivirus_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyAntivirusAsync();
        }
        private void ButtonBuyGame_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyGameAsync();
        }
        private void ButtonBuyBrowser_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyBrowserAsync();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


    }
}
