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
            page.Show();
            
        }
        private readonly DatabaseService databaseService = new();
        ContatoDb selectedProduct = new();
        private void DeleteContanto(object sender, RoutedEventArgs e)
        {
            
            var productToDelete = (sender as FrameworkElement).DataContext as Contato;
            databaseService.RemoveContato(productToDelete.Id);
            ContatoDataGrid.ItemsSource = databaseService.GetAllContatos();
        }

        private void SelectProductToEdit(object sender, RoutedEventArgs e)
        {
            var selectedProduct = (sender as FrameworkElement).DataContext as Contato;
            UpdateProductGrid.DataContext = selectedProduct;

        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            databaseService.UpdateContato(selectedProduct);
            UpdateProductGrid.DataContext = databaseService.GetAllContatos();
            UpdateProductGrid.DataContext = null;
        }

    }
    
}
