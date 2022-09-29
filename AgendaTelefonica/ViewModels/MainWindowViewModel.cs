using AgendaTelefonica.Database;
using AgendaTelefonica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.ViewModels
{
    public class MainWindowViewModel : ObservableCollection<Contato>
    {
        public List<Contato> Contatos { get; set; }
        private readonly DatabaseService databaseService = new();

        public MainWindowViewModel()
        {
            Contatos = databaseService.GetAllContatos().Select(item => new Contato(item)).ToList();
        }
    }
}
