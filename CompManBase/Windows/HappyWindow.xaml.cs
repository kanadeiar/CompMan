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
    /// Логика взаимодействия для HappyWindow.xaml
    /// </summary>
    public partial class HappyWindow : Window
    {
        private HappyWindowPanel _panel;
        public HappyWindow(HappyBase happy)
        {
            InitializeComponent();
            _panel = new HappyWindowPanel((Happy)happy);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HappyWindowPanel.DataContext = _panel;
        }
        
        private void ButtonHappy1_Click(object sender, RoutedEventArgs e)
        {
            _panel.DoHappy1();
        }
        private void ButtonHappy2_Click(object sender, RoutedEventArgs e)
        {
            _panel.DoHappy2();
        }
        private void ButtonHappy3_Click(object sender, RoutedEventArgs e)
        {
            _panel.DoHappy3();
        }
        private void ButtonHappy4_Click(object sender, RoutedEventArgs e)
        {
            _panel.DoHappy4();
        }
        private void ButtonHappy5_Click(object sender, RoutedEventArgs e)
        {
            _panel.DoHappy5();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


    }
}
