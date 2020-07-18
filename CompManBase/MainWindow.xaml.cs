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
            Binding bindingTitle = new Binding
            {
                Source = _panel,
                Path = new PropertyPath("Title"),
            };
            this.SetBinding(TitleProperty, bindingTitle);


        }
    }
}
