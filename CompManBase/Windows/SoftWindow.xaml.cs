﻿using CompManBase.Models;
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
            _panel.BuyOs();
        }



        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
