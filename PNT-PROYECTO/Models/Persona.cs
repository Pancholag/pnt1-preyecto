using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public abstract class Persona
    {
        [Key]
        public int Legajo { get; set; }
        [Required]
        public string? NombreApellido { get; set; }
        [Required]
        [EmailAddress]
        public string? Mail { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
