using Microsoft.EntityFrameworkCore;
using ControleDeTrabalhosAcademicos.Models;

namespace ControleDeTrabalhosAcademicos.Data
{
    public class TrabalhosContext : DbContext
    {
        public TrabalhosContext(DbContextOptions<TrabalhosContext> options)
            : base(options)
        {
        }

        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Orientador> Orientadores { get; set; }
    }
}
