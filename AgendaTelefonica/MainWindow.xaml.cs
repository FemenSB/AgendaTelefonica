using AgendaTelefonica.Database;
using AgendaTelefonica.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgendaTelefonica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Contato> Contatos { get; set; }
        private readonly DatabaseService databaseService = new();

        public MainWindow()
        {
            InitializeComponent();
            Contatos = databaseService.GetAllContatos().Select(item => new Contato(item)).ToList();
            ContatoDataGrid.ItemsSource = Contatos;
        }
    }
}
