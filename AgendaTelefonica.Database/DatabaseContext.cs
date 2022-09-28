using Microsoft.EntityFrameworkCore;
using AgendaTelefonica.Database.Utils;
using AgendaTelefonica.Database.Models;

namespace AgendaTelefonica.Database
{
    public class DatabaseContext : DbContext
    {
        internal DbSet<ContatoDb> Contatos { get; set; }
        internal DbSet<TipoDeContato> TiposDeContato { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            if(!ob.IsConfigured)
            {
                ob.UseSqlite($"Data Source={Constants.DATABASE_FILE_NAME}");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ContatoDb>(entity =>
            {
                entity.ToTable("Contatos");

                entity.HasKey(e => e.Id)
                      .HasName("id");

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .IsRequired();

                entity.Property(e => e.Numero)
                      .HasColumnName("numero")
                      .IsRequired();

                entity.Property(e => e.Anotacao)
                      .HasColumnName("anotacao");
            });

            mb.Entity<TipoDeContato>(entity =>
            {
                entity.ToTable("TiposDeContato");

                entity.HasKey(e => e.Nome)
                      .HasName("nome");

                entity.Property(e => e.Nome)
                      .HasColumnName("nome");
            });
        }
    }
}
