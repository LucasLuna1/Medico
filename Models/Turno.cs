public class Turno
{
    public int Id { get; set; }
    public DateTime FechaHora { get; set; }
    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}
