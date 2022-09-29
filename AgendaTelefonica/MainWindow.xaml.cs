using AgendaTelefonica.Database;
using AgendaTelefonica.Models;
using AgendaTelefonica.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AgendaTelefonica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowViewModel ViewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddContato(object sender, RoutedEventArgs e)
        {
            AddContatoPage page = new();
            this.Content = page;
        }
    }
}
