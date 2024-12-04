using System.ComponentModel.DataAnnotations;

namespace TurneroMedico.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
