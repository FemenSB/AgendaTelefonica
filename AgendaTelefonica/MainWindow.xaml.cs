using AgendaTelefonica.Database;
using AgendaTelefonica.Database.Models;
using AgendaTelefonica.Models;
using AgendaTelefonica.ViewModels;
using AgendaTelefonica.Views;
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
            AddContato page = new(); 
            page.ShowDialog();
            ViewModel.RefreshContatos();
            ContatoDataGrid.ItemsSource = ViewModel.Contatos;

        }
        private readonly DatabaseService databaseService = new();
        Contato selectedProduct;
        private void DeleteContanto(object sender, RoutedEventArgs e)
        {
            
            var productToDelete = (sender as FrameworkElement).DataContext as Contato;
            databaseService.RemoveContato(productToDelete.Id);
            ViewModel.RefreshContatos();
            ContatoDataGrid.ItemsSource = ViewModel.Contatos;
        }

        private void SelectProductToEdit(object sender, RoutedEventArgs e)
        {
            selectedProduct = (sender as FrameworkElement).DataContext as Contato;
            UpdateProductGrid.DataContext = selectedProduct;

        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            ContatoDb selectedContatoDb = new ContatoDb()
            {
                Nome = selectedProduct.Nome,
                Numero = selectedProduct.Numero,
                Id = selectedProduct.Id,
                Anotacao = selectedProduct.Anotacao
            };
            databaseService.UpdateContato(selectedContatoDb);
            ViewModel.RefreshContatos();
            ContatoDataGrid.ItemsSource = ViewModel.Contatos;
            UpdateProductGrid.DataContext = null;
        }

    }
    
}
