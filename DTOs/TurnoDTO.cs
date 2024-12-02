namespace TurneroMedico.DTOs
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorNombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
