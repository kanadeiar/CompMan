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
    /// Логика взаимодействия для HackMissionWindow.xaml
    /// </summary>
    public partial class HackMissionWindow : Window
    {
        private HackMissionWindowPanel _panel;
        public HackMissionWindow(HackBase hack)
        {
            InitializeComponent();
            _panel = new HackMissionWindowPanel((Hack)hack);
        }
        private void HackMissionWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            HackMissionWindowPanel.DataContext = _panel;
        }

        private void ButtonLeave_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonUse_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxPrograms.SelectedItem == null)
                return;
            _panel.UseProgram(ComboBoxPrograms.SelectedItem);
        }
    }
}
