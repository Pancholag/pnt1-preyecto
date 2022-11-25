using System.ComponentModel.DataAnnotations;
using static PNT_PROYECTO.Models.Profesor;

namespace PNT_PROYECTO.Models
{
    public class ProfeARegistrar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? NombreApellido { get; set; }
        [Required]
        [EmailAddress]
        public string? Mail { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public Rol? Tipo { get; set; }

    }
}
