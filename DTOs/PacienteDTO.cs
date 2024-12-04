namespace TurneroMedico.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        // Propiedad calculada opcional para obtener la edad
        public int Edad => DateTime.Now.Year - FechaNacimiento.Year -
                           (DateTime.Now.DayOfYear < FechaNacimiento.DayOfYear ? 1 : 0);
    }
}
