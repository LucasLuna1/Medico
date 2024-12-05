using Microsoft.EntityFrameworkCore;
using TurneroMedico.Models;

namespace TurneroMedico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Turno> Turnos { get; set; }
    }
}
