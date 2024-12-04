using TurneroMedico.Models;

public interface ITurnoRepository
{
    Task<List<Turno>> GetAllTurnosAsync();
    Task<Turno> GetTurnoByIdAsync(int id);
    Task CreateTurnoAsync(Turno turno);
    Task UpdateTurnoAsync(Turno turno);
}
