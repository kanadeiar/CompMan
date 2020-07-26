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



        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
