namespace TurneroMedico.DTOs
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        
        // Asegúrate de que las propiedades existan
        public int PacienteId { get; set; }
        public int DoctorId { get; set; }

        // Si estas propiedades pueden ser nulas, usa el tipo nullable
        public string? PacienteNombre { get; set; }
        public string? DoctorNombre { get; set; }

        // Propiedades de la fecha
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}