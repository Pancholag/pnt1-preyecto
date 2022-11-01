using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public abstract class Persona
    {
        [Key]
        public int Legajo { get; set; }
        public string? NombreApellido { get; set; }
        public string? Mail { get; set; }

    }
}
