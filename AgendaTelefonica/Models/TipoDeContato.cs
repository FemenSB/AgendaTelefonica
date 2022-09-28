using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Models
{
    public class TipoDeContato
    {
        public string Nome { set; get; }

        public TipoDeContato(AgendaTelefonica.Database.Models.TipoDeContato tipoDeContato)
        {
            Nome = tipoDeContato.Nome;
        }
    }
}
