using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Database.Models
{
    public class TipoDeContato
    {
        public string Nome { set; get; }
        public List<ContatoDb> ContatosDoTipo { set; get; }
    }
}
