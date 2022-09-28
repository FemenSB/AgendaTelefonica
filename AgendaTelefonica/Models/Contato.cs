using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Models
{
    public class Contato
    {
        public string Nome { set; get; }
        public string Numero { set; get; }
        public int Id { set; get; }
        public string? Anotacao { set; get; }
        public List<TipoDeContato> TiposDeContato { set; get; }
    }
}
