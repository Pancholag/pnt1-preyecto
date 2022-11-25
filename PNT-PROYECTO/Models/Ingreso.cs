using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public class Ingreso
    {
        [Key]
        public int Id { get; set; }
        public DateTime horaIngreso { get; set; }
        public Persona usuario { get; set; }
        
    }
}
