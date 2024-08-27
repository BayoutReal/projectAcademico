using Microsoft.EntityFrameworkCore;
using ControleDeTrabalhosAcademicos.Models;

namespace ControleDeTrabalhosAcademicos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Orientador> Orientadores { get; set; }

        // Override OnModelCreating if you have custom configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configurations can go here
        }
    }
}
