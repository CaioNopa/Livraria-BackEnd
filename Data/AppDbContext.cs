using Livro.Models;
using Microsoft.EntityFrameworkCore;

namespace Livro.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<LivroModel> Livros { get; set; }
        //um DbSet pra cada tabela 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }   
}