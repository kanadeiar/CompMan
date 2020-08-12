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
using CompManBase.Models;
using CompManBase.WinModels;

namespace CompManBase.Windows
{
    /// <summary>
    /// Логика взаимодействия для HackWindow.xaml
    /// </summary>
    public partial class HackWindow : Window
    {
        private HackWindowPanel _panel;
        public HackWindow(HackBase hack)
        {
            InitializeComponent();
            _panel = new HackWindowPanel((Hack)hack);
        }
        private void HackWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            HackWindowPanel.DataContext = _panel;
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
