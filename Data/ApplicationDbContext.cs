using Microsoft.EntityFrameworkCore;
using TurneroMedico.Models;

namespace TurneroMedico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; } = null!;
        public DbSet<Doctor> Doctores { get; set; } = null!;
        public DbSet<Turno> Turnos { get; set; } = null!;
    }
}
