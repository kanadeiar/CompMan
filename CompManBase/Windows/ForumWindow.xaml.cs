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
    /// Логика взаимодействия для ForumWindow.xaml
    /// </summary>
    public partial class ForumWindow : Window
    {
        private ForumWindowPanel _panel;
        public ForumWindow(ForumBase forum)
        {
            InitializeComponent();
            _panel = new ForumWindowPanel((Forum)forum);
        }
        private void ForumWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ForumWindowPanel.DataContext = _panel;
        }

        private void ButtonDo_OnClick(object sender, RoutedEventArgs e)
        {
            if (ComboBoxMessages.SelectedItem == null)
                return;
            _panel.BuyProgram(((ForumWindowPanel.ForumMes)ComboBoxMessages.SelectedItem).id);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
