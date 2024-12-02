namespace TurneroMedico.DTOs
{
    public class TurnoDTO
    {
        public int PacienteId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
