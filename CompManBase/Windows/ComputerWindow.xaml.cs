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
    /// Логика взаимодействия для ComputerWindow.xaml
    /// </summary>
    public partial class ComputerWindow : Window
    {
        private ComputerWindowPanel _panel;
        public ComputerWindow(ComputerBase computer)
        {
            InitializeComponent();
            _panel = new ComputerWindowPanel((Computer)computer);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComputerWindowPanel.DataContext = _panel;
        }

        private void ButtonBuyPlatform_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyPlatform();
        }
        private void ButtonBuyRam_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyRam();
        }
        private void ButtonBuyHdd_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyHdd();
        }
        private void ButtonBuyVideo_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyVideo();
        }
        private void ButtonBuyInternet_Click(object sender, RoutedEventArgs e)
        {
            _panel.BuyInternet();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


    }
}
