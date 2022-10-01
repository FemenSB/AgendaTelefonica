using AgendaTelefonica.Database;
using AgendaTelefonica.Models;
using AgendaTelefonica.Utils;
using AgendaTelefonica.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AgendaTelefonica.ViewModels
{
    public class AddContatoViewModel : ObservableCollection<Contato>
    {
        public string Nome { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Anotacao { get; set; } = string.Empty;

        private ICommand? _registerContato;
        public ICommand RegisterContato
        {
            get
            {
                return _registerContato ?? (_registerContato = new CommandHandler(() => RegisterContatoAction(), () => true));
            }
        }

        private readonly DatabaseService databaseService = new();

        public void RegisterContatoAction()
        {
            databaseService.AddContato(new Database.Models.ContatoDb() {Nome = this.Nome, Numero = this.Numero, Anotacao = this.Anotacao });
            
        }
    }
}
