﻿using CompManBase.Models;
using CompManBase.Windows;
using CompManBase.WinModels;
using System.Windows;
using System.Windows.Data;

namespace CompManBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowPanel _panel = new MainWindowPanel();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowPanel.DataContext = _panel;
            WindowTitleBinding();
        }

        ///////////////////////////////////////////////////////////////////////////

        private void WindowTitleBinding()
        {
            Binding bindingTitle = new Binding
            {
                Source = _panel,
                Path = new PropertyPath("Title"),
            };
            this.SetBinding(TitleProperty, bindingTitle);
        }

        #region Обработчики событий
        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"{_panel.Player.Level}");
            //_panel.Player.Computer.Platform = 1;
        }
        private void ButtonComputer_Click(object sender, RoutedEventArgs e)
        {
            ComputerWindow window = new ComputerWindow(_panel.Computer);
            window.ShowDialog();
        }
        private void ButtonSoft_Click(object sender, RoutedEventArgs e)
        {
            SoftWindow window = new SoftWindow(_panel.Soft);
            window.ShowDialog();
        }


        #endregion


    }
}
