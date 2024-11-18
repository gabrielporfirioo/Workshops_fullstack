using Microsoft.EntityFrameworkCore;
using WebApplication1_api.Models;

namespace WebApplication1_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Workshop> Workshops { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
                .HasMany(c => c.Workshops)
                .WithMany(w => w.Colaboradores);

            base.OnModelCreating(modelBuilder);
        }
    }
}
