using AgendaTelefonica.Database.Models;
using AgendaTelefonica.Database.Utils;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Database
{
    public class DatabaseService
    {
        private DbContextOptions<DatabaseContext> _options;

        public DatabaseService()
        {
            SetOptions();
        }

        private void SetOptions()
        {
            DbContextOptionsBuilder<DatabaseContext> ob = new();

            ob.UseSqlite($"Data Source={Constants.DATABASE_FILE_NAME}");
            _options = ob.Options;
        }

        public void EnsureDatabaseIsCreated()
        {
            using (DatabaseContext context = new (_options))
            {
                context.Database.EnsureCreated();
            }
        }

        public void AddContato(ContatoDb contato)
        {
            using (DatabaseContext context = new(_options))
            {
                context.Contatos.Add(contato);
                context.SaveChanges();
            }
        }

        public void RemoveContato(int id)
        {
            using (DatabaseContext context = new(_options))
            {
                ContatoDb? contato = context.Contatos.FirstOrDefault(item => item.Id == id);
                if(contato != null)
                {
                    context.Contatos.Remove(contato);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateContato(ContatoDb contatoAtualizado)
        {
            using (DatabaseContext context = new(_options))
            {
                ContatoDb? contato = context.Contatos.FirstOrDefault(item => item.Id == contatoAtualizado.Id);
                if (contato != null)
                {
                    contato.Nome = contatoAtualizado.Nome;
                    contato.Numero = contatoAtualizado.Numero;
                    contato.Anotacao = contatoAtualizado.Anotacao;
                    contato.TiposDeContato = contatoAtualizado.TiposDeContato;
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<ContatoDb> GetAllContatos()
        {
            using (DatabaseContext context = new(_options))
            {
                return context.Contatos.ToList();
            }
        }

        public void AddTipoDeContato(TipoDeContato tipoDeContato)
        {
            using (DatabaseContext context = new(_options))
            {
                context.TiposDeContato.Add(tipoDeContato);
                context.SaveChanges();
            }
        }

        public void RemoveTipoDeContato(string name)
        {
            using (DatabaseContext context = new(_options))
            {
                TipoDeContato? tipoDeContato = context.TiposDeContato.FirstOrDefault(item => item.Nome == name);
                if (tipoDeContato != null)
                {
                    context.TiposDeContato.Remove(tipoDeContato);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateTipoDeContato(TipoDeContato tipoDeContatoAtualizado)
        {
            using (DatabaseContext context = new(_options))
            {
                TipoDeContato? tipoDeContato = context.TiposDeContato.FirstOrDefault(item => item.Nome == tipoDeContatoAtualizado.Nome);
                if (tipoDeContato != null)
                {
                    tipoDeContato.Nome = tipoDeContatoAtualizado.Nome;
                    tipoDeContato.ContatosDoTipo = tipoDeContatoAtualizado.ContatosDoTipo;
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<TipoDeContato> GetAllTiposDeContato()
        {
            using (DatabaseContext context = new(_options))
            {
                return context.TiposDeContato.ToList();
            }
        }

    }

}
