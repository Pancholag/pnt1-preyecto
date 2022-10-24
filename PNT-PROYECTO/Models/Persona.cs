using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public abstract class Persona
    {
        [Key]
        public int Legajo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Mail { get; set; }

    }
}
