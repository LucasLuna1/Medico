namespace TurneroMedico.DTOs
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        
        // Relación con Paciente
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; } = string.Empty;

        // Relación con Doctor
        public int DoctorId { get; set; }
        public string DoctorNombre { get; set; } = string.Empty;

        // Información del turno
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }

        // Propiedades de presentación (opcional)
        public string FechaFormateada => Fecha.ToString("dd/MM/yyyy");
        public string HoraFormateada => Hora.ToString(@"hh\:mm");
    }
}
