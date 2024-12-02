using TurneroMedico.Models;

public interface ITurnoRepository
{
    Task<List<Turno>> GetAllTurnosAsync();
    Task<Turno> GetTurnoByIdAsync(int id);
    Task AddTurnoAsync(Turno turno);
    Task UpdateTurnoAsync(Turno turno);
    Task DeleteTurnoAsync(int id);
}
