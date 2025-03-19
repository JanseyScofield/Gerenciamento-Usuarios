using Microsoft.EntityFrameworkCore;
using GerenciamentoUsuarios.Infrastructure.Entities;

namespace GerenciamentoUsuarios.Infrastructure
{
    public class UsuariosDbContext : DbContext
    {
        public DbSet<Usuarios> Usuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "gerenciamento-usuarios", "users.db")}");
        }
    }
}
