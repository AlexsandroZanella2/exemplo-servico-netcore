using Exemplo.ServicoNetCore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Exemplo.ServicoNetCore.DataAccess
{
    public class PublicContext : DbContext
    {
        public DbSet<Loja> Loja { get; set; }

        public PublicContext(DbContextOptions<PublicContext> options)
            : base(options) { }

        //Essa é outra forma de realizar a conexao, passando a string diretamente inCode
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=masterkey;CommandTimeout=1024");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
