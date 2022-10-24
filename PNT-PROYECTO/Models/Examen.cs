using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public class Examen
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Titulo { get; set; }





    }
}
