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



        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
