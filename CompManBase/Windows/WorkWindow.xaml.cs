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
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private WorkWindowPanel _panel;
        public WorkWindow(WorkBase work)
        {
            InitializeComponent();
            _panel = new WorkWindowPanel((Work)work);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WorkWindowPanel.DataContext = _panel;
        }

        private void ButtonWork0_Click(object sender, RoutedEventArgs e)
        {
            _panel.GoToWork0();
        }
        private void ButtonWork1_Click(object sender, RoutedEventArgs e)
        {
            _panel.GoToWork1();
        }
        private void ButtonWork2_Click(object sender, RoutedEventArgs e)
        {
            _panel.GoToWork2();
        }
        private void ButtonWork3_Click(object sender, RoutedEventArgs e)
        {
            _panel.GoToWork3();
        }
        private void ButtonWork4_Click(object sender, RoutedEventArgs e)
        {
            _panel.GoToWork4();
        }
        private void ButtonWork5_Click(object sender, RoutedEventArgs e)
        {
            _panel.GoToWork5();
        }
        private void ButtonWork6_Click(object sender, RoutedEventArgs e)
        {
            _panel.GoToWork6();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


    }
}
