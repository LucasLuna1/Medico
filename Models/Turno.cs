namespace TurneroMedico.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string PacienteNombre { get; set; }
        public string DoctorNombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}