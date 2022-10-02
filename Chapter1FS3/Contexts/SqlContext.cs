using Chapter1FS3.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter1FS3.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(){}

        public SqlContext(DbContextOptions<SqlContext>options): base(options){}

        //vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-9RJ3MAO\\SQLEXPRESS; initial catalog = chapter1; Integrated Security = true");
            }
        }
        //dbset representa as entidades que serão utilizadas nas opçoes de leitura, criação,atualização e deleção
        public DbSet<Livro>? Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
