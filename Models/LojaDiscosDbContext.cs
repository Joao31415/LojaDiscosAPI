using Microsoft.EntityFrameworkCore;

namespace LojaDiscosAPI.Models
{
    public class LojaDiscosDbContext : DbContext
    {
        public LojaDiscosDbContext(DbContextOptions<LojaDiscosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Disco> Discos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
