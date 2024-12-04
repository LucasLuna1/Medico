using TurneroMedico.Models;
using TurneroMedico.Data;
using Microsoft.EntityFrameworkCore;

public class TurnoRepository : ITurnoRepository
{
    private readonly ApplicationDbContext _context;

    public TurnoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Turno>> GetAllTurnosAsync()
    {
        return await _context.Turnos.Include(t => t.Paciente).Include(t => t.Doctor).ToListAsync();
    }

    public async Task<Turno> GetTurnoByIdAsync(int id)
{
    var turno = await _context.Turnos
        .Include(t => t.Paciente)
        .Include(t => t.Doctor)
        .FirstOrDefaultAsync(t => t.Id == id);

    if (turno == null)
    {
        throw new InvalidOperationException($"No se encontró un turno con el ID {id}.");
    }

    return turno;
}

    public async Task CreateTurnoAsync(Turno turno)
    {
        _context.Turnos.Add(turno);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTurnoAsync(Turno turno)
    {
        _context.Turnos.Update(turno);
        await _context.SaveChangesAsync();
    }
}