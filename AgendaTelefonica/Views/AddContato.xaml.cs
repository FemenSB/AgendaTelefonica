using AgendaTelefonica.Database;
using AgendaTelefonica.Utils;
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

namespace AgendaTelefonica.Views
{
    /// <summary>
    /// Lógica interna para AddContato.xaml
    /// </summary>
    public partial class AddContato : Window
    {

       
        public AddContato()
        {
            InitializeComponent();

        }
        private void Registar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
